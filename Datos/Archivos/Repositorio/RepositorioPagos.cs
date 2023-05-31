using Entidades;
using Entidades.Pagos_y_Facturas;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioPagos 
    {
        Coneccion conexion = new Coneccion();
        public RepositorioPagos()
        {
        }
        public Pago Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows)
                {
                    return null;
                }

                Pago pago = new Pago();
                pago.Id = dataReader.GetInt32(0);
                pago.ValorIngresado = dataReader.GetDouble(1);
                pago.FechaPago = dataReader.GetDateTime(2);
                pago.IdInscripcion = dataReader.GetInt32(3);
                return pago;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Pago> Insert(Pago pago)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PAGOS_INSCRIPCIONES.p_insertarpago";

                    command.Parameters.Add("i_valor_ingresado", OracleDbType.Double).Value = pago.ValorIngresado;
                    command.Parameters.Add("i_id_inscripcion", OracleDbType.Int32).Value = pago.IdInscripcion;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Pago>(true, "Se ha registrado el pago correctamente.", null, pago);
            }
            catch (Exception)
            {
                return new Response<Pago>(true, "No se ha registrado el pago.", null, pago);
            }
        }

        public List<Pago> GetAll()
        {
            List<Pago> pagos = new List<Pago>();
            var comando = conexion._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM vista_pagos_inscripciones";
            conexion.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                pagos.Add(Mapper(lector));
            }
            conexion.Close();
            return pagos;
        }

        public string Delete(int id)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PAGOS_INSCRIPCIONES.p_eliminarpago";

                    command.Parameters.Add("id_pago", OracleDbType.Int32).Value = id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha eliminado el pago.";
            }
            catch (Exception)
            {
                return "No se ha eliminado el pago.";
            }
        }

        public string Update(Pago pago, int old_id)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PAGOS_INSCRIPCIONES.p_actualizarpago";

                    command.Parameters.Add("old_id", OracleDbType.Int32).Value = old_id;
                    command.Parameters.Add("u_valor_ingresado", OracleDbType.Double).Value = pago.ValorIngresado;
                    command.Parameters.Add("u_id_inscripcion", OracleDbType.Int32).Value = pago.IdInscripcion;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha actualizado el pago correctamente.";
            }
            catch (Exception)
            {
                return "No se ha actualizado el pago.";
            }
        }
    }
}
