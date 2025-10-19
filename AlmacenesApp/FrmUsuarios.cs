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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            GbModificarAgregar.Visible = false;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            GbModificarAgregar.Visible = true;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            GbModificarAgregar.Visible = true;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            if (MenuPrincipal.Escritura == 1) { BtnEditar.Enabled = true; BtnEliminar.Enabled = true; BtnNuevo.Enabled = true; }
        }
    }
}
