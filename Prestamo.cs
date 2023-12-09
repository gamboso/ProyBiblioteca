using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca 
{
     class Prestamo : Transaccion
    {
        string nombreUsuario;
        DateTime fechaMaxDevolucion, fechaTransaccion;

        public Prestamo(string nombreUsuario, string idLibro, DateTime fechaMaxDevolucion, DateTime fechaTransaccion) : base(idLibro, fechaTransaccion)
        {
            this.IdLibro = idLibro;
            this.nombreUsuario = nombreUsuario;
            this.fechaMaxDevolucion = fechaMaxDevolucion;
            this.fechaTransaccion = fechaTransaccion;

        }

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public DateTime FechaMaxDevolucion { get => fechaMaxDevolucion; set => fechaMaxDevolucion = value; }


    }

}
