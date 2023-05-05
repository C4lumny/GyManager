using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public interface I_CRUD<T> // Interfaz implementada en las clases de la capa Logica.
    {
        Response<T> Delete(string id);
        Response<T> Save(T obj);
        Response<T> Update(T obj_update, string id); 
        List<T> GetAll();
    }
}
