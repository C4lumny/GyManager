using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Supervisor : Usuario // Clase Coach, hereda atributos de la clase Persona y posee una lista que muestra cada cliente relacionado a una instancia de esta clase.
    {
        public Supervisor() {}
        public List<Cliente> ListaCliente_Supervisor { get; set; }
        public Supervisor(string id, string nombre, string genero, string telefono, double altura, double peso, DateTime fecha_nacimiento, DateTime fecha_ingreso, bool estado) : base(id, nombre, genero, telefono, altura, peso, fecha_nacimiento, fecha_ingreso, estado)
        {
            ListaCliente_Supervisor = new List<Cliente>();
        }
        public override string ToString()
        {
            return $"{id};{nombre};{genero};{telefono};{altura};{peso};{fecha_nacimiento};{fecha_ingreso};{estado}";
        }
    }
}
