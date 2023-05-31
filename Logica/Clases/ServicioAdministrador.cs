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


        public void Crear(Administrador entidad)
        {
            rep.Insert(entidad);
        }

        public void Eliminar(string id)
        {
            rep.Delete(id);
        }

    }
}
