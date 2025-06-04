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
    public partial class CrearUsuarioForm : Form
    {
        public CrearUsuarioForm()
        {
            InitializeComponent();
        }

        private void CrearUsuarioForm_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Add("admin");
            cmbTipo.Items.Add("usuario");
            cmbTipo.SelectedIndex = 1; // por defecto: usuario
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string tipo = cmbTipo.SelectedItem?.ToString();

            if (nombre == "" || contraseña == "" || tipo == null)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            string hash = Seguridad.EncriptarSHA256(contraseña);

            Conexion con = new Conexion();
            try
            {
                string query = "INSERT INTO usuarios (nombre_usuario, contraseña, tipo) VALUES (@nombre, @contraseña, @tipo)";
                MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@contraseña", hash);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.ExecuteNonQuery();
                con.Cerrar();

                MessageBox.Show("Usuario creado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Vuelve al formulario anterior
        }
    }
}
