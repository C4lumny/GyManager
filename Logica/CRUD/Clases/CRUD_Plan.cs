using Datos;
using Entidades;
using Logica.Operaciones;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CRUD_Plan: Public_Planes, ICRUD<PlanGimnasio> // Proporciona metodos para cumplir los requerimientos minimos del programa relacionados a los planes.
    {
        
        public CRUD_Plan() { }
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
        public List<PlanGimnasio> GetAll()
        {
            if (list.GetListaPlan() == null) { return null; }
            return list.GetListaPlan();
            // retorna la lista de los planes de la clase Listas.
        }

    }
}
