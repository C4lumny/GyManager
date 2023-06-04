using Entidades.Informacion_Persona;
using System;

namespace Entidades
{
    public class Clientess : Personas
    {
        public Clientess() 
        {
            datosBiomedicos = new DatosBiomedicos();
        }
        public Clientess(DatosBiomedicos datosBiomedicos)
        {
            this.datosBiomedicos = datosBiomedicos;
        }

        public Clientess(string id, string nombre, string apellido, string genero, string telefono, DateTime fecha_nacimiento, DateTime fecha_ingreso)
            : base(id, nombre, apellido, genero, telefono, fecha_nacimiento, fecha_ingreso)
        {
            datosBiomedicos = new DatosBiomedicos();
        }
        public DatosBiomedicos datosBiomedicos { get; set; }
    }
}
