using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Supervisores: Protected_Supervisor
    {
        public Public_Supervisores()
        {
            
        }
        public Supervisor ReturnFromList(string id_supervisor)
        {
            return GetLista().FirstOrDefault(item => item.id == id_supervisor); // devuelve null si no encontro un item, devuelve el item de la lista de supervisores en el cado de que la condicion se cuampla.
        }
    }
}
