using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{



    public class Persona
    {
        //Atributos de la clase Persona
       string nombre, departamento;
        DateTime fechaSancion;

        //Constructor

        // Persona sin sanción
        public Persona(String nombre, String departamento)
        {
            this.nombre = nombre;
            this.departamento = departamento;
        }
        // Persona con sanción
       public Persona( String nombre, String departamento, DateTime fechaSancion)
        {
            this.nombre = nombre;
            this.departamento = departamento;
            this.fechaSancion = fechaSancion;
        }

        //Getters y Setters
        public string Nombre { get => nombre; set => nombre = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public DateTime FechaSancion { get => fechaSancion; set => fechaSancion = value; }
    }
}
