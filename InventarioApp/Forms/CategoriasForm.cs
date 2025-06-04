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
    public partial class CategoriasForm : Form
    {
        private string tipoUsuario;
        public CategoriasForm(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;
            CargarCategorias();
            AplicarPermisos();
        }

        private void AplicarPermisos()
        {
            if (tipoUsuario == "usuario")
            {
                txtNombreCategoria.Enabled = false;
                btnAgregar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargarCategorias()
        {
            Conexion con = new Conexion();
            try
            {
                string query = "SELECT * FROM categorias";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con.Abrir());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCategorias.DataSource = dt;
                dgvCategorias.Columns["nombre"].HeaderText = "Nombre Categoría";
                dgvCategorias.Columns["id"].Visible = false;
                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCategoria.Text.Trim();
            if (nombre == "")
            {
                MessageBox.Show("Ingresa un nombre.");
                return;
            }

            Conexion con = new Conexion();
            try
            {
                string query = "INSERT INTO categorias (nombre) VALUES (@nombre)";
                MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.ExecuteNonQuery();
                con.Cerrar();

                MessageBox.Show("Categoría agregada.");
                txtNombreCategoria.Clear();
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["id"].Value);
                string nombre = txtNombreCategoria.Text.Trim();

                if (nombre == "")
                {
                    MessageBox.Show("Ingresa un nuevo nombre.");
                    return;
                }

                Conexion con = new Conexion();
                try
                {
                    string query = "UPDATE categorias SET nombre = @nombre WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    con.Cerrar();

                    MessageBox.Show("Categoría actualizada.");
                    txtNombreCategoria.Clear();
                    CargarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["id"].Value);

                DialogResult result = MessageBox.Show("¿Eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Conexion con = new Conexion();
                    try
                    {
                        string query = "DELETE FROM categorias WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        con.Cerrar();

                        MessageBox.Show("Categoría eliminada.");
                        CargarCategorias();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Vuelve al formulario anterior
        }
    }
}
