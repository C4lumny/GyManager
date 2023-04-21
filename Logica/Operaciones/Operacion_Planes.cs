using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Operacion_Planes
    {
        protected Listas list;
        protected RepositorioPlan ar;
        public Operacion_Planes()
        {
            list = new Listas();
            ar = new RepositorioPlan();
        }
        protected bool Exist(string id_plan)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_plan) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true;
            }
            return false;
        }
        public PlanGimnasio ReturnFromList(string id_plan)
        {
            return GetLista().FirstOrDefault(item => item.id == id_plan); // devuelve el plan de la lista de planes que cumple la condicion del predicado, en este caso que la id_plan sea igual a la id de un plan en la lista.
        }
        public int ReturnPlanDays(string id_plan)
        {
            if (Exist(id_plan))
            {
                return ReturnFromList(id_plan).dias;
            }
            return -1;
        }
        public List<PlanGimnasio> GetLista()
        {
            if (list.GetListaPlan() == null) { return null; }
            return list.GetListaPlan();
            // retorna la lista de los planes de la clase Listas.
        }
    }
}
