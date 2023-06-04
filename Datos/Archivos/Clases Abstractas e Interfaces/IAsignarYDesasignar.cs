using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos.Clases_Abstractas_e_Interfaces
{
    public interface IAsignarYDesasignar<T>
    {
        Response<T> Asignar();
        Response<T> Desasignar();
    }
}
