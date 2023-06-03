using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Archivos.Repositorio;
using Datos;
using Oracle.ManagedDataAccess.Client;
using Datos.Archivos.Clase_Abstracta;
using Datos.Archivos;

namespace Logica.Clases
{
    public class ServicioClientes : ICRUD<Clientess, string>, IGetBySearch<Clientess>
    {
        ConexionOracle coneccion;
        RepositorioClientes rep;

        public ServicioClientes()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioClientes(coneccion);
        }

        public string Actualizar(Clientess entidad, string id)
        {
            return rep.Update(entidad, id.ToString());
        }

        public string Crear(Clientess entidad)
        {
            return rep.Insert(entidad).Msg;
        }

        public string Eliminar(string id)
        {
           return rep.Delete(id.ToString());
        }
       
        public List<Clientess> GetAll() { 
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }

        public List<Clientess> GetListBySearch(string search)
        {
            throw new NotImplementedException();
        }

        public Clientess GetObjectById(string id)
        {
            try
            {
                return GetAll().FirstOrDefault(item => item.Id == id);
            }
            catch (Exception)
            {

                return null;
            };
        }
    }
}
