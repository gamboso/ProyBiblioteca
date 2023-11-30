using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    class Libro
    {
        //Atributos de la clase Libro
        String titulo, ubicacion;
        int idLibro;

        //Getters y Setters
        public string Titulo { get => titulo; set => titulo = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public int IdLibro { get => idLibro; set => idLibro = value; }
    }
}
