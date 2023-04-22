using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Operacion_Clientes
    {
        public RepositorioUsuarios ar;
        protected Listas list;
        public Operacion_Clientes()
        {
            list = new Listas();
            ar = new RepositorioUsuarios();
        }
        protected bool Exist(string id_cliente)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_cliente) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true; // encontro una id existente.
            }
            return false; // no encontro.
        }
        
        public List<Cliente> GetLista()
        {
            if (list.GetListaCliente() == null)
            {
                return null;
            }
            return list.GetListaCliente(); // retorna la lista de los clientes de la clase Listas.
        } 
        public Cliente ReturnFromList(string id_cliente)
        {
            return GetLista().FirstOrDefault(item => item.id == id_cliente); // devuelve null si no encontro un item, devuelve el item de la lista de supervisores en el cado de que la condicion se cuampla.
        }
    }
}
