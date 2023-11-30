using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    class Usuario
    {
        //Atributos de la clase Usuario
        String tipoUsuario, nombre, departamento;
        DateTime fechaSancion;

        //Getters y Setters
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public DateTime FechaSancion { get => fechaSancion; set => fechaSancion = value; }
    }
}
