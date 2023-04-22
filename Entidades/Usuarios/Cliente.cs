using System;

namespace Entidades
{
    public class Cliente : Usuario // Clase Clientes, hereda los atributos de la clase Persona y posee una relacion de composicion entre Clientes-Coach y Cliente-Plan. 
    {
        public Cliente() {}
        public Cliente(string id, string nombre, string genero, string telefono, double altura, double peso, DateTime fecha_nacimiento, string discapacidad, DateTime fecha_ingreso) : base(id, nombre, genero, telefono, altura, peso, fecha_nacimiento, fecha_ingreso)
        {
            imc = CalculateIMC(peso, altura);
            this.discapacidad = discapacidad;
        }
        public string discapacidad { get; set; }
        public double imc { get; set; } 
        public override string ToString()
        {
            return $"{id};{nombre};{genero};{telefono};{altura};{peso};{imc};{fecha_nacimiento};{discapacidad};{fecha_ingreso}";
        }
        double CalculateIMC(double peso, double altura)
        {
            return peso / (altura * altura); // retorna el imc (peso/ altura´2)
        }
    }
}
