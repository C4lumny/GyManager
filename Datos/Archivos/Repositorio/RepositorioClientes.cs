using Datos.Archivos;
using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Datos
{
    public class RepositorioClientes
    {
        Coneccion conexion = new Coneccion();
        string ruta = "Cliente.txt";
        public RepositorioClientes()
        { 
        }
        public Clientess Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows) { return null; }
                Clientess cliente = new Clientess();
                cliente.Id = dataReader.GetString(0);
                cliente.Nombre = dataReader.GetString(1); 
                cliente.Genero = dataReader.GetString(2); 
                cliente.Telefono = dataReader.GetString(3);
                cliente.Fecha_nacimiento = dataReader.GetDateTime(4);
                cliente.Fecha_ingreso = dataReader.GetDateTime(5);
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
            using (OracleCommand command = conexion._conexion.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PKG_CLIENTES.p_insertarcliente";

                command.Parameters.Add("i_id", OracleDbType.Varchar2).Value = cliente.Id;
                command.Parameters.Add("i_nombres", OracleDbType.Varchar2).Value = cliente.Nombre;
                command.Parameters.Add("i_apellidos", OracleDbType.Varchar2).Value = cliente.Apellido;
                command.Parameters.Add("i_genero", OracleDbType.Varchar2).Value = cliente.Genero;
                command.Parameters.Add("i_telefono", OracleDbType.Varchar2).Value = cliente.Telefono;
                command.Parameters.Add("i_fecha_nacimiento", OracleDbType.Date).Value = cliente.Fecha_nacimiento; // Asigna la fecha de nacimiento adecuada

                command.ExecuteNonQuery();
            }
            return new Response<Clientess>(true, "Se ha registrado correctamente.", null, cliente);
            }
            catch (Exception)
            {
                return new Response<Clientess>(true, "No se ha registrado al cliente.", null, cliente);
               
            }
        }
        public List<Clientess> GetAll()
        {
            List<Clientess> clientes = new List<Clientess>();
            var comando = conexion._conexion.CreateCommand();
            comando.CommandText = "select * from Personas";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                clientes.Add(Mapper(lector));
            }
            Close();
            return personas;
        }
    }
}
