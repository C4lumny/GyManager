using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos
{
    public class RepositorioSupervisor : I_Repositorio<Supervisor>
    {
        string ruta = "Supervisor.txt";
        public RepositorioSupervisor()
        {
            
        }

        public List<Supervisor> Load()
        {
            try
            {
                StreamReader reader2 = new StreamReader(ruta);
                var list = new List<Supervisor>();
                string linea;
                while (!reader2.EndOfStream)
                {
                    linea = reader2.ReadLine();
                    list.Add(Mapper(linea));
                }
                reader2.Close();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Supervisor Mapper(string linea)
        {
            var aux = linea.Split(';');
            try
            {

                Supervisor superisor = new Supervisor();
                superisor.id = aux[0];
                superisor.nombre = aux[1];
                superisor.genero = aux[2];
                superisor.telefono = aux[3];
                superisor.altura = double.Parse(aux[4]);
                superisor.peso = double.Parse(aux[5]);
                superisor.fecha_nacimiento = DateTime.Parse(aux[6]);
                superisor.fecha_ingreso = DateTime.Parse(aux[7]);
                superisor.estado = bool.Parse(aux[8]);
                return superisor;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Supervisor> Save(Supervisor supervisor)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(supervisor.ToString());
                writer.Close();
                return new Response<Supervisor>(true, "Se ha guardado correctamente.", null, supervisor);
            }
            catch (Exception)
            {
            }
            return new Response<Supervisor>(true, "Error!.", null, supervisor);
        }

        public bool Update(List<Supervisor> list)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, false);
                foreach (var item in list)
                {
                    writer.WriteLine(item.ToString());
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
