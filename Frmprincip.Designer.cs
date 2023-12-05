namespace ProyBiblioteca
{
    partial class FrmBiblio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBiblio));
            this.toolStripIconosIniciales = new System.Windows.Forms.ToolStrip();
            this.tsbLibros = new System.Windows.Forms.ToolStripButton();
            this.tsbUsuarios = new System.Windows.Forms.ToolStripButton();
            this.tsbPrestamos = new System.Windows.Forms.ToolStripButton();
            this.tcOpciones = new System.Windows.Forms.TabControl();
            this.tpAñadir = new System.Windows.Forms.TabPage();
            this.pcbModo = new System.Windows.Forms.PictureBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbxAtrib4 = new System.Windows.Forms.TextBox();
            this.tbxAtrib3 = new System.Windows.Forms.TextBox();
            this.tbxAtrib2 = new System.Windows.Forms.TextBox();
            this.tbxAtrib1 = new System.Windows.Forms.TextBox();
            this.lblAtrib4 = new System.Windows.Forms.Label();
            this.lblAtrib3 = new System.Windows.Forms.Label();
            this.lblAtrib2 = new System.Windows.Forms.Label();
            this.lblAtrib1 = new System.Windows.Forms.Label();
            this.tpBorrado = new System.Windows.Forms.TabPage();
            this.pcb2Modo = new System.Windows.Forms.PictureBox();
            this.tpModificado = new System.Windows.Forms.TabPage();
            this.pcb3Modo = new System.Windows.Forms.PictureBox();
            this.tpBuscar = new System.Windows.Forms.TabPage();
            this.pcb4Modo = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maximizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripIconosIniciales.SuspendLayout();
            this.tcOpciones.SuspendLayout();
            this.tpAñadir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbModo)).BeginInit();
            this.tpBorrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb2Modo)).BeginInit();
            this.tpModificado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb3Modo)).BeginInit();
            this.tpBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb4Modo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripIconosIniciales
            // 
            this.toolStripIconosIniciales.AutoSize = false;
            this.toolStripIconosIniciales.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLibros,
            this.tsbUsuarios,
            this.tsbPrestamos});
            this.toolStripIconosIniciales.Location = new System.Drawing.Point(0, 0);
            this.toolStripIconosIniciales.Name = "toolStripIconosIniciales";
            this.toolStripIconosIniciales.Size = new System.Drawing.Size(800, 37);
            this.toolStripIconosIniciales.TabIndex = 1;
            this.toolStripIconosIniciales.Text = "toolStrip1";
            // 
            // tsbLibros
            // 
            this.tsbLibros.Image = ((System.Drawing.Image)(resources.GetObject("tsbLibros.Image")));
            this.tsbLibros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLibros.Name = "tsbLibros";
            this.tsbLibros.Size = new System.Drawing.Size(59, 34);
            this.tsbLibros.Text = "Libros";
            this.tsbLibros.Click += new System.EventHandler(this.tsbLibros_Click);
            // 
            // tsbUsuarios
            // 
            this.tsbUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("tsbUsuarios.Image")));
            this.tsbUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUsuarios.Name = "tsbUsuarios";
            this.tsbUsuarios.Size = new System.Drawing.Size(72, 34);
            this.tsbUsuarios.Text = "Usuarios";
            this.tsbUsuarios.ToolTipText = "Usuarios";
            this.tsbUsuarios.Click += new System.EventHandler(this.tsbUsuarios_Click);
            // 
            // tsbPrestamos
            // 
            this.tsbPrestamos.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrestamos.Image")));
            this.tsbPrestamos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrestamos.Name = "tsbPrestamos";
            this.tsbPrestamos.Size = new System.Drawing.Size(82, 34);
            this.tsbPrestamos.Text = "Prestamos";
            this.tsbPrestamos.Click += new System.EventHandler(this.tsbPrestamos_Click);
            // 
            // tcOpciones
            // 
            this.tcOpciones.Controls.Add(this.tpAñadir);
            this.tcOpciones.Controls.Add(this.tpBorrado);
            this.tcOpciones.Controls.Add(this.tpModificado);
            this.tcOpciones.Controls.Add(this.tpBuscar);
            this.tcOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOpciones.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcOpciones.Location = new System.Drawing.Point(0, 37);
            this.tcOpciones.Name = "tcOpciones";
            this.tcOpciones.SelectedIndex = 0;
            this.tcOpciones.Size = new System.Drawing.Size(800, 413);
            this.tcOpciones.TabIndex = 3;
            // 
            // tpAñadir
            // 
            this.tpAñadir.Controls.Add(this.pcbModo);
            this.tpAñadir.Controls.Add(this.btnLimpiar);
            this.tpAñadir.Controls.Add(this.btnGuardar);
            this.tpAñadir.Controls.Add(this.tbxAtrib4);
            this.tpAñadir.Controls.Add(this.tbxAtrib3);
            this.tpAñadir.Controls.Add(this.tbxAtrib2);
            this.tpAñadir.Controls.Add(this.tbxAtrib1);
            this.tpAñadir.Controls.Add(this.lblAtrib4);
            this.tpAñadir.Controls.Add(this.lblAtrib3);
            this.tpAñadir.Controls.Add(this.lblAtrib2);
            this.tpAñadir.Controls.Add(this.lblAtrib1);
            this.tpAñadir.Location = new System.Drawing.Point(4, 24);
            this.tpAñadir.Name = "tpAñadir";
            this.tpAñadir.Padding = new System.Windows.Forms.Padding(3);
            this.tpAñadir.Size = new System.Drawing.Size(792, 385);
            this.tpAñadir.TabIndex = 0;
            this.tpAñadir.Text = "Añadir";
            this.tpAñadir.UseVisualStyleBackColor = true;
            // 
            // pcbModo
            // 
            this.pcbModo.Location = new System.Drawing.Point(30, 24);
            this.pcbModo.Name = "pcbModo";
            this.pcbModo.Size = new System.Drawing.Size(50, 50);
            this.pcbModo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbModo.TabIndex = 14;
            this.pcbModo.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Location = new System.Drawing.Point(547, 207);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(148, 53);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "LIMPIAR CAMPOS";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.UseWaitCursor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Location = new System.Drawing.Point(547, 110);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 53);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.UseWaitCursor = true;
            // 
            // tbxAtrib4
            // 
            this.tbxAtrib4.Location = new System.Drawing.Point(243, 242);
            this.tbxAtrib4.Name = "tbxAtrib4";
            this.tbxAtrib4.Size = new System.Drawing.Size(161, 22);
            this.tbxAtrib4.TabIndex = 11;
            // 
            // tbxAtrib3
            // 
            this.tbxAtrib3.Location = new System.Drawing.Point(243, 190);
            this.tbxAtrib3.Name = "tbxAtrib3";
            this.tbxAtrib3.Size = new System.Drawing.Size(161, 22);
            this.tbxAtrib3.TabIndex = 10;
            // 
            // tbxAtrib2
            // 
            this.tbxAtrib2.Location = new System.Drawing.Point(243, 141);
            this.tbxAtrib2.Name = "tbxAtrib2";
            this.tbxAtrib2.Size = new System.Drawing.Size(161, 22);
            this.tbxAtrib2.TabIndex = 9;
            // 
            // tbxAtrib1
            // 
            this.tbxAtrib1.Location = new System.Drawing.Point(243, 93);
            this.tbxAtrib1.Name = "tbxAtrib1";
            this.tbxAtrib1.Size = new System.Drawing.Size(161, 22);
            this.tbxAtrib1.TabIndex = 8;
            // 
            // lblAtrib4
            // 
            this.lblAtrib4.AutoSize = true;
            this.lblAtrib4.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtrib4.Location = new System.Drawing.Point(126, 243);
            this.lblAtrib4.Name = "lblAtrib4";
            this.lblAtrib4.Size = new System.Drawing.Size(66, 17);
            this.lblAtrib4.TabIndex = 7;
            this.lblAtrib4.Text = "Atributo 4";
            // 
            // lblAtrib3
            // 
            this.lblAtrib3.AutoSize = true;
            this.lblAtrib3.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtrib3.Location = new System.Drawing.Point(126, 191);
            this.lblAtrib3.Name = "lblAtrib3";
            this.lblAtrib3.Size = new System.Drawing.Size(66, 17);
            this.lblAtrib3.TabIndex = 6;
            this.lblAtrib3.Text = "Atributo 3";
            // 
            // lblAtrib2
            // 
            this.lblAtrib2.AutoSize = true;
            this.lblAtrib2.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtrib2.Location = new System.Drawing.Point(126, 142);
            this.lblAtrib2.Name = "lblAtrib2";
            this.lblAtrib2.Size = new System.Drawing.Size(66, 17);
            this.lblAtrib2.TabIndex = 5;
            this.lblAtrib2.Text = "Atributo 2";
            // 
            // lblAtrib1
            // 
            this.lblAtrib1.AutoSize = true;
            this.lblAtrib1.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtrib1.Location = new System.Drawing.Point(126, 93);
            this.lblAtrib1.Name = "lblAtrib1";
            this.lblAtrib1.Size = new System.Drawing.Size(66, 17);
            this.lblAtrib1.TabIndex = 4;
            this.lblAtrib1.Text = "Atributo 1";
            // 
            // tpBorrado
            // 
            this.tpBorrado.Controls.Add(this.pcb2Modo);
            this.tpBorrado.Location = new System.Drawing.Point(4, 24);
            this.tpBorrado.Name = "tpBorrado";
            this.tpBorrado.Padding = new System.Windows.Forms.Padding(3);
            this.tpBorrado.Size = new System.Drawing.Size(792, 385);
            this.tpBorrado.TabIndex = 1;
            this.tpBorrado.Text = "Borrar";
            this.tpBorrado.UseVisualStyleBackColor = true;
            // 
            // pcb2Modo
            // 
            this.pcb2Modo.Location = new System.Drawing.Point(30, 24);
            this.pcb2Modo.Name = "pcb2Modo";
            this.pcb2Modo.Size = new System.Drawing.Size(50, 50);
            this.pcb2Modo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb2Modo.TabIndex = 15;
            this.pcb2Modo.TabStop = false;
            // 
            // tpModificado
            // 
            this.tpModificado.Controls.Add(this.pcb3Modo);
            this.tpModificado.Location = new System.Drawing.Point(4, 24);
            this.tpModificado.Name = "tpModificado";
            this.tpModificado.Padding = new System.Windows.Forms.Padding(3);
            this.tpModificado.Size = new System.Drawing.Size(792, 385);
            this.tpModificado.TabIndex = 2;
            this.tpModificado.Text = "Modificar";
            this.tpModificado.UseVisualStyleBackColor = true;
            // 
            // pcb3Modo
            // 
            this.pcb3Modo.Location = new System.Drawing.Point(30, 24);
            this.pcb3Modo.Name = "pcb3Modo";
            this.pcb3Modo.Size = new System.Drawing.Size(50, 50);
            this.pcb3Modo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb3Modo.TabIndex = 15;
            this.pcb3Modo.TabStop = false;
            // 
            // tpBuscar
            // 
            this.tpBuscar.Controls.Add(this.pcb4Modo);
            this.tpBuscar.Location = new System.Drawing.Point(4, 24);
            this.tpBuscar.Name = "tpBuscar";
            this.tpBuscar.Padding = new System.Windows.Forms.Padding(3);
            this.tpBuscar.Size = new System.Drawing.Size(792, 385);
            this.tpBuscar.TabIndex = 3;
            this.tpBuscar.Text = "Búsqueda";
            this.tpBuscar.UseVisualStyleBackColor = true;
            // 
            // pcb4Modo
            // 
            this.pcb4Modo.Location = new System.Drawing.Point(30, 24);
            this.pcb4Modo.Name = "pcb4Modo";
            this.pcb4Modo.Size = new System.Drawing.Size(50, 50);
            this.pcb4Modo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb4Modo.TabIndex = 15;
            this.pcb4Modo.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maximizarToolStripMenuItem,
            this.minimizarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 70);
            // 
            // maximizarToolStripMenuItem
            // 
            this.maximizarToolStripMenuItem.Name = "maximizarToolStripMenuItem";
            this.maximizarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.maximizarToolStripMenuItem.Text = "Maximizar";
            this.maximizarToolStripMenuItem.Click += new System.EventHandler(this.maximizarToolStripMenuItem_Click);
            // 
            // minimizarToolStripMenuItem
            // 
            this.minimizarToolStripMenuItem.Name = "minimizarToolStripMenuItem";
            this.minimizarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.minimizarToolStripMenuItem.Text = "Minimizar";
            this.minimizarToolStripMenuItem.Click += new System.EventHandler(this.minimizarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // FrmBiblio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcOpciones);
            this.Controls.Add(this.toolStripIconosIniciales);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmBiblio";
            this.Text = " Biblioteca ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincip_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincip_Load);
            this.toolStripIconosIniciales.ResumeLayout(false);
            this.toolStripIconosIniciales.PerformLayout();
            this.tcOpciones.ResumeLayout(false);
            this.tpAñadir.ResumeLayout(false);
            this.tpAñadir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbModo)).EndInit();
            this.tpBorrado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcb2Modo)).EndInit();
            this.tpModificado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcb3Modo)).EndInit();
            this.tpBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcb4Modo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripIconosIniciales;
        private System.Windows.Forms.ToolStripButton tsbLibros;
        private System.Windows.Forms.ToolStripButton tsbUsuarios;
        private System.Windows.Forms.ToolStripButton tsbPrestamos;
        private System.Windows.Forms.TabControl tcOpciones;
        private System.Windows.Forms.TabPage tpAñadir;
        private System.Windows.Forms.TabPage tpBorrado;
        private System.Windows.Forms.TabPage tpModificado;
        private System.Windows.Forms.TabPage tpBuscar;
        private System.Windows.Forms.Label lblAtrib4;
        private System.Windows.Forms.Label lblAtrib3;
        private System.Windows.Forms.Label lblAtrib2;
        private System.Windows.Forms.Label lblAtrib1;
        private System.Windows.Forms.TextBox tbxAtrib4;
        private System.Windows.Forms.TextBox tbxAtrib3;
        private System.Windows.Forms.TextBox tbxAtrib2;
        private System.Windows.Forms.TextBox tbxAtrib1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pcbModo;
        private System.Windows.Forms.PictureBox pcb2Modo;
        private System.Windows.Forms.PictureBox pcb3Modo;
        private System.Windows.Forms.PictureBox pcb4Modo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maximizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

