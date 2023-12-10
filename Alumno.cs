using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    internal class Alumno : Persona
    {
        public Alumno(string nombre, string departamento) : base(nombre, departamento)
        {

            Nombre = nombre;
            Departamento = departamento;
        }

        public Alumno(string nombre, string departamento, DateTime fechaSancion) : base(nombre, departamento, fechaSancion)
        {
            Nombre = nombre;
            Departamento = departamento;
            FechaSancion = fechaSancion;
        }
    }
}
