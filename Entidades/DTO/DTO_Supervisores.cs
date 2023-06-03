using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class DTO_Supervisores
    {
        public DTO_Supervisores(string id, string nombre, string apellido, string genero, string telefono, string fecha_nacimiento, string correo, string fecha_ingreso)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Genero = genero;
            Telefono = telefono;
            FechaNacimiento = fecha_nacimiento;
            Correo = correo;
            FechaIngreso = fecha_ingreso;
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string FechaIngreso { get; set; }
    }
}
