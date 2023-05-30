using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public interface ICRUD<T>
    {
        void Crear(T entidad);
        T Leer();
        void Actualizar(T entidad, int id);
        void Eliminar(int id);
    }

}
