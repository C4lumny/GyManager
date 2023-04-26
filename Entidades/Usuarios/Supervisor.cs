using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Supervisor : Usuario
    { 
        public Supervisor()
        {
            Horarios = new List<Turno_Atencion>();
        }
        public bool estado { get; set; }
        public List<Turno_Atencion> Horarios { get; set; }
        public Supervisor(string id, string nombre, string genero, string telefono, double altura, double peso, DateTime fecha_nacimiento, DateTime fecha_ingreso, bool estado) : base(id, nombre, genero, telefono, altura, peso, fecha_nacimiento, fecha_ingreso)
        {
            this.estado = estado;
            Horarios = new List<Turno_Atencion>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{id};{nombre};{genero};{telefono};{altura};{peso};{fecha_nacimiento};{fecha_ingreso};{estado}");
            foreach (var item in Horarios)
            {
                sb.Append(";" + item.ToString());
            }
            return sb.ToString();
        }
    }
}
