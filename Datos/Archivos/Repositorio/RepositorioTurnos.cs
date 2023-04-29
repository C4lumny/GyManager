using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioTurnos : I_Repositorio<Turno_Atencion>
    {

        string ruta = "Turnos.txt";
        public RepositorioTurnos()
        {
        }
        public List<Turno_Atencion> Load()
        {
            try
            {
                StreamReader reader = new StreamReader(ruta);
                var list = new List<Turno_Atencion>();
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

        public Turno_Atencion Mapper(string linea)
        {
            
            try
            {
                var aux = linea.Split(';');                
                var turno = new Turno_Atencion(aux[0], aux[1], DateTime.Parse(aux[2]), DateTime.Parse(aux[3]));          
                return turno;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Turno_Atencion> Save(Turno_Atencion turno)
        {
            try
            {
                StreamWriter writer1 = new StreamWriter(ruta, true);
                writer1.WriteLine(turno.ToString());
                writer1.Close();
                return new Response<Turno_Atencion>(true, "Se ha guardado correctamente.", null, turno);
            }
            catch (Exception)
            {
            }
            return new Response<Turno_Atencion>(true, "Error!.", null, turno);
        }

        public bool Update(List<Turno_Atencion> list)
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
                        writer.WriteLine(item.ToString());
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
