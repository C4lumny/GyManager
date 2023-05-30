using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioClientes : ICRUD<Clientess>
    {
        public void Actualizar(Clientess entidad, int id)
        {
            throw new NotImplementedException();
        }

        public void Crear(Clientess entidad)
        {
            throw new NotImplementedException();
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
