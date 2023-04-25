using Entidades;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CRUD
{
    public class CRUD_HorarioSupervisor : Public_Supervisores, I_CRUD<Supervisor>
    {
        public CRUD_HorarioSupervisor()
        {
            
        }

        public Response<Supervisor> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Supervisor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<Supervisor> Save(Supervisor supervisor)
        {
            throw new NotImplementedException();
        }

        public Response<Supervisor> Update(Supervisor supervisor, string id)
        {
            throw new NotImplementedException();
        }
    }
}
