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
        protected RepositorioPlan ar_plan;
        protected Protected_Planes()
        {
            ar_plan = new RepositorioPlan();
        }
        protected override List<PlanGimnasio> GetLista()
        {
            var lista = ar_plan.Load();
            if (lista == null) { return null; }
            return lista;
            // retorna la lista de los planes de la clase Listas.
        }
        protected override bool Exist(string id_plan)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_plan) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true;
            }
            return false;
        }
       
    }
}
