using Datos;
using Datos.Archivos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioSupervisores : ICRUD<Supervisoress, string>, IGetBySearch<Supervisoress>
    {
        ConexionOracle coneccion;

        RepositorioSupervisor rep;

        public ServicioSupervisores()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioSupervisor(coneccion);
        }
        public Response<Supervisoress> Actualizar(Supervisoress entidad, string id)
        {
            try
            {
                if (!validarActualizacion(entidad, id).Success)
                {
                    return validarActualizacion(entidad, id);
                }
                return rep.Update(entidad, id);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Response<Supervisoress> Crear(Supervisoress entidad)
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

        public Response<Supervisoress> Eliminar(string id)
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

        public List<Supervisoress> GetAll()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }

        public List<Supervisoress> GetListBySearch(string search)
        {
            try
            {
                return GetAll().FindAll(item => item.Id.StartsWith(search) || item.Nombre.Contains(search) || item.Apellido.Contains(search));
            }
            catch (Exception)
            {

                return null;
            };
        }

        public Supervisoress GetObjectById(string id)
        {
            try
            {
                return GetAll().FirstOrDefault(item => item.Id == id);
            }
            catch (Exception)
            {

                return null;
            };
        }
        public Response<Supervisoress> validarCreacion(Supervisoress supervisor)
        {
            if (GetAll() == null)
            {
                return new Response<Supervisoress>(true, "Valido.");
            }
            else if (GetAll().Any(item => item.Id == supervisor.Id))
            {
                return new Response<Supervisoress>(false, "El supervisor ya se encuentra registrado.");
            }
            else if (supervisor.Fecha_nacimiento.AddYears(18) >= DateTime.Now)
            {
                return new Response<Supervisoress>(false, "La edad minima de registro es de 18 años.");
            }
            else
            {
                return new Response<Supervisoress>(true, "Valido.");
            }
        }
        public Response<Supervisoress> validarActualizacion(Supervisoress supervisor, string id_supervisor)
        {
            if (GetAll() == null)
            {
                return new Response<Supervisoress>(false, "No hay supervisores registrados.");
            }
            else if (GetAll().Any(item => item.Id == supervisor.Id && item.Id != id_supervisor))
            {
                return new Response<Supervisoress>(false, "El supervisor ya se encuentra registrado.");
            }
            else if (supervisor.Fecha_nacimiento.AddYears(14) >= DateTime.Now)
            {
                return new Response<Supervisoress>(false, "La edad minima de registro es de 18 años.");
            }
            else
            {
                return new Response<Supervisoress>(true, "Valido.");
            }
        }
    }
}
