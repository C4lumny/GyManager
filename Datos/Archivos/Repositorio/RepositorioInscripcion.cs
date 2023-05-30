using Datos.Archivos;
using Entidades;
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
    public class RepositorioInscripcion
    {
        Coneccion conexion = new Coneccion();
        public RepositorioInscripcion()
        {
        }
        public Inscripcion Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows) { return null; }
                Inscripcion inscripcion = new Inscripcion();
                inscripcion.Id = dataReader.GetInt32(0);
                inscripcion.FechaInicio = dataReader.GetDateTime(1);
                inscripcion.FechaFinal = dataReader.GetDateTime(2);
                inscripcion.Precio = dataReader.GetDouble(3);
                inscripcion.Descuento = dataReader.GetInt32(4);
                inscripcion.ClienteId = dataReader.GetString(5);
                inscripcion.SupervisorId = dataReader.GetString(6);
                inscripcion.PlanId = dataReader.GetInt32(7);
                inscripcion.IdEstado = dataReader.GetInt32(8);
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
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_INSCRIPCIONES.p_insertarinscripcion";

                    command.Parameters.Add("i_descuento", OracleDbType.Int32).Value = inscripcion.Descuento;
                    command.Parameters.Add("i_cliente_id", OracleDbType.Varchar2).Value = inscripcion.ClienteId;
                    command.Parameters.Add("i_supervisor_id", OracleDbType.Varchar2).Value = inscripcion.SupervisorId;
                    command.Parameters.Add("i_plan_id", OracleDbType.Int32).Value = inscripcion.PlanId;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Inscripcion>(true, "Se ha registrado correctamente.", null, inscripcion);
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(true, "No se ha registrado la inscripcion.", null, inscripcion);

            }
        }
        public List<Inscripcion> GetAll()
        {
            List<Inscripcion> clientes = new List<Inscripcion>();
            var comando = conexion._conexion.CreateCommand();
            comando.CommandText = "select * from Personas";
            conexion.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                clientes.Add(Mapper(lector));
            }
            conexion.Close();
            return clientes;
        }

        public string Delete(string id)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_INSCRIPCIONES.p_eliminarinscripcion";

                    command.Parameters.Add("id_cliente_or_inscripcion", OracleDbType.Varchar2).Value = id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();

                }
                return "Se ha eliminado la inscripcion ";
            }
            catch (Exception)
            {
                return "No se ha realizado la eliminacion";
            }


        }
        public string Update(Inscripcion inscripcion, string old_id)
        {

            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_INSCRIPCIONES.p_actualizarinscripcion";

                    command.Parameters.Add("old_id", OracleDbType.Varchar2).Value = old_id;
                    command.Parameters.Add("u_fecha_inicio", OracleDbType.Date).Value = inscripcion.FechaInicio;
                    command.Parameters.Add("u_descuento", OracleDbType.Int32).Value = inscripcion.Descuento;
                    command.Parameters.Add("u_cliente_id", OracleDbType.Varchar2).Value = inscripcion.ClienteId;
                    command.Parameters.Add("u_supervisor_id", OracleDbType.Varchar2).Value = inscripcion.SupervisorId;
                    command.Parameters.Add("u_plan_id", OracleDbType.Int32).Value = inscripcion.PlanId;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha actualizado correctamente.";
            }
            catch (Exception)
            {
                return "No se ha actualizado la inscripcion.";

            }

        }
    }
}
