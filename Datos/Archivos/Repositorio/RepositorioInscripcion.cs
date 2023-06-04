using Datos.Archivos;
using Datos.Archivos.Clase_Abstracta;
using Entidades;
using Entidades.Informacion_Persona;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace Datos
{
    public class RepositorioInscripcion : Abs_Repositorio<Inscripcion>, IUpdate<Inscripcion, string>
    {
        IConexion conexion;
        public RepositorioInscripcion(IConexion _connect)
        {
            conexion = _connect;
            MiVista("vista_inscripciones");
        }
        protected override Inscripcion Mapper(OracleDataReader dataReader)
        {
            try
            {

                if (!dataReader.HasRows) { return null; }
                Inscripcion inscripcion = new Inscripcion();
                inscripcion.Cliente = new Clientess();
                inscripcion.Supervisor = new Supervisoress();
                inscripcion.Plan = new PlanGimnasio();

                inscripcion.Id = dataReader.IsDBNull(0) ? null : (int?)dataReader.GetInt32(0);
                inscripcion.FechaInicio = dataReader.GetDateTime(1);
                inscripcion.FechaFinal = dataReader.GetDateTime(2);
                inscripcion.Precio = dataReader.GetDouble(3);
                inscripcion.Descuento = dataReader.GetInt32(4);

                inscripcion.Cliente.Id = dataReader.GetString(5);
                inscripcion.Cliente.Nombre = dataReader.GetString(6);
                inscripcion.Cliente.Apellido = dataReader.GetString(7);
                inscripcion.Supervisor.Id = dataReader.IsDBNull(8) ? "NULL" : dataReader.GetString(8);
                inscripcion.Supervisor.Nombre = dataReader.GetString(9);
                inscripcion.Supervisor.Apellido = dataReader.GetString(10);
                inscripcion.Plan.Nombre = dataReader.GetString(11);
                inscripcion.IdEstado = dataReader.GetString(12);

                return inscripcion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el mapeo de datos: " + ex.Message);
                return null;
            }
        }
        public Response<Inscripcion> Insert(Inscripcion inscripcion)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_INSCRIPCIONES.p_insertarinscripcion";

                    command.Parameters.Add("i_descuento", OracleDbType.Int32).Value = inscripcion.Descuento;
                    command.Parameters.Add("i_cliente_id", OracleDbType.Varchar2).Value = inscripcion.Cliente.Id;
                    command.Parameters.Add("i_supervisor_id", OracleDbType.Varchar2).Value = inscripcion.Supervisor.Id;
                    command.Parameters.Add("i_plan_id", OracleDbType.Int32).Value = inscripcion.Plan.Id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Inscripcion>(true, "Se ha registrado correctamente.", null, inscripcion);
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "No se ha registrado la inscripcion.", null, inscripcion);

            }
        }
        public Response<Inscripcion> Delete(string id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_INSCRIPCIONES.p_eliminarinscripcion";

                    command.Parameters.Add("id_cliente_or_inscripcion", OracleDbType.Varchar2).Value = id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();

                }
                return new Response<Inscripcion>(true, "Se ha eliminado correctamente.");
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "No se ha eliminado la inscripcion.");

            }


        }
        public Response<Inscripcion> Update(Inscripcion inscripcion, string old_id)
        {

            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_INSCRIPCIONES.p_actualizarinscripcion";

                    command.Parameters.Add("old_id", OracleDbType.Varchar2).Value = old_id;
                    command.Parameters.Add("u_fecha_inicio", OracleDbType.Date).Value = inscripcion.FechaInicio;
                    command.Parameters.Add("u_descuento", OracleDbType.Int32).Value = inscripcion.Descuento;
                    command.Parameters.Add("u_cliente_id", OracleDbType.Varchar2).Value = inscripcion.Cliente.Id;
                    command.Parameters.Add("u_supervisor_id", OracleDbType.Varchar2).Value = inscripcion.Supervisor.Id;
                    command.Parameters.Add("u_plan_id", OracleDbType.Int32).Value = inscripcion.Plan.Id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Inscripcion>(true, "Se ha actualizado correctamente.", null, inscripcion);
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "No se ha aztualizado la inscripcion.", null, inscripcion);

            }

        }
    }
}
