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
        protected RepositorioInscripcion ar;
        public Operacion_Inscripciones()
        {
            list = new Listas();
            ar = new RepositorioInscripcion();
            repositorioUsuarios = new RepositorioUsuarios();
            op_Clientes = new Operacion_Clientes();
            op_supervisor = new Operacion_Supervisor();
            op_plan = new Operacion_Planes();
        }
        private Response<Inscripcion> isRenovationValid(Inscripcion inscripcion, Supervisor supervisor, PlanGimnasio plan, double descuento)
        {
           
            if (GetLista() == null)
            {
                return new Response<Inscripcion>(false, "Lista vacia", null, null); // Lista vacia
            }
            else if (inscripcion == null)
            {
                return new Response<Inscripcion>(false, "ID no encontrado", null, null); // id no encontrado.
            }
            else if (supervisor == null)
            {
                return new Response<Inscripcion>(false, "Supervisor no encontrado", null, null); // id_supervisor no encontrado.
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
                    if (item.id == inscripcion.id && item.estado == true)
                    {
                        return new Response<Inscripcion>(false, "No es necesaria una renovacion", null, null); // El estado del id_inscripcion esta vigente, por ende no necesita renovacion.
                    }
                }
                return new Response<Inscripcion>(true, null, null, inscripcion); 
            }
        }
        protected bool Exist(string id_inscripcion)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_inscripcion) != null) // Valida si existe un item en la lista por medio de la id, retorna false si no encontro
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
                listaVigente.Sort((p1, p2) => p1.id.CompareTo(p2.id));

                return listaVigente; // retorna lista de contratos vigentes.
            }
        }
        public Inscripcion ReturnFromList(string id_inscripcion) 
        {
            return GetLista().FirstOrDefault(item => item.id == id_inscripcion);
        }
        public Response<Inscripcion> Renovate(string id_inscripcion, int dias, string id_supervisor, string id_plan, double descuento) 
        {
            try
            {
                Inscripcion inscripcion = ReturnFromList(id_inscripcion);
                Supervisor supervisor = op_supervisor.ReturnFromList(id_supervisor);
                PlanGimnasio plan = op_plan.ReturnFromList(id_plan);

                var response = isRenovationValid(inscripcion, supervisor, plan, descuento);
                if (!response.success)
                {
                    return response;
                }
                else
                {
                    //if (contratoCaducado.id_supervisor != id_supervisor)
                    //{
                    //    int pos = contratoCaducado.id_supervisor.ListaCliente_Supervisor.FindIndex(item => item.id == id_inscripcion.cliente.id);
                    //    contratoCaducado.id_supervisor.ListaCliente_Supervisor.RemoveAt(pos);
                    //    id_inscripcion.id_supervisor = id_supervisor;
                    //    id_supervisor.ListaCliente_Supervisor.Add(id_inscripcion.cliente);
                    //}
                    //else
                    //{
                    //    id_inscripcion.id_supervisor = id_supervisor;
                    //}
                    inscripcion.supervisor = supervisor;
                    inscripcion.plan = plan;
                    inscripcion.descuento = descuento;
                    inscripcion.precio = plan.precio * (100 - descuento) / 100;
                    inscripcion.fecha_inicio = DateTime.Now;
                    inscripcion.fecha_finalizacion = inscripcion.fecha_inicio.AddDays(dias);
                    inscripcion.estado = true;
                    ar.Save(inscripcion);
                    return new Response<Inscripcion>(true, "Contrato renovado", null, null); // Renovo el id_inscripcion.
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Exception", null, null); // Excepcion
            }
        }
        public void ValidateStatus() 
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
        protected bool ValidateCliente(string id)
        {
            if (GetLista().FirstOrDefault(item => item.cliente.id == id) == null)
            {
                return true;
            }
            return false;
        }
    }
}
