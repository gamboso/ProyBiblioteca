using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    internal class Alumno : Persona
    {
        public Alumno(string tipoUsuario, string nombre, string departamento) : base(tipoUsuario, nombre, departamento)
        {
            TipoUsuario = tipoUsuario;
            Nombre = nombre;
            Departamento = departamento;
        }

        public Alumno(string tipoUsuario, string nombre, string departamento, DateTime fechaSancion) : base(tipoUsuario, nombre, departamento, fechaSancion)
        {
            TipoUsuario = tipoUsuario;
            Nombre = nombre;    
            Departamento = departamento;
            FechaSancion = fechaSancion;
        }
    }
}
