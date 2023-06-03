using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class DTO_Inscripciones
    {
        public DTO_Inscripciones()
        {
        }

        public string Id { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public string Precio { get; set; }
        public string Descuento { get; set; }
        public string Cliente { get; set; }
        public string Supervisor { get; set; }
        public string Plan { get; set; }
        public string Estado { get; set; }
    }
}
