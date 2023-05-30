using Datos.Archivos;
using Entidades;
using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace Datos
{
    public class RepositorioPlan
    {
        Coneccion conexion = new Coneccion();

        protected string ruta = "Planes .txt"; 
        public RepositorioPlan()
        {
        }

        public PlanGimnasio Mapper(OracleDataReader dataReader)
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
                plan.Precio = dataReader.GetDouble(2);
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
                using (OracleCommand command = conexion._conexion.CreateCommand())
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

        public string Update(PlanGimnasio plan, string old_id)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
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
                return "Se ha actualizado correctamente.";
            }
            catch (Exception)
            {
                return "No se ha actualizado el plan.";
            }
        }

        public string Delete(string id)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_PLANES_GIMNASIO.p_eliminarplan";

                    command.Parameters.Add("d_id", OracleDbType.Int32).Value = id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha eliminado el plan.";
            }
            catch (Exception)
            {
                return "No se ha realizado la eliminación.";
            }
        }

        public List<PlanGimnasio> GetAll()
        {
            List<PlanGimnasio> planes = new List<PlanGimnasio>();
            var comando = conexion._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM Planes_Gimnasio";
            conexion.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                planes.Add(Mapper(lector));
            }
            conexion.Close();
            return planes;
        }

    }
}
