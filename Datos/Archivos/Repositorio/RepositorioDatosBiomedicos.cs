using Datos.Archivos;
using Datos.Archivos.Clase_Abstracta;
using Entidades;
using Entidades.Informacion_Persona;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioDatosBiomedicos : Abs_Repositorio<DatosBiomedicos>, IUpdate<DatosBiomedicos, string>
    {
        IConexion conexion;
        public RepositorioDatosBiomedicos(IConexion _connect)
        {
            conexion = _connect;
            MiVista("vista_datos_biomedicos");
        }
        protected override DatosBiomedicos Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows)
                {
                    return null;
                }

                DatosBiomedicos datosBiomedicos = new DatosBiomedicos();
                datosBiomedicos.Id = dataReader.IsDBNull(0) ? null : (int?)dataReader.GetInt32(0);
                datosBiomedicos.FechaRegistro = dataReader.GetDateTime(1);
                datosBiomedicos.Altura = dataReader.IsDBNull(2) ? null : (double?)dataReader.GetDouble(2);
                datosBiomedicos.Peso = dataReader.IsDBNull(3) ? null : (double?)dataReader.GetDouble(3);
                datosBiomedicos.Imc = dataReader.IsDBNull(4) ? null : (double?)dataReader.GetDouble(4);
                datosBiomedicos.GrasaCorporal = dataReader.IsDBNull(5) ? null : (int?)dataReader.GetInt32(5);
                datosBiomedicos.FrecuenciaCardiaca = dataReader.GetInt32(6);
                datosBiomedicos.PresionArterial = dataReader.IsDBNull(7) ? null : (int?)dataReader.GetInt32(7);
                datosBiomedicos.IdCategoriaPeso = dataReader.GetString(8);
                datosBiomedicos.id_cliente = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);


                return datosBiomedicos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<DatosBiomedicos> Insert(DatosBiomedicos datosBiomedicos)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_DATOS_BIOMEDICOS.p_insertardatobiomedico";

                    command.Parameters.Add("i_altura", OracleDbType.Double).Value = datosBiomedicos.Altura;
                    command.Parameters.Add("i_peso", OracleDbType.Double).Value = datosBiomedicos.Peso;
                    command.Parameters.Add("i_id_cliente", OracleDbType.Varchar2).Value = datosBiomedicos.id_cliente;
                    command.Parameters.Add("i_grasa", OracleDbType.Double).Value = datosBiomedicos.GrasaCorporal;
                    command.Parameters.Add("i_frecuencia", OracleDbType.Int32).Value = datosBiomedicos.FrecuenciaCardiaca;
                    command.Parameters.Add("i_presion", OracleDbType.Int32).Value = datosBiomedicos.PresionArterial;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<DatosBiomedicos>(true, "Se ha registrado correctamente.", null, datosBiomedicos);
            }
            catch (Exception)
            {
                return new Response<DatosBiomedicos>(false, "No se han registrado los datos biomédicos.", null, datosBiomedicos);
            }
        }

        public Response<DatosBiomedicos> Update(DatosBiomedicos datosBiomedicos, string id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_DATOS_BIOMEDICOS.p_actualizardatobiomedico";

                    command.Parameters.Add("old_cliente", OracleDbType.Varchar2).Value = id;
                    command.Parameters.Add("u_altura", OracleDbType.Double).Value = datosBiomedicos.Altura;
                    command.Parameters.Add("u_peso", OracleDbType.Double).Value = datosBiomedicos.Peso;
                    command.Parameters.Add("u_grasa", OracleDbType.Double).Value = datosBiomedicos.GrasaCorporal;
                    command.Parameters.Add("u_frecuencia", OracleDbType.Int32).Value = datosBiomedicos.FrecuenciaCardiaca;
                    command.Parameters.Add("u_presion", OracleDbType.Int32).Value = datosBiomedicos.PresionArterial;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<DatosBiomedicos>(true, "Se ha actualizado correctamente.", null, datosBiomedicos);
            }
            catch (Exception)
            {
                return new Response<DatosBiomedicos>(false, "No se han actualizado los datos biomédicos.", null, datosBiomedicos);
            }
        }

        public Response<DatosBiomedicos> Delete(string id)
        {
            try
            {
                using (OracleCommand command = conexion.ObtenerConexion().CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_DATOS_BIOMEDICOS.p_eliminardatobiomedico";

                    command.Parameters.Add("d_id_cliente", OracleDbType.Varchar2).Value = id;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return new Response<DatosBiomedicos>(true, "Se ha eliminado correctamente.");
            }
            catch (Exception)
            {
                return new Response<DatosBiomedicos>(true, "No se ha eliminado el datos biomédicos.");
            }
        }

    }
}
