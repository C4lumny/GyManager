using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class DTO_Pagos
    {
        public DTO_Pagos()
        {

        }
        public string Id { get; set; }
        public string ValorIngresado { get; set; }
        public string FechaPago { get; set; }
        public string idcliente { get; set; }
        public string nombrecliente { get; set; }
        public string apellidocliente { get; set; }
        public string idInscripcion { get; set; }
    }
}
