using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades;
using Logica.Operaciones.AccesoProtegido;
using System.Collections.Generic;
using System.Linq;

namespace Logica.Operaciones
{
    public class Protected_Supervisor : Abs_ProtectedClass<Supervisoress>
    {
        protected RepositorioSupervisor Repositorio_Supervisores;
        protected RepositorioTurnos Repositorio_Turnos; 
        protected Protected_Supervisor()
        {
            Repositorio_Turnos = new RepositorioTurnos();
            Repositorio_Supervisores = new RepositorioSupervisor();
        }
        protected override bool Exist(string id_supervisor)
        {
            if (GetMainList() != null)
            {
                return GetMainList().Any(item => item.Id == id_supervisor);
            }
            else { return false; }
        }
        protected override List<Supervisoress> GetMainList()
        {
            var Supervisores = Repositorio_Supervisores.Load();
            if (Supervisores == null)
            {
                return null;
            }
            var Turnos = Repositorio_Turnos.Load();
            if (Turnos != null)
            {
                foreach (var supervisor in Supervisores)
                {
                    supervisor.Horarios = Turnos.FindAll(turno => turno.Id_supervisor == supervisor.Id);
                }
            }
            return Supervisores;
        }
        protected bool IsTurnoValid(Turno_Atencion turno, Supervisoress supervisor)
        {
            if (turno.Hora_Inicio >= turno.Hora_Salida)
            {
                return false;
            }
            else
            {
                foreach (var item in supervisor.Horarios)
                {
                    if (turno.Dia.Replace(" ", "").ToLower() == item.Dia.Replace(" ", "").ToLower())
                    {
                        if (turno.Hora_Inicio.TimeOfDay >= item.Hora_Inicio.TimeOfDay && item.Hora_Salida.TimeOfDay >= turno.Hora_Inicio.TimeOfDay)
                        {
                            return false;
                        }
                        else if (turno.Hora_Inicio.TimeOfDay <= item.Hora_Inicio.TimeOfDay && turno.Hora_Salida.TimeOfDay >= item.Hora_Inicio.TimeOfDay)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
