using Datos.Archivos.Clase_Abstracta;
using Datos.Archivos.Clases_Abstractas_e_Interfaces;
using Entidades;
using Entidades.DTOHorarios;
using Entidades.Informacion_Persona;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
namespace Datos.Archivos.Repositorio
{
    public class RepositorioTurnos //: IAsignarYDesasignar
    {
        //IConexion conexion;
        //public RepositorioTurnos(IConexion _connect)
        //{
        //    conexion = _connect;
        //    MiVista("vista_clientes");
        //}
        //public Dtohorarios Mapper(OracleDataReader dataReader)
        //{
        //    try
        //    {
        //        if (!dataReader.HasRows) { return null; }
        //        Dtohorarios dtohorarios = new Dtohorarios();
        //        dtohorarios.Supervisor_Id = dataReader.GetString(0);
        //        dtohorarios.Supervisor_nombres = dataReader.GetString(1);
        //        dtohorarios.Supervisor_apellidos = dataReader.GetString(2);
        //        dtohorarios.Turno_id = dataReader.GetInt32(3).ToString();
        //        dtohorarios.Dia = dataReader.GetString(4);
        //        dtohorarios.HoraEntrada = dataReader.GetDateTime(5).ToShortTimeString();
        //        dtohorarios.HoraSalida = dataReader.GetDateTime(6).ToShortTimeString();
        //        return dtohorarios;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public Response<Turno_Atencion> Asignar(Turno_Atencion turno, string id_sup)
        //{
        //    try
        //    {
        //        using (OracleCommand command = conexion._conexion.CreateCommand())
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "PKG_TURNOS_ATENCION.p_asignarturno";

        //            command.Parameters.Add("a_id_sup", OracleDbType.Varchar2).Value = id_sup;
        //            command.Parameters.Add("a_dia", OracleDbType.Varchar2).Value = turno.Dia;
        //            command.Parameters.Add("a_hora_entrada", OracleDbType.Date).Value = turno.HoraEntrada;
        //            command.Parameters.Add("a_hora_salida", OracleDbType.Date).Value = turno.HoraSalida;

        //            conexion.Open();
        //            command.ExecuteNonQuery();
        //            conexion.Close();
        //        }
        //        return new Response<Turno_Atencion>(true, "Se ha registrado correctamente.", null, turno);
        //    }
        //    catch (Exception)
        //    {
        //        return new Response<Turno_Atencion>(true, "No se ha registrado el turno.", null, turno);
        //    }
        //}

        //public string Delete(int id_sup, string id_turno)
        //{
        //    try
        //    {
        //        using (OracleCommand command = conexion._conexion.CreateCommand())
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "PKG_TURNOS_ATENCION.p_eliminarturnosupervisor";

        //            command.Parameters.Add("e_id_sup", OracleDbType.Int32).Value = id_sup;
        //            command.Parameters.Add("e_id_turno", OracleDbType.Int32).Value = id_turno;

        //            conexion.Open();
        //            command.ExecuteNonQuery();
        //            conexion.Close();
        //        }
        //        return "Se ha eliminado el turno.";
        //    }
        //    catch (Exception)
        //    {
        //        return "No se ha realizado la eliminación del turno.";
        //    }
        //}

        //public List<Dtohorarios> GetAll()
        //{
        //    List<Dtohorarios> turnos = new List<Dtohorarios>();
        //    var comando = conexion._conexion.CreateCommand();
        //    comando.CommandText = "SELECT * FROM vista_horarios";
        //    conexion.Open();
        //    OracleDataReader lector = comando.ExecuteReader();
        //    while (lector.Read())
        //    {
        //        turnos.Add(Mapper(lector));
        //    }
        //    conexion.Close();
        //    return turnos;
        //}
    }
}
