using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

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
                supervisor.Id = aux[0];
                supervisor.Nombre = aux[1];
                supervisor.Genero = aux[2];
                supervisor.Telefono = aux[3];
                supervisor.Altura = double.Parse(aux[4]);
                supervisor.Peso = double.Parse(aux[5]);
                supervisor.Fecha_nacimiento = DateTime.Parse(aux[6]);
                supervisor.Fecha_ingreso = DateTime.Parse(aux[7]);
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

        public bool Update(List<Supervisor> Supervisores)
        {
            try
            {
                if (Supervisores.Count == 0 && File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(ruta, false);
                    foreach (var supervisor in Supervisores)
                    {
                        writer.WriteLine(supervisor.ToString());
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
