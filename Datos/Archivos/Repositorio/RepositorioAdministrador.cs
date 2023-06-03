using Entidades;
using Entidades.Administrador;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioAdministrador
    {
        ConexionOracle conexion = new ConexionOracle();
        public RepositorioAdministrador() 
        {
        }
        public Response<Administrador> Insert(Administrador administrador)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "pkg_administradores.p_insertaradministrador";

                    command.Parameters.Add("i_username", OracleDbType.Varchar2).Value = administrador.UserName;
                    command.Parameters.Add("i_password", OracleDbType.Varchar2).Value = administrador.Password;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Administrador>(true, "Se ha insertado el administrador correctamente.");
            }
            catch (Exception)
            {
                return new Response<Administrador>(false, "No se ha podido insertar el administrador.");
            }
        }

        public string Delete(string userName)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "pkg_administradores.p_eliminardministrador";

                    command.Parameters.Add("d_username", OracleDbType.Varchar2).Value = userName;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha eliminado el administrador correctamente.";
            }
            catch (Exception)
            {
                return "No se ha podido eliminar el administrador.";
            }
        }
    }
}
