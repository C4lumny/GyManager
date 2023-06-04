using System;
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

        public DatosBiomedicos(Clientess cliente)
        {
            this.id_cliente = cliente.Id;
        }

        public DatosBiomedicos(int id, DateTime fechaRegistro, double altura, double peso, double? imc, double grasaCorporal, int frecuenciaCardiaca, int presionArterial, string idCategoriaPeso, string cliente)
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
            this.id_cliente = cliente;
        }

        public int? Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double? Altura { get; set; }
        public double? Peso { get; set; }
        public double? Imc { get; set; }
        public double? GrasaCorporal { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public int? PresionArterial { get; set; }
        public string IdCategoriaPeso { get; set; }
        public string id_cliente { get; set; }

    }

}
