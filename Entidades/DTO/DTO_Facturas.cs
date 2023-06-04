using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class DTO_Facturas
    {
        public string Id { get; set; }
        public string PagoIngresado { get; set; }
        public string descuento { get; set; }
        public string Subtotal { get; set; }
        public string SaldoPendiente { get; set; }
        public string idInscripcion { get; set; }
        public string IdCliente { get; set; }
        public string Clientenombre { get; set; }
        public string PlanGimnasio { get; set; }



        public DTO_Facturas()
        {
        }
    }
}
