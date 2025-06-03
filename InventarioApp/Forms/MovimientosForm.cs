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

namespace InventarioApp.Forms
{
    public partial class MovimientosForm : Form
    {
        private string tipoUsuario;
        public MovimientosForm(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;
            CargarProductos();
            cmbTipo.Items.AddRange(new string[] { "Entrada", "Salida" });
            cmbTipo.SelectedIndex = 0;
            CargarHistorial();
            AplicarPermisos();
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
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMovimientos.DataSource = dt;

                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
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

                // 1. Registrar movimiento
                string query = "INSERT INTO movimientos_stock (producto_id, tipo, cantidad) VALUES (@producto_id, @tipo, @cantidad)";
                MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                cmd.Parameters.AddWithValue("@producto_id", productoId);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.ExecuteNonQuery();

                // 2. Actualizar stock en productos
                string operacion = (tipo == "entrada") ? "+" : "-";
                string update = $"UPDATE productos SET cantidad = cantidad {operacion} @cantidad WHERE id = @id";
                MySqlCommand cmd2 = new MySqlCommand(update, con.Abrir());
                cmd2.Parameters.AddWithValue("@cantidad", cantidad);
                cmd2.Parameters.AddWithValue("@id", productoId);
                cmd2.ExecuteNonQuery();

                con.Cerrar();

                MessageBox.Show("Movimiento registrado.");
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
    }
}

