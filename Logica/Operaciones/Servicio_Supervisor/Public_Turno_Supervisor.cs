using Datos.Archivos.Repositorio;
using Entidades;
using Logica.Operaciones;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CRUD
{
    public class Public_Turno_Supervisor : Public_Supervisores
    {
        public Public_Turno_Supervisor()
        {
        }

        public bool DeleteTurno(Turno_Atencion turno)
        {
            try
            {
                var Turnos = Repositorio_Turnos.Load();
                Turnos.RemoveAt(Turnos.FindIndex((item) => (item.Id_supervisor == turno.Id_supervisor && item.Dia == turno.Dia && item.Hora_Inicio == turno.Hora_Inicio) || (item.Id_supervisor == turno.Id_supervisor && item.Dia == turno.Dia && item.Hora_Salida == turno.Hora_Salida)));
                Repositorio_Turnos.Update(Turnos);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool SaveTurno(Turno_Atencion turno)
        {
            try
            {
                if (IsTurnoValid(turno, ReturnSupervisor(turno.Id_supervisor))) { Repositorio_Turnos.Save(turno); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTurno(Turno_Atencion old_turno, Turno_Atencion new_turno)
        {
            try
            {
                var Turnos = GetMainList();
                DeleteTurno(old_turno);
                SaveTurno(new_turno);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
