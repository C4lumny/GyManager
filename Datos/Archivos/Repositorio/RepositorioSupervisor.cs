using Datos.Archivos.Clase_Abstracta;
using Entidades;
using Entidades.Informacion_Persona;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Datos.Archivos
{
    public class RepositorioSupervisor : Abs_Repositorio<Supervisoress>, IUpdate<Supervisoress, string>
    {
        IConexion conexion;
        public RepositorioSupervisor(IConexion _connect)
        {
            conexion = _connect;
            MiVista("vista_supervisores");
        }


        protected override Supervisoress Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows)
                {
                    return null;
                }

                Supervisoress supervisor = new Supervisoress();
                supervisor.Id = dataReader.IsDBNull(0) ? null : dataReader.GetString(0);
                supervisor.Nombre = dataReader.IsDBNull(1) ? null : dataReader.GetString(1);
                supervisor.Apellido = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                supervisor.Genero = dataReader.IsDBNull(3) ? null : dataReader.GetString(3);
                supervisor.Telefono = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
                supervisor.Fecha_nacimiento = dataReader.IsDBNull(5) ? DateTime.MinValue : dataReader.GetDateTime(5);
                supervisor.Correo = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
                supervisor.Fecha_ingreso = dataReader.IsDBNull(7) ? DateTime.MinValue : dataReader.GetDateTime(7);


                return supervisor;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Supervisoress> Insert(Supervisoress supervisor)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_SUPERVISORES.p_insertarsupervisor";

                    command.Parameters.Add("i_id", OracleDbType.Varchar2).Value = supervisor.Id;
                    command.Parameters.Add("i_nombres", OracleDbType.Varchar2).Value = supervisor.Nombre;
                    command.Parameters.Add("i_apellidos", OracleDbType.Varchar2).Value = supervisor.Apellido;
                    command.Parameters.Add("i_genero", OracleDbType.Varchar2).Value = supervisor.Genero;
                    command.Parameters.Add("i_telefono", OracleDbType.Varchar2).Value = supervisor.Telefono;
                    command.Parameters.Add("i_fecha_nacimiento", OracleDbType.Date).Value = supervisor.Fecha_nacimiento;
                    command.Parameters.Add("i_correo", OracleDbType.Varchar2).Value = supervisor.Correo;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Supervisoress>(true, "Se ha registrado correctamente.", null, supervisor);
            }
            catch (Exception)
            {
                return new Response<Supervisoress>(false, "No se ha registrado el supervisor.", null, supervisor);
            }
        }

        public Response<Supervisoress> Update(Supervisoress supervisor, string old_id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_SUPERVISORES.p_actualizarsupervisor";

                    command.Parameters.Add("old_id", OracleDbType.Varchar2).Value = old_id;
                    command.Parameters.Add("u_id", OracleDbType.Varchar2).Value = supervisor.Id;
                    command.Parameters.Add("u_nombres", OracleDbType.Varchar2).Value = supervisor.Nombre;
                    command.Parameters.Add("u_apellidos", OracleDbType.Varchar2).Value = supervisor.Apellido;
                    command.Parameters.Add("u_genero", OracleDbType.Varchar2).Value = supervisor.Genero;
                    command.Parameters.Add("u_telefono", OracleDbType.Varchar2).Value = supervisor.Telefono;
                    command.Parameters.Add("u_fecha_nacimiento", OracleDbType.Date).Value = supervisor.Fecha_nacimiento;
                    command.Parameters.Add("u_correo", OracleDbType.Varchar2).Value = supervisor.Correo;
                    command.Parameters.Add("u_fecha_ingreso", OracleDbType.Date).Value = supervisor.Fecha_ingreso;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Supervisoress>(true, "Se ha actualizado correctamente.", null, supervisor);
            }
            catch (Exception)
            {
                return new Response<Supervisoress>(false, "No se ha azctualizado el supervisor.", null, supervisor);
            }
        }

        public Response<Supervisoress> Delete(string id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_SUPERVISORES.p_eliminarsupervisor";

                    command.Parameters.Add("d_id", OracleDbType.Varchar2).Value = id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Supervisoress>(true, "Se ha eliminado correctamente.");
            }
            catch (Exception)
            {
                return new Response<Supervisoress>(false, "No se ha eliminado el supervisor.");
            }
        }

    }
}
