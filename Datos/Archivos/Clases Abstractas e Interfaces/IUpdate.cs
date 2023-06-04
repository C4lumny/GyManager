using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos.Clase_Abstracta
{
    public interface IUpdate<T, Id_Type> : IDeleteAndInsert<T, Id_Type>
    {
        Response<T> Update(T cliente, Id_Type old_id);
    }
}
