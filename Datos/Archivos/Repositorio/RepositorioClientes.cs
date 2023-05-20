using Datos.Archivos;
using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Datos
{
    public class RepositorioClientes : Abs_Repositorio<Cliente>
    {
        Coneccion coneccion = new Coneccion();
        string ruta = "Cliente.txt";
        public RepositorioClientes()
        { 
            Ruta(ruta);
        }
        public override Cliente Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                Cliente cliente = new Cliente();
                cliente.Id = aux[0];
                cliente.Nombre = aux[1];
                cliente.Genero = aux[2];
                cliente.Telefono = aux[3];
                cliente.Altura = double.Parse(aux[4]);
                cliente.Peso = double.Parse(aux[5]);
                cliente.Imc = double.Parse(aux[6]);
                cliente.Fecha_nacimiento = DateTime.Parse(aux[7]);
                cliente.Discapacidad = aux[8];
                cliente.Fecha_ingreso = DateTime.Parse(aux[9]);
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Response<Cliente> Insert(Cliente persona)
        {
            using (var Comando = coneccion._conexion.CreateCommand())
            {
                Comando.CommandText = "Insert Into CLIENTES (ID, NOMBRES, GENERO, TELEFONO, ALTURA, PESO, IMC, FECHA_NACIMIENTO, DISCAPACIDAD, FECHA_INGRESO)" +
                " values (:ID, :NOMBRES, :GENERO, :TELEFONO, :ALTURA, :PESO, :IMC, :FECHA_NACIMIENTO, :DISCAPACIDAD, :FECHA_INGRESO)";
                Comando.Parameters.Add("ID", OracleDbType.Varchar2).Value = persona.Id;
                Comando.Parameters.Add("NOMBRES", OracleDbType.Varchar2).Value = persona.Nombre;
                Comando.Parameters.Add("GENERO", OracleDbType.Varchar2).Value = persona.Genero;
                Comando.Parameters.Add("TELEFONO", OracleDbType.Varchar2).Value = persona.Telefono;
                Comando.Parameters.Add("ALTURA", OracleDbType.Double).Value = persona.Altura;
                Comando.Parameters.Add("PESO", OracleDbType.Double).Value = persona.Peso;
                Comando.Parameters.Add("IMC", OracleDbType.Double).Value = persona.Imc;
                Comando.Parameters.Add("FECHA_NACIMIENTO", OracleDbType.Date).Value = persona.Fecha_nacimiento;
                Comando.Parameters.Add("DISCAPACIDAD", OracleDbType.Varchar2).Value = persona.Discapacidad;
                Comando.Parameters.Add("FECHA_INGRESO", OracleDbType.Date).Value = persona.Fecha_ingreso;
                coneccion.Open();
                Comando.ExecuteNonQuery();
                coneccion.Close();
            }
            return new Response<Cliente>(true, "Se ha registrado correctamente.", null, persona);
        }

    }
}
