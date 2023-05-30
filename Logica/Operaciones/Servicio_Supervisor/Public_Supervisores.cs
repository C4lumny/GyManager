using Entidades;
using System;
using System.Linq;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Supervisores : Protected_Supervisor
    {
        public Public_Supervisores()
        {
        }
        public Supervisoress ReturnSupervisor(string id_supervisor) 
        {
            try
            {
                return GetMainList().FirstOrDefault(supervisor => supervisor.Id == id_supervisor);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Turno_Atencion ReturnTurno(string id_supervisor, string dia, DateTime hora)
        {
            try
            {
                return Repositorio_Turnos.Load().FirstOrDefault((item) => (item.Id_supervisor == id_supervisor && item.Dia == dia && item.Hora_Inicio == hora) || (item.Id_supervisor == id_supervisor && item.Dia == dia && item.Hora_Salida == hora));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
