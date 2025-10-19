using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlmacenesApp
{
    public partial class MenuPrincipal : Form
    {
        private Usuario _usuario;
        public static int Escritura = 0;
        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = _usuario.NombreUsuario;
            TProductos.Enabled = false;
            TSalir.Enabled = false;
          

            foreach (var permiso in _usuario.Permisos)
            {


                if (permiso.NombreModulo.Equals("usuarios",StringComparison.OrdinalIgnoreCase))
                {
                    TsUsuarios.Enabled = permiso.PermisoLeerAbrir;

                    if (permiso.PermisoEscritura && permiso.PermisoLeerAbrir)
                    {
                        Escritura = 1; TsUsuarios.Enabled = true;
                    }




                    if (permiso.PermisoLeerAbrir)
                        TsUsuarios.Enabled = true;



                }
                else if(permiso.NombreModulo.Equals("productos", StringComparison.OrdinalIgnoreCase))
                {
                    TProductos.Enabled = permiso.PermisoEscritura;
                }
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entro a productos");
        }

     
        private void TsUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios fu = new FrmUsuarios();
            fu.ShowDialog();
        }
    }
}
