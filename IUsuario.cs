using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    public  interface IUsuario
    {
        DateTime calcularFechaDevolucion(Libro l);

        void calcularFechaSancion();
    }
}
