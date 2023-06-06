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
                cliente.Id = dataReader.IsDBNull(0) ? null : dataReader.GetString(0);
                cliente.Nombre = dataReader.IsDBNull(1) ? null : dataReader.GetString(1);
                cliente.Apellido = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                cliente.Genero = dataReader.IsDBNull(3) ? null : dataReader.GetString(3);
                cliente.Telefono = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
                cliente.Fecha_nacimiento = dataReader.IsDBNull(5) ? DateTime.MinValue : dataReader.GetDateTime(5);
                cliente.Fecha_ingreso = dataReader.IsDBNull(6) ? DateTime.MinValue : dataReader.GetDateTime(6);

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
                    command.Parameters.Add("i_altura", OracleDbType.Decimal).Value = Math.Round(double.Parse(cliente.datosBiomedicos.Altura.ToString()), 2);
                    command.Parameters.Add("i_peso", OracleDbType.Decimal).Value = Math.Round(double.Parse(cliente.datosBiomedicos.Peso.ToString()), 2);
                    command.Parameters.Add("i_grasa", OracleDbType.Decimal).Value = Math.Round(double.Parse(cliente.datosBiomedicos.GrasaCorporal.ToString()), 2);
                    command.Parameters.Add("i_frecuencia", OracleDbType.Decimal).Value = Math.Round(double.Parse(cliente.datosBiomedicos.FrecuenciaCardiaca.ToString()), 2);
                    command.Parameters.Add("i_presion", OracleDbType.Decimal).Value = Math.Round(double.Parse(cliente.datosBiomedicos.PresionArterial.ToString()), 2);
                    command.Parameters.Add("i_fecha_nacimiento", OracleDbType.Date).Value = cliente.Fecha_nacimiento;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<Clientess>(true, "Se ha registrado correctamente.", null, cliente);
            }
            catch (Exception)
            {
                return new Response<Clientess>(false, "No se ha registrado al cliente.", null, cliente);
            }
        }
        public Response<Clientess> Delete(string id_cliente)
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
                return new Response<Clientess>(true, "Se ha eliminado el cliente");
            }
            catch (Exception)
            {
                return new Response<Clientess>(false, "No se ha eliminado al cliente.");
            }
        }
        public Response<Clientess> Update(Clientess cliente, string old_id)
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
                return new Response<Clientess>(true, "Se ha actualizado el cliente", null, cliente);
            }
            catch (Exception)
            {
                return new Response<Clientess>(false, "No se ha registrado al cliente.", null, cliente);
            }
        }
    }

}
