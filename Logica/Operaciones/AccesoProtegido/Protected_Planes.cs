using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Protected_Planes
    {
        protected Listas list;
        protected RepositorioPlan ar;
        public Protected_Planes()
        {
            list = new Listas();
            ar = new RepositorioPlan();
        }
        protected List<PlanGimnasio> GetLista()
        {
            if (list.GetListaPlan() == null) { return null; }
            return list.GetListaPlan();
            // retorna la lista de los planes de la clase Listas.
        }
        protected bool Exist(string id_plan)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_plan) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true;
            }
            return false;
        }
       
    }
}
