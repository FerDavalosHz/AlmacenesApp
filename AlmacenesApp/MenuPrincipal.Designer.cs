namespace AlmacenesApp
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.almacenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.TProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.TSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.almacenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // almacenToolStripMenuItem
            // 
            this.almacenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsUsuarios,
            this.TProductos,
            this.TSalir});
            this.almacenToolStripMenuItem.Name = "almacenToolStripMenuItem";
            this.almacenToolStripMenuItem.Size = new System.Drawing.Size(66, 22);
            this.almacenToolStripMenuItem.Text = "Almacen";
            // 
            // TsUsuarios
            // 
            this.TsUsuarios.Enabled = false;
            this.TsUsuarios.Name = "TsUsuarios";
            this.TsUsuarios.Size = new System.Drawing.Size(196, 38);
            this.TsUsuarios.Text = "Usuarios";
            this.TsUsuarios.Click += new System.EventHandler(this.TsUsuarios_Click);
            // 
            // TProductos
            // 
            this.TProductos.Enabled = false;
            this.TProductos.Image = global::AlmacenesApp.Properties.Resources.icons8_producto_30;
            this.TProductos.Name = "TProductos";
            this.TProductos.Size = new System.Drawing.Size(196, 38);
            this.TProductos.Text = "Productos";
            this.TProductos.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // TSalir
            // 
            this.TSalir.Image = global::AlmacenesApp.Properties.Resources.icons8_salida_48;
            this.TSalir.Name = "TSalir";
            this.TSalir.Size = new System.Drawing.Size(196, 38);
            this.TSalir.Text = "Salir";
            this.TSalir.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(120, 6);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(41, 13);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "usuario";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 357);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem almacenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TProductos;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem TsUsuarios;
    }
}