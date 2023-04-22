using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Planes: Protected_Planes
    {
        public Public_Planes()
        {      
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
        
    }
}
