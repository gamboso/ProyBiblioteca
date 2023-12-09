using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
   public class Libro
    {
        //Atributos de la clase Libro
        String titulo, ubicacion;
        String idLibro;

        //Constructor
        public Libro(string ubicacion, string titulo, String idLibro)
        {
            this.ubicacion = ubicacion;
            this.titulo = titulo;
            this.idLibro = idLibro;
        }


        //Getters y Setters
        public string Titulo { get => titulo; set => titulo = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public String IdLibro { get => idLibro; set => idLibro = value; }
    }
}
