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
        RepositorioClientes Repositorio_Clientes;
        RepositorioSupervisor Repositorio_Supervisor;
        RepositorioPlan Repositorio_Planes;

        public RepositorioInscripcion()
        {
            Repositorio_Clientes = new RepositorioClientes();
            Repositorio_Supervisor = new RepositorioSupervisor();
            Repositorio_Planes = new RepositorioPlan();
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
            try
            {
                var aux = linea.Split(';');
                Inscripcion inscripcion = new Inscripcion();
                inscripcion.Id = aux[0];
                inscripcion.Fecha_inicio = DateTime.Parse(aux[1]);
                inscripcion.Fecha_finalizacion = DateTime.Parse(aux[2]);
                inscripcion.Precio = double.Parse(aux[3]);
                inscripcion.Descuento = int.Parse(aux[4]);
                var lista_cliente = Repositorio_Clientes.Load();
                var lista_plan = Repositorio_Planes.Load();
                var lista_sup = Repositorio_Supervisor.Load();
                inscripcion.cliente = null;
                inscripcion.supervisor = null;
                inscripcion.plan = null;
                if (lista_cliente != null && lista_sup != null && lista_plan != null)
                {
                    inscripcion.cliente = lista_cliente.FirstOrDefault(item => item.Id == aux[5]);
                    inscripcion.plan = lista_plan.FirstOrDefault(item => item.Id == aux[6]);
                    inscripcion.supervisor = lista_sup.FirstOrDefault(item => item.Id == aux[7]);
                }
                inscripcion.Estado = bool.Parse(aux[8]);
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
                    foreach (var incripcion in Inscripciones)
                    {
                        writer.WriteLine(incripcion.ToString());
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
