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
        protected Public_Clientes op_Clientes;
        protected Public_Supervisores op_supervisor;
        protected Public_Planes op_plan;
        public Protected_GetArchivo()
        {
            ar_inscripcion = new RepositorioInscripcion();
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
            var lista = ar_inscripcion.Load();
            if (lista == null)
            {
                return null;
            }
            else
            {
                var listaUpdate = new List<Inscripcion>(lista);
                foreach (var item in lista)
                {
                    var cliente = op_Clientes.ReturnFromList(item.cliente.id);
                    var supervisor = op_supervisor.ReturnFromList(item.supervisor.id);
                    var plan = op_plan.ReturnFromList(item.plan.id);

                    if (cliente == null)
                    {
                        listaUpdate.Remove(item);
                    }
                    else if (supervisor == null)
                    {
                        listaUpdate.Remove(item);
                    }
                    else if (plan == null)
                    {
                        listaUpdate.Remove(item);
                    }
                    else
                    {
                        item.cliente = cliente;
                        item.supervisor = supervisor;
                        item.plan = plan;
                    }
                }
                ar_inscripcion.Update(listaUpdate);
                return listaUpdate;
            }
        }
    }
}
