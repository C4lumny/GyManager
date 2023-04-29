using Entidades;
using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioAdministrador: I_Repositorio<Administrador>
    {
        string ruta = "Administrador";
        public RepositorioAdministrador()
        {
            
        }

        public List<Administrador> Load()
        {
            try
            {
                var list = new List<Administrador>();
                string linea;
                StreamReader sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    linea = sr.ReadLine();
                    list.Add(Mapper(linea));
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Administrador Mapper(string linea)
        {
            try
            { 
                var aux = linea.Split(';');
                Administrador administrador = new Administrador();
                administrador.NickName = aux[0];
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
                return new Response<Administrador>(true, "Se ha registrado correctamente.");
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
                StreamWriter writer = new StreamWriter(ruta, true);
                foreach (var admin in Administradores)
                {
                    writer.WriteLine(admin.ToString());
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
