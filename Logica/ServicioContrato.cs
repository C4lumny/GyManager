using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Logica
{
    public class ServicioContrato
    {
        RepositorioContratos ar = new RepositorioContratos();
        ServicioSupervisor servicioSupervisor ;
        ServicioPlan servicioPlan;
        Listas list;
        public ServicioContrato()
        { 
            list = new Listas();
            servicioSupervisor = new ServicioSupervisor();
            servicioPlan = new ServicioPlan();
        }
        public Response<Inscripcion> Delete(string id_contrato)
        {
            if (GetLista() == null)
            {
                return new Response<Inscripcion>(false, "Lista vacia", null, null); // Lista vacia.
            }
            else
            {
                var list = GetLista();
                int pos = list.FindIndex(item => item.Id == id_contrato); // Devuelve el indice (posicion) de un item de la lista que cumpla con la condicion 
                if (pos < 0)
                {
                    return new Response<Inscripcion>(false, "No se encontro el id del contrato que desea eliminar", null, null); // No se encontro el id del item que desea eliminar.
                }
                else
                {
                    Inscripcion contrato = ReturnFromList(id_contrato);
                    contrato.cliente.estado = false; // el estado del cliente pasa a no contratado.
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
                return GetLista().FindAll(item => item.Id.StartsWith(search) || item.cliente.nombre.Contains(search) || item.cliente.id.StartsWith(search)); // Find devuelve un item que cumplan la condicion del predicado.
            }
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
        public List<Inscripcion> GetLista()
        {
            var lista = list.GetListaContrato(); ;
            if (lista == null) { return null; }
            return lista;  // retorna la lista de contratos, privada para esta clase.
        }
        public Response<Inscripcion> Save(Inscripcion contrato) // guarda los contratos en una lista.
        {
            try
            {
                if (contrato.cliente == null)
                {
                    return new Response<Inscripcion>(false, "El cliente no existe", null, null); // El cliente elegido no existe.
                }
                else if (contrato.supervisor == null)
                {
                    return new Response<Inscripcion>(false, "El supervisor no existe", null, null); // El supervisor elegido no existe.
                }
                else if (contrato.plan == null)
                {
                    return new Response<Inscripcion>(false, "El plan no existe", null, null); // El plan elegido no existe
                }
                else if (contrato.descuento < 0 || contrato.descuento > 100)
                {
                    return new Response<Inscripcion>(false, "Descuento fuera de rango", null, null); ; // descuento fuera de rango.
                }
                else if (contrato.cliente.fecha_nacimiento.AddYears(18) > DateTime.Now)
                {
                    return new Response<Inscripcion>(false, "Edad menor a 18", null, null); // Si la edad del cliente es menor a 18.
                }
                else if (contrato.cliente.estado == true)
                {
                    return new Response<Inscripcion>(false, "Ya cuenta con un contrato", null, null); // Ya tiene un contrato
                }
                else if (list.GetListaContrato() == null)
                {
                    contrato.precio = contrato.plan.precio * (100 - contrato.descuento) / 100;
                    contrato.cliente.estado = true;
                    ar.Save(contrato);
                    /*contrato.supervisor.ListaCliente_Supervisor.Add(contrato.cliente);*/
                    return new Response<Inscripcion>(true, "Guardado sin validar", null, null); // Si la lista esta vacia, guarda sin validar
                }
                else if (Exist(contrato.Id))
                {
                    return new Response<Inscripcion>(false, "ID repetido", null, null); //ID repetido.
                }
                else
                {
                    contrato.precio = contrato.plan.precio * (100 - contrato.descuento) / 100;
                    contrato.cliente.estado = true;
                    ar.Save(contrato);
                    /*contrato.supervisor.ListaCliente_Supervisor.Add(contrato.cliente);*/
                    return new Response<Inscripcion>(true, "Guardado", null, null); // Si la id ingresada no esta repetida, guarda en la lista
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Eliminado", null, null); //Te jodiste exception xd
            }
        }
        public Response<Inscripcion> Update(Inscripcion contratoUpdate, string id_contrato) // reemplaza los datos de un contratoRenovado a otro.
        {
            try
            {
                if (GetLista() == null) { return new Response<Inscripcion>(true, "Lista Vacia", null, null); } // Lista vacia
                else
                {
                    var contrato = ReturnFromList(id_contrato);
                    if (contrato == null)
                    {
                        return new Response<Inscripcion>(false, "No se encontro ID", null, null); // No se encontro el id del contratoRenovado.
                    }
                    else if (contratoUpdate.cliente == null)
                    {
                        return new Response<Inscripcion>(false, "El cliente no existe", null, null); // El cliente no existe.
                    }
                    else if (contratoUpdate.supervisor == null)
                    {
                        return new Response<Inscripcion>(false, "El supervisor no existe", null, null); // El supervisor elegido no existe.
                    }
                    else if (contratoUpdate.plan == null)
                    {
                        return new Response<Inscripcion>(false, "El plan no existe", null, null); // El plan elegido no existe
                    }
                    else if (contratoUpdate.descuento < 0 || contratoUpdate.descuento > 100)
                    {
                        return new Response<Inscripcion>(false, "Descuento invalido", null, null); // descuento fuera de rango.
                    }
                    else if (Exist(contratoUpdate.Id))
                    {
                        return new Response<Inscripcion>(false, "ID repetido", null, null); //ID repetido.
                    }
                    else
                    {
                        contrato.Id = contratoUpdate.Id;
                        contrato.fecha_inicio = contratoUpdate.fecha_inicio;
                        contrato.fecha_finalizacion = contratoUpdate.fecha_finalizacion;
                        contrato.precio = contratoUpdate.precio;
                        contrato.cliente = contratoUpdate.cliente;
                        contrato.plan = contratoUpdate.plan;

                        int pos = contrato.supervisor.ListaCliente_Supervisor.FindIndex(item => item.id == contrato.cliente.id);
                        if (contrato.supervisor != contratoUpdate.supervisor)
                        {
                            contrato.supervisor.ListaCliente_Supervisor.RemoveAt(pos);
                            contrato.supervisor = contratoUpdate.supervisor;
                            contrato.supervisor.ListaCliente_Supervisor.Add(contrato.cliente);
                        }
                        else { contrato.supervisor = contratoUpdate.supervisor; }

                        return new Response<Inscripcion>(true, "Accion completada con exito", null, null); // reemplazo todo correctamente 
                    }
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Exception", null, null); // excepcion
            }
        }
        bool Exist(string dato)
        {
            if (GetLista().FirstOrDefault(item => item.Id == dato) != null) // Valida si existe un item en la lista por medio de la id, retorna false si no encontro
            {
                return true;
            }
            return false;
        }
        public Inscripcion ReturnFromList(string id_Contrato) // retorna un item de la lista por medio de la id, retorna null si no encontro.
        {
            return GetLista().FirstOrDefault(item => item.Id == id_Contrato);
        }
        public Response<Inscripcion> Renovate(string id_contrato, int dias, string  id_supervisor, string id_plan, double descuento) // Renovacion del contratoRenovado.
        {
            // recibe la id del contratoRenovado, los dias de ampliacion del contratoRenovado, (puede ser del plan o personalizado) recibe un supervisor un plan y un descuento. 
            try
            {
                var contratoRenovado = new Inscripcion();
                var contratoCaducado = ReturnFromList(id_contrato);
                contratoRenovado.Id = contratoCaducado.Id;
                contratoRenovado.cliente = contratoCaducado.cliente;
                ValidateStatus(); contratoRenovado.estado = contratoCaducado.estado;
                var supervisor = servicioSupervisor.ReturnFromList(id_supervisor);
                var plan = servicioPlan.ReturnFromList(id_plan);
                var response = isRenovationValid(contratoRenovado, supervisor, plan, descuento);
                 if (!response.success)
                {
                    return response;
                }
                else
                {
                    if (contratoCaducado.supervisor != supervisor)
                    {
                        int pos = contratoCaducado.supervisor.ListaCliente_Supervisor.FindIndex(item => item.id == contratoRenovado.cliente.id);
                        contratoCaducado.supervisor.ListaCliente_Supervisor.RemoveAt(pos);
                        contratoRenovado.supervisor = supervisor;
                        supervisor.ListaCliente_Supervisor.Add(contratoRenovado.cliente);
                    }
                    else
                    {
                        contratoRenovado.supervisor = supervisor;
                    }
                    contratoRenovado.plan = plan;
                    contratoRenovado.descuento = descuento;
                    contratoRenovado.precio = plan.precio * (100 - descuento) / 100;
                    contratoRenovado.fecha_inicio = DateTime.Now;
                    contratoRenovado.fecha_finalizacion = contratoRenovado.fecha_inicio.AddDays(dias);
                    contratoRenovado.estado = true;
                    ar.Save(contratoRenovado);
                    return new Response<Inscripcion>(true, "Contrato renovado", null, null); // Renovo el contratoRenovado.
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Exception", null, null); // Excepcion
            }
        }
        public void ValidateStatus() // Valida el estado del contratoRenovado, utilizar antes de aplicar la renovacion y antes de consultar un contratoRenovado.
        {
            var lista = GetLista();
            if (lista != null)
            {
                foreach (var item in lista)
                {
                    Console.WriteLine(item.Id);
                    if (DateTime.Now >= item.fecha_finalizacion)
                    {
                        item.estado = false;
                    }
                }
                ar.Update(lista);
            }
        }
        Response<Inscripcion> isRenovationValid(Inscripcion contrato, Supervisor supervisor, PlanGimnasio plan, double descuento)
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
                    if(item.Id == contrato.Id && item.estado == true)
                    {
                        return new Response<Inscripcion>(false, "No es necesaria una renovacion", null, null); // El estado del contratoRenovado esta vigente, por ende no necesita renovacion.
                    }
                }
                return new Response<Inscripcion>(true, null, null, null); //??????
            }
        }
        public double Ganancia() // ganancia
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
    }
}
