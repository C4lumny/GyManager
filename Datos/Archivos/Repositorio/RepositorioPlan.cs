using Datos.Archivos;
using Entidades;
using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Datos.Archivos.Clase_Abstracta;
using Entidades.Informacion_Persona;
using System.Numerics;

namespace Datos
{
    public class RepositorioPlan : Abs_Repositorio<PlanGimnasio>, IUpdate<PlanGimnasio, string>
    {
        IConexion conexion;

        public RepositorioPlan(IConexion _connect)
        {
            conexion = _connect;
            MiVista("vista_planes_gimnasio");
        }

        protected override PlanGimnasio Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows)
                {
                    return null;
                }

                PlanGimnasio plan = new PlanGimnasio();
                plan.Id = dataReader.GetInt32(0);
                plan.Nombre = dataReader.GetString(1);
                plan.Precio = dataReader.IsDBNull(2) ? null : (double?)dataReader.GetDouble(2);
                plan.Descripcion = dataReader.GetString(3);
                plan.Dias = dataReader.GetInt32(4);

                return plan;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<PlanGimnasio> Insert(PlanGimnasio plan)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PLANES_GIMNASIO.p_insertarplan";

                    command.Parameters.Add("i_nombre", OracleDbType.Varchar2).Value = plan.Nombre;
                    command.Parameters.Add("i_precio", OracleDbType.Double).Value = plan.Precio;
                    command.Parameters.Add("i_descripcion", OracleDbType.Varchar2).Value = plan.Descripcion;
                    command.Parameters.Add("i_dias", OracleDbType.Int32).Value = plan.Dias;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<PlanGimnasio>(true, "Se ha registrado correctamente.", null, plan);
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(true, "No se ha registrado el plan.", null, plan);
            }
        }

        public Response<PlanGimnasio> Update(PlanGimnasio plan, string old_id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PLANES_GIMNASIO.p_actualizarplan";

                    command.Parameters.Add("old_id", OracleDbType.Int32).Value = old_id;
                    command.Parameters.Add("u_nombre", OracleDbType.Varchar2).Value = plan.Nombre;
                    command.Parameters.Add("u_precio", OracleDbType.Double).Value = plan.Precio;
                    command.Parameters.Add("u_descripcion", OracleDbType.Varchar2).Value = plan.Descripcion;
                    command.Parameters.Add("u_dias", OracleDbType.Int32).Value = plan.Dias;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<PlanGimnasio>(true, "Se ha actualizado correctamente.", null, plan);
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(false, "No se ha actualizado el plan.", null, plan);
            }
        }

        public Response<PlanGimnasio> Delete(string id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PLANES_GIMNASIO.p_eliminarplan";

                    command.Parameters.Add("d_id", OracleDbType.Int32).Value = id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<PlanGimnasio>(true, "Se ha eliminado correctamente.");
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(false, "No se ha eliminado el plan.");
            }
        }

    }
}
