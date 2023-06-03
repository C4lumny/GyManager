using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class DTO_Cliente
    {

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Fecha_nacimiento { get; set; }
        public string Fecha_ingreso { get; set; }

        public DTO_Cliente() { }

        public DTO_Cliente(string id, string nombre, string apellido, string genero, string telefono, string fecha_nacimiento, string fecha_ingreso)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Genero = genero;
            Telefono = telefono;
            Fecha_nacimiento = fecha_nacimiento;
            Fecha_ingreso = fecha_ingreso;
        }

    }
}
