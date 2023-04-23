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
    public class RepositorioPlan: I_Repositorio<PlanGimnasio>
    {
        protected string ruta = "Planes .txt";
        public  RepositorioPlan()
        {
        }

        public Response<PlanGimnasio> Save(PlanGimnasio plan)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(plan.ToString());
                writer.Close();
                return new Response<PlanGimnasio>(true, "Se ha guardado correctamente.", null, plan);
            }
            catch (Exception)
            {
                return new Response<PlanGimnasio>(true, "Error!.", null, plan);
            }
        }

        public  PlanGimnasio Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                PlanGimnasio plan = new PlanGimnasio();
                plan.id = aux[0];
                plan.nombre = aux[1];
                plan.precio = double.Parse(aux[2]);
                plan.descripcion = aux[3];
                plan.dias = int.Parse(aux[4]);
                return plan;
            }
            catch (Exception) { }
            return null;
        }

        public bool Update(List<PlanGimnasio> planes)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, false);
                foreach (var item in planes)
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

        public  List<PlanGimnasio> Load()
        {
            try
            {
                StreamReader reader = new StreamReader(ruta);
                var list = new List<PlanGimnasio>();
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
