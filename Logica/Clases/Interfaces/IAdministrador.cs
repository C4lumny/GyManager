using Entidades;
using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public abstract class IAdministrador
    {
        public abstract Response<Administrador> ValidarAdmin(Administrador entidad);
        protected abstract List<Administrador> GetAll();
    }
}
