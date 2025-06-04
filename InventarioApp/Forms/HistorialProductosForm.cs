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
    public partial class HistorialProductosForm : Form
    {
        public HistorialProductosForm()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dateHistorial.Value.Date;
            Conexion con = new Conexion();
            try
            {
                con.Abrir();

                // Entradas
                var entradasQuery = @"SELECT producto_id, SUM(cantidad) AS total
                              FROM movimientos_stock
                              WHERE tipo = 'entrada' AND DATE(fecha) = @fecha
                              GROUP BY producto_id";
                var salidasQuery = @"SELECT producto_id, SUM(cantidad) AS total
                             FROM movimientos_stock
                             WHERE tipo = 'salida' AND DATE(fecha) = @fecha
                             GROUP BY producto_id";
                var productosQuery = @"SELECT id, nombre, precio, margen_porcentaje, precio_final, cantidad FROM productos";

                // Preparar DataTables
                MySqlCommand cmd1 = new MySqlCommand(entradasQuery, con.Abrir());
                cmd1.Parameters.AddWithValue("@fecha", fecha);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                DataTable dtEntradas = new DataTable();
                da1.Fill(dtEntradas);

                MySqlCommand cmd2 = new MySqlCommand(salidasQuery, con.Abrir());
                cmd2.Parameters.AddWithValue("@fecha", fecha);
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                DataTable dtSalidas = new DataTable();
                da2.Fill(dtSalidas);

                MySqlDataAdapter daProductos = new MySqlDataAdapter(productosQuery, con.Abrir());
                DataTable dtProductos = new DataTable();
                daProductos.Fill(dtProductos);

                // Calcular resultados
                DataTable resultado = new DataTable();
                resultado.Columns.Add("Producto");
                resultado.Columns.Add("Entradas");
                resultado.Columns.Add("Salidas");
                resultado.Columns.Add("Stock");
                resultado.Columns.Add("Beneficio (€)");

                decimal totalBeneficio = 0;

                foreach (DataRow prod in dtProductos.Rows)
                {
                    int id = Convert.ToInt32(prod["id"]);
                    string nombre = prod["nombre"].ToString();
                    decimal precio = Convert.ToDecimal(prod["precio"]);
                    decimal precioFinal = Convert.ToDecimal(prod["precio_final"]);
                    int stock = Convert.ToInt32(prod["cantidad"]);

                    int entradas = dtEntradas.AsEnumerable()
                        .Where(r => Convert.ToInt32(r["producto_id"]) == id)
                        .Select(r => Convert.ToInt32(r["total"]))
                        .FirstOrDefault();

                    int salidas = dtSalidas.AsEnumerable()
                        .Where(r => Convert.ToInt32(r["producto_id"]) == id)
                        .Select(r => Convert.ToInt32(r["total"]))
                        .FirstOrDefault();

                    decimal beneficio = (salidas * precioFinal) - (entradas * precio) - (stock * precio);
                    totalBeneficio += beneficio;

                    resultado.Rows.Add(nombre, entradas, salidas, stock, beneficio.ToString("0.00"));
                }

                dgvHistorial.DataSource = resultado;
                lblTotalBeneficio.Text = $"Beneficio neto total: {totalBeneficio.ToString("0.00")} €";

                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar historial: " + ex.Message);
            }
        }
    }
}
