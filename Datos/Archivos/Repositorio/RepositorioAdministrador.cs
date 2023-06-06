using Datos.Archivos.Clase_Abstracta;
using Entidades;
using Entidades.Administrador;
using Entidades.Pagos_y_Facturas;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioAdministrador : Abs_Repositorio<Administrador>
    {
        IConexion conexion;
        public RepositorioAdministrador(IConexion _connect) 
        {
            conexion = _connect;
            MiVista("vista_administradores");
        }
        protected override Administrador Mapper(OracleDataReader dataReader)
        {
            try
            {
                if (!dataReader.HasRows) { return null; }
                Administrador admin = new Administrador();
                admin.UserName = dataReader.GetString(0);
                admin.Password = dataReader.GetString(1);
                return admin;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
