using Entidades;
using Entidades.Administrador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos
{
    public abstract class Abs_Repositorio<T> 
    {
        string ruta;
        public string Ruta(string ruta)
        {
            this.ruta = ruta;
            return ruta;
        }
        public Response<T> Save(T dato)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(dato.ToString());
                writer.Close();
                return new Response<T>(true, "Se ha registrado correctamente.", null, dato);
            }
            catch (Exception)
            {
                return new Response<T>(false, "Error!!");
            }
        }
        public abstract T Mapper(string linea);
        public List<T> Load()
        {
            try
            {
                var list = new List<T>();
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
        public bool Update(List<T> list)
        {
            try
            {
                if (list.Count == 0 && File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(ruta, false);
                    foreach (var item in list)
                    {
                        writer.WriteLine(item.ToString());
                    }
                    writer.Close();
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
