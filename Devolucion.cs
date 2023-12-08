using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    class Devolucion : Transaccion
    {
        private string idLibroDevuelto;
        private DateTime fechaTransaccion;

        public Devolucion(string idLibro, DateTime fechaTransaccion) : base(idLibro, fechaTransaccion)
        {
            this.idLibroDevuelto = idLibro;
            this.fechaTransaccion = fechaTransaccion;
        }
        public string IdLibroDevuelto { get => idLibroDevuelto; set => idLibroDevuelto = value; }


    }
}
