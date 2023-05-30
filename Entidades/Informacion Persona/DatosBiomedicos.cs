﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Informacion_Persona
{
    public class DatosBiomedicos
    {
        public DatosBiomedicos()
        {
        }

        public DatosBiomedicos(int id, DateTime fechaRegistro, double altura, double peso, double? imc, double grasaCorporal, int frecuenciaCardiaca, int presionArterial, int? idCategoriaPeso, string idCliente)
        {
            Id = id;
            FechaRegistro = fechaRegistro;
            Altura = altura;
            Peso = peso;
            Imc = imc;
            GrasaCorporal = grasaCorporal;
            FrecuenciaCardiaca = frecuenciaCardiaca;
            PresionArterial = presionArterial;
            IdCategoriaPeso = idCategoriaPeso;
            IdCliente = idCliente;
        }

        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public double? Imc { get; set; }
        public double GrasaCorporal { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public int PresionArterial { get; set; }
        public int? IdCategoriaPeso { get; set; }
        public string IdCliente { get; set; }

        public override string ToString()
        {
            return $"{Id};{FechaRegistro};{Altura};{Peso};{Imc};{GrasaCorporal};{FrecuenciaCardiaca};{PresionArterial};{IdCategoriaPeso};{IdCliente}";
        }
    }

}
