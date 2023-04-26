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
    public class Public_Horarios : Protected_Supervisor
    {
        public Public_Horarios()
        {
            
        }

        public bool DeleteTurno(string id_sup, DateTime hora)
        {
            try
            {
                var lista = GetMainList();
                var sup = lista.FirstOrDefault(item => item.id == id_sup);
                int pos = sup.Horarios.FindIndex(item => item.Hora_Inicio.TimeOfDay == hora.TimeOfDay || item.Hora_Salida.TimeOfDay == hora.TimeOfDay);
                if (sup != null && pos >= 0)
                {
                    sup.Horarios.RemoveAt(pos);
                    ar_supervisor.Update(lista);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool SaveTurno(string id_sup, DateTime Hora_Inicial, DateTime Hora_Salida)
        {
            try
            {
                var lista = GetMainList();
                var sup = lista.FirstOrDefault(item => item.id == id_sup);
                if (sup != null && validarHora(sup, Hora_Inicial, Hora_Salida))
                {
                    var turno = new Turno_Atencion(Hora_Inicial, Hora_Salida);
                    sup.Horarios.Add(turno);
                    ar_supervisor.Update(lista);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTurno(string id_sup, DateTime Hora_Inicial, DateTime Hora_Salida)
        {
            try
            {
                var lista = GetMainList();
                var sup = lista.FirstOrDefault(item => item.id == id_sup);
                DeleteTurno(id_sup, Hora_Inicial);
                SaveTurno(id_sup, Hora_Inicial, Hora_Salida);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
