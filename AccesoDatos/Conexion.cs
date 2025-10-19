using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion(string servidor = "localhost", string usuario = "root", string password = "", string bd = "almacen4", int puerto = 3306)
        {
            _connectionString = $"server={servidor};port={puerto};user={usuario};password={password};database={bd};";
        }


        public string Comando(string q)
        {
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(q, con))
                    {
                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return $"Correcto, filas afectadas: {filasAfectadas}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Error en comando: {ex.Message}";
                }
            }
        }

        public DataSet Consultar(string q, string tabla)
        {
            DataSet ds = new DataSet();
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(q, con))
                    {
                        con.Open();
                        da.Fill(ds, tabla);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de consulta: {ex.Message}\nStackTrace: {ex.StackTrace}",
                                    "Error Conexión MySQL",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ds;
        }
    }
}
