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
        Response<T> Crear(T entidad);
        List<T> GetAll();
        Response<T> Actualizar(T entidad, Id_Type id);
        Response<T> Eliminar(Id_Type id);
    }

}
