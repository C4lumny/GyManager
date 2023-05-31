using Datos;
using Datos.Archivos.Repositorio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioInscripcion 
    {
        RepositorioInscripcion rep = new RepositorioInscripcion();
        public ServicioInscripcion()
        {
            
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

        public List<Inscripcion> Leer()
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
