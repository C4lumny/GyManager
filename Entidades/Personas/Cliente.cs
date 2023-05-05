using System;

namespace Entidades
{
    public class Cliente : Personas
    {
        public Cliente() 
        {
        }
        public Cliente(string id, string nombre, string genero, string telefono, double altura, double peso, double imc, DateTime fecha_nacimiento, string discapacidad, DateTime fecha_ingreso) : base(id, nombre, genero, telefono, altura, peso, fecha_nacimiento, fecha_ingreso)
        {
            this.Imc = imc;
            this.Discapacidad = discapacidad;
        }
        public string Discapacidad { get; set; }
        public double Imc { get; set; }
        public override string ToString()
        {
            return $"{Id};{Nombre};{Genero};{Telefono};{Altura};{Peso};{Imc};{Fecha_nacimiento};{Discapacidad};{Fecha_ingreso}";
        }

    }
}
