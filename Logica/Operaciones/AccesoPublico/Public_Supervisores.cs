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
            return GetMainList().FirstOrDefault(item => item.id == id_supervisor); 
        }
    }
}
