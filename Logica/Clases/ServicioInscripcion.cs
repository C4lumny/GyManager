using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades;
using Entidades.Informacion_Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioInscripcion : ICRUD<Inscripcion, string>, IGetBySearch<Inscripcion>
    {
        ConexionOracle coneccion;

        RepositorioInscripcion rep;
        public ServicioInscripcion()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioInscripcion(coneccion);
        }
        public Response<Inscripcion> Actualizar(Inscripcion entidad, string id)
        {
            try
            {
                return rep.Update(entidad, id);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Inscripcion> Crear(Inscripcion entidad)
        {
            try
            {
                return rep.Insert(entidad);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Inscripcion> Eliminar(string id)
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

        public List<Inscripcion> GetListBySearch(string search)
        {
            try
            {
                return GetAll().FindAll(item => item.Id.ToString().StartsWith(search) || item.Cliente.Id.StartsWith(search) || item.Plan.Id.ToString().StartsWith(search));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Inscripcion GetObjectById(string id)
        {
            try
            {
                return GetAll().FirstOrDefault(item => item.Cliente.Id == id || item.Id.ToString() == id);
            }
            catch (Exception)
            {

                return null;
            };
        }

        public List<Inscripcion> GetAll()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }


        public Response<Inscripcion> Renovar(Inscripcion entidad, string id)
        {
            try
            {
                if (entidad.IdEstado != "CADUCADO")
                {
                    return new Response<Inscripcion>(false, "Esta inscripcion esta vigente o todavia posee pagos pendientes");
                }
                return rep.Update(entidad, id);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
