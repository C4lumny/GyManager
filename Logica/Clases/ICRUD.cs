using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica.Clases
{
    public interface ICRUD<T, Id_Type>
    {
        string Crear(T entidad);
        List<T> GetAll();
        string Actualizar(T entidad, Id_Type id);
        string Eliminar(Id_Type id);
    }

}
