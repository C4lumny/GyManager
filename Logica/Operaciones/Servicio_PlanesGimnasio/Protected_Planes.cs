using Datos;
using Entidades;
using Logica.Operaciones.AccesoProtegido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Protected_Planes: Abs_ProtectedClass<PlanGimnasio>
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
            if (GetMainList().FirstOrDefault(item => item.Id == id_plan) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true;
            }
            return false;
        }
       
    }
}
