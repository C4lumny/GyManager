using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Archivos.Repositorio;
using Datos;

namespace Logica.Clases
{
    public class ServicioClientes 
    {
        RepositorioClientes rep = new RepositorioClientes();

        public ServicioClientes()
        {
            
        }

        public string Actualizar(Clientess entidad, int id)
        {
            return rep.Update(entidad, id.ToString());
        }

        public string Crear(Clientess entidad)
        {
            return rep.Insert(entidad).Msg;
        }

        public string Eliminar(int id)
        {
           return rep.Delete(id.ToString());
        }
        public List<Clientess> Leer() { 
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }

    }
}
