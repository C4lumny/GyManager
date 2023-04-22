using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Protected_Clientes
    {
        public RepositorioUsuarios ar;
        protected Listas list;
        public Protected_Clientes()
        {
            list = new Listas();
            ar = new RepositorioUsuarios();
        }
        protected List<Cliente> GetLista()
        {
            var lista = list.GetListaCliente();
            if (lista == null)
            {
                return null;
            }
            return lista; // retorna la lista de los clientes de la clase Listas.
        }
        protected bool Exist(string id_cliente)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_cliente) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true; // encontro una id existente.
            }
            return false; // no encontro.
        }
    }
}
