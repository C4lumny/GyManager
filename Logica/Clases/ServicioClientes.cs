using Datos;
using Datos.Archivos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica.Clases
{
    public class ServicioClientes : ICRUD<Clientess, string>, IGetBySearch<Clientess>
    {
        ConexionOracle coneccion;
        RepositorioClientes rep;

        public ServicioClientes()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioClientes(coneccion);
        }

        public Response<Clientess> Actualizar(Clientess entidad, string id)
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

        public Response<Clientess> Crear(Clientess entidad)
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

        public Response<Clientess> Eliminar(string id)
        {
            try
            {
                return rep.Delete(id.ToString());

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Clientess> GetAll()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }

        public List<Clientess> GetListBySearch(string search)
        {
            try
            {
                return GetAll().FindAll(clientes => clientes.Id.StartsWith(search) || clientes.Nombre.Contains(search) || clientes.Apellido.Contains(search));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Clientess> GetAll_NoInscripciones()
        {
            ServicioInscripcion servicioInscripcion = new ServicioInscripcion();

            try
            {
                List<Clientess> resultado = GetAll().Where(obj1 => !servicioInscripcion.GetAll().Any(obj2 => obj2.Cliente.Id == obj1.Id)).ToList();
                return resultado;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Clientess GetObjectById(string id)
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

        public Response<Clientess> validarCreacion(Clientess cliente)
        {
            if (GetAll() == null)
            {
                return new Response<Clientess>(true, "Valido.");
            }
            else if (GetAll().Any(item => item.Id == cliente.Id))
            {
                return new Response<Clientess>(false, "El cliente ya se encuentra registrado.");
            }
            else if (cliente.Fecha_nacimiento.AddYears(14) >= DateTime.Now)
            {
                return new Response<Clientess>(false, "La edad minima de registro es de 14 años.");
            }
            else
            {
                return new Response<Clientess>(true, "Valido.");
            }
        }

        public Response<Clientess> validarActualizacion(Clientess cliente, string id_cliente)
        {
            if (GetAll() == null)
            {
                return new Response<Clientess>(false, "No hay clientes registrados.");
            }
            else if (GetAll().Any(item => item.Id == cliente.Id && item.Id != id_cliente))
            {
                return new Response<Clientess>(false, "El cliente ya se encuentra registrado.");
            }
            else if (cliente.Fecha_nacimiento.AddYears(14) >= DateTime.Now)
            {
                return new Response<Clientess>(false, "La edad minima de registro es de 14 años.");
            }
            else
            {
                return new Response<Clientess>(true, "Valido.");
            }
        }
    }
}
