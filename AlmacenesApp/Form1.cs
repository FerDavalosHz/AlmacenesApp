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
using LogicaNegocio;

namespace AlmacenesApp
{
    public partial class frmLogin : Form
    {
        private UsuarioManejador _usuarioManejador;


        public frmLogin()
        {
            InitializeComponent();
            _usuarioManejador = new UsuarioManejador();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string clave = txtPassword.Text;

            var resultado = _usuarioManejador.ValidarLogin(usuario, clave);

          
            if (resultado.EsValido)
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal(resultado.UsuarioEncontrado);
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje, "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    
}
}
