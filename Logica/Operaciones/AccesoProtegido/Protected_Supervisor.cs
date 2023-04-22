using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Protected_Supervisor
    {
        protected Listas list;
        protected RepositorioUsuarios ar;
        public Protected_Supervisor()
        {
            list = new Listas();
            ar = new RepositorioUsuarios();
        }
        protected bool Exist(string id_supervisor)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_supervisor) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true; // encontro una id existente.
            }
            return false; // no encontro.
        }
        protected List<Supervisor> GetLista()
        {
            if (list.GetListaSupervisor() == null)
            {
                return null;
            }
            return list.GetListaSupervisor(); // retorna la lista de los supervisores de la clase Listas.
        }
    }
}
