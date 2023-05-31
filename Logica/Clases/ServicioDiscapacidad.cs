using Datos.Archivos.Repositorio;
using Entidades.Informacion_Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioDiscapacidad 
    {
        RepositorioDiscapacidades rep = new RepositorioDiscapacidades();

        public ServicioDiscapacidad()
        {
            
        }
        public string asignar(Discapacidad entidad, string id)
        {
            return rep.AsignarDiscapacidad(id, entidad).Msg;
        }

        public string eliminar(Discapacidad entidad, string id)
        {
            return rep.EliminarDiscapacidadCliente(id, entidad).Msg;
        }

    }
}
