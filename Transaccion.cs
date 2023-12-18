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


        public override bool Equals(object obj)
        {
            return obj is Transaccion transaccion &&
                   idLibro == transaccion.idLibro;
        }

        public override int GetHashCode()
        {
            return idLibro.GetHashCode();
        }

        public override string ToString()
        {
            return $"ID Libro: {IdLibro}, Fecha de Transacción: {FechaTransaccion.ToString("yyyy-MM-dd")}";
        }


    }
}
