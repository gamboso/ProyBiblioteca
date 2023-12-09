using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    public class Transaccion
    {
        string idLibro;
        DateTime fechaTransaccion;

        public Transaccion( string idLibro, DateTime fechaTransaccion)
        {
            this.idLibro = idLibro;
            this.fechaTransaccion = fechaTransaccion;
        }
        public string IdLibro { get; set; }
        public DateTime FechaTransaccion { get => fechaTransaccion; set => fechaTransaccion = value; }

    }
}
