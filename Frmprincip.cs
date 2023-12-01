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
    public partial class FrmPrincip : Form
    {
        public FrmPrincip()
        {
            InitializeComponent();
        }

        List<Usuario> misUsuarios = new List<Usuario>();
        List<Libro> misLibros = new List<Libro>();
        List<Prestamos> misPrestamos = new List<Prestamos>();
        private void FrmPrincip_Load(object sender, EventArgs e)
        {
            // Cambiar el directorio actual al del fichero
            Directory.SetCurrentDirectory("..\\..\\ficheros");
            // Debe ir antes de todo para que los métodos tengan el directorio correcto



            cargarUsuarios();
            cargarTransacciones();
            cargarLibros();

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
                DateTime fechaSancion = DateTime.Parse("1/01/1999");

                foreach (string s in usuarios)
                {
                    // Split en base a comas.
                    string[] userInfo = s.Split(',');

                    tipoUsuario = userInfo[0].Substring(0, userInfo[0].IndexOf(" ")).Trim();
                    Console.WriteLine($"Tipo de usuario: {tipoUsuario}");

                    nombre = userInfo[0].Substring(userInfo[0].IndexOf(" ") + 1).Trim();
                    Console.WriteLine($"Nombre: {nombre}");

                    if (userInfo.Length > 1)
                    {
                        departamento = userInfo[1].Trim();
                        Console.WriteLine($"Departamento: {departamento}");
                    }

                    if (userInfo.Length > 2 && userInfo[2].Contains("#"))
                    {
                        // Sacar solo la parte de la fecha
                        string fechaPart = userInfo[2].Substring(userInfo[2].IndexOf("#") + 1, userInfo[2].LastIndexOf("#") - userInfo[2].IndexOf("#") - 1);

                        // Convertir la fecha sin la hora
                        if (DateTime.TryParseExact(fechaPart, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaSancion))
                        {
                            Console.WriteLine($"Fecha de sanción: {fechaSancion.ToShortDateString()}");

                            fechaSancion = DateTime.Parse(fechaSancion.ToShortDateString());
                        }
                    }

                    Console.WriteLine(); // Añadir linea entre todo

                    //TODO hacer que añada los que no tienen sancion con el otro constructor.
                    Usuario us = new Usuario(tipoUsuario,nombre,departamento,fechaSancion);

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
            

                //Leer el fichero usuarios.txt
                string[] usuarios = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\libros.txt");

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




    }

}
