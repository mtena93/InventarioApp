using MySql.Data.MySqlClient;

namespace InventarioApp
{
    public class Conexion
    {
        private MySqlConnection conexion;

        public Conexion()
        {
            string cadena = "server=localhost;port=3306;user=root;password=;database=inventario_bd;"; // password en blanco por defecto con XAMPP
            conexion = new MySqlConnection(cadena);
        }

        public MySqlConnection Abrir()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();

            return conexion;
        }

        public void Cerrar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
