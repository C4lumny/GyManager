using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Archivos.Clase_Abstracta
{
    public interface IDeleteAndInsert<T, Id_Type>
    {
        Response<T> Insert(T cliente);
        string Delete(Id_Type id_cliente);
    }
}
