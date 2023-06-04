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
        public string Actualizar(PlanGimnasio entidad, string id)
        {
            return rep.Update(entidad, id);
        }

        public string Crear(PlanGimnasio entidad)
        {
            return rep.Insert(entidad).Msg;
        }

        public string Eliminar(string id)
        {
            return rep.Delete(id);
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
    }
}
