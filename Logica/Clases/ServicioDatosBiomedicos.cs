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
    public class ServicioDatosBiomedicos : ICRUD<DatosBiomedicos, string>, IGetBySearch<DatosBiomedicos>
    {
        ConexionOracle coneccion;
        RepositorioDatosBiomedicos rep;

        
        public ServicioDatosBiomedicos()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioDatosBiomedicos(coneccion);
        }
        public Response<DatosBiomedicos> Actualizar(DatosBiomedicos entidad, string id)
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

        public Response<DatosBiomedicos> Crear(DatosBiomedicos entidad)
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

        public Response<DatosBiomedicos> Eliminar(string id)
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

        public List<DatosBiomedicos> GetAll()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }

        public List<DatosBiomedicos> GetListBySearch(string search)
        {
            try
            {
                return GetAll().FindAll(item => item.Id.ToString().StartsWith(search) || item.id_cliente.StartsWith(search));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public DatosBiomedicos GetObjectById(string id)
        {
            try
            {
                return GetAll().FirstOrDefault(item => item.Id.ToString() == id);
            }
            catch (Exception)
            {

                return null;
            };
        }

        public List<DatosBiomedicos> GetHistorial()
        {
            rep.HistorialAccess();
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }
    }
}
