using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioContratos
    {
        protected string ruta = "Contrato.txt";
        public RepositorioContratos()
        {
        }
        public bool Save(Inscripcion contrato)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(contrato.ToString());
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Inscripcion Mapper(string linea)
        {
            RepositorioUsuarios repUsuarios = new RepositorioUsuarios();
            RepositorioPlan repPlanes = new RepositorioPlan();
            try
            {
                var aux = linea.Split(';');

                StringBuilder clientelinea = new StringBuilder();
                StringBuilder planlinea = new StringBuilder();
                StringBuilder supervisorlinea = new StringBuilder();
                for (int i = 5; i < 30; i++)
                {
                    if (i < 16)
                    {
                        clientelinea.Append(aux[i] + ";");
                    }
                    else if (i < 21 && i >= 16)
                    {
                        planlinea.Append(aux[i] + ";");
                    }
                    else if (i < 30 && i >= 21)
                    {
                        supervisorlinea.Append(aux[i] + ";");
                    }
                }
                string sup = "S;" + supervisorlinea.ToString().Substring(0, supervisorlinea.ToString().Length -1);
                string plan = planlinea.ToString().Substring(0, planlinea.ToString().Length - 1);
                string cliente = "C;" + clientelinea.ToString().Substring(0, clientelinea.ToString().Length - 1);
                Inscripcion contrato = new Inscripcion();
                contrato.Id = aux[0];
                contrato.fecha_inicio = DateTime.Parse(aux[1]);
                contrato.fecha_finalizacion = DateTime.Parse(aux[2]);
                contrato.precio = double.Parse(aux[3]);
                contrato.descuento = int.Parse(aux[4]);
                contrato.cliente = repUsuarios.Mapper(cliente) as Cliente;
                contrato.plan = repPlanes.Mapper(plan);
                contrato.supervisor = repUsuarios.Mapper(sup) as Supervisor;
                contrato.estado = bool.Parse(aux[30]);
                return contrato;
            }
            catch (Exception) { }
            return null;
        }
        public bool Update(List<Inscripcion> contratos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, false);
                foreach (var item in contratos)
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
