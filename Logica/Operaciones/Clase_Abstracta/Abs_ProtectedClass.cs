using System.Collections.Generic;

namespace Logica.Operaciones.AccesoProtegido
{
    public abstract class Abs_ProtectedClass<T>
    {
        protected abstract List<T> GetMainList();
        protected abstract bool Exist(string id);
    }
}
