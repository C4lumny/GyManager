using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioAdministrador : IAdministrador
    {
        ConexionOracle coneccion;
        RepositorioAdministrador rep;

        public ServicioAdministrador()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioAdministrador(coneccion);
        }
        public string Crear(Administrador entidad)
        {
            try
            {
                return rep.Insert(entidad).Msg;
            }
            catch (Exception)
            {

                return "Error";
            }
        }

        public string Eliminar(string id)
        {
            try
            {
                return rep.Delete(id);
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}
