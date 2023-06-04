using System;

namespace Entidades
{
    public class Personas // Clase Personas, proporciona la mayoria de atributos a la clase Coach y a la clase Clientes de la capa de Entidades.
    {
        public Personas() { } 
        public Personas(string id, string nombre, string apellido, string genero, string telefono, DateTime fecha_nacimiento, DateTime fecha_ingreso)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Genero = genero;
            Telefono = telefono;
            Fecha_nacimiento = fecha_nacimiento;
            Fecha_ingreso = fecha_ingreso;
        }
        public String Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Genero { get; set; }
        public String Telefono { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public DateTime Fecha_ingreso { get; set; }
    }
}
