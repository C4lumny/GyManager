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
    public class Public_Turno_Supervisor : Protected_Supervisor
    {
         protected RepositorioTurnos ar_turno;
        public Public_Turno_Supervisor()
        {
            ar_turno = new RepositorioTurnos();
        }

        public bool DeleteTurno(string id_sup, string dia, DateTime hora)
        {
            try
            {
                var lista = ar_turno.Load();
                var sup = GetMainList().FirstOrDefault(item => item.id == id_sup);
                int pos = lista.FindIndex(item => item.Hora_Inicio.TimeOfDay == hora.TimeOfDay || item.Hora_Salida.TimeOfDay == hora.TimeOfDay && item.dia == dia && item.id_sup == id_sup);
                var turno = sup.Horarios.FirstOrDefault(item => item.Hora_Inicio.TimeOfDay == hora.TimeOfDay || item.Hora_Salida.TimeOfDay == hora.TimeOfDay && item.dia == dia);
                if (sup != null && turno != null)
                {
                    sup.Horarios.Remove(turno);
                    lista.RemoveAt(pos);
                    ar_turno.Update(lista);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool SaveTurno(string id_sup, string dia, DateTime Hora_Inicial, DateTime Hora_Salida)
        {
            try
            {
                var lista = GetMainList();
                var sup = lista.FirstOrDefault(item => item.id == id_sup);
                if (sup != null && validarHora(sup,dia, Hora_Inicial, Hora_Salida))
                {
                    var turno = new Turno_Atencion(id_sup, dia, Hora_Inicial, Hora_Salida);
                    ar_turno.Save(turno); 
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTurno(string id_sup, string dia, DateTime Hora_Inicial, DateTime Hora_Salida)
        {
            try
            {
                var lista = GetMainList();
                var sup = lista.FirstOrDefault(item => item.id == id_sup);
                DeleteTurno(id_sup, dia, Hora_Inicial);
                SaveTurno(id_sup, dia, Hora_Inicial, Hora_Salida);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
