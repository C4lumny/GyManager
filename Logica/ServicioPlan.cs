using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioPlan  // Proporciona metodos para cumplir los requerimientos minimos del programa relacionados a los planes.
    {
        Listas list;
        RepositorioPlan ar = new RepositorioPlan();
        public ServicioPlan() { list = new Listas(); }
        public Response<PlanGimnasio> Delete(string id_plan)
        {
            if (GetLista() == null)
            {
                return new Response<PlanGimnasio>(false, "Lista vacia", null, null); // lista vacia.
            }
            else
            {
                int pos = GetLista().FindIndex(item => item.id == id_plan); // Devuelve el indice (posicion) de la lista que cumpla con la condicion 

                if (pos < 0) { return new Response<PlanGimnasio>(false, "No se pudo encontrar", null, null); } // No se encontro el id del item en la lista q desea eliminar.

                GetLista().RemoveAt(pos); return new Response<PlanGimnasio>(true, "Eliminado correctamente", null, null); //Elimino correctamente.
            }
        }
        public List<PlanGimnasio> GetBySearch(string search)
        {
            if (GetLista() == null)
            {
                return null;
            }
            else
            {
                return GetLista().FindAll(item => item.nombre.Contains(search)); // FindAll() devuelve una lista que cumplan la condicion del predicado.
            }
        }
        public List<PlanGimnasio> GetLista()
        {
            var lista = list.GetListaPlan();
            if (lista == null) { return null; }
            return lista;
            // retorna la lista de los planes de la clase Listas.
        }
        public Response<PlanGimnasio> Save(PlanGimnasio Plan)
        {
            try
            {
                if (GetLista() == null)
                {
                    ar.Save(Plan); return new Response<PlanGimnasio>(true, "Guardado", null, null); // guardo el plan
                }
                else if (Exist(Plan.id))
                {
                    return new Response<PlanGimnasio>(false, "ID repetida", null, null); // id repetida
                }
                else
                {
                    ar.Save(Plan); ; return new Response<PlanGimnasio>(true, "Guardado", null, null); ; //guardo el plan.
                }
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(false, "Exception", null, null); ; //Te jodiste exception xd
            }
        }
        public Response<PlanGimnasio> Update(PlanGimnasio PlanUpdate, string id_plan)
        {
            try
            {
                if (GetLista() == null) { return new Response<PlanGimnasio>(false, "Lista vacia", null, null); } // Lista vacia
                else
                {
                    if (!Exist(id_plan))
                    {
                        return new Response<PlanGimnasio>(false, "No se pudo encontrar", null, null); // No se encontro el id del item para actualizar.
                    }
                    else if (Exist(PlanUpdate.id))
                    {
                        return new Response<PlanGimnasio>(false, "ID repetida", null, null); //ID repetido al actualizar el plan.
                    }
                    else
                    {
                        var plan = ReturnFromList(id_plan);
                        plan.id = PlanUpdate.id;
                        plan.nombre = PlanUpdate.nombre;
                        plan.precio = PlanUpdate.precio;
                        plan.descripcion = PlanUpdate.descripcion;

                        return new Response<PlanGimnasio>(true, "Reemplazo correctamente", null, null); ; //Reemplazo correctamente.
                    }
                }
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(false, "EXCEPTION", null, null);
            }
        }
        bool Exist(string id_plan)
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
            if (GetLista().FirstOrDefault(item => item.id == id_plan) != null)
            {
                return GetLista().FirstOrDefault(item => item.id == id_plan).dias;
            }
            return -1;
        }
    }
}
