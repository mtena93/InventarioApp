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
    public partial class ProductosForm : Form
    {
        private string tipoUsuario;
        public ProductosForm(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;
            CargarProductos();
            AplicarPermisos();
            dgvProductos.CellFormatting += dgvProductos_CellFormatting;
        }

        private void AplicarPermisos()
        {
            if (tipoUsuario == "usuario")
            {
                btnAgregar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargarProductos()
        {
            Conexion con = new Conexion();
            try
            {
                con.Abrir();
                string query = "SELECT p.id, p.nombre, p.descripcion, p.precio, p.margen_porcentaje, p.precio_final, p.cantidad, c.nombre AS categoria FROM productos p LEFT JOIN categorias c ON p.categoria_id = c.id";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con.Abrir());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["precio"].DefaultCellStyle.Format = "0.00 €";
                dgvProductos.Columns["precio_final"].DefaultCellStyle.Format = "0.00 €";
                dgvProductos.Columns["nombre"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold); // Nombre en negrita
                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoDetalleForm form = new ProductoDetalleForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["id"].Value);
                ProductoDetalleForm form = new ProductoDetalleForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["id"].Value);

                DialogResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Conexion con = new Conexion();
                    try
                    {
                        con.Abrir();
                        string query = "DELETE FROM productos WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        con.Cerrar();

                        MessageBox.Show("Producto eliminado correctamente.");
                        CargarProductos(); // recargar lista
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); // Vuelve al formulario anterior
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "cantidad" && e.Value != null)
            {
                int cantidad = Convert.ToInt32(e.Value);
                if (cantidad > 0)
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
