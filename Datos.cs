using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyBiblioteca
{
    
    public partial class Datos : Form
    {
        private string Modo = "";
        public Datos(Transaccion t)
        {
            InitializeComponent();
        }
        public Datos(Libro l)
        {
            InitializeComponent();
        }
        public Datos(IUsuario u)
        {
            InitializeComponent();
        }
    }
}
