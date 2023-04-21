using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades;

namespace Datos
{
    public class RepositorioUsuarios
    {
        protected string ruta = "Personas.txt";
        public RepositorioUsuarios()
        {
        }
        public bool Save(Persona persona)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                if (persona is Cliente) 
                { 
                    Cliente cliente = (Cliente)persona;
                    writer.WriteLine("C;" + cliente.ToString());
                }
                else if(persona is Supervisor)
                {
                    Supervisor supervisor = (Supervisor)persona;
                    writer.WriteLine("S;" + supervisor.ToString());
                }
                writer.Close();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public Persona Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                if (aux[0] == "C")
                {
                    Cliente cliente = new Cliente();
                    cliente.id = aux[1];
                    cliente.nombre = aux[2];
                    cliente.genero = aux[3];
                    cliente.telefono = aux[4];
                    cliente.altura = double.Parse(aux[5]);
                    cliente.peso = double.Parse(aux[6]);
                    cliente.imc = double.Parse(aux[7]);
                    cliente.fecha_nacimiento = DateTime.Parse(aux[8]);
                    cliente.discapacidad = aux[9];
                    cliente.fecha_ingreso = DateTime.Parse(aux[10]);
                    cliente.estado = bool.Parse(aux[11]);
                    Persona persona = cliente;
                    return persona;
                }
                else if (aux[0] == "S")
                {
                    Supervisor superisor = new Supervisor();
                    superisor.id = aux[1];
                    superisor.nombre = aux[2];
                    superisor.genero = aux[3];
                    superisor.telefono = aux[4];
                    superisor.altura = double.Parse(aux[5]);
                    superisor.peso = double.Parse(aux[6]);
                    superisor.fecha_nacimiento = DateTime.Parse(aux[7]);
                    superisor.fecha_ingreso = DateTime.Parse(aux[8]);
                    superisor.estado = bool.Parse(aux[9]);
                    Persona persona = superisor;
                    return persona;
                }
            }
            catch (Exception) { }
            return null;
        }
        public bool Update(List<Persona> personas)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, false);
                foreach (var item in personas)
                {
                    if (item is Cliente)
                    {
                        Cliente cliente = (Cliente)item;
                        writer.WriteLine("C;" + cliente.ToString());
                    }
                    else if (item is Supervisor)
                    {
                        Supervisor supervisor = (Supervisor)item;
                        writer.WriteLine("S;" + supervisor.ToString());
                    }
                }
                writer.Close();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public List<Persona> Load()
        {
            try
            {
                StreamReader reader = new StreamReader(ruta);
                var list = new List<Persona>();
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
    }
}
