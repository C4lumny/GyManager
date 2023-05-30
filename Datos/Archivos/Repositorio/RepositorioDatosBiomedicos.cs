using Datos.Archivos;
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
    public class RepositorioDatosBiomedicos
    {
        public RepositorioDatosBiomedicos()
        {
            
        }
        Coneccion conexion = new Coneccion();
        public DatosBiomedicos Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows)
                {
                    return null;
                }

                DatosBiomedicos datosBiomedicos = new DatosBiomedicos();
                datosBiomedicos.Id = dataReader.GetInt32(0);
                datosBiomedicos.FechaRegistro = dataReader.GetDateTime(1);
                datosBiomedicos.Altura = dataReader.GetDouble(2);
                datosBiomedicos.Peso = dataReader.GetDouble(3);
                if (!dataReader.IsDBNull(4))
                    datosBiomedicos.Imc = dataReader.GetDouble(4);
                datosBiomedicos.GrasaCorporal = dataReader.GetDouble(5);
                datosBiomedicos.FrecuenciaCardiaca = dataReader.GetInt32(6);
                datosBiomedicos.PresionArterial = dataReader.GetInt32(7);
                if (!dataReader.IsDBNull(8))
                    datosBiomedicos.IdCategoriaPeso = dataReader.GetInt32(8);
                datosBiomedicos.IdCliente = dataReader.GetString(9);

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
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_DATOS_BIOMEDICOS.p_insertardatobiomedico";

                    command.Parameters.Add("i_altura", OracleDbType.Double).Value = datosBiomedicos.Altura;
                    command.Parameters.Add("i_peso", OracleDbType.Double).Value = datosBiomedicos.Peso;
                    command.Parameters.Add("i_id_cliente", OracleDbType.Varchar2).Value = datosBiomedicos.IdCliente;
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
                return new Response<DatosBiomedicos>(true, "No se ha registrado los datos biomédicos.", null, datosBiomedicos);
            }
        }

        public string Update(DatosBiomedicos datosBiomedicos, string old_cliente)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_DATOS_BIOMEDICOS.p_actualizardatobiomedico";

                    command.Parameters.Add("old_cliente", OracleDbType.Varchar2).Value = old_cliente;
                    command.Parameters.Add("u_altura", OracleDbType.Double).Value = datosBiomedicos.Altura;
                    command.Parameters.Add("u_peso", OracleDbType.Double).Value = datosBiomedicos.Peso;
                    command.Parameters.Add("u_grasa", OracleDbType.Double).Value = datosBiomedicos.GrasaCorporal;
                    command.Parameters.Add("u_frecuencia", OracleDbType.Int32).Value = datosBiomedicos.FrecuenciaCardiaca;
                    command.Parameters.Add("u_presion", OracleDbType.Int32).Value = datosBiomedicos.PresionArterial;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha actualizado correctamente.";
            }
            catch (Exception)
            {
                return "No se ha actualizado los datos biomédicos.";
            }
        }

        public string Delete(string idCliente)
        {
            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PKG_DATOS_BIOMEDICOS.p_eliminardatobiomedico";

                    command.Parameters.Add("d_id_cliente", OracleDbType.Varchar2).Value = idCliente;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                return "Se ha eliminado los datos biomédicos.";
            }
            catch (Exception)
            {
                return "No se ha realizado la eliminación de los datos biomédicos.";
            }
        }

        public List<DatosBiomedicos> GetAll()
        {
            List<DatosBiomedicos> datosBiomedicosList = new List<DatosBiomedicos>();
            var comando = conexion._conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM DatosBiomedicos";
            conexion.Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                datosBiomedicosList.Add(Mapper(lector));
            }
            conexion.Close();
            return datosBiomedicosList;
        }

        public int EncontrarDatoBiomedico(string idCliente)
        {
            int idDato = 0;

            try
            {
                using (OracleCommand command = conexion._conexion.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "pkg_datos_biomedicos.f_encontrardatobiomedico";
                    command.Parameters.Add("f_id_cliente", OracleDbType.Varchar2).Value = idCliente;
                    command.Parameters.Add("id_dato", OracleDbType.Int32).Direction = ParameterDirection.ReturnValue;

                    conexion.Open();
                    command.ExecuteNonQuery();
                    idDato = Convert.ToInt32(command.Parameters["id_dato"].Value);
                    conexion.Close();
                }
            }
            catch (Exception)
            {
                // Manejar la excepción según sea necesario
            }

            return idDato;
        }
    }
}
