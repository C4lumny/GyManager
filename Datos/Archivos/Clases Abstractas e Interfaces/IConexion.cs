using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Archivos.Clase_Abstracta
{
    public interface IConexion
    {
        OracleConnection ObtenerConexion();
        void Open();
        void Close();
    }
}
