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
        public string Actualizar(Supervisoress entidad, string id)
        {
            return rep.Update(entidad, id);
        }

        public string Crear(Supervisoress entidad)
        {
            return rep.Insert(entidad).Msg;
        }

        public string Eliminar(string id)
        {
            return rep.Delete(id);
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
    }
}
