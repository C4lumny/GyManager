using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades;
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
        public string Actualizar(Inscripcion entidad, string id)
        {
            return rep.Update(entidad, id);
        }

        public string Crear(Inscripcion entidad)
        {
            return rep.Insert(entidad).Msg;
        }

        public string Eliminar(string id)
        {
            return rep.Delete(id);
        }

        public List<Inscripcion> GetListBySearch(string search)
        {
            throw new NotImplementedException();
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
    }
}
