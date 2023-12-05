using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    internal class Profesor : Persona
    {
        public Profesor( string nombre, string departamento) : base( nombre, departamento)
        {
            Nombre = nombre;
            Departamento = departamento;
        }
        public Profesor( string nombre, string departamento, DateTime fechaSancion) : base( nombre, departamento, fechaSancion)
        {
            Nombre = nombre;
            Departamento = departamento;
            FechaSancion = fechaSancion;
        }
    }
}
