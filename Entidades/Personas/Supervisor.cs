using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Supervisores : Personas
    {
        public Supervisores() { }

        public Supervisores(string id, string nombre, string genero, string telefono, double altura, double peso, DateTime fecha_nacimiento, string correo, DateTime fecha_ingreso)
            : base(id, nombre, genero, telefono, altura, peso, fecha_nacimiento, fecha_ingreso)
        {
            Correo = correo;
        }

        public string Correo { get; set; }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Genero};{Telefono};{Altura};{Peso};{Fecha_nacimiento};{Correo};{Fecha_ingreso}";
        }
    }
}
