using Entidades;
using Entidades.Pagos_y_Facturas;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioFacturas
    {
        Coneccion conexion = new Coneccion();
        public RepositorioFacturas()
        {
                
        }
        public Facturas Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows) { return null; }
                Facturas factura = new Facturas();
                factura.Id = dataReader.GetInt32(0);
                factura.PagoIngresado = dataReader.GetDouble(1);
                factura.Subtotal = dataReader.GetDouble(2);
                factura.Saldo = dataReader.GetDouble(3);
                factura.IdInscripcion = dataReader.GetInt32(4);
                return factura;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Facturas> GetAll()
        {
            conexion.Open();
            List<Facturas> Facturas = new List<Facturas>();
            var comando = conexion._conexion.CreateCommand();
            comando.CommandText = "select * from vista_facturas";
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Facturas.Add(Mapper(lector));
            }
            conexion.Close();
            return Facturas;
        }
    }
}
