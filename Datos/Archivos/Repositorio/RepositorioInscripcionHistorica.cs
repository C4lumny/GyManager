using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioInscripcionHistorica
    {
        protected string ruta = "Inscripcion_Historial.txt";
        RepositorioClientes ar_cliente;
        RepositorioSupervisor ar_Supervisor;
        RepositorioPlan ar_plan;

        public RepositorioInscripcionHistorica()
        {
            ar_cliente = new RepositorioClientes();
            ar_Supervisor = new RepositorioSupervisor();
            ar_plan = new RepositorioPlan();
        }
        public Response<Inscripcion> Save(Inscripcion inscripcion)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(inscripcion.ToFullString());
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
            try
            {
                var aux = linea.Split(';');
                StringBuilder clientelinea = new StringBuilder();
                StringBuilder planlinea = new StringBuilder();
                StringBuilder supervisorlinea = new StringBuilder();
                for (int i = 6; i < aux.Count(); i++)
                {
                    if (i < 16)
                    {
                        clientelinea.Append(aux[i] + ";");
                    }
                    else if (i < 21 && i >= 16)
                    {
                        planlinea.Append(aux[i] + ";");
                    }
                    else if (i >= 21)
                    {
                        supervisorlinea.Append(aux[i] + ";");
                    }
                }
                string sup = supervisorlinea.ToString().Substring(0, supervisorlinea.ToString().Length - 1);
                string plan = planlinea.ToString().Substring(0, planlinea.ToString().Length - 1);
                string cliente = clientelinea.ToString().Substring(0, clientelinea.ToString().Length - 1);
                Inscripcion inscripcion = new Inscripcion();
                inscripcion.id = aux[0];
                inscripcion.fecha_inicio = DateTime.Parse(aux[1]);
                inscripcion.fecha_finalizacion = DateTime.Parse(aux[2]);
                inscripcion.precio = double.Parse(aux[3]);
                inscripcion.descuento = int.Parse(aux[4]);
                inscripcion.estado = bool.Parse(aux[5]);
                inscripcion.cliente = ar_cliente.Mapper(cliente);
                inscripcion.supervisor = ar_Supervisor.Mapper(sup);
                inscripcion.plan = ar_plan.Mapper(plan);
                return inscripcion;
            }
            catch (Exception) { }
            return null;
        }
        public bool Update(List<Inscripcion> list)
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
                        writer.WriteLine(item.ToFullString());
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
