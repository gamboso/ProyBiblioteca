namespace ProyBiblioteca
{
    partial class Datos
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
            this.gbDatosAlumno = new System.Windows.Forms.GroupBox();
            this.gbDatosLibro = new System.Windows.Forms.GroupBox();
            this.gbDatosPAS = new System.Windows.Forms.GroupBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.gbDatosProfesor = new System.Windows.Forms.GroupBox();
            this.gbDatosDevolucion = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gbDatosAlumno
            // 
            this.gbDatosAlumno.Location = new System.Drawing.Point(12, 12);
            this.gbDatosAlumno.Name = "gbDatosAlumno";
            this.gbDatosAlumno.Size = new System.Drawing.Size(343, 289);
            this.gbDatosAlumno.TabIndex = 0;
            this.gbDatosAlumno.TabStop = false;
            this.gbDatosAlumno.Text = "Alumno";
            // 
            // gbDatosLibro
            // 
            this.gbDatosLibro.Location = new System.Drawing.Point(382, 12);
            this.gbDatosLibro.Name = "gbDatosLibro";
            this.gbDatosLibro.Size = new System.Drawing.Size(444, 276);
            this.gbDatosLibro.TabIndex = 1;
            this.gbDatosLibro.TabStop = false;
            this.gbDatosLibro.Text = "Libro";
            // 
            // gbDatosPAS
            // 
            this.gbDatosPAS.Location = new System.Drawing.Point(12, 307);
            this.gbDatosPAS.Name = "gbDatosPAS";
            this.gbDatosPAS.Size = new System.Drawing.Size(343, 252);
            this.gbDatosPAS.TabIndex = 2;
            this.gbDatosPAS.TabStop = false;
            this.gbDatosPAS.Text = "PAS";
            // 
            // gbDatos
            // 
            this.gbDatos.Location = new System.Drawing.Point(382, 307);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(444, 252);
            this.gbDatos.TabIndex = 3;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Prestamo";
            // 
            // gbDatosProfesor
            // 
            this.gbDatosProfesor.Location = new System.Drawing.Point(855, 12);
            this.gbDatosProfesor.Name = "gbDatosProfesor";
            this.gbDatosProfesor.Size = new System.Drawing.Size(394, 289);
            this.gbDatosProfesor.TabIndex = 4;
            this.gbDatosProfesor.TabStop = false;
            this.gbDatosProfesor.Text = "Profesor";
            // 
            // gbDatosDevolucion
            // 
            this.gbDatosDevolucion.Location = new System.Drawing.Point(855, 307);
            this.gbDatosDevolucion.Name = "gbDatosDevolucion";
            this.gbDatosDevolucion.Size = new System.Drawing.Size(394, 252);
            this.gbDatosDevolucion.TabIndex = 5;
            this.gbDatosDevolucion.TabStop = false;
            this.gbDatosDevolucion.Text = "Devolucion";
            // 
            // Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 641);
            this.Controls.Add(this.gbDatosDevolucion);
            this.Controls.Add(this.gbDatosProfesor);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.gbDatosPAS);
            this.Controls.Add(this.gbDatosLibro);
            this.Controls.Add(this.gbDatosAlumno);
            this.Name = "Datos";
            this.ShowIcon = false;
            this.Text = "Datos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosAlumno;
        private System.Windows.Forms.GroupBox gbDatosLibro;
        private System.Windows.Forms.GroupBox gbDatosPAS;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.GroupBox gbDatosProfesor;
        private System.Windows.Forms.GroupBox gbDatosDevolucion;
    }
}