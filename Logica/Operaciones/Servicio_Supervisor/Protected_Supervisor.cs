using Datos;
using Datos.Archivos;
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
        protected Protected_Supervisor()
        {
            ar_supervisor = new RepositorioSupervisor();
        }
        protected override bool Exist(string id_supervisor)
        {
            if (GetMainList().FirstOrDefault(item => item.id == id_supervisor) != null)
            {
                return true; // encontro una id existente.
            }
            return false; // no encontro.
        }
        protected override List<Supervisor> GetMainList()
        {
            var lista = ar_supervisor.Load();
            if (lista == null)
            {
                return null;
            }
            return lista.OfType<Supervisor>().ToList(); // retorna la lista de los supervisores de la clase Listas.
        }
        public bool validarHora(Supervisor sup, DateTime Hora_Inicial, DateTime Hora_Salida)
        {
            if (Hora_Inicial >= Hora_Salida)
            {
                return false;
            }
            else
            {
                foreach (var item in sup.Horarios)
                {
                    if (Hora_Inicial.TimeOfDay >= item.Hora_Inicio.TimeOfDay && item.Hora_Salida.TimeOfDay >= Hora_Inicial.TimeOfDay)
                    {
                        return false;
                    }
                    else if (Hora_Inicial.TimeOfDay <= item.Hora_Inicio.TimeOfDay && Hora_Salida.TimeOfDay >= item.Hora_Inicio.TimeOfDay)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
