using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public interface IAdministrador
    {
        string Crear(Administrador entidad);

        string Eliminar(string id);
    }
}
