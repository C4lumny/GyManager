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
        public void Actualizar(Inscripcion entidad, string id)
        {
            rep.Update(entidad, id);
        }

        public void Crear(Inscripcion entidad)
        {
            rep.Insert(entidad);
        }

        public void Eliminar(string id)
        {
            rep.Delete(id);
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
