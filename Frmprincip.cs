using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            cargarUsuarios();
        }

        private void cargarUsuarios()
        {
            try
            {
                // Cambiar el directorio actual a ficheros
                Directory.SetCurrentDirectory("..\\..\\ficheros");

                //Leer el fichero usuarios.txt
               string[] usuarios =  File.ReadAllLines(Directory.GetCurrentDirectory()+"\\usuarios.txt");

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
