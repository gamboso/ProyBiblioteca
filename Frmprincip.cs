using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class tbxAtrib1 : Form
    {

        public tbxAtrib1()
        {
            InitializeComponent();
        }
        
        List<Persona> misUsuarios = new List<Persona>();
        List<Libro> misLibros = new List<Libro>();
        List<Transaccion> misPrestamos = new List<Transaccion>();
        private void FrmPrincip_Load(object sender, EventArgs e)
        {
            



            cargarUsuarios();
            cargarTransacciones();
            cargarLibros();

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
                    ; if (fechaSancion.Equals(DateTime.Parse("1/01/1000")))
                    {
                        if (tipoUsuario.Equals("alumno"))
                        {
                            usuario = new Alumno(nombre, departamento);
                        }
                        else if (tipoUsuario.Equals("pas"))
                        {
                            usuario = new PAS( nombre, departamento);
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
                            usuario = new PAS( nombre, departamento, fechaSancion);
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
                        Console.WriteLine( "| Nombre : " + us.Nombre + "| Departamento : " + us.Departamento + "| Fecha sancion : " + us.FechaSancion.ToString("d/M/yyyy"));
                    }
                    else
                    {
                        Console.WriteLine(  "| Nombre : " + us.Nombre + "| Departamento : " + us.Departamento);
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
            try
            {
                Console.WriteLine("====== Transacciones ======");


                //Leer el fichero usuarios.txt
                string[] usuarios = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\transacciones.txt");

                foreach (string s in usuarios)
                {
                    Console.WriteLine(s);
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

        }

        private void tsbUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void tsbPrestamos_Click(object sender, EventArgs e)
        {

        }

        private void cargarInterfazLibros()
        {

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
