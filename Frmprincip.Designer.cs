namespace ProyBiblioteca
{
    partial class FrmPrincip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincip));
            this.toolStripIconosIniciales = new System.Windows.Forms.ToolStrip();
            this.tsbLibros = new System.Windows.Forms.ToolStripButton();
            this.tsbUsuarios = new System.Windows.Forms.ToolStripButton();
            this.tsbPrestamos = new System.Windows.Forms.ToolStripButton();
            this.toolStripIconosIniciales.SuspendLayout();
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
            // 
            // tsbUsuarios
            // 
            this.tsbUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("tsbUsuarios.Image")));
            this.tsbUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUsuarios.Name = "tsbUsuarios";
            this.tsbUsuarios.Size = new System.Drawing.Size(72, 34);
            this.tsbUsuarios.Text = "Usuarios";
            this.tsbUsuarios.ToolTipText = "Usuarios";
            // 
            // tsbPrestamos
            // 
            this.tsbPrestamos.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrestamos.Image")));
            this.tsbPrestamos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrestamos.Name = "tsbPrestamos";
            this.tsbPrestamos.Size = new System.Drawing.Size(82, 34);
            this.tsbPrestamos.Text = "Prestamos";
            // 
            // FrmPrincip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripIconosIniciales);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmPrincip";
            this.Text = "Biblioteca Gamboso";
            this.Load += new System.EventHandler(this.FrmPrincip_Load);
            this.toolStripIconosIniciales.ResumeLayout(false);
            this.toolStripIconosIniciales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripIconosIniciales;
        private System.Windows.Forms.ToolStripButton tsbLibros;
        private System.Windows.Forms.ToolStripButton tsbUsuarios;
        private System.Windows.Forms.ToolStripButton tsbPrestamos;
    }
}

