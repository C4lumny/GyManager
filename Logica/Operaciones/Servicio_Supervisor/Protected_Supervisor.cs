using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades;
using Logica.Operaciones.AccesoProtegido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Protected_Supervisor: Abs_ProtectedClass<Supervisor>
    {
        protected RepositorioSupervisor ar_supervisor;
        protected RepositorioTurnos ar_turno;
        protected Protected_Supervisor()
        {
            ar_turno = new RepositorioTurnos();
            ar_supervisor = new RepositorioSupervisor();
        }
        protected override bool Exist(string id_supervisor)
        {
            if (GetMainList().FirstOrDefault(item => item.id == id_supervisor) != null)
            {
                return true; 
            }
            return false; 
        }
        protected override List<Supervisor> GetMainList()
        {
            var listaSup = ar_supervisor.Load();
            if (listaSup == null)
            {
                return null;
            }
            var listaTurno = ar_turno.Load();
            if (listaTurno != null)
            {
                foreach (var supervisor in listaSup)
                {
                    supervisor.Horarios = listaTurno.FindAll(turno => turno.id_supervisor == supervisor.id);
                }
            }
            return listaSup; 
        }
        protected bool validarHora(Turno_Atencion turno, Supervisor supervisor)
        {
            if (turno.Hora_Inicio >= turno.Hora_Salida)
            {
                return false;
            }
            else
            {
                foreach (var item in supervisor.Horarios)
                {
                    if (turno.dia.Replace(" ", "").ToLower() == item.dia.Replace(" ", "").ToLower())
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
