using System;

namespace Entidades
{
    public class Clientess : Personas
    {
        public Clientess() { }

        public Clientess(string id, string nombre, string apellido, string genero, string telefono, DateTime fecha_nacimiento, DateTime fecha_ingreso)
            : base(id, nombre, apellido, genero, telefono, fecha_nacimiento, fecha_ingreso)
        {
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Apellido};{Genero};{Telefono};{Fecha_nacimiento};{Fecha_ingreso}";
        }
    }
}
