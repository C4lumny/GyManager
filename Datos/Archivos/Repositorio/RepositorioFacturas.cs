using Datos.Archivos.Clase_Abstracta;
using Entidades;
using Entidades.Informacion_Persona;
using Entidades.Pagos_y_Facturas;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioFacturas : Abs_Repositorio<Facturas>
    {
        IConexion conexion;
        public RepositorioFacturas(IConexion _connect)
        {
            conexion = _connect;
            MiVista("vista_facturas");
        }
        protected override Facturas Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows) { return null; }
                Facturas factura = new Facturas();
                factura.Id = dataReader.IsDBNull(0) ? null : (int?)dataReader.GetInt32(0);
                factura.PagoIngresado = dataReader.GetDouble(1);
                factura.Subtotal = dataReader.GetDouble(2);
                factura.Saldo = dataReader.GetDouble(3);
                factura.Inscripcion.Id = dataReader.IsDBNull(4) ? null : (int?)dataReader.GetInt32(4);
                return factura;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
