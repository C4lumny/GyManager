using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CRUD.Interfaz
{
    public interface IListas<T>
    {
        List<T> GetLista();

    }
}
