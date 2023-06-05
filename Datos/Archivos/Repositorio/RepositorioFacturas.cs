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
                factura.Inscripcion.Descuento = dataReader.IsDBNull(5) ? null : (int?)dataReader.GetInt32(5);
                factura.Inscripcion.Precio = dataReader.IsDBNull(6) ? null : (int?)dataReader.GetDouble(6);
                factura.Inscripcion.Cliente.Id = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
                factura.Inscripcion.Cliente.Nombre = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
                factura.Inscripcion.Cliente.Apellido = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);
                factura.Inscripcion.Plan.Nombre = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                factura.Inscripcion.Plan.Precio = dataReader.IsDBNull(11) ? null : (int?)dataReader.GetDouble(11);
                return factura;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
