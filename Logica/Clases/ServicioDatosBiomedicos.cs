using Datos;
using Datos.Archivos.Repositorio;
using Entidades.Informacion_Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioDatosBiomedicos 
    {
        RepositorioDatosBiomedicos rep = new RepositorioDatosBiomedicos();
        public ServicioDatosBiomedicos()
        {
            
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

        public List<DatosBiomedicos> Leer()
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
