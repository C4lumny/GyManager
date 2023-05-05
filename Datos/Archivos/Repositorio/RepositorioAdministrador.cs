using Entidades;
using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.IO;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioAdministrador : Abs_Repositorio<Administrador>
    {
        string ruta = "Administrador.txt";
        public RepositorioAdministrador()
        {
            Ruta(ruta);
            if (!File.Exists(ruta))
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine("system;gymanager");
                writer.Close();
            }
        }
        public override Administrador Mapper(string linea)
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
    }
}
