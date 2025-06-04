using InventarioApp.Forms;
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
    public partial class MenuPrincipal : Form
    {
        private string tipoUsuario;
        public MenuPrincipal(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;
            AplicarPermisos();
        }

        private void AplicarPermisos()
        {
            if (tipoUsuario == "usuario")
            {
                btnCrearUsuario.Visible = false;
                btnHistorialProductos.Visible = false;
            }

            this.Text += $" - Rol: {tipoUsuario}";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ProductosForm productosForm = new ProductosForm(tipoUsuario);
            productosForm.ShowDialog(); // para que se abra como ventana modal
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            MovimientosForm form = new MovimientosForm(tipoUsuario);
            form.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            CategoriasForm form = new CategoriasForm(tipoUsuario);
            form.ShowDialog();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            CrearUsuarioForm form = new CrearUsuarioForm();
            form.ShowDialog();
        }

        private void btnHistorialProductos_Click(object sender, EventArgs e)
        {
            HistorialProductosForm form = new HistorialProductosForm();
            form.ShowDialog(); // Modal
        }
    }
}
