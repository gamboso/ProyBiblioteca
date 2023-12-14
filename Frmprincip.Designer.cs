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
            this.tsbTransacciones = new System.Windows.Forms.ToolStripButton();
            this.tcOpciones = new System.Windows.Forms.TabControl();
            this.tpAñadir = new System.Windows.Forms.TabPage();
            this.gbAux = new System.Windows.Forms.GroupBox();
            this.cbUsuariosAnadirPrestamos = new System.Windows.Forms.ComboBox();
            this.cbLibroPresDev = new System.Windows.Forms.ComboBox();
            this.mtbFechaAniadirPrestamo = new System.Windows.Forms.MaskedTextBox();
            this.tbxAtrib3 = new System.Windows.Forms.TextBox();
            this.tbxAtrib2 = new System.Windows.Forms.TextBox();
            this.tbxAtrib1 = new System.Windows.Forms.TextBox();
            this.lblAtrib3 = new System.Windows.Forms.Label();
            this.lblAtrib2 = new System.Windows.Forms.Label();
            this.lblAtrib1 = new System.Windows.Forms.Label();
            this.gbAtribs = new System.Windows.Forms.GroupBox();
            this.rbOpcion3 = new System.Windows.Forms.RadioButton();
            this.rbOpcion2 = new System.Windows.Forms.RadioButton();
            this.rbOpcion1 = new System.Windows.Forms.RadioButton();
            this.pcbModo = new System.Windows.Forms.PictureBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tpBorrado = new System.Windows.Forms.TabPage();
            this.lblFechaBorrarPrestamo = new System.Windows.Forms.Label();
            this.mtbFechaBorrarPrestamo = new System.Windows.Forms.MaskedTextBox();
            this.lvBorrar = new System.Windows.Forms.ListView();
            this.ilProfesoresAlumnosPAS = new System.Windows.Forms.ImageList(this.components);
            this.lblBorrar = new System.Windows.Forms.Label();
            this.pcb2Modo = new System.Windows.Forms.PictureBox();
            this.tpModificado = new System.Windows.Forms.TabPage();
            this.lblFechaModificarPrestamo = new System.Windows.Forms.Label();
            this.mtbFechaModificarPrestamo = new System.Windows.Forms.MaskedTextBox();
            this.lblModificar = new System.Windows.Forms.Label();
            this.lvModificar = new System.Windows.Forms.ListView();
            this.pcb3Modo = new System.Windows.Forms.PictureBox();
            this.tpBuscar = new System.Windows.Forms.TabPage();
            this.lblInfoBuscar = new System.Windows.Forms.Label();
            this.mtbFechaBusquedaPrestamo = new System.Windows.Forms.MaskedTextBox();
            this.cbFiltrarPor = new System.Windows.Forms.ComboBox();
            this.lblFiltrarPor = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txbBuscar = new System.Windows.Forms.TextBox();
            this.lvDevoluciones = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPrestamos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idLibr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fechamax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvBusqueda = new System.Windows.Forms.ListView();
            this.pcb4Modo = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maximizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilPrestamos = new System.Windows.Forms.ImageList(this.components);

            this.lblPrestamos = new System.Windows.Forms.Label();
            this.lblDevol = new System.Windows.Forms.Label();
            this.toolStripIconosIniciales.SuspendLayout();
            this.tcOpciones.SuspendLayout();
            this.tpAñadir.SuspendLayout();
            this.gbAux.SuspendLayout();
            this.gbAtribs.SuspendLayout();
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
            this.tsbTransacciones});
            this.toolStripIconosIniciales.Location = new System.Drawing.Point(0, 0);
            this.toolStripIconosIniciales.Name = "toolStripIconosIniciales";
            this.toolStripIconosIniciales.Size = new System.Drawing.Size(1197, 37);
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
            // tsbTransacciones
            // 
            this.tsbTransacciones.Image = ((System.Drawing.Image)(resources.GetObject("tsbTransacciones.Image")));
            this.tsbTransacciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransacciones.Name = "tsbTransacciones";
            this.tsbTransacciones.Size = new System.Drawing.Size(100, 34);
            this.tsbTransacciones.Text = "Transacciones";
            this.tsbTransacciones.Click += new System.EventHandler(this.tsbPrestamos_Click);
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
            this.tcOpciones.Size = new System.Drawing.Size(1197, 540);
            this.tcOpciones.TabIndex = 3;
            // 
            // tpAñadir
            // 
            this.tpAñadir.Controls.Add(this.gbAux);
            this.tpAñadir.Controls.Add(this.gbAtribs);
            this.tpAñadir.Controls.Add(this.pcbModo);
            this.tpAñadir.Controls.Add(this.btnLimpiar);
            this.tpAñadir.Controls.Add(this.btnGuardar);
            this.tpAñadir.Location = new System.Drawing.Point(4, 24);
            this.tpAñadir.Name = "tpAñadir";
            this.tpAñadir.Padding = new System.Windows.Forms.Padding(3);
            this.tpAñadir.Size = new System.Drawing.Size(1189, 512);
            this.tpAñadir.TabIndex = 0;
            this.tpAñadir.Text = "Añadir";
            this.tpAñadir.UseVisualStyleBackColor = true;
            // 
            // gbAux
            // 
            this.gbAux.Controls.Add(this.cbUsuariosAnadirPrestamos);
            this.gbAux.Controls.Add(this.cbLibroPresDev);
            this.gbAux.Controls.Add(this.mtbFechaAniadirPrestamo);
            this.gbAux.Controls.Add(this.tbxAtrib3);
            this.gbAux.Controls.Add(this.tbxAtrib2);
            this.gbAux.Controls.Add(this.tbxAtrib1);
            this.gbAux.Controls.Add(this.lblAtrib3);
            this.gbAux.Controls.Add(this.lblAtrib2);
            this.gbAux.Controls.Add(this.lblAtrib1);
            this.gbAux.Location = new System.Drawing.Point(628, 99);
            this.gbAux.Name = "gbAux";
            this.gbAux.Size = new System.Drawing.Size(553, 243);
            this.gbAux.TabIndex = 16;
            this.gbAux.TabStop = false;
            // 
            // cbUsuariosAnadirPrestamos
            // 
            this.cbUsuariosAnadirPrestamos.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUsuariosAnadirPrestamos.FormattingEnabled = true;
            this.cbUsuariosAnadirPrestamos.Location = new System.Drawing.Point(252, 55);
            this.cbUsuariosAnadirPrestamos.Name = "cbUsuariosAnadirPrestamos";
            this.cbUsuariosAnadirPrestamos.Size = new System.Drawing.Size(241, 24);
            this.cbUsuariosAnadirPrestamos.TabIndex = 21;
            // 
            // cbLibroPresDev
            // 
            this.cbLibroPresDev.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLibroPresDev.FormattingEnabled = true;
            this.cbLibroPresDev.Location = new System.Drawing.Point(252, 112);
            this.cbLibroPresDev.Name = "cbLibroPresDev";
            this.cbLibroPresDev.Size = new System.Drawing.Size(241, 24);
            this.cbLibroPresDev.TabIndex = 20;
            // 
            // mtbFechaAniadirPrestamo
            // 
            this.mtbFechaAniadirPrestamo.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbFechaAniadirPrestamo.Location = new System.Drawing.Point(393, 170);
            this.mtbFechaAniadirPrestamo.Mask = "00/00/0000";
            this.mtbFechaAniadirPrestamo.Name = "mtbFechaAniadirPrestamo";
            this.mtbFechaAniadirPrestamo.Size = new System.Drawing.Size(100, 23);
            this.mtbFechaAniadirPrestamo.TabIndex = 19;
            this.mtbFechaAniadirPrestamo.ValidatingType = typeof(System.DateTime);
            // 
            // tbxAtrib3
            // 
            this.tbxAtrib3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAtrib3.Location = new System.Drawing.Point(241, 170);
            this.tbxAtrib3.Name = "tbxAtrib3";
            this.tbxAtrib3.Size = new System.Drawing.Size(252, 23);
            this.tbxAtrib3.TabIndex = 18;
            // 
            // tbxAtrib2
            // 
            this.tbxAtrib2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAtrib2.Location = new System.Drawing.Point(241, 113);
            this.tbxAtrib2.Name = "tbxAtrib2";
            this.tbxAtrib2.Size = new System.Drawing.Size(252, 23);
            this.tbxAtrib2.TabIndex = 17;
            // 
            // tbxAtrib1
            // 
            this.tbxAtrib1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAtrib1.Location = new System.Drawing.Point(241, 54);
            this.tbxAtrib1.Name = "tbxAtrib1";
            this.tbxAtrib1.Size = new System.Drawing.Size(252, 23);
            this.tbxAtrib1.TabIndex = 16;
            // 
            // lblAtrib3
            // 
            this.lblAtrib3.AutoSize = true;
            this.lblAtrib3.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtrib3.Location = new System.Drawing.Point(19, 166);
            this.lblAtrib3.Name = "lblAtrib3";
            this.lblAtrib3.Size = new System.Drawing.Size(106, 26);
            this.lblAtrib3.TabIndex = 14;
            this.lblAtrib3.Text = "Atributo 3";
            // 
            // lblAtrib2
            // 
            this.lblAtrib2.AutoSize = true;
            this.lblAtrib2.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtrib2.Location = new System.Drawing.Point(19, 107);
            this.lblAtrib2.Name = "lblAtrib2";
            this.lblAtrib2.Size = new System.Drawing.Size(106, 26);
            this.lblAtrib2.TabIndex = 13;
            this.lblAtrib2.Text = "Atributo 2";
            // 
            // lblAtrib1
            // 
            this.lblAtrib1.AutoSize = true;
            this.lblAtrib1.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtrib1.Location = new System.Drawing.Point(19, 48);
            this.lblAtrib1.Name = "lblAtrib1";
            this.lblAtrib1.Size = new System.Drawing.Size(106, 26);
            this.lblAtrib1.TabIndex = 12;
            this.lblAtrib1.Text = "Atributo 1";
            // 
            // gbAtribs
            // 
            this.gbAtribs.Controls.Add(this.rbOpcion3);
            this.gbAtribs.Controls.Add(this.rbOpcion2);
            this.gbAtribs.Controls.Add(this.rbOpcion1);
            this.gbAtribs.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAtribs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gbAtribs.Location = new System.Drawing.Point(150, 88);
            this.gbAtribs.Name = "gbAtribs";
            this.gbAtribs.Size = new System.Drawing.Size(435, 254);
            this.gbAtribs.TabIndex = 15;
            this.gbAtribs.TabStop = false;
            this.gbAtribs.Text = "Atrib";
            // 
            // rbOpcion3
            // 
            this.rbOpcion3.AutoSize = true;
            this.rbOpcion3.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpcion3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbOpcion3.Location = new System.Drawing.Point(250, 109);
            this.rbOpcion3.Name = "rbOpcion3";
            this.rbOpcion3.Size = new System.Drawing.Size(152, 30);
            this.rbOpcion3.TabIndex = 18;
            this.rbOpcion3.TabStop = true;
            this.rbOpcion3.Text = "radioButton3";
            this.rbOpcion3.UseVisualStyleBackColor = true;
            // 
            // rbOpcion2
            // 
            this.rbOpcion2.AutoSize = true;
            this.rbOpcion2.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpcion2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbOpcion2.Location = new System.Drawing.Point(48, 152);
            this.rbOpcion2.Name = "rbOpcion2";
            this.rbOpcion2.Size = new System.Drawing.Size(152, 30);
            this.rbOpcion2.TabIndex = 17;
            this.rbOpcion2.TabStop = true;
            this.rbOpcion2.Text = "radioButton2";
            this.rbOpcion2.UseVisualStyleBackColor = true;
            // 
            // rbOpcion1
            // 
            this.rbOpcion1.AutoSize = true;
            this.rbOpcion1.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpcion1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbOpcion1.Location = new System.Drawing.Point(48, 66);
            this.rbOpcion1.Name = "rbOpcion1";
            this.rbOpcion1.Size = new System.Drawing.Size(152, 30);
            this.rbOpcion1.TabIndex = 16;
            this.rbOpcion1.TabStop = true;
            this.rbOpcion1.Text = "radioButton1";
            this.rbOpcion1.UseVisualStyleBackColor = true;
            this.rbOpcion1.CheckedChanged += new System.EventHandler(this.cambioCheckRadioButton);
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
            this.btnLimpiar.Location = new System.Drawing.Point(628, 412);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(148, 53);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "LIMPIAR CAMPOS";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.UseWaitCursor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Location = new System.Drawing.Point(400, 412);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 53);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.UseWaitCursor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tpBorrado
            // 
            this.tpBorrado.Controls.Add(this.lblFechaBorrarPrestamo);
            this.tpBorrado.Controls.Add(this.mtbFechaBorrarPrestamo);
            this.tpBorrado.Controls.Add(this.lvBorrar);
            this.tpBorrado.Controls.Add(this.lblBorrar);
            this.tpBorrado.Controls.Add(this.pcb2Modo);
            this.tpBorrado.Location = new System.Drawing.Point(4, 24);
            this.tpBorrado.Name = "tpBorrado";
            this.tpBorrado.Padding = new System.Windows.Forms.Padding(3);
            this.tpBorrado.Size = new System.Drawing.Size(1189, 512);
            this.tpBorrado.TabIndex = 1;
            this.tpBorrado.Text = "Borrar";
            this.tpBorrado.UseVisualStyleBackColor = true;
            // 
            // lblFechaBorrarPrestamo
            // 
            this.lblFechaBorrarPrestamo.AutoSize = true;
            this.lblFechaBorrarPrestamo.Location = new System.Drawing.Point(261, 71);
            this.lblFechaBorrarPrestamo.Name = "lblFechaBorrarPrestamo";
            this.lblFechaBorrarPrestamo.Size = new System.Drawing.Size(46, 15);
            this.lblFechaBorrarPrestamo.TabIndex = 19;
            this.lblFechaBorrarPrestamo.Text = "Fecha:";
            // 
            // mtbFechaBorrarPrestamo
            // 
            this.mtbFechaBorrarPrestamo.Location = new System.Drawing.Point(313, 64);
            this.mtbFechaBorrarPrestamo.Mask = "00/00/0000";
            this.mtbFechaBorrarPrestamo.Name = "mtbFechaBorrarPrestamo";
            this.mtbFechaBorrarPrestamo.Size = new System.Drawing.Size(100, 22);
            this.mtbFechaBorrarPrestamo.TabIndex = 18;
            this.mtbFechaBorrarPrestamo.ValidatingType = typeof(System.DateTime);
            // 
            // lvBorrar
            // 
            this.lvBorrar.HideSelection = false;
            this.lvBorrar.LargeImageList = this.ilProfesoresAlumnosPAS;
            this.lvBorrar.Location = new System.Drawing.Point(264, 116);
            this.lvBorrar.Name = "lvBorrar";
            this.lvBorrar.Size = new System.Drawing.Size(602, 263);
            this.lvBorrar.SmallImageList = this.ilProfesoresAlumnosPAS;
            this.lvBorrar.TabIndex = 17;
            this.lvBorrar.UseCompatibleStateImageBehavior = false;
            this.lvBorrar.View = System.Windows.Forms.View.SmallIcon;
            this.lvBorrar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvBorrar_MouseDoubleClick);
            // 
            // ilProfesoresAlumnosPAS
            // 
            this.ilProfesoresAlumnosPAS.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilProfesoresAlumnosPAS.ImageStream")));
            this.ilProfesoresAlumnosPAS.TransparentColor = System.Drawing.Color.Transparent;
            this.ilProfesoresAlumnosPAS.Images.SetKeyName(0, "profesor.png");
            this.ilProfesoresAlumnosPAS.Images.SetKeyName(1, "alumno.png");
            this.ilProfesoresAlumnosPAS.Images.SetKeyName(2, "pas.png");
            this.ilProfesoresAlumnosPAS.Images.SetKeyName(3, "libro-cerrado.png");
            // 
            // lblBorrar
            // 
            this.lblBorrar.AutoSize = true;
            this.lblBorrar.Location = new System.Drawing.Point(261, 98);
            this.lblBorrar.Name = "lblBorrar";
            this.lblBorrar.Size = new System.Drawing.Size(216, 15);
            this.lblBorrar.TabIndex = 16;
            this.lblBorrar.Text = "Doble clic para borrar un registro:";
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
            this.tpModificado.Controls.Add(this.lblFechaModificarPrestamo);
            this.tpModificado.Controls.Add(this.mtbFechaModificarPrestamo);
            this.tpModificado.Controls.Add(this.lblModificar);
            this.tpModificado.Controls.Add(this.lvModificar);
            this.tpModificado.Controls.Add(this.pcb3Modo);
            this.tpModificado.Location = new System.Drawing.Point(4, 24);
            this.tpModificado.Name = "tpModificado";
            this.tpModificado.Padding = new System.Windows.Forms.Padding(3);
            this.tpModificado.Size = new System.Drawing.Size(1189, 512);
            this.tpModificado.TabIndex = 2;
            this.tpModificado.Text = "Modificar";
            this.tpModificado.UseVisualStyleBackColor = true;
            // 
            // lblFechaModificarPrestamo
            // 
            this.lblFechaModificarPrestamo.AutoSize = true;
            this.lblFechaModificarPrestamo.Location = new System.Drawing.Point(262, 70);
            this.lblFechaModificarPrestamo.Name = "lblFechaModificarPrestamo";
            this.lblFechaModificarPrestamo.Size = new System.Drawing.Size(46, 15);
            this.lblFechaModificarPrestamo.TabIndex = 21;
            this.lblFechaModificarPrestamo.Text = "Fecha:";
            // 
            // mtbFechaModificarPrestamo
            // 
            this.mtbFechaModificarPrestamo.Location = new System.Drawing.Point(314, 63);
            this.mtbFechaModificarPrestamo.Mask = "00/00/0000";
            this.mtbFechaModificarPrestamo.Name = "mtbFechaModificarPrestamo";
            this.mtbFechaModificarPrestamo.Size = new System.Drawing.Size(100, 22);
            this.mtbFechaModificarPrestamo.TabIndex = 20;
            this.mtbFechaModificarPrestamo.ValidatingType = typeof(System.DateTime);
            // 
            // lblModificar
            // 
            this.lblModificar.AutoSize = true;
            this.lblModificar.Location = new System.Drawing.Point(260, 97);
            this.lblModificar.Name = "lblModificar";
            this.lblModificar.Size = new System.Drawing.Size(269, 15);
            this.lblModificar.TabIndex = 17;
            this.lblModificar.Text = "Selecciona el registro que desea modificar:";
            // 
            // lvModificar
            // 
            this.lvModificar.HideSelection = false;
            this.lvModificar.Location = new System.Drawing.Point(265, 115);
            this.lvModificar.Name = "lvModificar";
            this.lvModificar.Size = new System.Drawing.Size(603, 262);
            this.lvModificar.TabIndex = 16;
            this.lvModificar.UseCompatibleStateImageBehavior = false;
            this.lvModificar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvModificar_MouseDoubleClick);
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
            this.tpBuscar.Controls.Add(this.lblDevol);
            this.tpBuscar.Controls.Add(this.lblPrestamos);
            this.tpBuscar.Controls.Add(this.lblInfoBuscar);
            this.tpBuscar.Controls.Add(this.mtbFechaBusquedaPrestamo);
            this.tpBuscar.Controls.Add(this.cbFiltrarPor);
            this.tpBuscar.Controls.Add(this.lblFiltrarPor);
            this.tpBuscar.Controls.Add(this.btnBuscar);
            this.tpBuscar.Controls.Add(this.txbBuscar);
            this.tpBuscar.Controls.Add(this.lvDevoluciones);
            this.tpBuscar.Controls.Add(this.lvPrestamos);
            this.tpBuscar.Controls.Add(this.lvBusqueda);
            this.tpBuscar.Controls.Add(this.pcb4Modo);
            this.tpBuscar.Location = new System.Drawing.Point(4, 24);
            this.tpBuscar.Name = "tpBuscar";
            this.tpBuscar.Padding = new System.Windows.Forms.Padding(3);
            this.tpBuscar.Size = new System.Drawing.Size(1189, 512);
            this.tpBuscar.TabIndex = 3;
            this.tpBuscar.Text = "Búsqueda";
            this.tpBuscar.UseVisualStyleBackColor = true;
            // 
            // lblInfoBuscar
            // 
            this.lblInfoBuscar.AutoSize = true;
            this.lblInfoBuscar.Location = new System.Drawing.Point(391, 34);
            this.lblInfoBuscar.Name = "lblInfoBuscar";
            this.lblInfoBuscar.Size = new System.Drawing.Size(150, 15);
            this.lblInfoBuscar.TabIndex = 26;
            this.lblInfoBuscar.Text = "Búsqueda por nombre: ";
            // 
            // mtbFechaBusquedaPrestamo
            // 
            this.mtbFechaBusquedaPrestamo.Location = new System.Drawing.Point(668, 51);
            this.mtbFechaBusquedaPrestamo.Mask = "00/00/0000";
            this.mtbFechaBusquedaPrestamo.Name = "mtbFechaBusquedaPrestamo";
            this.mtbFechaBusquedaPrestamo.Size = new System.Drawing.Size(100, 22);
            this.mtbFechaBusquedaPrestamo.TabIndex = 25;
            this.mtbFechaBusquedaPrestamo.ValidatingType = typeof(System.DateTime);
            // 
            // cbFiltrarPor
            // 
            this.cbFiltrarPor.FormattingEnabled = true;
            this.cbFiltrarPor.Items.AddRange(new object[] {
            "Nombre Usuario",
            "Fecha Transaccion",
            "Titulo Libro",
            "Departamento"});
            this.cbFiltrarPor.Location = new System.Drawing.Point(240, 51);
            this.cbFiltrarPor.Name = "cbFiltrarPor";
            this.cbFiltrarPor.Size = new System.Drawing.Size(121, 23);
            this.cbFiltrarPor.TabIndex = 24;
            this.cbFiltrarPor.SelectedIndexChanged += new System.EventHandler(this.cbFiltrarPor_SelectedIndexChanged);
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.Location = new System.Drawing.Point(161, 55);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(73, 15);
            this.lblFiltrarPor.TabIndex = 23;
            this.lblFiltrarPor.Text = "Filtrar por:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(790, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(143, 41);
            this.btnBuscar.TabIndex = 22;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txbBuscar
            // 
            this.txbBuscar.Location = new System.Drawing.Point(394, 61);
            this.txbBuscar.Name = "txbBuscar";
            this.txbBuscar.Size = new System.Drawing.Size(374, 22);
            this.txbBuscar.TabIndex = 21;
            // 
            // lvDevoluciones
            // 
            this.lvDevoluciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvDevoluciones.FullRowSelect = true;
            this.lvDevoluciones.GridLines = true;
            this.lvDevoluciones.HideSelection = false;
            this.lvDevoluciones.Location = new System.Drawing.Point(698, 113);
            this.lvDevoluciones.Name = "lvDevoluciones";
            this.lvDevoluciones.Size = new System.Drawing.Size(453, 363);
            this.lvDevoluciones.TabIndex = 18;
            this.lvDevoluciones.UseCompatibleStateImageBehavior = false;
            this.lvDevoluciones.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID Libro";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Fecha Transaccion";
            this.columnHeader4.Width = 169;
            // 
            // lvPrestamos
            // 
            this.lvPrestamos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.idLibr,
            this.fechamax,
            this.columnHeader2});
            this.lvPrestamos.FullRowSelect = true;
            this.lvPrestamos.GridLines = true;
            this.lvPrestamos.HideSelection = false;
            this.lvPrestamos.Location = new System.Drawing.Point(44, 113);
            this.lvPrestamos.Name = "lvPrestamos";
            this.lvPrestamos.Size = new System.Drawing.Size(465, 363);
            this.lvPrestamos.TabIndex = 17;
            this.lvPrestamos.UseCompatibleStateImageBehavior = false;
            this.lvPrestamos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Usuario";
            this.columnHeader1.Width = 87;
            // 
            // idLibr
            // 
            this.idLibr.Text = "ID Libro";
            this.idLibr.Width = 89;
            // 
            // fechamax
            // 
            this.fechamax.Text = "Fecha Máxima Dev";
            this.fechamax.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fecha Transaccion";
            this.columnHeader2.Width = 152;
            // 
            // lvBusqueda
            // 
            this.lvBusqueda.FullRowSelect = true;
            this.lvBusqueda.GridLines = true;
            this.lvBusqueda.HideSelection = false;
            this.lvBusqueda.Location = new System.Drawing.Point(333, 153);
            this.lvBusqueda.Name = "lvBusqueda";
            this.lvBusqueda.Size = new System.Drawing.Size(600, 250);
            this.lvBusqueda.TabIndex = 16;
            this.lvBusqueda.UseCompatibleStateImageBehavior = false;
            this.lvBusqueda.View = System.Windows.Forms.View.Details;
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
            this.maximizarToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.maximizarToolStripMenuItem.Text = "Maximizar";
            this.maximizarToolStripMenuItem.Click += new System.EventHandler(this.maximizarToolStripMenuItem_Click);
            // 
            // minimizarToolStripMenuItem
            // 
            this.minimizarToolStripMenuItem.Name = "minimizarToolStripMenuItem";
            this.minimizarToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.minimizarToolStripMenuItem.Text = "Minimizar";
            this.minimizarToolStripMenuItem.Click += new System.EventHandler(this.minimizarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ilPrestamos
            // 
            this.ilPrestamos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPrestamos.ImageStream")));
            this.ilPrestamos.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPrestamos.Images.SetKeyName(0, "libroDevuelto.png");
            this.ilPrestamos.Images.SetKeyName(1, "libroPrestado.png");
            // 
            // lblPrestamos
            // 
            this.lblPrestamos.AutoSize = true;
            this.lblPrestamos.Location = new System.Drawing.Point(44, 94);
            this.lblPrestamos.Name = "lblPrestamos";
            this.lblPrestamos.Size = new System.Drawing.Size(72, 15);
            this.lblPrestamos.TabIndex = 27;
            this.lblPrestamos.Text = " Préstamos";
            // 
            // lblDevol
            // 
            this.lblDevol.AutoSize = true;
            this.lblDevol.Location = new System.Drawing.Point(695, 94);
            this.lblDevol.Name = "lblDevol";
            this.lblDevol.Size = new System.Drawing.Size(88, 15);
            this.lblDevol.TabIndex = 28;
            this.lblDevol.Text = "Devoluciones";
            // 
            // FrmBiblio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 577);
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
            this.gbAux.ResumeLayout(false);
            this.gbAux.PerformLayout();
            this.gbAtribs.ResumeLayout(false);
            this.gbAtribs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbModo)).EndInit();
            this.tpBorrado.ResumeLayout(false);
            this.tpBorrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb2Modo)).EndInit();
            this.tpModificado.ResumeLayout(false);
            this.tpModificado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb3Modo)).EndInit();
            this.tpBuscar.ResumeLayout(false);
            this.tpBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb4Modo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripIconosIniciales;
        private System.Windows.Forms.ToolStripButton tsbLibros;
        private System.Windows.Forms.ToolStripButton tsbUsuarios;
        private System.Windows.Forms.ToolStripButton tsbTransacciones;
        private System.Windows.Forms.TabControl tcOpciones;
        private System.Windows.Forms.TabPage tpAñadir;
        private System.Windows.Forms.TabPage tpBorrado;
        private System.Windows.Forms.TabPage tpModificado;
        private System.Windows.Forms.TabPage tpBuscar;
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
        private System.Windows.Forms.ListView lvBusqueda;
        private System.Windows.Forms.GroupBox gbAtribs;
        private System.Windows.Forms.RadioButton rbOpcion3;
        private System.Windows.Forms.RadioButton rbOpcion2;
        private System.Windows.Forms.RadioButton rbOpcion1;
        private System.Windows.Forms.GroupBox gbAux;
        private System.Windows.Forms.TextBox tbxAtrib3;
        private System.Windows.Forms.TextBox tbxAtrib2;
        private System.Windows.Forms.TextBox tbxAtrib1;
        private System.Windows.Forms.Label lblAtrib3;
        private System.Windows.Forms.Label lblAtrib2;
        private System.Windows.Forms.Label lblAtrib1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txbBuscar;
        private System.Windows.Forms.ComboBox cbFiltrarPor;
        private System.Windows.Forms.Label lblFiltrarPor;
        private System.Windows.Forms.MaskedTextBox mtbFechaBusquedaPrestamo;
        private System.Windows.Forms.Label lblModificar;
        private System.Windows.Forms.ListView lvModificar;
        private System.Windows.Forms.Label lblBorrar;
        private System.Windows.Forms.ListView lvBorrar;
        private System.Windows.Forms.Label lblFechaBorrarPrestamo;
        private System.Windows.Forms.MaskedTextBox mtbFechaBorrarPrestamo;
        private System.Windows.Forms.Label lblFechaModificarPrestamo;
        private System.Windows.Forms.MaskedTextBox mtbFechaModificarPrestamo;
        private System.Windows.Forms.ImageList ilProfesoresAlumnosPAS;
        private System.Windows.Forms.ImageList ilPrestamos;
        private System.Windows.Forms.MaskedTextBox mtbFechaAniadirPrestamo;
        private System.Windows.Forms.ComboBox cbLibroPresDev;
        private System.Windows.Forms.ComboBox cbUsuariosAnadirPrestamos;
        private System.Windows.Forms.Label lblInfoBuscar;
        private System.Windows.Forms.ListView lvDevoluciones;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvPrestamos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader idLibr;
        private System.Windows.Forms.ColumnHeader fechamax;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblDevol;
        private System.Windows.Forms.Label lblPrestamos;
    }
}

