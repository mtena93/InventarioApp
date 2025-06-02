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
        public ProductosForm()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            Conexion con = new Conexion();
            try
            {
                con.Abrir();
                string query = "SELECT p.id, p.nombre, p.descripcion, p.precio, p.cantidad, c.nombre AS categoria FROM productos p LEFT JOIN categorias c ON p.categoria_id = c.id";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con.Abrir());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
                con.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }
    }
}
