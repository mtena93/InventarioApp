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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (usuario == "" || contraseña == "")
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            Conexion con = new Conexion();

            try
            {
                con.Abrir();

                string query = "SELECT * FROM usuarios WHERE nombre_usuario = @usuario AND contraseña = @contraseña";
                MySqlCommand cmd = new MySqlCommand(query, con.Abrir());
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("¡Login correcto!");
                    // Aquí puedes abrir el formulario principal:
                    this.Hide();
                    MenuPrincipal menu = new MenuPrincipal();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }

                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }
    }
}
