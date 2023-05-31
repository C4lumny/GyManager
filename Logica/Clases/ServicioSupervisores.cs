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
        public void Actualizar(Supervisoress entidad, string id)
        {
            rep.Update(entidad, id);
        }

        public void Crear(Supervisoress entidad)
        {
            rep.Insert(entidad);
        }

        public void Eliminar(string id)
        {
            rep.Delete(id);
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
