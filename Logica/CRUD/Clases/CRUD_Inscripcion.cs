using Datos;
using Entidades;
using Logica.Operaciones;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Logica
{
    public class CRUD_Inscripcion: Operacion_Inscripciones, ICRUD<Inscripcion>
    {
        public CRUD_Inscripcion()
        { 
            
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
        public Response<Inscripcion> Save(Inscripcion contrato) // guarda los contratos en una lista.
        {
            try
            {
                var lista = GetLista();
                Console.WriteLine(contrato.cliente.ToString());
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
                else if (lista == null)
                {
                    contrato.precio = contrato.plan.precio * (100 - contrato.descuento) / 100;
                    contrato.cliente.estado = true;
                    ar.Save(contrato);
                    /*contrato.supervisor.ListaCliente_Supervisor.Add(contrato.cliente);*/
                    return new Response<Inscripcion>(true, "Inscripcion realizada correctamente.", null, null); // Si la lista esta vacia, guarda sin validar
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
                    return new Response<Inscripcion>(true, "Inscripcion realizada correctamente.", null, null); // Si la id ingresada no esta repetida, guarda en la lista
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
                var list = GetLista();
                if (list == null) { return new Response<Inscripcion>(true, "Lista Vacia", null, null); } // Lista vacia
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
       
    }
}
