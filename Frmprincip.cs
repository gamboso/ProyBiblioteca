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


/*ACUERDATE DE GUARDAR EN GITHUB ANTES DE SALIR*/


namespace ProyBiblioteca
{
    public partial class FrmBiblio : Form
    {
        public FrmBiblio()
        {
            InitializeComponent();
        }

        List<Persona> misUsuarios = new List<Persona>();
        List<Libro> misLibros = new List<Libro>();
        List<Transaccion> misTransacciones = new List<Transaccion>();
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
                        // Sacar solo la parte de la fecha
                        string fechaPart = infoUsuario[2].Substring(infoUsuario[2].IndexOf("#") + 1, infoUsuario[2].LastIndexOf("#") - infoUsuario[2].IndexOf("#") - 1);

                        // Convertir la fecha sin la hora
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
                        // se usa el constructor sin sancion si no tiene fecha (la fecha inicializada es 1/01/1000)
                        usuario = new Persona(nombre, departamento);
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
                    /*Al parecer en C# la fecha por defecto la fecha es "1/1/0001 12:00:00 am" cuando no esta definida, por lo que sí haces un usuario.FechaSancion
                     sale con eso, y al parecer DateTime siempre tiene hora, y no encontré otra clase de SOLO fecha, pero se puede ignorar.
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


                    if (s.Contains("fecha"))
                    {
                        string[] split = s.Substring(indicePrimerEspacio).Split(',');
                        fechaTransaccion = DateTime.Parse(split[0].Trim()+","+split[1].Trim() + ","+split[2].Trim());
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
                    } else if (s.Contains("devolucion")){

                       string[] split = s.Split(' ');

                        tipoTransaccion = split[0];
                        idLibroPrestado = split[1];
                        /*
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"Tipo de transacción: {tipoTransaccion}");
                        Console.WriteLine($"Id libro devuelto: {idLibroPrestado}");
                        */
                        Transaccion ts = new Devolucion(idLibroPrestado,fechaTransaccion);
                        misTransacciones.Add(ts);
                    } 
                  }

                //Imprimir todas las transacciones en MisTransacciones
                foreach (Transaccion ts in misTransacciones)
                {
                    if (ts.GetType().Name.Equals("Prestamo")) {
                        Prestamo ps = (Prestamo)ts;
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"Tipo de transacción: Prestamo");
                        Console.WriteLine($"Nombre de usuario: {ps.NombreUsuario}");
                        Console.WriteLine($"ID de libro prestado: {ps.IdLibroPrestado}");
                        Console.WriteLine($"Fecha de máxima de devolución: {ps.FechaMaxDevolucion.ToString("d/M/yyyy")}");
                        Console.WriteLine($"Fecha transacción: {ps.FechaTransaccion.ToString("d/M/yyyy")}");
                    } else if (ts.GetType().Name.Equals("Devolucion")) {
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
                    int idLibro = 0;

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
                            idLibro = int.Parse(s.Substring(indiceComa + 1));
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
            cargarInterfazLibros();
        }

        private void tsbUsuarios_Click(object sender, EventArgs e)
        {
            cargarInterfazPersonas();
        }

        private void tsbPrestamos_Click(object sender, EventArgs e)
        {
            cargarInterfazPrestamos();
        }

        private void cargarInterfazLibros()
        {
            cargarImagen("libro");
            cargarInterfazBusqueda("Libros");

        }

        private void cargarInterfazPersonas()
        {
            cargarImagen("perfil");
            cargarInterfazBusqueda("Personas");

        }

        private void cargarInterfazPrestamos()
        {
            cargarImagen("Prestamo");
            cargarInterfazBusqueda("Transaccion");
        }

        //Método que carga las imagenes en los picture box
        private void cargarImagen(String imagen)
        {
            pcbModo.Image = System.Drawing.Image.FromFile(".\\Icons\\" + imagen + ".png");
            pcb2Modo.Image = System.Drawing.Image.FromFile(".\\Icons\\" + imagen + ".png");
            pcb3Modo.Image = System.Drawing.Image.FromFile(".\\Icons\\" + imagen + ".png");
            pcb4Modo.Image = System.Drawing.Image.FromFile( ".\\Icons\\" + imagen + ".png");
        }

        //Método que cambia la Interfaz de Búsqueda en función del objeto a buscar (Libros, Personas o Transacciones)
        private void cargarInterfazBusqueda(String tipoLV)
        {
            lvBusqueda.Columns.Clear();
            lvBusqueda.Items.Clear();

            if (tipoLV.Equals("Libros"))
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

                lvBusqueda.Columns.Add(chID);
                lvBusqueda.Columns.Add(chTitulo);
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
            else if (tipoLV.Equals("Personas"))
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
    }

}
