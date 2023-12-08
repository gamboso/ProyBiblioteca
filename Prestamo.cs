using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca 
{
     class Prestamo : Transaccion
    {
        string nombreUsuario, idLibroPrestado;
        DateTime fechaMaxDevolucion, fechaTransaccion;
        

        public Prestamo(string nombreUsuario, string idLibroPrestado, DateTime fechaMaxDevolucion, DateTime fechaTransaccion)
            : base(idLibroPrestado, fechaTransaccion)
        {
            this.nombreUsuario = nombreUsuario;
            this.idLibroPrestado = idLibroPrestado;
            this.fechaMaxDevolucion = fechaMaxDevolucion;
            this.fechaTransaccion = fechaTransaccion;
        }

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string IdLibroPrestado { get => idLibroPrestado; set => idLibroPrestado = value; }
        public DateTime FechaMaxDevolucion { get => fechaMaxDevolucion; set => fechaMaxDevolucion = value; }


    }

}
