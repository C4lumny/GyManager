using Entidades.Informacion_Persona;
using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Archivos.Clase_Abstracta;
using Datos.Archivos.Clases_Abstractas_e_Interfaces;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioDiscapacidades //: IAsignarYDesasignar
    {
        //IConexion conexion;

        //public RepositorioDiscapacidades(IConexion _connect)
        //{
        //    conexion = _connect;
        //    MiVista("vista_clientes");
        //}

        //public Response<Discapacidad> AsignarDiscapacidad(string idCliente, Discapacidad discapacidad)
        //{
        //    Response<Discapacidad> response = new Response<Discapacidad>(false, "", null, null);

        //    try
        //    {
        //        using (OracleCommand command = conexion._conexion.CreateCommand())
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "pkg_discapacidades.p_asignardiscapacidad";

        //            command.Parameters.Add("id_cliente", OracleDbType.Varchar2).Value = idCliente;
        //            command.Parameters.Add("discapacidad", OracleDbType.Varchar2).Value = discapacidad;

        //            conexion.Open();
        //            command.ExecuteNonQuery();
        //            conexion.Close();

        //            response.Success = true;
        //            response.Msg = "Discapacidad asignada correctamente";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Msg = ex.Message;
        //    }

        //    return response;
        //}

        //public Response<Discapacidad> EliminarDiscapacidadCliente(string idCliente, Discapacidad idDiscapacidad)
        //{
        //    Response<Discapacidad> response = new Response<Discapacidad>(false, "", null, null);

        //    try
        //    {
        //        using (OracleCommand command = conexion._conexion.CreateCommand())
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "pkg_discapacidades.p_eliminardiscapacidadcliente";

        //            command.Parameters.Add("id_cliente", OracleDbType.Varchar2).Value = idCliente;
        //            command.Parameters.Add("id_discapacidad", OracleDbType.Varchar2).Value = idDiscapacidad;

        //            conexion.Open();
        //            command.ExecuteNonQuery();
        //            conexion.Close();

        //            response.Success = true;
        //            response.Msg = "Discapacidad eliminada del cliente correctamente";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Msg = ex.Message;
        //    }

        //    return response;
        //}

        //public Response<Discapacidad> EncontrarDiscapacidad(string nombre)
        //{
        //    Response<Discapacidad> response = new Response<Discapacidad>(false, "", null, null);

        //    try
        //    {
        //        using (OracleCommand command = conexion._conexion.CreateCommand())
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "pkg_discapacidades.f_encontrardiscapacidad";

        //            command.Parameters.Add("f_nombre", OracleDbType.Varchar2).Value = nombre;
        //            command.Parameters.Add("result", OracleDbType.Int32).Direction = ParameterDirection.ReturnValue;

        //            conexion.Open();
        //            command.ExecuteNonQuery();

        //            int idDiscapacidad = Convert.ToInt32(command.Parameters["result"].Value);
        //            conexion.Close();

        //            if (idDiscapacidad != -1)
        //            {
        //                Discapacidad discapacidad = new Discapacidad
        //                {
        //                    Id = idDiscapacidad,
        //                    Nombre = nombre
        //                };

        //                response.Success = true;
        //                response.Msg = "Discapacidad encontrada";
        //                response.Object = discapacidad;
        //            }
        //            else
        //            {
        //                response.Msg = "Discapacidad no encontrada";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Msg = ex.Message;
        //    }

        //    return response;
        //}
    }
}
