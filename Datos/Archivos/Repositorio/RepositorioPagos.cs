using Datos.Archivos.Clase_Abstracta;
using Entidades;
using Entidades.Informacion_Persona;
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
    public class RepositorioPagos : Abs_Repositorio<Pago>, IUpdate<Pago, int>
    {
        IConexion conexion;
        public RepositorioPagos(IConexion _connect)
        {
            conexion = _connect;
            MiVista("vista_pagos_inscripciones");
        }
        protected override Pago Mapper(OracleDataReader dataReader)
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
                pago.Inscripcion.Id = dataReader.GetInt32(3);
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
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PAGOS_INSCRIPCIONES.p_insertarpago";

                    command.Parameters.Add("i_valor_ingresado", OracleDbType.Double).Value = pago.ValorIngresado;
                    command.Parameters.Add("i_id_inscripcion", OracleDbType.Int32).Value = pago.Inscripcion.Id;

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

        public string Delete(int id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
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
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PAGOS_INSCRIPCIONES.p_actualizarpago";

                    command.Parameters.Add("old_id", OracleDbType.Int32).Value = old_id;
                    command.Parameters.Add("u_valor_ingresado", OracleDbType.Double).Value = pago.ValorIngresado;
                    command.Parameters.Add("u_id_inscripcion", OracleDbType.Int32).Value = pago.Inscripcion.Id;

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
