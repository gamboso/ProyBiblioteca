using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProyBiblioteca
{
    public class Persona : IUsuario
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
        public Persona(String nombre, String departamento, DateTime fechaSancion)
        {
            this.nombre = nombre;
            this.departamento = departamento;
            this.fechaSancion = fechaSancion;
        }

        //Getters y Setters
        public string Nombre { get => nombre; set => nombre = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public DateTime FechaSancion { get => fechaSancion; set => fechaSancion = value; }

        public DateTime calcularFechaDevolucion(Libro l)
        {

            /*La fecha en la que se devolverá un libro dependerá del tipo de usuario y de la ubicación del libro.
Alumno: 10 días si esta en sala y 15 si está en almacen.
Pas: 15 días en ambos casos.
Profesor: 30 días si está en sala, y 45 si está en almacen.*/

            string tipo = this.GetType().Name;
            if (tipo.Equals("Alumno") && l.Ubicacion.Equals("sala"))
            {

                //Añadir 10 dias
                return DateTime.Now.AddDays(10);

            }
            else if (tipo.Equals("Alumno") && l.Ubicacion.Equals("almacen"))
            {
                //Añadir 15 dias

                return DateTime.Now.AddDays(15);

            }
            else if (tipo.Equals("PAS"))
            {
                //Añadir 15 dias

                return DateTime.Now.AddDays(15);
            }
            else if (tipo.Equals("Profesor") && l.Ubicacion.Equals("sala"))
            {
                //Añadir 30 dias
                return DateTime.Now.AddDays(30);

            }

            else if (tipo.Equals("Profesor") && l.Ubicacion.Equals("almacen"))
            {
                //Añadir 45 dias
                return DateTime.Now.AddDays(45);

            }

            return DateTime.MinValue;
        }

        public void calcularFechaSancion(DateTime fechaDevolucion)
        {
            if (fechaDevolucion > DateTime.Now)
            {
                // No hay retraso, no se aplica sanción
                return;
            }

            // Calcular días de retraso
            int diasRetraso = (int)(DateTime.Now - fechaDevolucion).TotalDays;

            // Aplicar sanción según el tipo de usuario
            switch (this)
            {
                case Alumno alumno:
                    // Sanción para Alumno: nº días de retraso * 7
                    alumno.FechaSancion = DateTime.Now.AddDays(diasRetraso * 7);
                    break;

                case Profesor profesor:
                    // Sanción para Profesor: nº días de retraso * 2
                    profesor.FechaSancion = DateTime.Now.AddDays(diasRetraso * 2);
                    break;

                case PAS pas:
                    // Sanción para PAS: nº días de retraso * 3
                    pas.FechaSancion = DateTime.Now.AddDays(diasRetraso * 3);
                    break;

                default:
                    // Otro tipo de Persona, no se aplica sanción
                    break;
            }
        }

        public void calcularFechaSancion()
        {

        }
    }
}
