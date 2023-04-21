using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Operacion_Inscripciones
    {
        protected Listas list;
        protected Operacion_Clientes op_Clientes;
        protected Operacion_Supervisor op_supervisor;
        protected Operacion_Planes op_plan;
        protected RepositorioUsuarios repositorioUsuarios;
        protected RepositorioContratos ar;
        public Operacion_Inscripciones()
        {
            list = new Listas();
            ar = new RepositorioContratos();
            repositorioUsuarios = new RepositorioUsuarios();
        }
        private Response<Inscripcion> isRenovationValid(Inscripcion contrato, Supervisor supervisor, PlanGimnasio plan, double descuento)
        {
            if (GetLista() == null)
            {
                return new Response<Inscripcion>(false, "Lista vacia", null, null); // Lista vacia
            }
            else if (!Exist(contrato.Id))
            {
                return new Response<Inscripcion>(false, "ID no encontrado", null, null); // Id no encontrado.
            }
            else if (supervisor == null)
            {
                return new Response<Inscripcion>(false, "Supervisor no encontrado", null, null); // supervisor no encontrado.
            }
            else if (plan == null)
            {
                return new Response<Inscripcion>(false, "No se encontro el plan", null, null); // Plan no encontrado.
            }
            else if (descuento > 100 || descuento < 0)
            {
                return new Response<Inscripcion>(false, "Descuento invalido", null, null); // descuento no puede ser menor a 0 o mayor que 100
            }
            else
            {
                foreach (var item in list.GetListaContrato())
                {
                    if (item.Id == contrato.Id && item.estado == true)
                    {
                        return new Response<Inscripcion>(false, "No es necesaria una renovacion", null, null); // El estado del inscripcion esta vigente, por ende no necesita renovacion.
                    }
                }
                return new Response<Inscripcion>(true, null, null, null); //??????
            }
        }
        protected bool Exist(string dato)
        {
            if (GetLista().FirstOrDefault(item => item.Id == dato) != null) // Valida si existe un item en la lista por medio de la id, retorna false si no encontro
            {
                return true;
            }
            return false;
        }
        protected double Ganancia() // ganancia
        {
            double ganancia = 0;
            if (GetLista() != null)
            {
                foreach (var item in GetLista())
                {
                    ganancia += item.precio;
                }
            }
            return ganancia;
        }
        public List<Inscripcion> GetListaVigentes()
        {
            if (GetLista() == null)
            {
                return null; // Si esta vacia retorna null.
            }
            else
            {
                ValidateStatus();
                var listaVigente = GetLista().FindAll(item => item.estado == true);  // FindAll devuelve una lista de contratos que cumplan la condicion del predicado, en este caso, retorna los contratos tal que su estado sea true.
                listaVigente.Sort((p1, p2) => p1.fecha_inicio.CompareTo(p2.fecha_inicio));

                return listaVigente; // retorna lista de contratos vigentes.
            }
        }
        public Inscripcion ReturnFromList(string id_Contrato) // retorna un item de la lista por medio de la id, retorna null si no encontro.
        {
            return GetLista().FirstOrDefault(item => item.Id == id_Contrato);
        }
        public Response<Inscripcion> Renovate(string id_inscripcion, int dias, string id_supervisor, string id_plan, double descuento) // Renovacion del inscripcion.
        {
            // recibe la id del inscripcion, los dias de ampliacion del inscripcion, (puede ser del plan o personalizado) recibe un supervisor un plan y un descuento. 
            try
            {
                var inscripcion = new Inscripcion(ReturnFromList(id_inscripcion));
                var supervisor = op_supervisor.ReturnFromList(id_supervisor);
                var plan = op_plan.ReturnFromList(id_plan);
                var response = isRenovationValid(inscripcion, supervisor, plan, descuento);
                if (!response.success)
                {
                    return response;
                }
                else
                {
                    //if (contratoCaducado.supervisor != supervisor)
                    //{
                    //    int pos = contratoCaducado.supervisor.ListaCliente_Supervisor.FindIndex(item => item.id == inscripcion.cliente.id);
                    //    contratoCaducado.supervisor.ListaCliente_Supervisor.RemoveAt(pos);
                    //    inscripcion.supervisor = supervisor;
                    //    supervisor.ListaCliente_Supervisor.Add(inscripcion.cliente);
                    //}
                    //else
                    //{
                    //    inscripcion.supervisor = supervisor;
                    //}
                    inscripcion.supervisor = supervisor;
                    inscripcion.plan = plan;
                    inscripcion.descuento = descuento;
                    inscripcion.precio = plan.precio * (100 - descuento) / 100;
                    inscripcion.fecha_inicio = DateTime.Now;
                    inscripcion.fecha_finalizacion = inscripcion.fecha_inicio.AddDays(dias);
                    inscripcion.estado = true;
                    ar.Save(inscripcion);
                    return new Response<Inscripcion>(true, "Contrato renovado", null, null); // Renovo el inscripcion.
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Exception", null, null); // Excepcion
            }
        }
        public void ValidateStatus() // Valida el estado del inscripcion, utilizar antes de aplicar la renovacion y antes de consultar un inscripcion.
        {
            var lista = GetLista();
            if (lista != null)
            {
                foreach (var item in lista)
                {
                    if (DateTime.Now >= item.fecha_finalizacion)
                    {
                        item.estado = false;
                    }
                }
                ar.Update(lista);
            }
        }
        public List<Inscripcion> GetLista()
        {
            var lista = list.GetListaContrato(); ;
            if (lista == null) { return null; }
            return lista;  // retorna la lista de contratos, privada para esta clase.
        }
    }
}
