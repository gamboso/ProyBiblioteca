using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    class Devolucion : Transaccion
    {
        private DateTime fechaTransaccion;

        public Devolucion(string idLibro, DateTime fechaTransaccion) : base(idLibro, fechaTransaccion)
        {
            this.IdLibro = idLibro;
            this.fechaTransaccion = fechaTransaccion;
        }


    }
}
