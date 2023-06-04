using Entidades;
using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Entidades.Informacion_Persona;
using Datos.Archivos.Clase_Abstracta;

namespace Datos.Archivos
{
    public abstract class Abs_Repositorio<T> : ConexionOracle
    {
        string vista;
        public Abs_Repositorio()
        {
        }
        protected string MiVista(string vista)
        {
            this.vista = vista;
            return vista;
        }
        public List<T> GetAll()
        {
            List<T> lista = new List<T>();
            var comando = _conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM " + vista;
            Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(Mapper(lector));
            }
            Close();
            return lista;
        }
        protected abstract T Mapper(OracleDataReader dataReader);

    }
}
