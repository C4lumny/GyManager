using Datos.Archivos.Repositorio;
using Entidades.Administrador;
using Logica.Operaciones.AccesoProtegido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.Servicio_Administrador
{
    public class Protected_Administrador: Abs_ProtectedClass<Administrador>
    {
        RepositorioAdministrador ar_admin; 
        protected Protected_Administrador() { ar_admin = new RepositorioAdministrador(); }

        protected bool Login(Administrador admin)
        {
            if (Validar(admin))
            {
                return true;
            }
            return false;
        }
        bool @Validar(Administrador admin)
        {
            var lista = GetMainList();
            var adminVerificado = lista.FirstOrDefault(item => item.NickName == admin.NickName && item.Password == admin.Password);
            if (lista == null)
            {
                return false;
            }
            else if (adminVerificado == null)
            {
                return false;
            }
            return true;
        }

        protected override List<Administrador> GetMainList()
        {
            var lista = ar_admin.Load();
            if (lista == null)
            {
                return null;
            } 
            return lista;
        }

        protected override bool Exist(string id)
        {
            throw new NotImplementedException();
        }
        protected bool SignUp()
        {
            return true;
        }
    }
}
