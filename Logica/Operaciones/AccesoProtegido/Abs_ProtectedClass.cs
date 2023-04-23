using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.AccesoProtegido
{
    public abstract class Abs_ProtectedClass<T>
    {
        protected abstract List<T> GetLista();
        protected abstract bool Exist(string id);
    }
}
