using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using Org.BouncyCastle.Bcpg;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class UsuarioManejador
    {
         UsuarioAccesoDatos _usuarioAccesoDatos;
         Conexion _ad;
        public UsuarioManejador()
        {
            _usuarioAccesoDatos = new UsuarioAccesoDatos();
            _ad = new Conexion();
        }

        public void MostrarUsuarios(DataGridView tabla)
        {
            string consulta = "SELECT Id AS idusuario, NombreUsuario, Clave FROM usuarios";

           
            tabla.Columns.Clear();

           
            tabla.DataSource = _ad.Consultar(consulta, "usuarios").Tables[0];

            if (tabla.Columns.Contains("idusuario"))
                tabla.Columns["idusuario"].Visible = false;

            tabla.AutoResizeColumns();
        }
        public (bool EsValido, string Mensaje, Usuario UsuarioEncontrado) ValidarLogin(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                return (false, "Por favor, ingrese el nombre de usuario y la contraseña", null);
            }

            DataSet ds = _usuarioAccesoDatos.ValidarCredenciales(usuario, clave);

         

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >= 1)
            {
                DataTable dt = ds.Tables[0];
                Usuario user = new Usuario();

                foreach (DataRow row in dt.Rows)
                {
                    if (user.Id == 0)
                    {
                        user.Id = Convert.ToInt32(row["Id_Usuario"]);
                        user.NombreUsuario = row["NombreUsuario"].ToString();
                        user.Email = row["Email"].ToString();
                    }

                    Permisos permisos = new Permisos
                    {
                        NombreModulo = row["Nombre_Modulo"].ToString(),
                        PermisoEscritura = Convert.ToBoolean(row["Permiso_Escritura"]),
                        PermisoLeerAbrir = Convert.ToBoolean(row["Permiso_Leer_Abrir"])
                    };

                    user.Permisos.Add(permisos);
                }

                return (true, "Inicio de sesión exitoso", user);
            }
            else
            {
                return (false, "Credenciales incorrectas. Verificar usuario y contraseña", null);
            }
        }


        public void AgregarUsuarioConPermiso(string nombreUsuario, string clave, string tipoPermiso, string email = "")
        {
            DataSet idmax = _ad.Consultar("SELECT COALESCE(MAX(Id), 0) AS MaxId FROM usuarios", "maxid");
            int nuevoUsuarioId = Convert.ToInt32(idmax.Tables["maxid"].Rows[0]["MaxId"]) + 1;
            //La neta me hubiera ahorrado un buen de dolores de cabeza si simplemente hubiera agregado el auto_increment

            _ad.Comando("INSERT INTO usuarios (Id, NombreUsuario, Clave, Email) VALUES (" + nuevoUsuarioId + ", '" + nombreUsuario + "', '" + clave + "', '" + email + "')");

            bool escritura = false;
            bool lectura = false;

            if (tipoPermiso.ToLower() == "lectura") lectura = true;
            if (tipoPermiso.ToLower() == "escritura") { lectura = true; escritura = true; }

            int valEscritura = 0;
            int valLectura = 0;

            if (escritura) valEscritura = 1;
            if (lectura) valLectura = 1;

            _ad.Comando("INSERT INTO usuarios_permisos (Usuario_Id, Modulo_Id, Permiso_Escritura, Permiso_Leer_Abrir) " +
                        "VALUES (" + nuevoUsuarioId + ", 2, " + valEscritura + ", " + valLectura + ")");

            MessageBox.Show("Usuario y permisos agregados correctamente");
        }

        public void EditarUsuario(int idUsuario, string nombreUsuario, string clave, string tipoPermiso, string email = "")
        {
            _ad.Comando("UPDATE usuarios SET NombreUsuario = '" + nombreUsuario + "', Clave = '" + clave +"', Email = '" + email + "' WHERE Id = " + idUsuario);

            bool escritura = false;
            bool lectura = false;

            if (tipoPermiso.ToLower() == "lectura") lectura = true;
            if (tipoPermiso.ToLower() == "escritura") { lectura = true; escritura = true; }

            int valEscritura = 0;
            int valLectura = 0;

            if (escritura) valEscritura = 1;
            if (lectura) valLectura = 1;
 _ad.Comando("UPDATE usuarios_permisos SET Permiso_Escritura = " + valEscritura +
                        ", Permiso_Leer_Abrir = " + valLectura +
                        " WHERE Usuario_Id = " + idUsuario + " AND Modulo_Id = 2");

            MessageBox.Show("Usuario y permisos actualizados correctamente");
        }

        public void EliminarUsuario(int idUsuario)
        {
            _ad.Comando("DELETE FROM usuarios_permisos WHERE Usuario_Id = " + idUsuario);
            _ad.Comando("DELETE FROM usuarios WHERE Id = " + idUsuario);

            MessageBox.Show("Usuario eliminado correctamente");
        }

    }

}

