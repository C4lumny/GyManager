using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Informacion_Persona
{
    public class Discapacidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return $"{Id};{Nombre}";
        }
    }
}
