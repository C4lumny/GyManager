﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Informacion_Persona
{
    public class DatosBiomedicos
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public double? Imc { get; set; }
        public string Discapacidad { get; set; }
        public int IdCategoriaPeso { get; set; }
        public string IdCliente { get; set; }

        public override string ToString()
        {
            return $"{Id};{FechaRegistro};{Altura};{Peso};{Imc};{Discapacidad};{IdCategoriaPeso};{IdCliente}";
        }
    }

}
