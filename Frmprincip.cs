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
        //Posición original
        int originalIndex;
        List<Libro> LibrosEnStock = new List<Libro>();
        List<Libro> LibrosPrestados = new List<Libro>();
        List<Persona> misUsuarios = new List<Persona>();
        List<Libro> misLibros = new List<Libro>();
        List<Transaccion> misTransacciones = new List<Transaccion>();
        //String auxiliar que toma el texto del toolStripMenuItem seleccionado
        string interfSeleccionada = "Libros";
        private int indiceSeleccionado = -1;
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
            //Guardar posición del tbBorrado
            int originalIndex = tcOpciones.TabPages.IndexOf(tpBorrado);
            //

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


        private List<Transaccion> QuitarDuplicadosDeTransacciones(List<Transaccion> transacciones)
        {
            // Diccionario para almacenar la última transacción para cada libro
            Dictionary<string, Transaccion> ultimaTransaccionPorLibro = new Dictionary<string, Transaccion>();

            // Iterar a través de las transacciones en orden inverso para priorizar las transacciones más recientes
            for (int i = transacciones.Count - 1; i >= 0; i--)
            {
                Transaccion ts = transacciones[i];

                // Actualizar la última transacción para cada libro
                if (!ultimaTransaccionPorLibro.ContainsKey(ts.IdLibro))
                {
                    ultimaTransaccionPorLibro[ts.IdLibro] = ts;
                }
            }

            // Devolver las transacciones más recientes para cada libro
            List<Transaccion> ultimasTransacciones = ultimaTransaccionPorLibro.Values.Reverse().ToList();

            return ultimasTransacciones;
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

                // Leer el fichero transacciones.txt
                string[] transacciones = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\transacciones.txt");

                // List to store all transactions
                List<Transaccion> todasLasTransacciones = new List<Transaccion>();

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
                        tipoTransaccion = s.Substring(0, indicePrimerEspacio);
                        nombreUsuario = s.Substring(indicePrimerEspacio + 1, s.IndexOf(',') - indicePrimerEspacio - 1);
                        idLibroPrestado = s.Substring(s.IndexOf(',') + 1, ultimaComa - s.IndexOf(',') - 1);
                        fechaMaxDevolucion = DateTime.Parse(s.Substring(s.IndexOf('#') + 1, ultimoHashtag - s.IndexOf('#') - 1));

                        // Crear la instancia basada en el tipo
                        Transaccion ts;
                        if (s.Contains("prestamo"))
                        {
                            ts = new Prestamo(nombreUsuario, idLibroPrestado, fechaMaxDevolucion, fechaTransaccion);
                        }
                        else
                        {
                            ts = new Devolucion(idLibroPrestado, fechaTransaccion);
                        }

                        todasLasTransacciones.Add(ts);
                    }
                    else if (s.Contains("devolucion"))
                    {
                        string[] split = s.Split(' ');
                        tipoTransaccion = split[0];
                        idLibroPrestado = split[1];

                        // Crear una instancia de devolución
                        Transaccion ts = new Devolucion(idLibroPrestado, fechaTransaccion);
                        todasLasTransacciones.Add(ts);
                    }
                }

                // Remover los duplicados utilizando el método
                misTransacciones = QuitarDuplicadosDeTransacciones(todasLasTransacciones);

                // Print the updated misTransacciones
                foreach (Transaccion ts in misTransacciones)
                {
                    if (ts is Prestamo)
                    {
                        Prestamo ps = (Prestamo)ts;
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"Tipo de transacción: Prestamo");
                        Console.WriteLine($"Nombre de usuario: {ps.NombreUsuario}");
                        Console.WriteLine($"ID de libro prestado: {ps.IdLibro}");
                        Console.WriteLine($"Fecha de máxima de devolución: {ps.FechaMaxDevolucion.ToString("d/M/yyyy")}");
                        Console.WriteLine($"Fecha transacción: {ps.FechaTransaccion.ToString("d/M/yyyy")}");
                    }
                    else if (ts is Devolucion)
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
            cargarLibrosPrestadosCB();

            interfSeleccionada = tsbTransacciones.Text;
            cargarInterfazTransacciones();

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

        private void cargarInterfazTransacciones()
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
                    //Elementos de la interfaz de añadir -------------------------------------------
                    tpAñadir.Text = "Añadir";
                    tpBorrado.Text = "Borrar";
                    tpModificado.Text = "Modificar";
                    tpBuscar.Text = "Buscar";
                    gbAtribs.Text = "Ubicación del libro ";
                    rbOpcion1.Text = "Sala";
                    rbOpcion2.Text = "Almacén";
                    lblAtrib1.Text = "Título Libro";
                    lblAtrib1.Show();
                    tbxAtrib1.Show();
                    lblAtrib2.Text = "ID Libro";
                    lblAtrib3.Hide();
                    tbxAtrib3.Hide();
                    rbOpcion3.Hide();
                    tbxAtrib1.Show();
                    tbxAtrib2.Show();
                    mtbFechaAniadirPrestamo.Hide();
                    //------------------------------------------------------------------------------

                    /*Poner tpBorrado cuando es Libro*/
                    if (!tcOpciones.TabPages.Contains(tpBorrado))
                    {
                        tcOpciones.TabPages.Insert(originalIndex, tpBorrado);
                    }

                    //Elementos de la interfaz de búsqueda------------------------------------------
                    cambiarListViewBusqueda("Libro");
                    lblFiltroTransacciones.Hide();
                    cbFiltroTransacciones.Hide();
                    mtbBuscarFechaTransac.Hide();
                    tbxBuscar.Show();
                    cbLibroPresDev.Hide();
                    cbUsuariosAnadirPrestamos.Hide();
                    lblInfoBuscar.Show();
                    lvBusqueda.Show();
                    lvPrestamos.Hide();
                    lvDevoluciones.Hide();
                    lblDevol.Hide();
                    lblPrestamos.Hide();
                    //------------------------------------------------------------------------------

                    //Elementos de la interfaz de modificar ----------------------------------------
                    mtbFechaModificarPrestamo.Hide();
                    lblFechaModificarPrestamo.Hide();
                    lbAtr1.Show();
                    lbAtr2.Show();
                    lbAtr1.Text = "Titulo";
                    lbAtr2.Text = "ID Libro";
                    txtAtr1.Show();
                    txtAtr12.Hide();
                    txtAtr13.Hide();
                    txtAtr22.Hide();
                    txtAtr2.Show();
                    masked2Atr3.Hide();
                    maskedAtr3.Hide();
                    lblAtr3.Hide();
                    //------------------------------------------------------------------------------

                    //Elementos de la interfaz de borrado ------------------------------------------
                    cambiarLvBorrar("Libro");
                    mtbFechaBorrarPrestamo.Hide();
                    lblFechaBorrarPrestamo.Hide();
                    //------------------------------------------------------------------------------
                    break;

                case "Persona":
                    //Elementos de la interfaz de añadir -------------------------------------------
                    tpAñadir.Text = "Añadir";
                    tpBorrado.Text = "Borrar";
                    tpModificado.Text = "Modificar";
                    tpBuscar.Text = "Buscar";

                    /*Poner tpBorrado si es Persona*/
                    if (!tcOpciones.TabPages.Contains(tpBorrado))
                    {
                        tcOpciones.TabPages.Insert(originalIndex, tpBorrado);
                    }

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
                    mtbFechaAniadirPrestamo.Hide();
                    //------------------------------------------------------------------------------

                    //Elementos de la interfaz de búsqueda------------------------------------------
                    cambiarListViewBusqueda("Persona");
                    lblFiltroTransacciones.Hide();
                    cbFiltroTransacciones.Hide();
                    mtbBuscarFechaTransac.Hide();
                    tbxBuscar.Show();
                    cbLibroPresDev.Hide();
                    cbUsuariosAnadirPrestamos.Hide();
                    lblInfoBuscar.Show();
                    lvPrestamos.Hide();
                    lvDevoluciones.Hide();
                    lvBusqueda.Show();
                    lblPrestamos.Hide();
                    lblDevol.Hide();
                    //------------------------------------------------------------------------------

                    //Elementos de la interfaz de modificación -------------------------------------
                    mtbFechaModificarPrestamo.Hide();
                    lblFechaModificarPrestamo.Hide();
                    lbAtr1.Show();
                    lbAtr2.Show();
                    lbAtr1.Text = "Nombre";
                    lbAtr2.Text = "Departamento";
                    lblAtr3.Text = "Fecha Sancion";
                    txtAtr1.Hide();
                    txtAtr12.Show();
                    txtAtr22.Show();
                    txtAtr13.Hide();
                    txtAtr2.Hide();
                    masked2Atr3.Hide();
                    maskedAtr3.Show();
                    lblAtr3.Show();

                    //------------------------------------------------------------------------------

                    //Elementos de la interfaz de borrado ------------------------------------------
                    cambiarLvBorrar("Persona");
                    mtbFechaBorrarPrestamo.Hide();
                    lblFechaBorrarPrestamo.Hide();
                    //------------------------------------------------------------------------------
                    break;

                case "Transaccion":
                    //Elementos de la interfaz de añadir -------------------------------------------
                    tpAñadir.Text = "Prestar y Devolver";
                    tpBorrado.Text = "Borrar";
                    tpModificado.Text = "Modificar";
                    tpBuscar.Text = "Buscar";


                    if (tcOpciones.TabPages.Contains(tpBorrado))
                    {
                        originalIndex = tcOpciones.TabPages.IndexOf(tpBorrado);
                        tcOpciones.TabPages.Remove(tpBorrado);
                    }

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
                    lblAtrib3.Text = "Fecha Devolución";
                    tbxAtrib3.Hide();
                    tbxAtrib2.Hide();
                    tbxAtrib1.Hide();
                    mtbFechaAniadirPrestamo.Show();
                    //------------------------------------------------------------------------------

                    //Elementos de la interfaz de búsqueda------------------------------------------
                    tbxBuscar.Show();
                    mtbBuscarFechaTransac.Hide();
                    lblFiltroTransacciones.Show();
                    cbFiltroTransacciones.Show();
                    cbLibroPresDev.Show();
                    lblInfoBuscar.Hide();
                    cbFiltroTransacciones.SelectedIndex = 0;
                    lvBusqueda.Hide();
                    lvDevoluciones.Show();
                    lvPrestamos.Show();
                    lblPrestamos.Show();
                    lblDevol.Show();
                    //------------------------------------------------------------------------------

                    //Elementos de la interfaz de modificación -------------------------------------
                    lblFechaModificarPrestamo.Show();
                    mtbFechaModificarPrestamo.Show();
                    lbAtr1.Show();
                    lbAtr2.Hide();
                    lbAtr1.Text = "ID Libro";
                    lblAtr3.Text = "Fecha Devolucion";
                    txtAtr13.Show();
                    txtAtr1.Hide();
                    txtAtr12.Hide();
                    txtAtr2.Hide();
                    txtAtr22.Hide();
                    masked2Atr3.Show();
                    maskedAtr3.Hide();
                    lblAtr3.Show();
                    //------------------------------------------------------------------------------

                    //Elementos de la interfaz de borrado ------------------------------------------
                    cambiarLvBorrar("Transaccion");
                    mtbFechaBorrarPrestamo.Show();
                    lblFechaBorrarPrestamo.Show();
                    //------------------------------------------------------------------------------
                    break;
                default:
                    break;
            }
        }

        private void cambiarLvBorrar(String tipoLV)
        {
            lvModificar.Clear();
            lvBorrar.Clear();
            if (tipoLV.Equals("Libro"))
            {
                foreach (Libro l in misLibros)
                {
                    lvBorrar.SmallImageList = ilProfesoresAlumnosPAS;
                    lvModificar.SmallImageList = ilProfesoresAlumnosPAS;

                    ListViewItem item = new ListViewItem(l.Titulo, 3);
                    ListViewItem items = new ListViewItem(l.Titulo, 3);

                    lvBorrar.Items.Add(item);
                    lvModificar.Items.Add(items);

                }

            }
            else if (tipoLV.Equals("Transaccion"))
            {
                foreach (Transaccion t in misTransacciones)
                {
                    lvBorrar.SmallImageList = ilPrestamos;
                    lvModificar.SmallImageList = ilPrestamos;
                    string clase = t.GetType().ToString();
                    // Encuentra la última posición del punto
                    int lastIndex = clase.LastIndexOf('.');

                    // Obtiene la parte después del último punto
                    string resultadoclase = lastIndex != -1 ? clase.Substring(lastIndex + 1) : clase;
                    Console.WriteLine(resultadoclase);

                    if (resultadoclase.Equals("Prestamo"))
                    {
                        ListViewItem item = new ListViewItem(resultadoclase + ": " + t.ToString(), 1);
                        lvBorrar.Items.Add(item);
                        ListViewItem items = new ListViewItem(resultadoclase + ": " + t.ToString(), 1);
                        lvModificar.Items.Add(items);
                    }
                    else if (resultadoclase.Equals("Devolucion"))
                    {

                        ListViewItem item = new ListViewItem(resultadoclase + ": " + t.ToString(), 0);
                        lvBorrar.Items.Add(item);
                        ListViewItem items = new ListViewItem(resultadoclase + ": " + t.ToString(), 0);
                        lvModificar.Items.Add(items);

                    }
                }
            }
            else if (tipoLV.Equals("Persona"))
            {
                foreach (Persona p in misUsuarios)
                {
                    lvBorrar.SmallImageList = ilProfesoresAlumnosPAS;
                    lvModificar.SmallImageList = ilProfesoresAlumnosPAS;

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
                        ListViewItem items = new ListViewItem(p.Nombre, 1);
                        lvModificar.Items.Add(items);
                    }
                    else if (resultadoclase.Equals("Alumno"))
                    {

                        ListViewItem item = new ListViewItem(p.Nombre, 2);
                        lvBorrar.Items.Add(item);
                        ListViewItem items = new ListViewItem(p.Nombre, 2);
                        lvModificar.Items.Add(items);

                    }
                    else if (resultadoclase.Equals("Profesor"))
                    {

                        ListViewItem item = new ListViewItem(p.Nombre, 0);
                        lvBorrar.Items.Add(item);
                        ListViewItem items = new ListViewItem(p.Nombre, 0);
                        lvModificar.Items.Add(items);

                    }
                }
            }
        }

        //Método que cambia la Interfaz de Búsqueda en función del objeto a buscar (Libros, Personas o Transacciones)
        private void cambiarListViewBusqueda(String tipoLV)
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

            if (cbFiltroTransacciones.Text.Equals("Fecha Transaccion"))
            {
                tbxBuscar.Hide();
                mtbBuscarFechaTransac.Show();

            }
            else
            {
                tbxBuscar.Show();
                mtbBuscarFechaTransac.Hide();
            }
        }

        private void cambioCheckRadioButton(object sender, EventArgs e)
        {
            //Solo hace el evento si está en la interfaz de Transacciones
            if (rbOpcion1.Checked)
            {
                if (rbOpcion1.Text.Equals("Devolución"))
                {
                    cargarLibrosPrestadosCB();
                    lblAtrib3.Text = "Fecha Devolución";
                    lblAtrib1.Hide();
                    tbxAtrib1.Hide();
                    cbUsuariosAnadirPrestamos.Hide();
                }
            }
            else if (rbOpcion2.Checked)
            {
                if (rbOpcion2.Text.Equals("Préstamo"))
                {
                    cargarLibrosEnStockYUsuariosCB();
                    lblAtrib3.Text = "Fecha Préstamo";
                    lblAtrib1.Show();
                    tbxAtrib1.Hide();
                    cbUsuariosAnadirPrestamos.Show();
                }
            }
        }

        private void cargarLibrosPrestadosCB()
        {
            // cbLibroPresDev.SelectedItem = "";

            cbLibroPresDev.Text = "";

            cbUsuariosAnadirPrestamos.Items.Clear();
            cbLibroPresDev.Items.Clear();

            foreach (Libro l in LibrosPrestados)
            {
                cbLibroPresDev.Items.Add(l.Titulo);
            }
        }

        private void cargarLibrosEnStockYUsuariosCB()
        {

            cbLibroPresDev.Text = "";
            cbLibroPresDev.Items.Clear();
            cbUsuariosAnadirPrestamos.Items.Clear();
            foreach (Libro l in LibrosEnStock)
            {
                cbLibroPresDev.Items.Add(l.Titulo);
            }

            foreach (Persona p in misUsuarios)
            {
                cbUsuariosAnadirPrestamos.Items.Add(p.Nombre);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (interfSeleccionada)
            {
                case "Libros":
                    // SI ALGUNA CADENA ESTA VACIA O NO ES UN NÚMERO NO GUARDA NADA
                    if (string.IsNullOrEmpty(tbxAtrib1.Text) || string.IsNullOrEmpty(tbxAtrib2.Text))
                    {
                        MessageBox.Show("No puedes dejar campos vacíos");
                    }
                    else
                    {
                        string titulo = tbxAtrib1.Text;
                        string idLibro = tbxAtrib2.Text;
                        string ubicacion = rbOpcion1.Checked ? rbOpcion1.Text : rbOpcion2.Text;

                        if (!int.TryParse(idLibro, out _))
                        {
                            MessageBox.Show("Debes introducir un número válido como ID del libro");
                        }
                        else if (existeIDLibro(idLibro))
                        {
                            MessageBox.Show("¡Vaya! El ID del libro ya existe");
                        }
                        else
                        {
                            Libro l = new Libro(ubicacion, titulo, idLibro);
                            //Añadir el libro a la lista
                            misLibros.Add(l);

                            //Escribir libros al fichero
                            escribirLibro(l);

                            //Cargar lista libros
                            cargarLibros();

                            // Actualizar libros
                            ActualizaListaDeLibrosEnStockYLibrosPrestados();

                            MessageBox.Show("El libro se ha añadido correctamente");
                        }
                    }
                    break;

                case "Usuarios":
                    // SI ALGUNA CADENA ESTA VACIA NO GUARDA NADA
                    //   if (tbxAtrib1.Text.Equals("") || tbxAtrib2.Text.Equals("") || tbxAtrib3.Text.Equals(""))
                    if (tbxAtrib1.Text.Equals("") || tbxAtrib2.Text.Equals("")) // El atributo 3 fechaSancion si puede estar en blanco
                    {
                        MessageBox.Show("No puedes dejar campos vacios");
                    }
                    else
                    {
                        String nombre = tbxAtrib1.Text;
                        String depto = tbxAtrib2.Text;
                        DateTime fechaSancion = DateTime.Parse("1/01/0001");

                        if (existeNombrePers(nombre))
                        {
                            MessageBox.Show("Vaya! " + nombre + " ya existe");
                        }
                        else
                        {
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
                                    //Añadir persona a la lista
                                    misUsuarios.Add(p);

                                    //Llamar al método para añadir a la persona al archivo
                                    escribirPersona(p);

                                    //Recargar lista de usuarios
                                    cargarUsuarios();

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
                                //Añadir persona a la lista
                                misUsuarios.Add(p);

                                //Llamar al método para añadir a la persona al archivo
                                escribirPersona(p);

                                //Cargar usuarios
                                cargarUsuarios();

                            }
                            MessageBox.Show("El usuario se ha añadido correctamente");
                        }
                    }
                    break;

                case "Transacciones":

                    try
                    {
                        String tituloLib = cbLibroPresDev.Text;

                        // Siempre es la transaccion la fecha actual

                        DateTime fechaTransaccion = DateTime.Now;
                        Transaccion transaccion = null;

                        if (rbOpcion1.Checked) // SI ESTA GUARDANDO EN DEVOLUCION
                        {
                            if (cbLibroPresDev.Text.Equals("") || mtbFechaAniadirPrestamo.MaskCompleted == false) // Si hay algún campo vacio no deja guardar
                            {
                                MessageBox.Show("No puedes dejar campos vacíos");
                            }
                            else  // Si no estan vacios añade el libro  
                            {
                                Libro libro = null;
                                int position = 0;
                                foreach (Libro lib in LibrosPrestados)
                                {
                                    if (tituloLib.Equals(lib.Titulo))
                                    {
                                        libro = lib;
                                        break;
                                    }
                                    else
                                    {
                                        position = position + 1;
                                    }
                                }

                                string libroId = libro.IdLibro;

                                //Añadir nueva devolución
                                transaccion = new Devolucion(libroId, fechaTransaccion);

                                //Quitar y poner los libros en stock
                              //  MessageBox.Show(position + " titulo " + LibrosPrestados[position].Titulo);
                                LibrosPrestados.RemoveAt(position);
                               // MessageBox.Show(position + " titulo " + LibrosPrestados[position].Titulo);
                                LibrosEnStock.Add(libro);
                                MessageBox.Show("Se añadio correctamente!");

                                //ACTUALIZAR LISTA Y CARGAR LOS LIBROS
                                //ActualizaListaDeLibrosEnStockYLibrosPrestados();
                                cargarLibrosPrestadosCB();

                            }
                        }
                        else  // SI ESTA GUARDANDO PRESTAMO
                        {
                            if (cbUsuariosAnadirPrestamos.Text.Equals("") ||
                                cbLibroPresDev.Text.Equals("") ||
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

                                int position = 0;
                                foreach (Libro lib in LibrosEnStock)
                                {
                                    if (tituloLib.Equals(lib.Titulo))
                                    {
                                        libro = lib;
                                        break;
                                    }
                                    else
                                    {
                                        position = position++;
                                    }
                                }

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

                                //Quitar y poner los libros en stock

                                LibrosEnStock.RemoveAt(position);
                                LibrosPrestados.Add(libro);

                                transaccion.ToString();

                                MessageBox.Show("La transacción se ha añadido correctamente");

                                //ACTUALIZAR LISTA, CARGAR LOS LIBROS EN STOCK Y LOS USUARIOS
                                // ActualizaListaDeLibrosEnStockYLibrosPrestados();
                                cargarLibrosEnStockYUsuariosCB();

                            }
                        }
                        //Escribir de las transacciones de hoy si hace falta
                        escribirFecha();
                        // Escribir la transacción en el fichero
                        escribirTransaccion(transaccion);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pueden dejar campos vacíos");
                    }
                    break;

                default:
                    break;
            }
        }

        //Método que comprueba si el id parámetro ya existeID en la colección de libros
        private Boolean existeIDLibro(string id)
        {

            Boolean existeID = false;
            foreach (Libro l in misLibros)
            {
                if (int.Parse(l.IdLibro) == int.Parse(id))
                {
                    existeID = true;
                }
            }
            return existeID;
        }



        //Método que comprueba si el nombre del usuario parámetro existeID en la lista de usuarios
        private Boolean existeNombrePers(string nombre)
        {
            Boolean existeNombre = false;
            foreach (Persona p in misUsuarios)
            {
                if (p.Nombre.Equals(nombre))
                {
                    existeNombre = true;
                }
            }

            return existeNombre;
        }

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



        //Método para escribir Libro
        private void escribirLibro(Libro libro)
        {

            string rutaArchivo = Directory.GetCurrentDirectory() + "\\ficheros\\usuarios.txt";


            string ubicacion = "";
            if (libro.Ubicacion.Equals("Almacén"))
            {
                ubicacion = "almacen";
            }
            else if (libro.Ubicacion.Equals("Sala"))
            {
                ubicacion = "sala";
            }

            string tituloLibro = libro.Titulo;
            string idLibro = libro.IdLibro;

            string linea = $"{ubicacion} {tituloLibro}, {idLibro}";

            // Agregar al archivo de libros
            using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\ficheros\\libros.txt"))
            {
                sw.WriteLine(linea);
            }


        }

        //Método para escribir Persona

        private void escribirPersona(Persona persona)
        {
            string rutaArchivo = Directory.GetCurrentDirectory() + "\\ficheros\\usuarios.txt";

            string tipoUsuario = "";
            if (persona is Alumno)
            {
                tipoUsuario = "alumno";
            }
            else if (persona is Profesor)
            {
                tipoUsuario = "profesor";
            }
            else if (persona is PAS)
            {
                tipoUsuario = "pas";
            }

            string nombre = persona.Nombre;
            string departamento = persona.Departamento;
            string fechaSancion = persona.FechaSancion.ToString("d/M/yyyy");

            string linea = "";

            if (persona.FechaSancion == DateTime.MinValue)
            {
                linea = $"{tipoUsuario} {nombre}, {departamento}";
            }
            else
            {
                linea = $"{tipoUsuario} {nombre}, {departamento}, #{fechaSancion}#";

            }
            // Agregar al archivo de usuarios
            using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\ficheros\\usuarios.txt"))
            {
                sw.WriteLine(linea);
            }
        }

        //Método para escribir Transacción

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

        //Método para borrar Libro del fichero
        private void borrarLibro(Libro libro)
        {
            string tituloLibro = libro.Titulo;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ficheros", "libros.txt");

            // Lectura de todas las líneas del archivo
            string[] lines = File.ReadAllLines(filePath);

            // Búsqueda del título del libro en cada línea
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(tituloLibro))
                {
                    // Si se encuentra el título, se elimina la línea
                    lines[i] = string.Empty;
                    break;
                }
            }

            // Escritura de las líneas modificadas de vuelta al archivo
            File.WriteAllLines(filePath, lines);
        }


        //Método para borrar Persona del fichero
        private void borrarPersona(Persona persona)
        {
            string nombre = persona.Nombre;

            // Ruta del archivo usuarios.txt
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ficheros", "usuarios.txt");

            // Lectura de todas las líneas del archivo
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            // Búsqueda del nombre de la persona en cada línea
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(nombre))
                {
                    // Si se encuentra el nombre, se elimina la línea
                    lines.RemoveAt(i);
                    break;
                }
            }

            // Escritura de las líneas modificadas de vuelta al archivo
            File.WriteAllLines(filePath, lines);
        }

        private void borrarTransaccion(Transaccion transaccion)
        {
            string idLibroTransaccion = transaccion.IdLibro;
        }



        //Método para borrar 
        private void lvBorrar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvBorrar.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvBorrar.SelectedItems[0];

                // Muestra un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Deseas borrar este elemento? " + selectedItem.Name, "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Realiza la lógica de borrado aquí
                    lvBorrar.Items.Remove(selectedItem);
                    // También puedes añadir la lógica para borrar de tu fuente de datos si es necesario
                    if (interfSeleccionada.Equals("Libros"))
                    {
                        Libro libBorrar = null;
                        foreach (Libro l in misLibros)
                        {
                            if (l.Titulo.Equals(selectedItem.Text))
                            {
                                libBorrar = l;

                            }
                        }
                        misLibros.Remove(libBorrar);
                        borrarLibro(libBorrar); // Llamada al método de borrar libro
                    }
                    else if (interfSeleccionada.Equals("Usuarios"))
                    {
                        Persona persBorrar = null;
                        foreach (Persona p in misUsuarios)
                        {
                            if (p.Nombre.Equals(selectedItem.Text))
                            {
                                persBorrar = p;
                            }
                        }

                        misUsuarios.Remove(persBorrar);

                        borrarPersona(persBorrar); // Llamada al método de borrar persona

                    }
                    else
                    {
                        Transaccion transaccionBorrar = null;
                        foreach (Transaccion t in misTransacciones)
                        {
                            if ((t.GetType().Name + ": " + t.ToString()).Equals(selectedItem.Text))
                            {
                                transaccionBorrar = t;
                            }
                        }
                        misTransacciones.Remove(transaccionBorrar);
                    }
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

        private void lvModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay algún elemento seleccionado en el ListView
            if (lvModificar.SelectedItems.Count > 0)
            {
                // Obtener el primer elemento seleccionado
                ListViewItem selectedItem = lvModificar.SelectedItems[0];

                switch (interfSeleccionada)
                {
                    case "Libros":
                        string titulo = selectedItem.Text;
                        string idLibro = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                        txtAtr1.Text = titulo;
                        txtAtr2.Text = idLibro;
                        break;

                    case "Usuarios":
                        string nombre = selectedItem.Text;
                        string departamento = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;
                        string fechaSancion = selectedItem.SubItems.Count > 2 ? selectedItem.SubItems[2].Text : string.Empty;

                        txtAtr12.Text = nombre;
                        txtAtr22.Text = departamento;
                        maskedAtr3.Text = fechaSancion;
                        break;

                    case "Transacciones":
                        string idTransaccion = selectedItem.Text;
                        string fechaDevolucion = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                        txtAtr13.Text = idTransaccion;
                        masked2Atr3.Text = fechaDevolucion;
                        break;
                }
            }
        }




        private void btnGuardarMod_Click(object sender, EventArgs e)
        {
            switch (interfSeleccionada)
            {
                case "Libros":
                    // Verificar si hay algún elemento seleccionado en el ListView
                    if (lvModificar.SelectedItems.Count > 0)
                    {
                        // Obtener el primer elemento seleccionado
                        ListViewItem selectedItem = lvModificar.SelectedItems[0];

                        // Obtener el índice seleccionado
                        int indiceSeleccionado = selectedItem.Index;

                        // Verificar si los campos están llenos
                        if (!string.IsNullOrEmpty(txtAtr1.Text) && !string.IsNullOrEmpty(txtAtr2.Text))
                        {
                            ModificarLibro(txtAtr1.Text, txtAtr2.Text, indiceSeleccionado);
                            CargarDatosLibros(); // Recargar datos en el ListView
                            MessageBox.Show("Libro Modificado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No puedes dejar campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecciona un libro para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Usuarios":
                    // Verificar si hay algún elemento seleccionado en el ListView
                    if (lvModificar.SelectedItems.Count > 0)
                    {
                        // Obtener el primer elemento seleccionado
                        ListViewItem selectedItem = lvModificar.SelectedItems[0];

                        // Obtener el índice seleccionado
                        int indiceSeleccionado = selectedItem.Index;

                        // Verificar si los campos están llenos
                        if (!string.IsNullOrEmpty(txtAtr12.Text) && !string.IsNullOrEmpty(txtAtr22.Text) && maskedAtr3.MaskCompleted)
                        {
                            ModificarUsuario(txtAtr12.Text, txtAtr22.Text, maskedAtr3.Text, indiceSeleccionado);
                            CargarDatosUsuarios(); // Recargar datos en el ListView
                            MessageBox.Show("Usuario Modificado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No puedes dejar campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecciona un usuario para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Transacciones":
                    // Verificar si hay algún elemento seleccionado en el ListView
                    if (lvModificar.SelectedItems.Count > 0)
                    {
                        // Obtener el primer elemento seleccionado
                        ListViewItem selectedItem = lvModificar.SelectedItems[0];

                        // Obtener el índice seleccionado
                        int indiceSeleccionado = selectedItem.Index;

                        // Verificar si los campos están llenos
                        if (!string.IsNullOrEmpty(txtAtr13.Text) && masked2Atr3.MaskCompleted)
                        {
                            ModificarTransaccion(txtAtr13.Text, masked2Atr3.Text, indiceSeleccionado);
                            CargarDatosTransacciones(); // Recargar datos en el ListView
                            MessageBox.Show("Transacción Modificada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No puedes dejar campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecciona una transacción para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                default:
                    break;
            }
        }

            private void CargarDatosLibros()
        {
            // Cargar datos de libros en el ListView
            lvModificar.Items.Clear();
            foreach (Libro libro in misLibros)
            {
                ListViewItem item = new ListViewItem(libro.Titulo);
                item.SubItems.Add(libro.IdLibro);
                lvModificar.Items.Add(item);
            }
        }

        private void CargarDatosUsuarios()
        {
            // Cargar datos de usuarios en el ListView
            lvModificar.Items.Clear();
            foreach (Persona persona in misUsuarios)
            {
                ListViewItem item = new ListViewItem(persona.Nombre);
                item.SubItems.Add(persona.Departamento);
                lvModificar.Items.Add(item);
            }
        }

        private void CargarDatosTransacciones()
        {
            // Cargar datos de transacciones en el ListView
            lvModificar.Items.Clear();
            foreach (Transaccion transaccion in misTransacciones)
            {
                ListViewItem item = new ListViewItem(transaccion.IdLibro);
                lvModificar.Items.Add(item);
            }
        }

        private void ModificarLibro(string nuevoTitulo, string nuevoIdLibro, int indiceSeleccionado)
        {
            if (indiceSeleccionado >= 0 && indiceSeleccionado < misLibros.Count)
            {
                misLibros[indiceSeleccionado].Titulo = nuevoTitulo;
                misLibros[indiceSeleccionado].IdLibro = nuevoIdLibro;

                // Actualizar el ListViewItem directamente en el ListView
                lvModificar.Items[indiceSeleccionado].Text = nuevoTitulo;
                if (lvModificar.Items[indiceSeleccionado].SubItems.Count > 1)
                {
                    lvModificar.Items[indiceSeleccionado].SubItems[1].Text = nuevoIdLibro;
                }

                // Guardar los datos modificados
                GuardarDatosLibro(misLibros);

                // Establecer el índice seleccionado a -1 después de la modificación
                this.indiceSeleccionado = -1;
            }
        }

        private void ModificarUsuario(string nuevoNombre, string nuevoDepartamento, string nuevaFechaSancion, int indiceSeleccionado)
        {
            if (indiceSeleccionado >= 0 && indiceSeleccionado < misUsuarios.Count)
            {
                misUsuarios[indiceSeleccionado].Nombre = nuevoNombre;
                misUsuarios[indiceSeleccionado].Departamento = nuevoDepartamento;
                misUsuarios[indiceSeleccionado].FechaSancion = DateTime.Parse(nuevaFechaSancion);

                // Actualizar el ListViewItem directamente en el ListView
                lvModificar.Items[indiceSeleccionado].Text = nuevoNombre;
                if (lvModificar.Items[indiceSeleccionado].SubItems.Count > 1)
                {
                    lvModificar.Items[indiceSeleccionado].SubItems[1].Text = nuevoDepartamento;
                }
                if (lvModificar.Items[indiceSeleccionado].SubItems.Count > 2)
                {
                    lvModificar.Items[indiceSeleccionado].SubItems[2].Text = nuevaFechaSancion;
                }

                // Guardar datos modificados
                GuardarDatosUsuario(misUsuarios);

                this.indiceSeleccionado = -1;
            }
        }

        private void ModificarTransaccion(string nuevoIdLibro, string nuevaFechaDevolucion, int indiceSeleccionado)
        {
            if (indiceSeleccionado >= 0 && indiceSeleccionado < misTransacciones.Count)
            {
                misTransacciones[indiceSeleccionado].IdLibro = nuevoIdLibro;
                misTransacciones[indiceSeleccionado].FechaTransaccion = DateTime.Parse(nuevaFechaDevolucion);

                // Actualizar el ListViewItem directamente en el ListView
                lvModificar.Items[indiceSeleccionado].Text = nuevoIdLibro;
                if (lvModificar.Items[indiceSeleccionado].SubItems.Count > 1)
                {
                    lvModificar.Items[indiceSeleccionado].SubItems[1].Text = nuevaFechaDevolucion;
                }

                // Guardar datos modificados
                GuardarDatosTransaccion(misTransacciones);

                this.indiceSeleccionado = -1;
            }
        }
        private void GuardarDatosLibro(List<Libro> libros)
        {
            try
            {
                List<string> lines = libros.Select(libro => libro.ToString()).ToList();
                File.WriteAllLines("libros.txt", lines);
                Console.WriteLine("Datos de libros guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar datos de libros: " + ex.Message);
            }
        }

        private void GuardarDatosUsuario(List<Persona> usuarios)
        {
            try
            {
                List<string> lines = usuarios.Select(usuario => usuario.ToString()).ToList();
                File.WriteAllLines("usuarios.txt", lines);
                Console.WriteLine("Datos de usuarios guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar datos de usuarios: " + ex.Message);
            }
        }

        private void GuardarDatosTransaccion(List<Transaccion> transacciones)
        {
            try
            {
                List<string> lines = transacciones.Select(transaccion => transaccion.ToString()).ToList();
                File.WriteAllLines("transacciones.txt", lines);
                Console.WriteLine("Datos de transacciones guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar datos de transacciones: " + ex.Message);
            }
        }




        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lvPrestamos.Items.Clear();
            lvDevoluciones.Items.Clear();
            lvBusqueda.Items.Clear();

            String sBusqueda = tbxBuscar.Text;
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
            else if (interfSeleccionada.Equals("Usuarios"))
            {
                lvBusqueda.Items.Clear();
                foreach (Persona per in misUsuarios)
                {
                    if (per.Nombre.Contains(sBusqueda))
                    {
                        ListViewItem lviAux = new ListViewItem(per.Nombre);
                        lviAux.SubItems.Add(per.Departamento);
                        lviAux.SubItems.Add(per.GetType().Name);
                        String fechaSancion = per.FechaSancion.ToString("dd/MM/yyyy");
                        if (fechaSancion.Equals("01/01/0001"))
                        {
                            lviAux.SubItems.Add("-");
                        }
                        else 
                        {
                            lviAux.SubItems.Add(per.FechaSancion.ToString("dd/M/yyyy"));
                        }

                        lvBusqueda.Items.Add(lviAux);
                    }
                }
            }
            else if (interfSeleccionada.Equals("Transacciones"))
            {
                //Comprobamos qué opción está elegida en el combo box
                switch (cbFiltroTransacciones.Text)
                {
                    //Filtrar por la fecha de la transacción
                    case "Fecha Transaccion":
                        foreach (Transaccion transaccion in misTransacciones)
                        {
                            //Verificamos que la fecha de transacción coincide con la introducida en el MaskedTextbox
                            if (transaccion.FechaTransaccion.ToString("dd/MM/yyyy").Equals(mtbBuscarFechaTransac.Text))
                            {
                                //Si la transacción es un préstamo...
                                if (transaccion.GetType().Name.Equals("Prestamo"))
                                {
                                    //Creamos un objeto Prestamo auxiliar a partir de un casting de la transacción
                                    Prestamo presAux = (Prestamo)transaccion;
                                    anadirPrestamoFiltrado(presAux);
                                }
                                //Si la transacción es una devolución...
                                else
                                {
                                    //Creamos un objeto Devolucion auxiliar igual a un casting de la transacción
                                    Devolucion devAux = (Devolucion)transaccion;
                                    anadirDevolFiltrada(devAux);
                                }
                            }
                        }
                        break;


                    case "Titulo Libro":
                        foreach (Transaccion transaccion in misTransacciones)
                        {
                            //Tomamos el id del libro de una transacción
                            String idLibAux = transaccion.IdLibro;
                            String nomLibroAux = "";
                            foreach (Libro l in misLibros)
                            {
                                //Buscamos ese id en nuestra coleccion de libros y tomamos el título del libro
                                if (l.IdLibro.Equals(idLibAux))
                                {
                                    nomLibroAux = l.Titulo;
                                }
                            }

                            //Si el título del libro contiene la cadena buscada, la transacción se añade al ListView correspondiente
                            if (nomLibroAux.Contains(sBusqueda))
                            {
                                if (transaccion.GetType().Name.Equals("Prestamo"))
                                {
                                    Prestamo presAux = (Prestamo)transaccion;
                                    anadirPrestamoFiltrado(presAux);
                                }
                                else
                                {
                                    Devolucion devAux = (Devolucion)transaccion;
                                    anadirDevolFiltrada(devAux);
                                }
                            }
                        }
                        break;

                    case "Nombre Usuario":
                        foreach (Transaccion transaccion in misTransacciones)
                        {
                            //Si la transacción es un préstamo...
                            if (transaccion.GetType().Name.Equals("Prestamo"))
                            {
                                //Creamos un préstamo auxiliar
                                Prestamo presAux = (Prestamo)transaccion;

                                //Si el nombre de usuario del préstamo contiene la cadena buscada, añadimos el préstamo al ListView
                                if (presAux.NombreUsuario.Contains(tbxBuscar.Text))
                                {
                                    anadirPrestamoFiltrado(presAux);
                                }
                            }
                        }
                        break;

                    case "Departamento":
                        foreach (Transaccion transaccion in misTransacciones)
                        {
                            //
                            if (transaccion.GetType().Name.Equals("Prestamo"))
                            {
                                Prestamo presAux = (Prestamo)transaccion;
                                String nomAux = presAux.NombreUsuario;
                                String deptoAux = "";

                                foreach (Persona pers in misUsuarios)
                                {
                                    if (pers.Nombre.Equals(nomAux))
                                    {
                                        deptoAux = pers.Departamento;
                                    }
                                }

                                if (deptoAux.Contains(sBusqueda))
                                {
                                    anadirPrestamoFiltrado(presAux);
                                }
                            }
                        }
                        break;

                    default:
                        MessageBox.Show("Opción inválida");
                        break;
                }
            }
        }

        private void anadirDevolFiltrada(Devolucion devAux)
        {
            ListViewItem lvi = new ListViewItem(devAux.IdLibro);
            lvi.SubItems.Add(devAux.FechaTransaccion.ToString("dd/MM/yyyy"));
            lvDevoluciones.Items.Add(lvi);
        }

        private void anadirPrestamoFiltrado(Prestamo presAux)
        {
            ListViewItem lvi = new ListViewItem(presAux.NombreUsuario);
            lvi.SubItems.Add(presAux.IdLibro);
            lvi.SubItems.Add(presAux.FechaMaxDevolucion.ToString("dd/MM/yyyy"));
            lvi.SubItems.Add(presAux.FechaTransaccion.ToString("dd/MM/yyyy"));
            lvPrestamos.Items.Add(lvi);
        }


    }
}

