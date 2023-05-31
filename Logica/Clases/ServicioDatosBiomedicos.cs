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
        public void Actualizar(DatosBiomedicos entidad, string id)
        {
            rep.Update(entidad, id);
        }

        public void Crear(DatosBiomedicos entidad)
        {
            rep.Insert(entidad);
        }

        public void Eliminar(string id)
        {
            rep.Delete(id);
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
