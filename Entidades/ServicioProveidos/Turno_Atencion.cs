using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno_Atencion
    {
        public string Jornada { get; set; }
        public DateTime Hora_Inicio { get; set; }
        public DateTime Hora_Salida { get; set; }
        public string dia { get; set; }
        public string id_supervisor { get; set; }
        public Turno_Atencion(Supervisor supervisor, string dia, DateTime hora_Inicio, DateTime hora_Salida)
        {
            this.id_supervisor = supervisor.id;
            this.dia = dia;
            Hora_Inicio = hora_Inicio;
            Hora_Salida = hora_Salida;
            Jornada = CalculateTurno();
        }
        public Turno_Atencion(string id_supervisor, string dia, DateTime hora_Inicio, DateTime hora_Salida)
        {
            this.id_supervisor = id_supervisor;
            this.dia = dia;
            Hora_Inicio = hora_Inicio;
            Hora_Salida = hora_Salida;
            Jornada = CalculateTurno();
        }
        string CalculateTurno()
        {
            if (Hora_Inicio.TimeOfDay > new TimeSpan(12, 0, 0) && Hora_Inicio.TimeOfDay < new TimeSpan(19, 0, 0))
            {
                return "Tarde";
            }
            else if (Hora_Inicio.TimeOfDay >= new TimeSpan(19, 0, 0))
            {
                return "Noche";
            }
            else
            {
                return "Mañana";
            }
        }
        public override string ToString()
        {
            return $"{id_supervisor};{dia};{Hora_Inicio.ToShortTimeString()};{Hora_Salida.ToShortTimeString()}"; 
        }
    }
}
