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
                var lista = ar_turno.Load();

                lista.RemoveAt(lista.FindIndex((item) => (item.id_supervisor == turno.id_supervisor && item.dia == turno.dia && item.Hora_Inicio == turno.Hora_Inicio) || (item.id_supervisor == turno.id_supervisor && item.dia == turno.dia && item.Hora_Salida == turno.Hora_Salida)));
                foreach (var item in lista)
                {
                    Console.WriteLine(item.ToString());
                }
                ar_turno.Update(lista);
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

                var lista = GetMainList();
                if (validarHora(turno, ReturnSupervisorFromList(turno.id_supervisor))) { ar_turno.Save(turno); }
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
                var lista = GetMainList();
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
