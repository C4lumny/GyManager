using Datos;
using Entidades;
using Logica.Operaciones.AccesoProtegido;
using System.Collections.Generic;
using System.Linq;

namespace Logica.Operaciones
{
    public class Protected_Planes : Abs_ProtectedClass<PlanGimnasio>
    {
        protected RepositorioPlan Repositorio_Planes;
        protected Protected_Planes()
        { 
            Repositorio_Planes = new RepositorioPlan();
        }
        protected override List<PlanGimnasio> GetMainList()
        {
            var Planes = Repositorio_Planes.Load();
            if (Planes == null) { return null; }
            return Planes;
        }
        protected override bool Exist(string id_plan)
        {
            if (GetMainList() != null)
            {
                return GetMainList().Any(item => item.Id == id_plan);
            }
            else { return false; }
        }
    }
}
