using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public interface IGetBySearch<T>
    {
        List<T> GetListBySearch(string search);
        T GetObjectById(string id);
    }
}
