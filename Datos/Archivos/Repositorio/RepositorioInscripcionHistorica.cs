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
        RepositorioClientes Repositorio_Clientes;
        RepositorioSupervisor Repositorio_Supervisores;
        RepositorioPlan Repositorio_Planes;
        RepositorioTurnos Repositorio_Turnos;

        public RepositorioInscripcionHistorica()
        {
            Repositorio_Turnos = new RepositorioTurnos();
            Repositorio_Clientes = new RepositorioClientes();
            Repositorio_Supervisores = new RepositorioSupervisor();
            Repositorio_Planes = new RepositorioPlan();
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
                for (int i = 6; i < 29; i++)
                {
                    if (i < 16)
                    {
                        clientelinea.Append(aux[i] + ";");
                    }
                    else if (i < 21 && i >= 16)
                    {
                        planlinea.Append(aux[i] + ";");
                    }
                    else if (i >= 21 && i < 29)
                    {
                        supervisorlinea.Append(aux[i] + ";");
                    }   
                }
                string sup = supervisorlinea.ToString().Substring(0, supervisorlinea.ToString().Length - 1);
                string plan = planlinea.ToString().Substring(0, planlinea.ToString().Length - 1);
                string cliente = clientelinea.ToString().Substring(0, clientelinea.ToString().Length - 1);
                Inscripcion inscripcion = new Inscripcion();
                inscripcion.Id = aux[0];
                inscripcion.Fecha_inicio = DateTime.Parse(aux[1]);
                inscripcion.Fecha_finalizacion = DateTime.Parse(aux[2]);
                inscripcion.Precio = double.Parse(aux[3]);
                inscripcion.Descuento = int.Parse(aux[4]);
                inscripcion.Estado = bool.Parse(aux[5]);
                inscripcion.cliente = Repositorio_Clientes.Mapper(cliente);
                inscripcion.supervisor = Repositorio_Supervisores.Mapper(sup);
                for (int i = 29; i < aux.Count()-2; i = i + 3)
                {
                    inscripcion.supervisor.Horarios.Add(new Turno_Atencion(aux[21], aux[i], DateTime.Parse(aux[i+1]), DateTime.Parse(aux[i + 2])));
                }
                inscripcion.plan = Repositorio_Planes.Mapper(plan);
                return inscripcion;
            }
            catch (Exception) { }
            return null;
        }
        public bool Update(List<Inscripcion> Inscripciones)
        {
            try
            {
                if (Inscripciones.Count == 0 && File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(ruta, false);
                    foreach (var inscripcion in Inscripciones)
                    {
                        writer.WriteLine(inscripcion.ToFullString());
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
