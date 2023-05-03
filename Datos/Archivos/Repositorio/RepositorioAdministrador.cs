using Entidades;
using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.IO;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioAdministrador : I_Repositorio<Administrador>
    {
        string ruta = "Administrador.txt";
        public RepositorioAdministrador()
        {
            if (!File.Exists(ruta))
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine("system;gymanager");
                writer.Close();
            }
        }

        public List<Administrador> Load()
        {
            try
            {
                var list = new List<Administrador>();
                string linea;
                StreamReader reader = new StreamReader(ruta);
                while (!reader.EndOfStream)
                {
                    linea = reader.ReadLine();
                    list.Add(Mapper(linea));
                }
                reader.Close();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Administrador Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                Administrador administrador = new Administrador();
                administrador.UserName = aux[0];
                administrador.Password = aux[1];
                return administrador;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Administrador> Save(Administrador admin)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(admin.ToString());
                writer.Close();
                return new Response<Administrador>(true, "Se ha registrado correctamente.", null, admin);
            }
            catch (Exception)
            {

                return new Response<Administrador>(false, "Error!!");
            }
        }

        public bool Update(List<Administrador> Administradores)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, false);
                foreach (var item in Administradores)
                {
                    writer.WriteLine(item.ToString());
                }
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
