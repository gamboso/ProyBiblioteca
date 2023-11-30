using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    class Prestamos
    {
        String nombreUsuario, idLibroPrestado;
        DateTime fechaDevolucion;

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string IdLibroPrestado { get => idLibroPrestado; set => idLibroPrestado = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
    }
}
