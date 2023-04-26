using Datos.Archivos;
using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.Operaciones.AccesoPublico;

namespace Logica.Operaciones.AccesoProtegido
{
    public class Protected_GetArchivo : Abs_ProtectedClass<Inscripcion>
    {
        protected RepositorioInscripcion ar_inscripcion;
        protected RepositorioSupervisor ar_supervisor;
        protected RepositorioPlan ar_plan;
        protected RepositorioClientes ar_clientes;
        protected Public_Clientes op_Clientes;
        protected Public_Supervisores op_supervisor;
        protected Public_Planes op_plan;
        public Protected_GetArchivo()
        {
            ar_inscripcion = new RepositorioInscripcion();
            ar_supervisor = new RepositorioSupervisor();
            ar_plan = new RepositorioPlan();
            ar_clientes = new RepositorioClientes();
            op_Clientes = new Public_Clientes();
            op_supervisor = new Public_Supervisores();
            op_plan = new Public_Planes();
        }
        protected override bool Exist(string id_inscripcion)
        {
            if (GetMainList().FirstOrDefault(item => item.id == id_inscripcion) != null) // Valida si existe un item en la lista por medio de la id, retorna false si no encontro
            {
                return true;
            }
            return false;
        }
        protected override List<Inscripcion> GetMainList()
        {
            //var lista = ar_inscripcion.Load();
            //if (lista == null) { return null; }
            //return lista;

            var lista = ar_inscripcion.Load();
            if (lista == null)
            {
                return null;
            }
            else
            {

                foreach (var item in lista)
                {
                    var cliente = op_Clientes.ReturnFromList(item.cliente.id);
                    var supervisor = op_supervisor.ReturnFromList(item.supervisor.id);
                    var plan = op_plan.ReturnFromList(item.plan.id);

                    if (cliente == null)
                    {
                        lista.Remove(item);
                    }
                    else if (supervisor == null)
                    {
                        lista.Remove(item);
                    }
                    else if (plan == null)
                    {
                        lista.Remove(item);
                    }
                    else
                    {
                        item.cliente = cliente;
                        item.supervisor = supervisor;
                        item.plan = plan;
                    }
                }
                ar_inscripcion.Update(lista);
            }
            return lista;
        }
        protected List<Supervisor> GetSupervisores()
        {
            var lista = ar_supervisor.Load();
            if (lista == null) { return null; }
            return lista;
        }
        protected List<Inscripcion> GetUpdatedList()
        {
            var lista = ar_inscripcion.Load();
            if (lista == null)
            {
                return null;
            }
            else
            {

                foreach (var item in lista)
                {
                    var cliente = op_Clientes.ReturnFromList(item.cliente.id);
                    var supervisor = op_supervisor.ReturnFromList(item.supervisor.id);
                    var plan = op_plan.ReturnFromList(item.plan.id);

                    if (cliente == null)
                    {
                        lista.Remove(item);
                    }
                    else if (supervisor == null)
                    {
                        lista.Remove(item);
                    }
                    else if (plan == null)
                    {
                        lista.Remove(item);
                    }
                    else
                    {
                        item.cliente = cliente;
                        item.supervisor = supervisor;
                        item.plan = plan;
                    }
                }
                ar_inscripcion.Update(lista);
            }
            return lista;
        }
        protected List<PlanGimnasio> GetPlanes()
        {
            var lista = ar_plan.Load();
            if (lista == null) { return null; }
            return lista;
        }
        protected List<Cliente> GetClientes()
        {
            var lista = ar_clientes.Load();
            if (lista == null) { return null; }
            return lista;
        }

    }
}
