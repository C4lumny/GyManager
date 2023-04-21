﻿using System;
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
        string ruta1 = "Cliente.txt";
        string ruta2 = "Supervisor.txt";

        public RepositorioUsuarios()
        {
        }
        public bool Save(Persona persona)
        {
            try
            {
                if (persona is Cliente) 
                {
                    StreamWriter writer = new StreamWriter(ruta1, true);
                    Cliente cliente = (Cliente)persona;
                    writer.WriteLine(cliente.ToString());
                    writer.Close();
                }
                else if(persona is Supervisor)
                {
                    StreamWriter writer = new StreamWriter(ruta2, true);
                    Supervisor supervisor = (Supervisor)persona;
                    writer.WriteLine(supervisor.ToString());
                    writer.Close();
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public Persona Mapper(string linea)
        {
            var aux = linea.Split(';');
            try
            {
                if (aux.Length > 9)
                {
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
                    cliente.estado = bool.Parse(aux[10]);
                    return cliente;
                }
                else
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
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Update(List<Persona> personas)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta1, false);
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
                StreamReader reader = new StreamReader(ruta2);
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
