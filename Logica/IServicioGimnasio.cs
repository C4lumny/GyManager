using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public interface IServicioGimnasio<T> // Interfaz implementada en las clases de la capa Logica.
    {
        List<T> GetLista();
        int Save(T dato);
        int Update(T dato);
        bool Delete(T dato);
        int GetPositionByID(string id);
        int GetPositionByName(string nombre);
        bool Exist(T dato);
        T GetBySearch(string search);
    }
}
