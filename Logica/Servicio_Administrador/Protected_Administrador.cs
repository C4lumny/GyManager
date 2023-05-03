using Datos.Archivos.Repositorio;
using Entidades;
using Entidades.Administrador;
using Logica.Operaciones.AccesoProtegido;
using System.Collections.Generic;
using System.Linq;

namespace Logica.Operaciones.Servicio_Administrador
{
    public class Protected_Administrador : Abs_ProtectedClass<Administrador>
    {
        RepositorioAdministrador ar_admin;
        protected Protected_Administrador() { ar_admin = new RepositorioAdministrador(); }

        protected Response<Administrador> SignIn(string UserName, string Password)
        {
            return isUserValid(UserName, Password);
        }
        Response<Administrador> isUserValid(string UserName, string Password)
        {
            var lista = GetMainList();
            if (lista == null)
            {
                return new Response<Administrador>(false, "No hay usuarios registrados actualmente.");
            }
            var adminVerificado = lista.FirstOrDefault(item => item.UserName.ToLower().Replace(" ", "") == UserName.ToLower().Replace(" ", "") && item.Password == Password);
            if (adminVerificado == null)
            {
                return new Response<Administrador>(false, "Ingrese los datos correctamente");
            }
            return new Response<Administrador>(true, "Bienvenid@: " + UserName);

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
        protected override bool Exist(string UserName)
        {
            var lista = GetMainList();
            if (lista == null)
            {
                return false;
            }
            var admin = lista.FirstOrDefault(item => item.UserName.ToLower().Replace(" ", "") == UserName.ToLower().Replace(" ", ""));
            if (admin == null)
            {
                return false;
            }
            return true;
        }
        protected Response<Administrador> SignUp(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName.Replace(" ", "")) && string.IsNullOrEmpty(Password.Replace(" ", "")))
            {
                return new Response<Administrador>(false, "Por favor, ingrese correctamente el usuario y la contraseña.");
            }
            else if (UserName.Length < 6)
            {
                return new Response<Administrador>(false, "Ingrese un usuario valido. (minimo 6 caracteres)");
            }
            else if (Password.Length < 6)
            {
                return new Response<Administrador>(false, "Ingrese una contraseña valida. (minimo 6 caracteres)");
            }
            else if (Exist(UserName))
            {
                return new Response<Administrador>(false, "Usuario ya registrado. Por favor ingrese un nuevo usuario.");
            }
            return ar_admin.Save(new Administrador(UserName, Password));
        }
        protected Response<Administrador> Delete(string UserName, string Password)
        {
            var lista = GetMainList();
            if (lista == null)
            {
                return new Response<Administrador>(false, "No hay usuarios registrados actualmente.");
            }
            else if (!isUserValid(UserName, Password).Success)
            {
                return new Response<Administrador>(false, "Por favor, ingrese correctamente el usuario y la contraseña.");
            }
            else
            {
                var admin = lista.Find(item => item.UserName == UserName);
                lista.Remove(admin);
                if (ar_admin.Update(lista))
                {
                    return new Response<Administrador>(true, "Se ha eliminado correctamente a: " + admin.UserName, null, admin);
                }
                else
                {
                    return new Response<Administrador>(false, "No se ha podido eliminar.");
                }
            }
        }
    }
}
