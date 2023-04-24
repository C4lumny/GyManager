using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades;
using Datos.Archivos;

namespace Datos
{
    public class RepositorioClientes: I_Repositorio<Cliente>
    {
        string ruta = "Cliente.txt";

        public RepositorioClientes()
        {
        }
        public Response<Cliente> Save(Cliente cliente)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(cliente.ToString());
                writer.Close();
                return new Response<Cliente>(true, "Se ha guardado correctamente.", null, cliente);
            }
            catch (Exception)
            {
            }
            return new Response<Cliente>(false, "No se ha podido guardar el cliente.", null, cliente); 
        }

        public Cliente Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                Cliente cliente = new Cliente();
                cliente.id = aux[0];
                cliente.nombre = aux[1];
                cliente.genero = aux[2];
                cliente.telefono = aux[3];
                cliente.altura = double.Parse(aux[4]);
                cliente.peso = double.Parse(aux[5]);
                cliente.imc = double.Parse(aux[6]);
                cliente.fecha_nacimiento = DateTime.Parse(aux[7]);
                cliente.discapacidad = aux[8];
                cliente.fecha_ingreso = DateTime.Parse(aux[9]);
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cliente> Load()
        {
            try
            {
                StreamReader reader1 = new StreamReader(ruta);
                var list = new List<Cliente>();
                string linea;
                while (!reader1.EndOfStream)
                {
                    linea = reader1.ReadLine();
                    list.Add(Mapper(linea));
                }
                reader1.Close();
                return  list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(List<Cliente> list)
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
