using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public interface ICRUD<T> // Interfaz implementada en las clases de la capa Logica.
    {
        Response<T> Delete(string id);
        List<T> GetBySearch(string id);
        Response<T> Save(T obj);
        Response<T> Update(T obj, string id);
    }
}
