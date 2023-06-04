using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Archivos.Repositorio;
using Datos;
using Entidades.Pagos_y_Facturas;
using Datos.Archivos;

namespace Logica.Clases
{
    public class ServicioPlanGimnasio : ICRUD<PlanGimnasio, string>, IGetBySearch<PlanGimnasio>
    {
        ConexionOracle coneccion;

        RepositorioPlan rep;
        public ServicioPlanGimnasio()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioPlan(coneccion);
        }
        public Response<PlanGimnasio> Actualizar(PlanGimnasio entidad, string id)
        {
            try
            {
                if (!validarActualizacion(entidad, id).Success)
                {
                    return validarCreacion(entidad);
                }
                return rep.Update(entidad, id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<PlanGimnasio> Crear(PlanGimnasio entidad)
        {
            try
            {
                if (!validarCreacion(entidad).Success)
                {
                    return validarCreacion(entidad);
                }
                return rep.Insert(entidad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<PlanGimnasio> Eliminar(string id)
        {
            try
            {
                return rep.Delete(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PlanGimnasio> GetAll()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }

        public List<PlanGimnasio> GetListBySearch(string search)
        {
            try
            {
                return GetAll().FindAll(item => item.Id.ToString().StartsWith(search) || item.Nombre.StartsWith(search));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public PlanGimnasio GetObjectById(string id)
        {
            try
            {
                return GetAll().FirstOrDefault(item => item.Id.ToString() == id || item.Nombre == id);
            }
            catch (Exception)
            {

                return null;
            };
        }

        public Response<PlanGimnasio> validarCreacion(PlanGimnasio plan)
        {

            if (GetAll().Any(item => item.Nombre.ToUpper() == plan.Nombre.ToUpper()))
            {
                return new Response<PlanGimnasio>(false, "Por favor ingrese un nombre de plan unico .");
            }
            else if (plan.Dias <= 0)
            {
                return new Response<PlanGimnasio>(false, "Cantidad de dias invalida.");
            }
            return new Response<PlanGimnasio>(true, "Valido.");
        }

        public Response<PlanGimnasio> validarActualizacion(PlanGimnasio plan, string id_plan)
        {
            var plan_old = GetObjectById(id_plan);
            
            if (GetAll().Any(item => item.Nombre == plan.Nombre && item.Nombre.ToUpper() != plan_old.Nombre.ToUpper()))
            {
                return new Response<PlanGimnasio>(false, "Por favor ingrese un nombre de plan unico .");
            }
            else if (plan.Dias <= 0)
            {
                return new Response<PlanGimnasio>(false, "Cantidad de dias invalida.");
            }
            return new Response<PlanGimnasio>(true, "Valido.");
        }
    }
}
