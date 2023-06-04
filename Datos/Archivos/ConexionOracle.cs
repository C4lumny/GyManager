using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using Datos.Archivos.Clase_Abstracta;

namespace Datos.Archivos
{
    public class ConexionOracle : IConexion
    {
        public OracleConnection _conexion;
        public ConexionOracle()
        {
            _conexion = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XEPDB1)));User Id=Aisaac;Password=isaacdavid1234;");
        }
        public void Open()
        {
            _conexion.Open();
        }
        public void Close()
        {
            _conexion.Close();
        }
        public OracleConnection ObtenerConexion()
        {
            return _conexion;
        }
    }
}
