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
        public UsuarioAccesoDatos _usuarioAccesoDatos;

        public UsuarioManejador()
        {
            _usuarioAccesoDatos = new UsuarioAccesoDatos();
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


    }

}

