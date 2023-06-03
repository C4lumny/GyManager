using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class DTO_DatosBiomedicos
    {
        public DTO_DatosBiomedicos()
        {
        }

        public string Id { get; set; }
        public string FechaRegistro { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public string Imc { get; set; }
        public string GrasaCorporal { get; set; }
        public string FrecuenciaCardiaca { get; set; }
        public string PresionArterial { get; set; }
        public string CategoriaPeso { get; set; }
        public string idcliente { get; set; }
        public string nombrescliente { get; set; }
        public string apellidoscliente { get; set; }

    }
}
