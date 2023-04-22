using Datos;
using Entidades;
using Logica.Operaciones;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Logica
{
    public class CRUD_Inscripcion: Public_Inscripciones, ICRUD<Inscripcion>
    {
        public CRUD_Inscripcion()
        { 
            
        }
        public Response<Inscripcion> Delete(string id_inscripcion)
        {
            if (GetLista() == null)
            {
                return new Response<Inscripcion>(false, "Lista vacia", null, null); // Lista vacia.
            }
            else
            {
                var list = GetLista();
                int pos = list.FindIndex(item => item.id == id_inscripcion); // Devuelve el indice (posicion) de un item de la lista que cumpla con la condicion 
                if (pos < 0)
                {
                    return new Response<Inscripcion>(false, "No se encontro el id del contrato que desea eliminar", null, null); // No se encontro el id del item que desea eliminar.
                }
                else
                {
                    Inscripcion contrato = ReturnFromList(id_inscripcion);
                    contrato.supervisor.ListaCliente_Supervisor.Remove(contrato.cliente); // el supervisor asignado se le añade a su propia lista el cliente.
                    list.RemoveAt(pos);
                    ar.Update(list);
                    return new Response<Inscripcion>(true, "Eliminado correctamente", null, null);  //Elimino correctamente.
                }
            }
        } 
        public List<Inscripcion> GetBySearch(string search)
        {
            if (GetLista() == null) 
            {
                return null; // retorna null si esta vacia.
            }
            else
            {
                return GetLista().FindAll(item => item.id.StartsWith(search) || item.cliente.nombre.Contains(search) || item.cliente.id.StartsWith(search)); // Find devuelve un item que cumplan la condicion del predicado.
            }
        }
        public Response<Inscripcion> Save(Inscripcion inscripcion) // guarda los contratos en una lista.
        {
            try
            {
                ValidateStatus();
                var lista = GetLista();
                if (inscripcion.cliente == null)
                {
                    return new Response<Inscripcion>(false, "El cliente no existe", null, null); // El cliente elegido no existe.
                }
                else if (inscripcion.supervisor == null)
                {
                    return new Response<Inscripcion>(false, "El supervisor no existe", null, null); // El supervisor elegido no existe.
                }
                else if (inscripcion.plan == null)
                {
                    return new Response<Inscripcion>(false, "El plan no existe", null, null); // El plan elegido no existe
                }
                else if (inscripcion.descuento < 0 || inscripcion.descuento > 100)
                {
                    return new Response<Inscripcion>(false, "Descuento fuera de rango", null, null); ; // descuento fuera de rango.
                }
                else if (inscripcion.cliente.fecha_nacimiento.AddYears(18) > DateTime.Now)
                {
                    return new Response<Inscripcion>(false, "Edad menor a 18", null, null);
                }
                else if (lista == null)
                {
                    inscripcion.precio = inscripcion.plan.precio * (100 - inscripcion.descuento) / 100;
                    ar.Save(inscripcion);
                    /*inscripcion.supervisor.ListaCliente_Supervisor.Add(inscripcion.cliente);*/
                    return new Response<Inscripcion>(true, "Inscripcion realizada correctamente.", null, null);
                }
                else if (!ValidateCliente(inscripcion.cliente.id))
                {
                    return new Response<Inscripcion>(false, "El cliente ya cuenta con un contrato", null, null);
                }
                else if (Exist(inscripcion.id))
                {
                    return new Response<Inscripcion>(false, "ID repetido", null, null); //ID repetido.
                }
                else
                {
                    inscripcion.precio = inscripcion.plan.precio * (100 - inscripcion.descuento) / 100;
                    ar.Save(inscripcion);
                    /*inscripcion.supervisor.ListaCliente_Supervisor.Add(inscripcion.cliente);*/
                    return new Response<Inscripcion>(true, "Inscripcion realizada correctamente.", null, null);
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Excepcion", null, null);
            }
        }
        public Response<Inscripcion> Update(Inscripcion inscripcionUpdate, string id_inscripcion) // reemplaza los datos de un contratoRenovado a otro.
        {
            try
            {
                var list = GetLista();
                if (list == null) { return new Response<Inscripcion>(true, "Lista Vacia", null, null); } // Lista vacia
                else
                {
                    var inscripcion = ReturnFromList(id_inscripcion);
                    if (inscripcion == null)
                    {
                        return new Response<Inscripcion>(false, "No se encontro ID", null, null); // No se encontro el id del contratoRenovado.
                    }
                    else if (inscripcionUpdate.cliente == null)
                    {
                        return new Response<Inscripcion>(false, "El cliente no existe", null, null); // El cliente no existe.
                    }
                    else if (inscripcionUpdate.supervisor == null)
                    {
                        return new Response<Inscripcion>(false, "El supervisor no existe", null, null); // El supervisor elegido no existe.
                    }
                    else if (inscripcionUpdate.plan == null)
                    {
                        return new Response<Inscripcion>(false, "El plan no existe", null, null); // El plan elegido no existe
                    }
                    else if (inscripcionUpdate.descuento < 0 || inscripcionUpdate.descuento > 100)
                    {
                        return new Response<Inscripcion>(false, "Descuento invalido", null, null); // descuento fuera de rango.
                    }
                    else if (Exist(inscripcionUpdate.id))
                    {
                        return new Response<Inscripcion>(false, "ID repetido", null, null); //ID repetido.
                    }
                    else
                    {
                        inscripcion.id = inscripcionUpdate.id;
                        inscripcion.fecha_inicio = inscripcionUpdate.fecha_inicio;
                        inscripcion.fecha_finalizacion = inscripcionUpdate.fecha_finalizacion;
                        inscripcion.precio = inscripcionUpdate.precio;
                        inscripcion.cliente = inscripcionUpdate.cliente;
                        inscripcion.plan = inscripcionUpdate.plan;

                        //int pos = inscripcion.supervisor.ListaCliente_Supervisor.FindIndex(item => item.id == inscripcion.cliente.id);
                        //if (inscripcion.supervisor != inscripcionUpdate.supervisor)
                        //{
                        //    inscripcion.supervisor.ListaCliente_Supervisor.RemoveAt(pos);
                        //    inscripcion.supervisor = inscripcionUpdate.supervisor;
                        //    inscripcion.supervisor.ListaCliente_Supervisor.Add(inscripcion.cliente);
                        //}
                        //else { inscripcion.supervisor = inscripcionUpdate.supervisor; }
                        inscripcion.supervisor = inscripcionUpdate.supervisor;
                        ValidateStatus();

                        return new Response<Inscripcion>(true, "Accion completada con exito", null, null); // reemplazo todo correctamente 
                    }
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Exception", null, null); // excepcion
            }
        }
        public List<Inscripcion> GetAll()
        {
            ValidateStatus();
            var lista = list.GetListaContrato(); ;
            if (lista == null) { return null; }
            return lista;
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
    }
}
