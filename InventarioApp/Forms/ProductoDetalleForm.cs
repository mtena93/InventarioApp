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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            decimal precio = decimal.Parse(txtPrecio.Text);
            int cantidad = int.Parse(txtCantidad.Text);
            int categoriaId = (int)cmbCategoria.SelectedValue;

            Conexion con = new Conexion();
            try
            {
                con.Abrir();
                MySqlCommand cmd;

                if (productoId.HasValue)
                {
                    // Editar
                    string query = "UPDATE productos SET nombre=@nombre, descripcion=@descripcion, precio=@precio, cantidad=@cantidad, categoria_id=@categoria WHERE id=@id";
                    cmd = new MySqlCommand(query, con.Abrir());
                    cmd.Parameters.AddWithValue("@id", productoId);
                }
                else
                {
                    // Agregar
                    string query = "INSERT INTO productos (nombre, descripcion, precio, cantidad, categoria_id) VALUES (@nombre, @descripcion, @precio, @cantidad, @categoria)";
                    cmd = new MySqlCommand(query, con.Abrir());
                }

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@categoria", categoriaId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto guardado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra sin guardar
        }
    }
}
