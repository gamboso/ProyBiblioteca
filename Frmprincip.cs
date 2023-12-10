using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


/*ACUERDATE DE GUARDAR EN GITHUB ANTES DE SALIR*/


namespace ProyBiblioteca
{
    public partial class FrmBiblio : Form
    {
        public FrmBiblio()
        {
            InitializeComponent();
        }
        List<Libro> LibrosEnStock = new List<Libro>();
        List<Libro> LibrosPrestados = new List<Libro>();
        List<Persona> misUsuarios = new List<Persona>();
        List<Libro> misLibros = new List<Libro>();
        List<Transaccion> misTransacciones = new List<Transaccion>();

        //String auxiliar que toma el texto del toolStripMenuItem seleccionado
        string interfSeleccionada = "Libros";
        private void FrmPrincip_Load(object sender, EventArgs e)
        {
            // Cambiar el directorio actual al del fichero
            Directory.SetCurrentDirectory("..\\..\\ficheros");
            // Debe ir antes de todo para que los métodos tengan el directorio correcto

            cargarUsuarios();
            cargarTransacciones();
            cargarLibros();
            Directory.SetCurrentDirectory("..");
            cargarInterfazLibros();
            ActualizaListaDeLibrosEnStockYLibrosPrestados();
            

        }

        private void ActualizaListaDeLibrosEnStockYLibrosPrestados()
        {

            LibrosPrestados.Clear();
            LibrosEnStock.Clear();

            foreach (Libro l in misLibros)
            {
                bool estaPrestado = false;
                foreach (Transaccion t in misTransacciones)
                {
                    estaPrestado = t.IdLibro.Equals(l.IdLibro);
                    if (estaPrestado)
                        break;
                }

                if (estaPrestado)
                {
                    LibrosPrestados.Add(l);
                    Console.WriteLine("Libro Prestado: " + l.Titulo);
                }
                else
                {
                    LibrosEnStock.Add(l);
                    Console.WriteLine("Libro en Stock: " + l.Titulo);
                }
            }
        }

        private void FrmPrincip_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar la biblioteca?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario selecciona "No", cancela el cierre del formulario
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Esto evita que se cierre el formulario
            }

        }

        private void cargarUsuarios()
        {
            try
            {
                Console.WriteLine("====== Usuarios ======");

                // Leer el fichero usuarios.txt
                string[] usuarios = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\usuarios.txt");

                string tipoUsuario = "";
                string nombre = "";
                string departamento = "";

                foreach (string s in usuarios)
                {
                    DateTime fechaSancion = DateTime.Parse("1/01/1000"); // Move the declaration here

                    // Split en base a comas.
                    string[] infoUsuario = s.Split(',');

                    tipoUsuario = infoUsuario[0].Substring(0, infoUsuario[0].IndexOf(" ")).Trim();
                    nombre = infoUsuario[0].Substring(infoUsuario[0].IndexOf(" ") + 1).Trim();

                    if (infoUsuario.Length > 1)
                    {
                        departamento = infoUsuario[1].Trim();
                    }

                    if (infoUsuario.Length > 2 && infoUsuario[2].Contains("#"))
                    {
                        // Sacar solo la parte de la fechaTransaccion
                        string fechaPart = infoUsuario[2].Substring(infoUsuario[2].IndexOf("#") + 1, infoUsuario[2].LastIndexOf("#") - infoUsuario[2].IndexOf("#") - 1);

                        // Convertir la fechaTransaccion sin la hora
                        if (DateTime.TryParseExact(fechaPart, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaSancion))
                        {
                            fechaSancion = DateTime.Parse(fechaSancion.ToShortDateString());
                        }
                    }

                    Persona usuario = null;
                    if (fechaSancion.Equals(DateTime.Parse("1/01/1000")))
                    {
                        if (tipoUsuario.Equals("alumno"))
                        {
                            usuario = new Alumno(nombre, departamento);
                        }
                        else if (tipoUsuario.Equals("pas"))
                        {
                            usuario = new PAS(nombre, departamento);
                        }
                        else if (tipoUsuario.Equals("profesor"))
                        {
                            usuario = new Profesor(nombre, departamento);
                        }
                        // se usa el constructor sin sancion si no tiene fechaTransaccion (la fechaTransaccion inicializada es 1/01/1000)
                    }
                    else
                    {
                        if (tipoUsuario.Equals("alumno"))
                        {
                            usuario = new Alumno(nombre, departamento, fechaSancion);
                        }
                        else if (tipoUsuario.Equals("pas"))
                        {
                            usuario = new PAS(nombre, departamento, fechaSancion);
                        }
                        else if (tipoUsuario.Equals("profesor"))
                        {
                            usuario = new Profesor(nombre, departamento, fechaSancion);
                        }
                    }

                    // Se añade el usuario a la lista
                    misUsuarios.Add(usuario);
                }

                // Recorrer la lista e imprimir todos los usuarios para confirmar que se realizó correctamente
                foreach (Persona us in misUsuarios)
                {
                    /*Al parecer en C# la fechaTransaccion por defecto la fechaTransaccion es "1/1/0001 12:00:00 am" cuando no esta definida, por lo que sí haces un usuario.FechaSancion
                     sale con eso, y al parecer DateTime siempre tiene hora, y no encontré otra clase de SOLO fechaTransaccion, pero se puede ignorar.
                     */

                    if (!us.FechaSancion.Equals(DateTime.Parse("1/1/0001")))
                    {
                        Console.WriteLine("| Nombre : " + us.Nombre + "| Departamento : " + us.Departamento + "| Fecha sancion : " + us.FechaSancion.ToString("d/M/yyyy"));
                    }
                    else
                    {
                        Console.WriteLine("| Nombre : " + us.Nombre + "| Departamento : " + us.Departamento);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void cargarTransacciones()
        {

            DateTime fecha = DateTime.Parse("1/01/1000");

            string nombreUsuario = "";
            string idLibroPrestado = "";
            string tipoTransaccion = "";
            DateTime fechaMaxDevolucion = DateTime.Parse("1/01/1000");
            DateTime fechaTransaccion = DateTime.Parse("1/01/1000");

            try
            {
                Console.WriteLine("====== Transacciones ======");


                //Leer el fichero transacciones.txt
                string[] transacciones = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\transacciones.txt");
                foreach (string s in transacciones)
                {
                    int indicePrimerEspacio = s.IndexOf(' ');
                    int ultimaComa = s.LastIndexOf(',');
                    int ultimoHashtag = s.LastIndexOf('#');


                    if (s.Contains("fecha")) // Esto es el "fecha" literal del archivo se refiere a la fecha de la transacción 
                    {
                        string[] split = s.Substring(indicePrimerEspacio).Split(',');
                        fechaTransaccion = DateTime.Parse(split[0].Trim() + "," + split[1].Trim() + "," + split[2].Trim());
                    }
                    else if (!s.Contains("devolucion") && (indicePrimerEspacio != -1))
                    {
                        // Desde la posición inicial hasta el primer espacio.
                        tipoTransaccion = s.Substring(0, indicePrimerEspacio);

                        // Desde el primer espacio hasta la primera coma.
                        nombreUsuario = s.Substring(indicePrimerEspacio + 1, s.IndexOf(',') - indicePrimerEspacio - 1);

                        // Desde la primera coma hasta la ultima.
                        idLibroPrestado = s.Substring(s.IndexOf(',') + 1, ultimaComa - s.IndexOf(',') - 1);

                        // Fecha 
                        fechaMaxDevolucion = DateTime.Parse(s.Substring(s.IndexOf('#') + 1, ultimoHashtag - s.IndexOf('#') - 1));
                        /*
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"Tipo de transacción: {tipoTransaccion}");
                        Console.WriteLine($"Nombre de usuario: {nombreUsuario}");
                        Console.WriteLine($"ID de libro prestado: {idLibroPrestado}");
                        Console.WriteLine($"Fecha de máxima de devolución: {fechaMaxDevolucion.ToString("d/M/yyyy")}");
                        Console.WriteLine($"Fecha transacción: {fechaTransaccion.ToString("d/M/yyyy")}");
                        */
                        Transaccion ts = new Prestamo(nombreUsuario, idLibroPrestado, fechaMaxDevolucion, fechaTransaccion); ;

                        misTransacciones.Add(ts);
                    }
                    else if (s.Contains("devolucion"))
                    {

                        string[] split = s.Split(' ');

                        tipoTransaccion = split[0];
                        idLibroPrestado = split[1];
                        /*
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"Tipo de transacción: {tipoTransaccion}");
                        Console.WriteLine($"Id libro devuelto: {idLibroPrestado}");
                        */
                        Transaccion ts = new Devolucion(idLibroPrestado, fechaTransaccion);
                        misTransacciones.Add(ts);
                    }
                }

                //Imprimir todas las transacciones en MisTransacciones

                foreach (Transaccion ts in misTransacciones)
                {
                    if (ts.GetType().Name.Equals("Prestamo"))
                    {
                        Prestamo ps = (Prestamo)ts;
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"Tipo de transacción: Prestamo");
                        Console.WriteLine($"Nombre de usuario: {ps.NombreUsuario}");
                        Console.WriteLine($"ID de libro prestado: {ps.IdLibro}");
                        Console.WriteLine($"Fecha de máxima de devolución: {ps.FechaMaxDevolucion.ToString("d/M/yyyy")}");
                        Console.WriteLine($"Fecha transacción: {ps.FechaTransaccion.ToString("d/M/yyyy")}");
                    }
                    else if (ts.GetType().Name.Equals("Devolucion"))
                    {
                        Devolucion dv = (Devolucion)ts;

                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"Tipo de transacción: Devolución");
                        Console.WriteLine($"Id libro devuelto: {dv.IdLibro}");
                        Console.WriteLine($"Fecha de transacción: {dv.FechaTransaccion.ToString("d/M/yyyy")}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        private void cargarLibros()
        {
            try
            {
                Console.WriteLine("====== Libros ======");

                // Leer el fichero libros.txt
                string[] libros = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\libros.txt");

                foreach (string s in libros)
                {
                    string ubicacion = "";
                    string titulo = "";
                    String idLibro = "";

                    // Encontrar la posición del primer espacio
                    int indicePrimerEspacio = s.IndexOf(' ');

                    // Verificar si se encontró un espacio
                    if (indicePrimerEspacio != -1)
                    {
                        ubicacion = s.Substring(0, indicePrimerEspacio);

                        // Encontrar la posición de la coma después del primer espacio
                        int indiceComa = s.IndexOf(',', indicePrimerEspacio);

                        // Verificar si se encontró una coma
                        if (indiceComa != -1)
                        {
                            // Obtener el título desde el espacio hasta la coma
                            titulo = s.Substring(indicePrimerEspacio + 1, indiceComa - indicePrimerEspacio - 1);

                            // Obtener el idLibro después de la coma
                            idLibro = s.Substring(indiceComa + 1);
                        }
                    }

                    // Crear instancia de Libro
                    Libro libro = new Libro(ubicacion, titulo, idLibro);

                    // Añadir el libro a la lista
                    misLibros.Add(libro);
                }

                // Imprimir la información de los libros para confirmar que se cargaron correctamente
                foreach (Libro libro in misLibros)
                {
                    Console.WriteLine($"Ubicacion: {libro.Ubicacion} | Titulo: {libro.Titulo} | ID: {libro.IdLibro}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void tsbLibros_Click(object sender, EventArgs e)
        {
            interfSeleccionada = tsbLibros.Text;
            cargarInterfazLibros();
        }

        private void tsbUsuarios_Click(object sender, EventArgs e)
        {
            interfSeleccionada = tsbUsuarios.Text;
            cargarInterfazPersonas();
        }

        private void tsbPrestamos_Click(object sender, EventArgs e)
        {
            interfSeleccionada = tsbPrestamos.Text;
            cargarInterfazPrestamos();
        }

        private void cargarInterfazLibros()
        {
            cargarImagen("libro");
            cambioDeInterfaz("Libro");
            tpAñadir.BackColor = Color.LightPink;
            tpBorrado.BackColor = Color.LightPink;
            tpBuscar.BackColor = Color.LightPink;
            tpModificado.BackColor = Color.LightPink;

        }

        private void cargarInterfazPersonas()
        {
            cargarImagen("perfil");
            cambioDeInterfaz("Persona");
            tpAñadir.BackColor = Color.LightSkyBlue;
            tpBorrado.BackColor = Color.LightSkyBlue;
            tpBuscar.BackColor = Color.LightSkyBlue;
            tpModificado.BackColor = Color.LightSkyBlue;

        }

        private void cargarInterfazPrestamos()
        {
            cargarImagen("Prestamo");
            cambioDeInterfaz("Transaccion");
            tpAñadir.BackColor = Color.LightYellow;
            tpBorrado.BackColor = Color.LightYellow;
            tpBuscar.BackColor = Color.LightYellow;
            tpModificado.BackColor = Color.LightYellow;
        }

        //Método que carga las imagenes en los picture box
        private void cargarImagen(String imagen)
        {
            pcbModo.Image = System.Drawing.Image.FromFile(".\\Icons\\" + imagen + ".png");
            pcb2Modo.Image = System.Drawing.Image.FromFile(".\\Icons\\" + imagen + ".png");
            pcb3Modo.Image = System.Drawing.Image.FromFile(".\\Icons\\" + imagen + ".png");
            pcb4Modo.Image = System.Drawing.Image.FromFile(".\\Icons\\" + imagen + ".png");
        }



        //Método que cambia los cuatro tipos de interfaces en función del objeto a añadir (Libros, Personas o Transacciones)
        private void cambioDeInterfaz(String tipo)
        {
            gbAtribs.Show();
            rbOpcion1.Checked = true;
            switch (tipo)
            {
                case "Libro":
                    cambiarListView("Libro");
                    CambiarlvBorrar("Libro");
                    tpAñadir.Text = "Añadir";
                    tpBorrado.Text = "Borrar";
                    tpModificado.Text = "Modificar";
                    tpBuscar.Text = "Buscar";

                    gbAtribs.Text = "Ubicación del libro ";
                    rbOpcion1.Text = "Sala";
                    rbOpcion2.Text = "Almacén";
                    rbOpcion3.Hide();
                    tbxAtrib1.Show();
                    tbxAtrib2.Show();

                    lblAtrib1.Text = "Título Libro";
                    lblAtrib1.Show();
                    tbxAtrib1.Show();
                    lblAtrib2.Text = "ID Libro";
                    lblAtrib3.Hide();
                    tbxAtrib3.Hide();
                    lvDevoluciones.Hide();
                    lvPrestamos.Hide();
                    lvBusqueda.Show();
                    lblDevoluciones.Hide();
                    lblFiltrarPor.Hide();
                    lblPrestamo.Hide();
                    cbFiltrarPor.Hide();
                    mtbFechaBusquedaPrestamo.Hide();
                    txbBuscar.Show();
                    lblFechaModificarPrestamo.Hide();
                    mtbFechaBorrarPrestamo.Hide();
                    mtbFechaModificarPrestamo.Hide();
                    lblFechaBorrarPrestamo.Hide();
                    cbLibrosaniadirPrestamoODevolucion.Hide();
                    mtbFechaAniadirPrestamo.Hide();
                    cbUsuariosAnadirPrestamos.Hide();
                    lblInfoBuscar.Show();
                    break;

                case "Persona":
                    cambiarListView("Persona");
                    CambiarlvBorrar("Persona");
                    tpAñadir.Text = "Añadir";
                    tpBorrado.Text = "Borrar";
                    tpModificado.Text = "Modificar";
                    tpBuscar.Text = "Buscar";

                    //GroupBox de RadioButtons
                    gbAtribs.Text = "Tipo de usuario ";
                    rbOpcion1.Text = "Alumno";
                    rbOpcion2.Text = "Profesor";
                    rbOpcion3.Show();
                    tbxAtrib2.Show();
                    tbxAtrib1.Show();
                    rbOpcion3.Text = "PAS";

                    //GroupBox de Labels y TextBox
                    lblAtrib1.Text = "Nombre";
                    lblAtrib1.Show();
                    tbxAtrib1.Show();
                    lblAtrib2.Text = "Departamento";
                    lblAtrib3.Show();
                    lblAtrib3.Text = "Fecha sanción";
                    tbxAtrib3.Show();
                    lvDevoluciones.Hide();
                    lvPrestamos.Hide();
                    lvBusqueda.Show();
                    lblDevoluciones.Hide();
                    lblFiltrarPor.Hide();
                    lblPrestamo.Hide();
                    cbFiltrarPor.Hide();
                    mtbFechaBusquedaPrestamo.Hide();
                    txbBuscar.Show();
                    lblFechaModificarPrestamo.Hide();
                    mtbFechaBorrarPrestamo.Hide();
                    mtbFechaModificarPrestamo.Hide();
                    lblFechaBorrarPrestamo.Hide();
                    cbLibrosaniadirPrestamoODevolucion.Hide();
                    mtbFechaAniadirPrestamo.Hide();
                    cbUsuariosAnadirPrestamos.Hide();
                    lblInfoBuscar.Show();
                    break;

                case "Transaccion":
                    cambiarListView("Transaccion");
                    CambiarlvBorrar("Transaccion");
                    tpAñadir.Text = "Prestar y Devolver";
                    tpBorrado.Text = "Borrar";
                    tpModificado.Text = "Modificar";
                    tpBuscar.Text = "Buscar";


                    gbAtribs.Text = "Tipo ";
                    rbOpcion1.Text = "Devolución";
                    rbOpcion2.Text = "Préstamo";
                    rbOpcion3.Hide();



                    lblAtrib1.Text = "Nombre usuario";
                    lblAtrib1.Hide();
                    tbxAtrib1.Hide();
                    cbUsuariosAnadirPrestamos.Hide();

                    lblAtrib2.Text = "ID Libro";
                    lblAtrib3.Show();
                    lblAtrib3.Text = "Fecha devolución";
                    tbxAtrib3.Hide();
                    tbxAtrib2.Hide();
                    tbxAtrib1.Hide();

                    txbBuscar.Hide();
                    mtbFechaBusquedaPrestamo.Hide();
                    lvDevoluciones.Show();
                    lvPrestamos.Show();
                    lvBusqueda.Hide();
                    lblDevoluciones.Show();
                    lblFiltrarPor.Show();
                    lblPrestamo.Show();
                    cbFiltrarPor.Show();
                    lblFechaModificarPrestamo.Show();
                    mtbFechaBusquedaPrestamo.Show();
                    mtbFechaBorrarPrestamo.Show();
                    mtbFechaModificarPrestamo.Show();
                    lblFechaBorrarPrestamo.Show();
                    cbLibrosaniadirPrestamoODevolucion.Show();
                    mtbFechaAniadirPrestamo.Show();
                    lblInfoBuscar.Hide();

                    break;

                default:
                    break;

            }

        }

        private void CambiarlvBorrar(String tipoLV)
        {
            
            lvBorrar.Clear();
            if (tipoLV.Equals("Libro"))
            {
                foreach (Libro l in misLibros)
                {
                    lvBorrar.SmallImageList = ilProfesoresAlumnosPAS;
                    ListViewItem item = new ListViewItem(l.Titulo, 3);


                    lvBorrar.Items.Add(item);

                }

            }
            else if (tipoLV.Equals("Transaccion"))
            {
                foreach (Transaccion t in misTransacciones)
                {
                    lvBorrar.SmallImageList = ilPrestamos;
                    string clase = t.GetType().ToString();
                    // Encuentra la última posición del punto
                    int lastIndex = clase.LastIndexOf('.');

                    // Obtiene la parte después del último punto
                    string resultadoclase = lastIndex != -1 ? clase.Substring(lastIndex + 1) : clase;
                    Console.WriteLine(resultadoclase);

                    if (resultadoclase.Equals("Prestamo"))
                    {
                        ListViewItem item = new ListViewItem(resultadoclase + ": " +t.ToString(), 1);
                        lvBorrar.Items.Add(item);
                    }
                    else if (resultadoclase.Equals("Devolucion"))
                    {

                        ListViewItem item = new ListViewItem(resultadoclase + ": " + t.ToString(), 0);
                        lvBorrar.Items.Add(item);

                    }
                    

                }

            }
            else if (tipoLV.Equals("Persona"))
            {
                foreach (Persona p in misUsuarios)
                {
                    lvBorrar.SmallImageList = ilProfesoresAlumnosPAS;
                    
                    string clase = p.GetType().ToString();
                    // Encuentra la última posición del punto
                    int lastIndex = clase.LastIndexOf('.');

                    // Obtiene la parte después del último punto
                    string resultadoclase = lastIndex != -1 ? clase.Substring(lastIndex + 1) : clase;
                    Console.WriteLine(resultadoclase);
                    if (resultadoclase.Equals("PAS"))
                    {
                        ListViewItem item = new ListViewItem(p.Nombre, 1);
                        lvBorrar.Items.Add(item);
                    } 
                    else if (resultadoclase.Equals("Alumno"))
                    {

                        ListViewItem item = new ListViewItem(p.Nombre, 2);
                        lvBorrar.Items.Add(item);

                    }
                    else if (resultadoclase.Equals("Profesor"))
                    {

                        ListViewItem item = new ListViewItem(p.Nombre, 0);
                        lvBorrar.Items.Add(item);

                    }


                }
            }
            
            
        }

        //Método que cambia la Interfaz de Búsqueda en función del objeto a buscar (Libros, Personas o Transacciones)
        private void cambiarListView(String tipoLV)
        {
            lvBusqueda.Columns.Clear();
            lvBusqueda.Items.Clear();

            if (tipoLV.Equals("Libro"))
            {
                ColumnHeader chID = new ColumnHeader();
                chID.Width = 200;
                chID.Text = "ID";

                ColumnHeader chTitulo = new ColumnHeader();
                chTitulo.Width = 200;
                chTitulo.Text = "Título";

                ColumnHeader chUbi = new ColumnHeader();
                chUbi.Width = 200;
                chUbi.Text = "Ubicación";

                lvBusqueda.Columns.Add(chTitulo);
                lvBusqueda.Columns.Add(chID);
                lvBusqueda.Columns.Add(chUbi);

            }
            else if (tipoLV.Equals("Transaccion"))
            {
                ColumnHeader chIDLibro = new ColumnHeader();
                chIDLibro.Width = 150;
                chIDLibro.Text = "ID Libro";

                ColumnHeader chNombreUsuario = new ColumnHeader();
                chNombreUsuario.Width = 150;
                chNombreUsuario.Text = "Nombre Usuario";

                ColumnHeader chTipoTransaccion = new ColumnHeader();
                chTipoTransaccion.Width = 150;
                chTipoTransaccion.Text = "Transacción";

                ColumnHeader chFechaDev = new ColumnHeader();
                chFechaDev.Width = 150;
                chFechaDev.Text = "Fecha devolución";

                lvBusqueda.Columns.Add(chIDLibro);
                lvBusqueda.Columns.Add(chNombreUsuario);
                lvBusqueda.Columns.Add(chTipoTransaccion);
                lvBusqueda.Columns.Add(chFechaDev);

            }
            else if (tipoLV.Equals("Persona"))
            {
                ColumnHeader chNombre = new ColumnHeader();
                chNombre.Width = 150;
                chNombre.Text = "Nombre";

                ColumnHeader chDept = new ColumnHeader();
                chDept.Width = 150;
                chDept.Text = "Departamento";

                ColumnHeader chTipoUsuario = new ColumnHeader();
                chTipoUsuario.Width = 150;
                chTipoUsuario.Text = "Tipo usuario";

                ColumnHeader chFechaSancion = new ColumnHeader();
                chFechaSancion.Width = 150;
                chFechaSancion.Text = "Fecha sanción";

                lvBusqueda.Columns.Add(chNombre);
                lvBusqueda.Columns.Add(chDept);
                lvBusqueda.Columns.Add(chTipoUsuario);
                lvBusqueda.Columns.Add(chFechaSancion);
            }
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Recorre todas las pestañas del TabControl
            foreach (TabPage tabPage in tcOpciones.TabPages)
            {
                LimpiarControles(tabPage.Controls);
            }
        }

        private void LimpiarControles(Control.ControlCollection controls)
        {
            // Recorre todos los controles
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is MaskedTextBox)
                {
                    ((MaskedTextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                else if (control.HasChildren)
                {
                    // Recursivo para los controles secundarios
                    LimpiarControles(control.Controls);
                }
            }
        }

        private void cbFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFiltrarPor.Text.Equals("Fecha"))
            {
                txbBuscar.Hide();
                mtbFechaBusquedaPrestamo.Show();

            }
            else
            {
                txbBuscar.Show();
                mtbFechaBusquedaPrestamo.Hide();
            }
        }

        private void cambioCheckRadioButton(object sender, EventArgs e)
        {
            //Solo hace el evento si está en la interfaz de Transacciones
            if (rbOpcion1.Checked)
            {
                if (rbOpcion1.Text.Equals("Devolución"))
                {
                    ActualizaListaDeLibrosEnStockYLibrosPrestados();
                    cbLibrosaniadirPrestamoODevolucion.Items.Clear();
                    foreach (Libro l in LibrosPrestados)
                    {
                        cbLibrosaniadirPrestamoODevolucion.Items.Add(l.Titulo);
                    }
                    lblAtrib3.Text = "Fecha Devolucion:";
                    lblAtrib1.Hide();
                    tbxAtrib1.Hide();
                    cbUsuariosAnadirPrestamos.Hide();
                }
            }
            else if (rbOpcion2.Checked)
            {
                if (rbOpcion2.Text.Equals("Préstamo"))
                {
                    ActualizaListaDeLibrosEnStockYLibrosPrestados();
                    cbUsuariosAnadirPrestamos.Items.Clear();
                    cbLibrosaniadirPrestamoODevolucion.Items.Clear();

                    foreach (Persona p in misUsuarios)
                    {
                        cbUsuariosAnadirPrestamos.Items.Add(p.Nombre);
                    }
                    foreach (Libro l in LibrosEnStock)
                    {
                        cbLibrosaniadirPrestamoODevolucion.Items.Add(l.Titulo);
                    }
                    lblAtrib3.Text = "Fecha Prestamo:";
                    lblAtrib1.Show();
                    tbxAtrib1.Hide();
                    cbUsuariosAnadirPrestamos.Show();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (interfSeleccionada)
            {
                case "Libros":
                    // SI ALGUNA CADENA ESTA VACIA NO GUARDA NADA
                    if (tbxAtrib1.Text.Equals("") || tbxAtrib2.Text.Equals(""))
                    {
                        MessageBox.Show("No puedes dejar campos vacios");
                    }
                    else
                    {
                        String titulo = tbxAtrib1.Text;
                        String idLibro = tbxAtrib2.Text;
                        String ubicacion = "";
                        if (rbOpcion1.Checked)

                        {
                            ubicacion = rbOpcion1.Text;
                        }
                        else
                            ubicacion = rbOpcion2.Text;

                        Libro l = new Libro(ubicacion, titulo, idLibro);
                        misLibros.Add(l);

                        MessageBox.Show("El libro se ha añadido correctamente");
                    }
                    break;

                case "Usuarios":
                    // SI ALGUNA CADENA ESTA VACIA NO GUARDA NADA
                    if (tbxAtrib1.Text.Equals("") || tbxAtrib2.Text.Equals("") || tbxAtrib3.Text.Equals(""))
                    {
                        MessageBox.Show("No puedes dejar campos vacios");
                    }
                    else
                    {
                        String nombre = tbxAtrib1.Text;
                        String depto = tbxAtrib2.Text;
                        DateTime fechaSancion = DateTime.Parse("1/01/1000");
                        // Convertir la fechaTransaccion sin la hora
                        if (!tbxAtrib3.Text.Equals(""))
                        {
                            if (DateTime.TryParseExact(tbxAtrib3.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaSancion))
                            {
                                Persona p = null;
                                fechaSancion = DateTime.Parse(fechaSancion.ToShortDateString());
                                if (rbOpcion1.Checked)
                                {
                                    p = new Alumno(nombre, depto, fechaSancion);
                                }
                                else if (rbOpcion2.Checked)
                                {
                                    p = new Profesor(nombre, depto, fechaSancion);
                                }
                                else if (rbOpcion3.Checked)
                                {
                                    p = new PAS(nombre, depto, fechaSancion);
                                }
                                misUsuarios.Add(p);
                            }
                            else
                            {
                                MessageBox.Show("El formato de la fecha es inválido");
                            }
                        }
                        else
                        {
                            Persona p = null;
                            if (rbOpcion1.Checked)
                            {
                                p = new Alumno(nombre, depto);
                            }
                            else if (rbOpcion2.Checked)
                            {
                                p = new Profesor(nombre, depto);
                            }
                            else if (rbOpcion3.Checked)
                            {
                                p = new PAS(nombre, depto);
                            }
                            misUsuarios.Add(p);
                        }
                        MessageBox.Show("El usuario se ha añadido correctamente");
                    }
                    break;

                case "Transacciones":
                    String tituloLib = cbLibrosaniadirPrestamoODevolucion.SelectedItem.ToString();

                    // Siempre es la transaccion la fecha actual

                    DateTime fechaTransaccion = DateTime.Now;

                    Transaccion transaccion = null;

                    if (rbOpcion1.Checked) //DEVOLUCION
                    {
                        if (cbLibrosaniadirPrestamoODevolucion.Text.Equals("") ||
                            mtbFechaAniadirPrestamo.MaskCompleted == false)
                        {
                            MessageBox.Show("No puedes dejar campos vacíos");
                        }
                        else
                        {
                            // AÑADIR LA TRANSACCIÓN DE DEVOLUCIÓN

                            Libro libro = null;


                            int position = 0;
                            foreach (Libro lib in LibrosPrestados)
                            {

                                if (tituloLib.Equals(lib.Titulo))

                                {

                                    libro = lib;

                                    break;
                                }
                                position++;
                            }

                            string libroId = libro.IdLibro;

                            //añadir devolucion
                            transaccion = new Devolucion(libroId, fechaTransaccion);
                            //a
                            if (LibrosPrestados.Count > 0 && position < LibrosPrestados.Count)
                            {
                                LibrosEnStock.RemoveAt(position);
                            }
                            LibrosPrestados.Add(libro);

                            MessageBox.Show("Se aniadio corerctamente!");
                        }
                    }
                    else  // PRESTAMO
                    {

                        if (cbUsuariosAnadirPrestamos.Text.Equals("") ||
                            cbLibrosaniadirPrestamoODevolucion.Text.Equals("") ||
                            mtbFechaAniadirPrestamo.MaskCompleted == false)
                        {
                            MessageBox.Show("No puedes dejar campos vacíos");
                        }
                        else
                        {

                            String nombreUsuario = cbUsuariosAnadirPrestamos.SelectedItem.ToString();

                            Persona persona = null;
                            Libro libro = null;
                            DateTime fechaMaxDevolucion = DateTime.MaxValue;

                            int position = 0 ;
                            foreach (Libro lib in LibrosEnStock)
                            {
                             
                                if (tituloLib.Equals(lib.Titulo))

                                {
                                                                 
                                    libro = lib;
                                    
                                    break;
                                }
                                position++;
                            }
                            if (LibrosPrestados.Count > 0 && position < LibrosPrestados.Count)
                            {
                                LibrosPrestados.RemoveAt(position);
                            }
                            LibrosEnStock.Add(libro);

                            foreach (Persona p in misUsuarios)
                            {
                                if (p.Nombre.Equals(nombreUsuario))
                                {
                                    persona = p;

                                    switch (persona)
                                    {
                                        case Alumno alumno:
                                            // Acciones específicas para Alumno
                                            MessageBox.Show($"Es un Alumno: {alumno.GetType().Name}");
                                            fechaMaxDevolucion = alumno.calcularFechaDevolucion(libro);
                                            // Otras acciones específicas para Alumno
                                            break;

                                        case Profesor profesor:
                                            // Acciones específicas para Profesor
                                            MessageBox.Show($"Es un Profesor: {profesor.GetType().Name}");
                                            fechaMaxDevolucion = profesor.calcularFechaDevolucion(libro);
                                            // Otras acciones específicas para Profesor
                                            break;

                                        case PAS pas:
                                            // Acciones específicas para PAS
                                            MessageBox.Show($"Es un PAS: {pas.GetType().Name}");
                                            fechaMaxDevolucion = pas.calcularFechaDevolucion(libro);
                                            // Otras acciones específicas para PAS
                                            break;

                                        default:
                                            // Acciones por defecto o para otros tipos de Persona
                                            MessageBox.Show($"Es otro tipo de Persona: {p.GetType().Name}");
                                            // Otras acciones por defecto
                                            break;
                                    }
                                }
                            }

                            // Verificar si el usuario no se encontró en la lista
                            if (persona == null)
                            {
                                MessageBox.Show("No se encontró el usuario.");
                            }



                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine($"Tipo de transacción: Prestamo");
                            Console.WriteLine($"Nombre de usuario: {nombreUsuario}");
                            Console.WriteLine($"ID de libro prestado: {libro.IdLibro} Título: {libro.Titulo} ");
                            Console.WriteLine($"Fecha de máxima de devolución: {fechaMaxDevolucion.ToString("d/M/yyyy")}");
                            Console.WriteLine($"Fecha transacción: {fechaTransaccion.ToString("d/M/yyyy")}");

                            string libroId = libro.IdLibro;
                            transaccion = new Prestamo(nombreUsuario, libroId, fechaMaxDevolucion, fechaTransaccion);

                            Prestamo pres = (Prestamo)transaccion;

                            //Añadir la transacción
                            misTransacciones.Add(transaccion);
                            LibrosEnStock.RemoveAt(position);
                            LibrosPrestados.Add(libro);

                            transaccion.ToString();
                            MessageBox.Show("La transacción se ha añadido correctamente");
                        }
                    }
                    //Escribir de las transacciones de hoy si hace falta
                    escribirFecha();
                    // Escribir la transacción en el fichero
                    escribirTransaccion(transaccion);

                    break;


                default:
                    break;
            }
        }

        //Método que controla que no se pueda escribir en un combo box 
       /* private void evitarEscrituraEnComboBox(object sender, EventArgs e)
        {
            cbUsuariosAnadirPrestamos.ResetText();
        }*/

        private void escribirFecha()
        {
            //Leer el fichero transacciones.txt
            DateTime diaHoy = DateTime.Now;
            string fechaHoy = diaHoy.ToString("d, M, yyyy"); ;
            string linea = "fecha " + fechaHoy;
            string ultimaLinea = "";
            string[] transacciones = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\ficheros\\transacciones.txt");
            foreach (string s in transacciones)
            {
                int indicePrimerEspacio = s.IndexOf(' ');
                int ultimaComa = s.LastIndexOf(',');
                int ultimoHashtag = s.LastIndexOf('#');


                if (s.Equals(linea)) // Esto es el "fecha" literal del archivo se refiere a la fecha de la transacción 
                {
                    ultimaLinea = s;
                    break;
                }
            }

            if (!ultimaLinea.Equals(linea))
            {
                //Añadir al fichero de transacciones la fecha actual
                StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\ficheros\\transacciones.txt");

                sw.WriteLine(linea);
                sw.Flush();
                sw.Close();
            }
        }


        private void escribirTransaccion(Transaccion t)
        {
            if (t is Prestamo)
            {
                Prestamo p = (Prestamo)t;

                string usuario = p.NombreUsuario;
                string idLibro = p.IdLibro;  // Asegúrate de que la propiedad sea IdLibroPrestado
                string fechaDev = p.FechaMaxDevolucion.ToString("d/M/yyyy");

                string linea = "prestamo " + usuario + ", " + idLibro + ", " + "#" + fechaDev + "#";

                // Añadir al fichero de transacciones la fecha actual
                using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\ficheros\\transacciones.txt"))
                {
                    sw.WriteLine(linea);
                }
            }
            else if (t is Devolucion)
            {
                Devolucion d = (Devolucion)t;

                string idLibro = d.IdLibro;  // Asegúrate de que la propiedad sea IdLibro

                string linea = "devolucion " + idLibro;

                // Añadir al fichero de transacciones la fecha actual
                using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\ficheros\\transacciones.txt"))
                {
                    sw.WriteLine(linea);
                }
            }
        }


        private void lvBorrar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvBorrar.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvBorrar.SelectedItems[0];

                // Muestra un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Deseas borrar este elemento?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Realiza la lógica de borrado aquí
                    lvBorrar.Items.Remove(selectedItem);
                    // También puedes añadir la lógica para borrar de tu fuente de datos si es necesario
                }
            }
        }

        private void lvModificar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvBorrar.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvBorrar.SelectedItems[0];

                switch (interfSeleccionada)
                {
                    case "Libros":

                        break;

                    case "Usuarios":

                        break;

                    case "Transacciones":
                        break;

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String sBusqueda = txbBuscar.Text; 
            if (interfSeleccionada.Equals("Libros"))
            {
                lvBusqueda.Items.Clear();
                foreach (Libro lib in misLibros)
                {
                    if (lib.Titulo.Contains(sBusqueda))
                    {
                        ListViewItem lviAux = new ListViewItem(lib.Titulo);
                        lviAux.SubItems.Add(lib.IdLibro);
                        lviAux.SubItems.Add(lib.Ubicacion);
                        lvBusqueda.Items.Add(lviAux);
                    }
                }
            }
        }
    }

}
