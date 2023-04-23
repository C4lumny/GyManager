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
                StreamReader reader = new StreamReader(ruta);
                var list = new List<Supervisor>();
                string linea;
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

        public Supervisor Mapper(string linea)
        {
            
            try
            {
                var aux = linea.Split(';');
                Supervisor supervisor = new Supervisor();
                supervisor.id = aux[0];
                supervisor.nombre = aux[1];
                supervisor.genero = aux[2];
                supervisor.telefono = aux[3];
                supervisor.altura = double.Parse(aux[4]);
                supervisor.peso = double.Parse(aux[5]);
                supervisor.fecha_nacimiento = DateTime.Parse(aux[6]);
                supervisor.fecha_ingreso = DateTime.Parse(aux[7]);
                supervisor.estado = bool.Parse(aux[8]);
                return supervisor;
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
                StreamWriter writer1 = new StreamWriter(ruta, true);
                writer1.WriteLine(supervisor.ToString());
                writer1.Close();
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
                }
                writer.Close();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
