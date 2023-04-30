﻿using Datos.Archivos.Repositorio;
using Entidades;
using Entidades.Administrador;
using Logica.Operaciones.AccesoProtegido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.Servicio_Administrador
{
    public class Protected_Administrador
    {
        RepositorioAdministrador ar_admin; 
        protected Protected_Administrador() { ar_admin = new RepositorioAdministrador(); }

        protected Response<Administrador> SignIn(string NickName, string Password)
        {
            return isUserValid(NickName, Password);
        }
        Response<Administrador> isUserValid(string NickName, string Password)
        {
            var lista = GetMainList();
            var adminVerificado = lista.FirstOrDefault(item => item.NickName.ToLower().Replace(" ", "") == NickName.ToLower().Replace(" ", "") && item.Password == Password);
            if (lista == null)
            {
                return new Response<Administrador>(false, "No hay usuarios registrados actualmente.");
            }
            else if (adminVerificado == null)
            {
                return new Response<Administrador>(false, "Ingrese los datos correctamente");
            }
            return new Response<Administrador>(true, "Bienvenid@: " + NickName);
            
        }
        protected List<Administrador> GetMainList()
        {
            var lista = ar_admin.Load();
            if (lista == null)
            {
                return null;
            } 
            return lista;
        }
        protected bool Exist(string NickName)
        {
            var lista = GetMainList();
            var admin = lista.FirstOrDefault(item => item.NickName.ToLower().Replace(" ", "") == NickName.ToLower().Replace(" ", ""));
            if (lista == null)
            {
                return false;
            }
            else if (admin == null)
            {
                return false;
            }
            return true;
        }
        protected Response<Administrador> SignUp(string NickName, string Password)
        {
            if (string.IsNullOrEmpty(NickName.Replace(" ", "")) && string.IsNullOrEmpty(Password.Replace(" ", "")))
            {
                return new Response<Administrador>(false, "Por favor, ingrese correctamente el usuario y la contraseña.");
            }
            else if (NickName.Length < 6)
            {
                return new Response<Administrador>(false, "Ingrese un usuario valido. (minimo 6 caracteres)");
            }
            else if (Password.Length < 6)
            {
                return new Response<Administrador>(false, "Ingrese una contraseña valida. (minimo 6 caracteres)");
            }
            else if (Exist(NickName))
            {
                return new Response<Administrador>(false, "Usuario ya registrado. Por favor ingrese un nuevo usuario.");
            }
            
            return ar_admin.Save(new Administrador(NickName, Password));
        }
        protected Response<Administrador> Delete(string NickName, string Password)
        {
            var lista = GetMainList();
            if (lista != null)
            {
                return new Response<Administrador>(false, "No hay usuarios registrados actualmente.");
            }
            else if (!isUserValid(NickName, Password).Success)
            {
                return new Response<Administrador>(false, "Por favor, ingrese correctamente el usuario y la contraseña.");
            }
            else 
            {
                var admin = lista.Find(item => item.NickName == NickName);
                lista.Remove(admin);
                if (ar_admin.Update(lista))
                {
                    return new Response<Administrador>(true, "Se ha eliminado correctamente.", null, admin);
                }
                else
                {
                    return new Response<Administrador>(false, "No se ha podido eliminar.");

                }
            }
        }
    }
}