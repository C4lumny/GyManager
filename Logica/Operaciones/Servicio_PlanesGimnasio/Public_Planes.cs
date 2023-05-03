using Entidades;
using System;
using System.Linq;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Planes : Protected_Planes
    {
        public Public_Planes()
        {
        }
        public PlanGimnasio ReturnPlan(string id_plan)
        {
            try
            {
                return GetMainList().FirstOrDefault(item => item.Id == id_plan);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public int ReturnPlanDays(string id_plan)
        {
            if (Exist(id_plan))
            {
                return ReturnPlan(id_plan).Dias;
            }
            return -1;
        }
    }
}
