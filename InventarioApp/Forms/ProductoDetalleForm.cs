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

namespace InventarioApp
{
    public partial class ProductoDetalleForm : Form
    {
        private int? productoId = null; // null = agregar, no null = editar

        public ProductoDetalleForm(int? id = null)
        {
            InitializeComponent();
            txtPrecio.TextChanged += (s, e) => CalcularPrecioFinal();
            txtMargen.TextChanged += (s, e) => CalcularPrecioFinal();
            productoId = id;
            CargarCategorias();


            if (productoId.HasValue)
            {
                CargarDatosProducto();
                this.Text = "Editar Producto";
            }
            else
            {
                this.Text = "Agregar Producto";
            }
        }

        private void CargarCategorias()
        {
            Conexion con = new Conexion();
            try
            {
                MySqlConnection conexion = con.Abrir();

                string query = "SELECT id, nombre FROM categorias";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCategoria.DataSource = dt;
                cmbCategoria.DisplayMember = "nombre";
                cmbCategoria.ValueMember = "id";

                if (dt.Rows.Count > 0)
                    cmbCategoria.SelectedIndex = 0;

                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }



        private void CargarDatosProducto()
        {
            Conexion con = new Conexion();
            try
            {
                con.Abrir();
                string query = "SELECT * FROM productos WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                cmd.Parameters.AddWithValue("@id", productoId);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNombre.Text = reader["nombre"].ToString();
                    txtDescripcion.Text = reader["descripcion"].ToString();
                    txtPrecio.Text = reader["precio"].ToString();
                    txtCantidad.Text = reader["cantidad"].ToString();
                    cmbCategoria.SelectedValue = reader["categoria_id"];
                    txtMargen.Text = reader["margen_porcentaje"].ToString();
                    txtPrecioFinal.Text = reader["precio_final"].ToString();
                }

                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message);
            }
        
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            decimal.TryParse(txtPrecio.Text, out decimal precioBase);
            int.TryParse(txtCantidad.Text, out int cantidad);
            decimal margen = 0;
            decimal.TryParse(txtMargen.Text, out margen);
            decimal precioFinal = precioBase + (precioBase * margen / 100);
            int categoriaId = (int)cmbCategoria.SelectedValue;


            Conexion con = new Conexion();
            try
            {
                con.Abrir();

                string query;

                if (productoId.HasValue)
                {
                    // EDITAR
                    query = @"UPDATE productos SET nombre = @nombre, descripcion = @descripcion, precio = @precio, 
                      cantidad = @cantidad, categoria_id = @categoria_id, margen_porcentaje = @margen, 
                      precio_final = @precioFinal WHERE id = @id";
                }
                else
                {
                    // AGREGAR
                    query = @"INSERT INTO productos (nombre, descripcion, precio, cantidad, categoria_id, margen_porcentaje, precio_final) 
                      VALUES (@nombre, @descripcion, @precio, @cantidad, @categoria_id, @margen, @precioFinal)";
                }

                MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@precio", precioBase);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@categoria_id", categoriaId);
                cmd.Parameters.AddWithValue("@margen", margen);
                cmd.Parameters.AddWithValue("@precioFinal", precioFinal);

                if (productoId.HasValue)
                    cmd.Parameters.AddWithValue("@id", productoId.Value);

                cmd.ExecuteNonQuery();
                con.Cerrar();

                MessageBox.Show("Producto guardado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }


        private void CalcularPrecioFinal()
        {
            if (decimal.TryParse(txtPrecio.Text, out decimal precioBase) &&
                decimal.TryParse(txtMargen.Text, out decimal margen))
            {
                decimal precioFinal = precioBase + (precioBase * margen / 100);
                txtPrecioFinal.Text = precioFinal.ToString("0.00");
            }
            else
            {
                txtPrecioFinal.Text = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra sin guardar
        }
    }
}
