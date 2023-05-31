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
    public class ServicioSupervisores 
    {
        RepositorioSupervisor rep = new RepositorioSupervisor();
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

        public List<Supervisoress> Leer()
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
