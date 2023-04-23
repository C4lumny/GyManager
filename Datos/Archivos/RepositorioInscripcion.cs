using Datos.Archivos;
using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioInscripcion: I_Repositorio<Inscripcion>
    {
        protected string ruta = "Inscripcion.txt";

        public RepositorioInscripcion()
        {

        }
        public Response<Inscripcion> Save(Inscripcion inscripcion)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(inscripcion.ToString());
                writer.Close();
                return new Response<Inscripcion>(true, "Se ha guardado correctamente.", null, inscripcion);
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(true, "Error", null, inscripcion);
            }
        }
        public Inscripcion Mapper(string linea)
        {
            RepositorioClientes repClientes = new RepositorioClientes();
            RepositorioSupervisor repSupervisor = new RepositorioSupervisor();
            RepositorioPlan repPlanes = new RepositorioPlan();
            try
            {
                var aux = linea.Split(';');

                StringBuilder clientelinea = new StringBuilder();
                StringBuilder planlinea = new StringBuilder();
                StringBuilder supervisorlinea = new StringBuilder();
                for (int i = 5; i < 29; i++)
                {
                    if (i < 15)
                    {
                        clientelinea.Append(aux[i] + ";");
                    }
                    else if (i < 20 && i >= 15)
                    {
                        planlinea.Append(aux[i] + ";");
                    }
                    else if (i < 29 && i >= 20)
                    {
                        supervisorlinea.Append(aux[i] + ";");
                    }
                }
                string sup = supervisorlinea.ToString().Substring(0, supervisorlinea.ToString().Length -1);
                string plan = planlinea.ToString().Substring(0, planlinea.ToString().Length - 1);
                string cliente = clientelinea.ToString().Substring(0, clientelinea.ToString().Length - 1);
                Inscripcion inscripcion = new Inscripcion();
                inscripcion.id = aux[0];
                inscripcion.fecha_inicio = DateTime.Parse(aux[1]);
                inscripcion.fecha_finalizacion = DateTime.Parse(aux[2]);
                inscripcion.precio = double.Parse(aux[3]);
                inscripcion.descuento = int.Parse(aux[4]);
                inscripcion.cliente = repClientes.Mapper(cliente);
                inscripcion.plan = repPlanes.Mapper(plan);
                inscripcion.supervisor = repSupervisor.Mapper(sup);
                inscripcion.estado = bool.Parse(aux[29]);
                return inscripcion;
            }
            catch (Exception) { }
            return null;
        }
        public bool Update(List<Inscripcion> inscripciones)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, false);
                foreach (var item in inscripciones)
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
        public List<Inscripcion> Load()
        {
            try
            {
                StreamReader reader = new StreamReader(ruta);
                var list = new List<Inscripcion>();
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
