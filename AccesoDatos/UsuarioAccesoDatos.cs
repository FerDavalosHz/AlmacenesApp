using System.Data;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class UsuarioAccesoDatos
    {
        private Conexion _conexion;

        public UsuarioAccesoDatos()
        {
            _conexion = new Conexion("localhost", "root", "", "almacen4", 3306);

        }

        public DataSet ValidarCredenciales(string nombreUsuario, string clave)
        {
            string query = $@"
                SELECT
                    u.Id AS Id_Usuario,
                    u.NombreUsuario,
                    u.Email,
                    m.nombre AS Nombre_Modulo,
                    up.permiso_escritura AS Permiso_Escritura,
                    up.permiso_leer_abrir AS Permiso_Leer_Abrir
                FROM usuarios u
                JOIN usuarios_permisos up ON u.Id = up.usuario_id
                JOIN modulos m ON up.modulo_id = m.id
                WHERE u.NombreUsuario = '{nombreUsuario}' 
                AND u.Clave = '{clave}'
                ORDER BY u.NombreUsuario, m.nombre;";

            MessageBox.Show($"Query generada:\n{query}", "Debug Query");

            return _conexion.Consultar(query, "usuarios");
        }
    }
}
