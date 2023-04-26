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
    public class CRUD_Plan: Public_Planes, I_CRUD<PlanGimnasio> // Proporciona metodos para cumplir los requerimientos minimos del programa relacionados a los planes.
    {
        
        public CRUD_Plan() { }
        public Response<PlanGimnasio> Delete(string id_plan)
        {
            if (GetMainList() == null)
            {
                return new Response<PlanGimnasio>(false, "Lista vacia"); // lista vacia.
            }
            else
            {
                int pos = GetMainList().FindIndex(item => item.id == id_plan); // Devuelve el indice (posicion) de la lista que cumpla con la condicion 

                if (pos < 0) { return new Response<PlanGimnasio>(false, "No se pudo encontrar el plan que desea eliminar"); } // No se encontro el id del item en la lista q desea eliminar.
               
                PlanGimnasio plan = ReturnFromList(id_plan);
                GetMainList().RemoveAt(pos); return new Response<PlanGimnasio>(true, "Plan eliminado correctamente", null, plan); //Elimino correctamente.
            }
        }
        public List<PlanGimnasio> GetBySearch(string search)
        {
            if (GetMainList() == null)
            {
                return null;
            }
            else
            {
                return GetMainList().FindAll(item => item.nombre.Contains(search)); // FindAll() devuelve una lista que cumplan la condicion del predicado.
            }
        }
        public Response<PlanGimnasio> Save(PlanGimnasio Plan)
        {
            try
            {
                if (GetMainList() == null)
                {
                    ar_plan.Save(Plan); return new Response<PlanGimnasio>(true, "Se ha registrado el plan correctamente."); // guardo el plan
                }
                else if (Exist(Plan.id))
                {
                    return new Response<PlanGimnasio>(false, "El plan ingresado ya se encuentra registrado, por favor ingrese un nuevo ID"); // id repetida
                }
                else
                {
                    ar_plan.Save(Plan); ; return new Response<PlanGimnasio>(true, "Se ha registrado el plan correctamente.", null, Plan); ; //guardo el plan.
                }
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(false, "Error!", null, null); ; //Te jodiste exception xd
            }
        }
        public Response<PlanGimnasio> Update(PlanGimnasio PlanUpdate, string id_plan)
        {
            try
            {
                if (GetMainList() == null) { return new Response<PlanGimnasio>(false, "No se ha registrado ningun plan, por favor ingrese uno antes de continuar."); } // Lista vacia
                else
                {
                    if (!Exist(id_plan))
                    {
                        return new Response<PlanGimnasio>(false, "No se encontro el Plan que desea actualizar"); // No se encontro el id del item para actualizar.
                    }
                    else if (Exist(PlanUpdate.id))
                    {
                        return new Response<PlanGimnasio>(false, "El ID al que desea actualizar corresponde a un ID ya registrado, por favor ingrese un nuevo ID"); //ID repetido al actualizar el plan.
                    }
                    else
                    {
                        var plan = ReturnFromList(id_plan);
                        plan.id = PlanUpdate.id;
                        plan.nombre = PlanUpdate.nombre;
                        plan.precio = PlanUpdate.precio;
                        plan.descripcion = PlanUpdate.descripcion;

                        return new Response<PlanGimnasio>(true, "Actualizo correctamente el Plan", null, plan); ; //Reemplazo correctamente.
                    }
                }
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(false, "Error!");
            }
        }
        public List<PlanGimnasio> GetAll()
        {
            var lista = GetMainList();
            if (lista == null) { return null; }
            return lista;
            // retorna la lista de los planes de la clase Listas.
        }

    }
}
