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

        private void cargarUsuarios() {

        }
    }
}
