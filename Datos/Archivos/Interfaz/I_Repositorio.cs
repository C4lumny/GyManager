using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos
{
    public interface I_Repositorio<T>
    {
        Response<T> Save(T dato);
        T Mapper(string linea);
        List<T> Load();
        bool Update(List<T> list);
    }
}
