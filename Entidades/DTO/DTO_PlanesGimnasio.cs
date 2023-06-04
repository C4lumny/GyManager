using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class DTO_PlanesGimnasio
    {
        public DTO_PlanesGimnasio()
        {
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Descripcion { get; set; }
        public string Dias { get; set; }
    }
}
