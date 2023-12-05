using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    internal class PAS : Persona
    {
        public PAS( string nombre, string departamento) : base(nombre, departamento)
        {
            Nombre = nombre;
            Departamento = departamento;
        }
        public PAS( string nombre, string departamento, DateTime fechaSancion) : base( nombre, departamento, fechaSancion)
        {
            Nombre = nombre;
            Departamento = departamento;
            FechaSancion = fechaSancion;
        }
    }
}
