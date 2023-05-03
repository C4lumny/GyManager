using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Supervisor : Personas
    {
        public Supervisor()
        {
            Horarios = new List<Turno_Atencion>();
        }
        public List<Turno_Atencion> Horarios { get; set; }
        public Supervisor(string id, string nombre, string genero, string telefono, double altura, double peso, DateTime fecha_nacimiento, DateTime fecha_ingreso) : base(id, nombre, genero, telefono, altura, peso, fecha_nacimiento, fecha_ingreso)
        {
            Horarios = new List<Turno_Atencion>();
        }
        public override string ToString()
        {
            return $"{Id};{Nombre};{Genero};{Telefono};{Altura};{Peso};{Fecha_nacimiento};{Fecha_ingreso}";
        }
        public string ToFullString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Id};{Nombre};{Genero};{Telefono};{Altura};{Peso};{Fecha_nacimiento};{Fecha_ingreso}");
            foreach (var item in Horarios)
            {
                sb.Append($";{item.Dia};{item.Hora_Inicio};{item.Hora_Salida}");
            }
            return sb.ToString();
        }
    }
}
