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
    public class ServicioClientes : ICRUD<Clientess>
    {
        RepositorioClientes rep = new RepositorioClientes();

        public ServicioClientes()
        {
            
        }

        public void Actualizar(Clientess entidad, int id)
        {
            rep.Update(entidad, id.ToString());
        }

        public void Crear(Clientess entidad)
        {
            rep.Insert(entidad);
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        Clientess ICRUD<Clientess>.Leer()
        {
            throw new NotImplementedException();
        }
    }
}
