using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    class Transaccion
    {
        String nombreUsuario, idLibroPrestado,tipoTransaccion;
        DateTime fechaDevolucion;

        public Transaccion(string nombreUsuario, string idLibroPrestado, string tipoTransaccion, DateTime fechaDevolucion)
        {
            this.nombreUsuario = nombreUsuario;
            this.idLibroPrestado = idLibroPrestado;
            this.tipoTransaccion = tipoTransaccion;
            this.fechaDevolucion = fechaDevolucion;
        }

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string IdLibroPrestado { get => idLibroPrestado; set => idLibroPrestado = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public string TipoTransaccion { get => tipoTransaccion; set => tipoTransaccion = value; }
    }
}
