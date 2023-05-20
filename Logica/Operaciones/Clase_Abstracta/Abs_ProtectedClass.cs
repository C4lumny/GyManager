using System.Collections.Generic;

namespace Logica.Operaciones.AccesoProtegido
{
    public abstract class Abs_ProtectedClass<T>
    {
        public Abs_ProtectedClass()
        {

        }
        protected abstract List<T> GetMainList();
        protected abstract bool Exist(string id);
    }
} 
