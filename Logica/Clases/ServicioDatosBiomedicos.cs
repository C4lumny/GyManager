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
        public string Actualizar(DatosBiomedicos entidad, string id)
        {
           return rep.Update(entidad, id);
        }

        public string Crear(DatosBiomedicos entidad)
        {
            return rep.Insert(entidad).Msg;
        }

        public string Eliminar(string id)
        {
            return rep.Delete(id);
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
            throw new NotImplementedException();
        }

        public DatosBiomedicos GetObjectById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
