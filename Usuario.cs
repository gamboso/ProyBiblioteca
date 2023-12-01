using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    public class Usuario
    {
        //Atributos de la clase Usuario
        String tipoUsuario, nombre, departamento;
        DateTime fechaSancion;

        //Constructor

        // Usuario sin sanción
        public Usuario(String tipoUsuario, String nombre, String departamento)
        {
            this.tipoUsuario = tipoUsuario;
            this.nombre = nombre;
            this.departamento = departamento;
        }
        // Usuario con sanción
       public Usuario(String tipoUsuario, String nombre, String departamento, DateTime fechaSancion)
        {
            this.tipoUsuario = tipoUsuario;
            this.nombre = nombre;
            this.departamento = departamento;
            this.fechaSancion = fechaSancion;
        }



        //Getters y Setters
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public DateTime FechaSancion { get => fechaSancion; set => fechaSancion = value; }
    }
}
