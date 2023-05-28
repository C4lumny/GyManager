using System;

namespace Entidades
{
    public class Clientes : Personas
    {
        public Clientes() { }

        public Clientes(string id, string nombre, string genero, string telefono, double altura, double peso, DateTime fecha_nacimiento, DateTime fecha_ingreso)
            : base(id, nombre, genero, telefono, altura, peso, fecha_nacimiento, fecha_ingreso)
        {
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Genero};{Telefono};{Altura};{Peso};{Fecha_nacimiento};{Fecha_ingreso}";
        }
    }
}
