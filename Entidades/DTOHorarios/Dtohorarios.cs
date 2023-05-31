using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOHorarios
{
    public class Dtohorarios
    {

        public string Supervisor_Id { get; set; }
        public string Supervisor_nombres { get; set; }
        public string Supervisor_apellidos { get; set; }
        public string Turno_id { get; set; }
        public string Dia { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }

            public Dtohorarios()
            {
            }

        public Dtohorarios(string supervisor_Id, string supervisor_nombres, string supervisor_apellidos, string turno_id, string dia, string horaEntrada, string horaSalida)
        {
            Supervisor_Id = supervisor_Id;
            Supervisor_nombres = supervisor_nombres;
            Supervisor_apellidos = supervisor_apellidos;
            Turno_id = turno_id;
            Dia = dia;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
        }
    }
}
