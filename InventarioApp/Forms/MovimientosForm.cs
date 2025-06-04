using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;


namespace InventarioApp.Forms
{
    public partial class MovimientosForm : Form
    {
        private string tipoUsuario;
        private DataTable movimientosData;
        public MovimientosForm(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;
            CargarProductos();
            cmbTipo.Items.AddRange(new string[] { "entrada", "salida" });
            cmbTipo.SelectedIndex = 0;
            CargarHistorial();
            AplicarPermisos();
            cmbFiltroProducto.SelectedIndexChanged += (s, e) => AplicarFiltro();
            cmbFiltroTipo.SelectedIndexChanged += (s, e) => AplicarFiltro();
            txtFiltroCantidad.TextChanged += (s, e) => AplicarFiltro();
            dateDesde.ValueChanged += (s, e) => AplicarFiltro();
            dateHasta.ValueChanged += (s, e) => AplicarFiltro();
        }


        private void AplicarPermisos()
        {
            if (tipoUsuario == "usuario")
            {
                cmbProducto.Enabled = false;
                btnRegistrar.Enabled = false;
                cmbTipo.Enabled = false;
                txtCantidad.Enabled = false;
            }
        }

        private void CargarProductos()
        {
            Conexion con = new Conexion();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT id, nombre FROM productos", con.Abrir());
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Cerrar();

                cmbProducto.DataSource = dt;
                cmbProducto.DisplayMember = "nombre";
                cmbProducto.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void CargarHistorial()
        {
            Conexion con = new Conexion();
            try
            {
                con.Abrir();
                string query = @"
            SELECT m.id, p.nombre AS producto, m.tipo, m.cantidad, m.fecha
            FROM movimientos_stock m
            INNER JOIN productos p ON m.producto_id = p.id
            ORDER BY m.fecha DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con.Abrir());
                movimientosData = new DataTable(); // 👈 global
                da.Fill(movimientosData);
                dgvMovimientos.DataSource = movimientosData;
                dgvMovimientos.Columns["id"].HeaderText = "ID";
                dgvMovimientos.Columns["producto"].HeaderText = "Producto";
                dgvMovimientos.Columns["tipo"].HeaderText = "Tipo";
                dgvMovimientos.Columns["cantidad"].HeaderText = "Cantidad";
                dgvMovimientos.Columns["fecha"].HeaderText = "Fecha";
                LlenarFiltros();

                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }

            lblTotalFiltrado.Text = $"Resultados: {movimientosData.Rows.Count} de {movimientosData.Rows.Count}";

        }


        private void AplicarFiltro()
        {
            if (movimientosData == null) return;

            string filtro = "";

            if (cmbFiltroProducto.SelectedItem != null && cmbFiltroProducto.SelectedItem.ToString() != "")
                filtro += $"producto = '{cmbFiltroProducto.SelectedItem}' AND ";

            if (cmbFiltroTipo.SelectedItem != null && cmbFiltroTipo.SelectedItem.ToString() != "")
                filtro += $"tipo = '{cmbFiltroTipo.SelectedItem}' AND ";

            if (!string.IsNullOrWhiteSpace(txtFiltroCantidad.Text))
                filtro += $"CONVERT(cantidad, 'System.String') LIKE '%{txtFiltroCantidad.Text}%' AND ";

            DateTime desde = dateDesde.Value.Date;
            DateTime hasta = dateHasta.Value.Date.AddDays(1).AddTicks(-1); // fin del día

            filtro += $"fecha >= #{desde:yyyy-MM-dd}# AND fecha <= #{hasta:yyyy-MM-dd}# AND ";

            if (filtro.EndsWith(" AND "))
                filtro = filtro.Substring(0, filtro.Length - 5);

            movimientosData.DefaultView.RowFilter = filtro;
            lblTotalFiltrado.Text = $"Resultados: {movimientosData.DefaultView.Count} de {movimientosData.Rows.Count}";

        }

        private void LlenarFiltros()
        {
            // Limpiar primero
            cmbFiltroProducto.Items.Clear();
            cmbFiltroTipo.Items.Clear();

            // Producto
            var productos = movimientosData.AsEnumerable()
                .Select(r => r.Field<string>("producto"))
                .Distinct()
                .OrderBy(n => n);

            foreach (var p in productos)
                cmbFiltroProducto.Items.Add(p);

            cmbFiltroProducto.Items.Insert(0, ""); // opción vacía (sin filtro)
            cmbFiltroProducto.SelectedIndex = 0;

            // Tipo
            cmbFiltroTipo.Items.Add(""); // sin filtro
            cmbFiltroTipo.Items.Add("entrada");
            cmbFiltroTipo.Items.Add("salida");
            cmbFiltroTipo.SelectedIndex = 0;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null || cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un producto y tipo de movimiento.");
                return;
            }

            int productoId = (int)cmbProducto.SelectedValue;
            string tipo = cmbTipo.SelectedItem.ToString();
            int cantidad;

            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Introduce una cantidad válida.");
                return;
            }

            Conexion con = new Conexion();
            try
            {
                con.Abrir();

                // 1. Consultar el stock actual
                string stockQuery = "SELECT cantidad FROM productos WHERE id = @id";
                MySqlCommand cmdStock = new MySqlCommand(stockQuery, con.Abrir());
                cmdStock.Parameters.AddWithValue("@id", productoId);
                int stockActual = Convert.ToInt32(cmdStock.ExecuteScalar());

                if (tipo == "salida" && stockActual == 0)
                {
                    MessageBox.Show($"No hay suficiente stock. El stock es 0");
                    con.Cerrar();
                    return;
                }

                // 2. Validar si hay stock suficiente para salida
                if (tipo == "salida" && cantidad > stockActual)
                {
                    MessageBox.Show($"No hay suficiente stock. Solo hay {stockActual} unidades disponibles.");
                    con.Cerrar();
                    return;
                }

                // 3. Registrar el movimiento
                string movimientoQuery = "INSERT INTO movimientos_stock (producto_id, tipo, cantidad) VALUES (@producto_id, @tipo, @cantidad)";
                MySqlCommand cmdMovimiento = new MySqlCommand(movimientoQuery, con.Abrir());
                cmdMovimiento.Parameters.AddWithValue("@producto_id", productoId);
                cmdMovimiento.Parameters.AddWithValue("@tipo", tipo);
                cmdMovimiento.Parameters.AddWithValue("@cantidad", cantidad);
                cmdMovimiento.ExecuteNonQuery();

                // 4. Actualizar el stock
                string updateQuery = tipo == "entrada"
                    ? "UPDATE productos SET cantidad = cantidad + @cantidad WHERE id = @id"
                    : "UPDATE productos SET cantidad = cantidad - @cantidad WHERE id = @id";

                MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, con.Abrir());
                cmdUpdate.Parameters.AddWithValue("@cantidad", cantidad);
                cmdUpdate.Parameters.AddWithValue("@id", productoId);
                cmdUpdate.ExecuteNonQuery();

                con.Cerrar();

                MessageBox.Show("Movimiento registrado correctamente.");
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Vuelve al formulario anterior
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (movimientosData == null || movimientosData.DefaultView.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "MovimientosExportados.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wb = new XLWorkbook();
                    var ws = wb.Worksheets.Add("Movimientos");

                    // Convertir DataView filtrado a DataTable
                    DataView dv = movimientosData.DefaultView;
                    DataTable dtFiltrado = dv.ToTable(false);

                    // Agregar encabezados
                    for (int i = 0; i < dtFiltrado.Columns.Count; i++)
                    {
                        ws.Cell(1, i + 1).Value = dtFiltrado.Columns[i].ColumnName;
                    }

                    // Agregar filas
                    for (int i = 0; i < dtFiltrado.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtFiltrado.Columns.Count; j++)
                        {
                            var valor = dtFiltrado.Rows[i][j];
                            ws.Cell(i + 2, j + 1).Value = valor != DBNull.Value ? valor.ToString() : "";
                        }
                    }

                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Exportación completada con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }
    }
   }

