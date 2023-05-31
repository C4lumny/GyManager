using Datos;
using Datos.Archivos.Repositorio;
using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioAdministrador 
    {
        RepositorioAdministrador rep = new RepositorioAdministrador();


        public string Crear(Administrador entidad)
        {

               return rep.Insert(entidad).Msg;

        }

        public string Eliminar(string id)
        {
                return rep.Delete(id);
        }

    }
}
