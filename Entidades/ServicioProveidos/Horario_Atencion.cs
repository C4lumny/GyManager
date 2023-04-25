using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horario_Atencion
    {
        public string turno { get; set; }
        public DateTime Hora_Inicio { get; set; }
        public DateTime Hora_Salida { get; set; }
        public Horario_Atencion()
        {
        }
        public Horario_Atencion(DateTime hora_Inicio, DateTime hora_Salida)
        {
            Hora_Inicio = hora_Inicio;
            Hora_Salida = hora_Salida;
            turno = CalculateTurno();
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
            return $"{Hora_Inicio.ToShortTimeString()};{Hora_Salida.ToShortTimeString()};{turno}"; 
        }
    }
}
