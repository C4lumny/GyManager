using Datos.Archivos;
using Datos.Archivos.Clase_Abstracta;
using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Datos
{
    public class RepositorioClientes : Abs_Repositorio<Clientess>, IUpdate<Clientess, string>
    {
        IConexion conexion;

        public RepositorioClientes(IConexion _connect)
        {
            conexion = _connect;
            MiVista("vista_clientes");
        }

        protected override Clientess Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows) { return null; }
                Clientess cliente = new Clientess();
                cliente.Id = dataReader.GetString(0);
                cliente.Nombre = dataReader.GetString(1);
                cliente.Apellido = dataReader.GetString(2);
                cliente.Genero = dataReader.GetString(3); 
                cliente.Telefono = dataReader.GetString(4);
                cliente.Fecha_nacimiento = dataReader.GetDateTime(5);
                cliente.Fecha_ingreso = dataReader.GetDateTime(6);

                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Response<Clientess> Insert(Clientess cliente)
        {
            try
            {
            using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PKG_CLIENTE.p_insertarcliente";

                command.Parameters.Add("i_id", OracleDbType.Varchar2).Value = cliente.Id;
                command.Parameters.Add("i_nombres", OracleDbType.Varchar2).Value = cliente.Nombre;
                command.Parameters.Add("i_apellidos", OracleDbType.Varchar2).Value = cliente.Apellido;
                command.Parameters.Add("i_genero", OracleDbType.Varchar2).Value = cliente.Genero;
                command.Parameters.Add("i_telefono", OracleDbType.Varchar2).Value = cliente.Telefono;
                command.Parameters.Add("i_fecha_nacimiento", OracleDbType.Date).Value = cliente.Fecha_nacimiento; // Asigna la fecha de nacimiento adecuada

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
            }
            return new Response<Clientess>(true, "Se ha registrado correctamente.", null, cliente);
            }
            catch (Exception)
            {
                return new Response<Clientess>(true, "No se ha registrado al cliente.", null, cliente);
               
            }
        }
        public string Delete(string id_cliente)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_CLIENTE.p_eliminarcliente";

                    // Configura los parámetros del procedimiento almacenado
                    command.Parameters.Add("d_id", OracleDbType.Varchar2).Value = id_cliente;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();

                }
                return "Se ha eliminado el cliente";
            }
            catch (Exception)
            {
                return "No se ha realizado la actualizacion";
            }
        }
        public string DeleteAll()
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_CLIENTE.p_eliminartodocliente";
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();

                }
                return "Se ha eliminado el cliente";
            }
            catch (Exception)
            {
                return "No se ha realizado la actualizacion";
            }
        }
        public string Update(Clientess cliente, string old_id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_CLIENTE.p_actualizarcliente";

                    // Configura los parámetros del procedimiento almacenado
                    command.Parameters.Add("old_id", OracleDbType.Varchar2).Value = old_id;
                    command.Parameters.Add("u_id", OracleDbType.Varchar2).Value = cliente.Id;
                    command.Parameters.Add("u_nombres", OracleDbType.Varchar2).Value = cliente.Nombre;
                    command.Parameters.Add("u_apellidos", OracleDbType.Varchar2).Value = cliente.Apellido;
                    command.Parameters.Add("u_genero", OracleDbType.Varchar2).Value = cliente.Genero;
                    command.Parameters.Add("u_telefono", OracleDbType.Varchar2).Value = cliente.Telefono;
                    command.Parameters.Add("u_fecha_nacimiento", OracleDbType.Date).Value = cliente.Fecha_nacimiento;
                    command.Parameters.Add("u_fecha_ingreso", OracleDbType.Date).Value = cliente.Fecha_ingreso;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();

                }
                return "Se ha actualizado el cliente";
            }
            catch (Exception)
            {
                return "No se ha realizado la actualizacion";
            }
        }
    }

}
