using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace AlmacenesApp
{
    public partial class FrmUsuarios : Form
    {
        UsuarioManejador Um;
        Usuario u = new Usuario();
        int op = 0;
        public FrmUsuarios()
        {
            InitializeComponent();
            Um = new UsuarioManejador();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            GbModificarAgregar.Visible = false;
            CmbPermisos.SelectedIndex = -1;
            TxtClave.Clear();
            TxtUsuario.Clear();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            op = 0;
            GbModificarAgregar.Visible = true;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (u != null && u.Id > 0)
            {
                op = 1;
                GbModificarAgregar.Visible = true;
            }
            else
            {
                MessageBox.Show("Seleccione primero un usuario");
            }
        }


        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Um.MostrarUsuarios(DtgDatos);
            if (MenuPrincipal.Escritura == 1) { BtnEditar.Enabled = true; BtnEliminar.Enabled = true; BtnNuevo.Enabled = true; }
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow fila = DtgDatos.Rows[e.RowIndex];


                u.Id = Convert.ToInt32(fila.Cells["idusuario"].Value);
                u.NombreUsuario = fila.Cells["NombreUsuario"].Value.ToString();
                u.Clave = fila.Cells["Clave"].Value.ToString();

                TxtUsuario.Text = u.NombreUsuario;
                TxtClave.Text = u.Clave;

            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (op == 0)
            Um.AgregarUsuarioConPermiso(TxtUsuario.Text, TxtClave.Text, CmbPermisos.Text);
            if (op == 1)
                Um.EditarUsuario(u.Id, TxtUsuario.Text, TxtClave.Text, CmbPermisos.Text);
            CmbPermisos.SelectedIndex = -1;
            TxtClave.Clear();
            TxtUsuario.Clear();
            Um.MostrarUsuarios(DtgDatos);
            GbModificarAgregar.Visible = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (u == null || u.Id <= 0)
            {
                MessageBox.Show("Seleccione primero un usuario");
                return;
            }

            if (u.NombreUsuario.Equals("admin"))
            {
                MessageBox.Show("No puedes borrar el usuario Admin :)");
                return;
            }

            var rs = MessageBox.Show(
                "¿Está seguro de que desea eliminar al usuario: " + u.NombreUsuario + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (rs == DialogResult.Yes)
            {
                Um.EliminarUsuario(u.Id);
                MessageBox.Show("Usuario eliminado correctamente");
                Um.MostrarUsuarios(DtgDatos); 
            }
        }

        private void DtgDatos_SelectionChanged(object sender, EventArgs e)
        {
            GbModificarAgregar.Visible = false;
        }
    }
}
