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
        public void asignar(Discapacidad entidad, string id)
        {
            rep.AsignarDiscapacidad(id, entidad);
        }

        public void eliminar(Discapacidad entidad, string id)
        {
            rep.EliminarDiscapacidadCliente(id, entidad);
        }

    }
}
