using Entidades;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class CRUD_Plan : Public_Planes, I_CRUD<PlanGimnasio>
    {

        public CRUD_Plan() { }
        public Response<PlanGimnasio> Delete(string id_plan)
        { 
            var Planes = GetMainList();
            if (Planes == null)
            {
                return new Response<PlanGimnasio>(false, "No hay planes registrados actualmente.");
            }
            else
            {
                int pos = Planes.FindIndex(item => item.Id == id_plan);
                PlanGimnasio plan = ReturnPlan(id_plan);

                if (plan == null) { return new Response<PlanGimnasio>(false, "No se pudo encontrar el plan que desea eliminar"); }

                Planes.RemoveAt(pos);
                Repositorio_Planes.Update(Planes);
                return new Response<PlanGimnasio>(true, "El plan: " + plan.Nombre + ". Se ha eliminado correctamente", Planes, plan);
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
                return GetMainList().FindAll(plan => plan.Nombre.Contains(search) || plan.Id.StartsWith(search));
            }
        }
        public Response<PlanGimnasio> Save(PlanGimnasio plan)
        {
            try
            {
                if (GetMainList() == null)
                {
                    Repositorio_Planes.Save(plan); return new Response<PlanGimnasio>(true, "Se ha registrado el plan correctamente.");
                }
                else if (Exist(plan.Id))
                {
                    return new Response<PlanGimnasio>(false, "El plan ingresado ya se encuentra registrado, por favor ingrese un nuevo ID");
                }
                else
                {
                    Repositorio_Planes.Save(plan);
                    return new Response<PlanGimnasio>(true, "Se ha registrado el plan correctamente.", null, plan);
                }
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(false, "Error!", null, null);
            }
        }
        public Response<PlanGimnasio> Update(PlanGimnasio plan_modificado, string id_plan)
        {
            try
            {
                var Planes = GetMainList();
                if (Planes == null) { return new Response<PlanGimnasio>(false, "No se ha registrado ningun plan, por favor ingrese uno antes de continuar."); } // Lista vacia
                else
                {
                    if (!Exist(id_plan))
                    {
                        return new Response<PlanGimnasio>(false, "No se encontro el Plan que desea actualizar"); // No se encontro el id del plan para actualizar.
                    }
                    else if (Exist(plan_modificado.Id) && plan_modificado.Id != id_plan)
                    {
                        return new Response<PlanGimnasio>(false, "El ID al que desea actualizar corresponde a un ID ya registrado, por favor ingrese un nuevo ID"); //ID repetido al actualizar el plan.
                    }
                    else
                    {
                        var plan = Planes.Find(item => item.Id == id_plan);
                        plan.Id = plan_modificado.Id;
                        plan.Nombre = plan_modificado.Nombre;
                        plan.Precio = plan_modificado.Precio;
                        plan.Descripcion = plan_modificado.Descripcion;
                        if (Repositorio_Planes.Update(Planes))
                        {
                            return new Response<PlanGimnasio>(true, "Se ha actualizado el plan", Planes, plan);
                        }
                        else
                        {
                            return new Response<PlanGimnasio>(false, "Error!");
                        }
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
            var Planes = GetMainList();
            if (Planes == null) { return null; }
            return Planes;
        }

    }
}
