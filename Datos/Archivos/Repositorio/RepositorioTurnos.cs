using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
namespace Datos.Archivos.Repositorio
{
    public class RepositorioTurnos 
    {
        Coneccion conexion = new Coneccion();
        public RepositorioTurnos()
        { 
        }
        public Turno_Atencion Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows)
                {
                    return null;
                }

                Turno_Atencion turno = new Turno_Atencion();
                turno.Id = dataReader.GetInt32(0);
                turno.Dia = dataReader.GetString(1);
                turno.HoraEntrada = dataReader.GetDateTime(2);
                turno.HoraSalida = dataReader.GetDateTime(3);

                return turno;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Turno_Atencion> Insert(Turno_Atencion turno)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_TURNOS_ATENCION.p_insertarturno";

                    command.Parameters.Add("i_dia", OracleDbType.Varchar2).Value = turno.Dia;
                    command.Parameters.Add("i_hora_entrada", OracleDbType.Date).Value = turno.HoraEntrada;
                    command.Parameters.Add("i_hora_salida", OracleDbType.Date).Value = turno.HoraSalida;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Turno_Atencion>(true, "Se ha registrado correctamente.", null, turno);
            }
            catch (Exception)
            {
                return new Response<Turno_Atencion>(true, "No se ha registrado el turno.", null, turno);
            }
        }

        public string Update(Turno_Atencion turno, int old_id)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_TURNOS_ATENCION.p_actualizarturno";

                    command.Parameters.Add("old_id", OracleDbType.Int32).Value = old_id;
                    command.Parameters.Add("u_dia", OracleDbType.Varchar2).Value = turno.Dia;
                    command.Parameters.Add("u_hora_entrada", OracleDbType.Date).Value = turno.HoraEntrada;
                    command.Parameters.Add("u_hora_salida", OracleDbType.Date).Value = turno.HoraSalida;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha actualizado correctamente.";
            }
            catch (Exception)
            {
                return "No se ha actualizado el turno.";
            }
        }

        public string Delete(int id)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_TURNOS_ATENCION.p_eliminarturno";

                    command.Parameters.Add("d_id", OracleDbType.Int32).Value = id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha eliminado el turno.";
            }
            catch (Exception)
            {
                return "No se ha realizado la eliminación del turno.";
            }
        }

        public List<Turno_Atencion> GetAll()
        {
            List<Turno_Atencion> turnos = new List<Turno_Atencion>();
            var comando = conexion._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM Turnos_Atencion";
            conexion.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                turnos.Add(Mapper(lector));
            }
            conexion.Close();
            return turnos;
        }
    }
}
