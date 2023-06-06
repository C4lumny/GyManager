using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades;
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

        protected override List<Administrador> GetAll()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }

        public override Response<Administrador> ValidarAdmin(Administrador entidad)
        {
            if (!GetAll().Any(item => item.UserName.ToUpper() == entidad.UserName.ToUpper() && item.Password == entidad.Password))
            {
                return new Response<Administrador>(false, "Usuario y/o contraseña incorrectos");
            }
            else
            {
                return new Response<Administrador>(true, "Bienvenido: "  + entidad.UserName + "!");
            }
        }
    }
}
