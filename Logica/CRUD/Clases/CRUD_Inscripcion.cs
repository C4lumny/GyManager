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
    public class CRUD_Inscripcion: Public_Inscripciones, I_CRUD<Inscripcion>
    {
        public CRUD_Inscripcion()
        { 
            
        }
        public Response<Inscripcion> Delete(string id_inscripcion)
        {
            if (GetLista() == null)
            {
                return new Response<Inscripcion>(false, "No se han encontrado inscripciones."); // Lista vacia.
            }
            else
            {
                var list = GetLista();
                int pos = list.FindIndex(item => item.id == id_inscripcion); 
                if (pos < 0)
                {
                    return new Response<Inscripcion>(false, "No se encontro el id del contrato que desea eliminar"); 
                }
                Inscripcion inscripcion = ReturnFromList(id_inscripcion);
                inscripcion.supervisor.ListaClientes.Remove(inscripcion.cliente); 
                list.RemoveAt(pos);
                ar_inscripcion.Update(list);
                return new Response<Inscripcion>(true, "Inscripcion eliminada correctamente", null, inscripcion);  
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
        public Response<Inscripcion> Save(Inscripcion inscripcion) 
        {
            try
            {
                ValidateStatus();
                var lista = GetLista();
                if (inscripcion.cliente == null)
                {
                    return new Response<Inscripcion>(false, "El cliente ingresado no existe");
                }
                else if (inscripcion.supervisor == null)
                {
                    return new Response<Inscripcion>(false, "El supervisor ingresado no existe");
                }
                else if (inscripcion.plan == null)
                {
                    return new Response<Inscripcion>(false, "El plan ingresado no existe");
                }
                else if (inscripcion.descuento < 0 || inscripcion.descuento > 100)
                {
                    return new Response<Inscripcion>(false, "Descuento fuera de rango"); 
                }
                else if (inscripcion.cliente.fecha_nacimiento.AddYears(18) > DateTime.Now)
                {
                    return new Response<Inscripcion>(false, "El cliente es menor de edad.");
                }
                else if (lista == null)
                {
                    inscripcion.precio = inscripcion.plan.precio * (100 - inscripcion.descuento) / 100;

                    /*inscripcion.supervisor.ListaClientes.Add(inscripcion.cliente);*/
                    return ar_inscripcion.Save(inscripcion);
                }
                else if (!ValidateCliente(inscripcion.cliente.id))
                {
                    return new Response<Inscripcion>(false, "El cliente ya esta inscrito");
                }
                else if (Exist(inscripcion.id))
                {
                    return new Response<Inscripcion>(false, "El ID de la inscripcion ya se encuentra registrado."); 
                }
                else
                {
                    inscripcion.precio = inscripcion.plan.precio * (100 - inscripcion.descuento) / 100;
                    /*inscripcion.supervisor.ListaClientes.Add(inscripcion.cliente);*/
                    return ar_inscripcion.Save(inscripcion);
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Error!");
            }
        }
        public Response<Inscripcion> Update(Inscripcion inscripcionUpdate, string id_inscripcion) 
        {
            try
            {
                var list = GetLista();
                if (list == null) { return new Response<Inscripcion>(true, "No se han encontrado inscripciones."); } 
                else
                {
                    var inscripcion = ReturnFromList(id_inscripcion);
                    if (inscripcion == null)
                    {
                        return new Response<Inscripcion>(false, "No se encontro la inscripcion que se desea actualizar."); 
                    }
                    else if (inscripcionUpdate.cliente == null)
                    {
                        return new Response<Inscripcion>(false, "El cliente ingresado no existe"); 
                    }
                    else if (inscripcionUpdate.supervisor == null)
                    {
                        return new Response<Inscripcion>(false, "El supervisor ingresado no existe"); 
                    }
                    else if (inscripcionUpdate.plan == null)
                    {
                        return new Response<Inscripcion>(false, "El plan ingresado no existe");
                    }
                    else if (inscripcionUpdate.descuento < 0 || inscripcionUpdate.descuento > 100)
                    {
                        return new Response<Inscripcion>(false, "Descuento fuera de rango"); 
                    }
                    else if (Exist(inscripcionUpdate.id))
                    {
                        return new Response<Inscripcion>(false, "El ID ingresado ya esta registrado. Por favor ingrese otro"); 
                    }
                    else
                    {
                        inscripcion.id = inscripcionUpdate.id;
                        inscripcion.fecha_inicio = inscripcionUpdate.fecha_inicio;
                        inscripcion.fecha_finalizacion = inscripcionUpdate.fecha_finalizacion;
                        inscripcion.precio = inscripcionUpdate.precio;
                        inscripcion.cliente = inscripcionUpdate.cliente;
                        inscripcion.plan = inscripcionUpdate.plan;

                        //int pos = inscripcion.supervisor.ListaClientes.FindIndex(item => item.id == inscripcion.cliente.id);
                        //if (inscripcion.supervisor != inscripcionUpdate.supervisor)
                        //{
                        //    inscripcion.supervisor.ListaClientes.RemoveAt(pos);
                        //    inscripcion.supervisor = inscripcionUpdate.supervisor;
                        //    inscripcion.supervisor.ListaClientes.Add(inscripcion.cliente);
                        //}
                        //else { inscripcion.supervisor = inscripcionUpdate.supervisor; }
                        inscripcion.supervisor = UpdateSupervisorList(inscripcion, inscripcionUpdate);
                        ValidateStatus();
                        if (ar_inscripcion.Update(list))
                        {
                            return new Response<Inscripcion>(true, "Se ha actualizado la inscripcion", list, inscripcion); 
                        }
                        else
                        {
                            return new Response<Inscripcion>(false, "Error!"); 
                        }
                    }
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Error!"); 
            }
        }
        public List<Inscripcion> GetAll()
        {
            ValidateStatus();
            var lista = GetLista(); 
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
                    //    int pos = contratoCaducado.id_supervisor.ListaClientes.FindIndex(item => item.id == id_inscripcion.cliente.id);
                    //    contratoCaducado.id_supervisor.ListaClientes.RemoveAt(pos);
                    //    id_inscripcion.id_supervisor = id_supervisor;
                    //    id_supervisor.ListaClientes.Add(id_inscripcion.cliente);
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
                    ar_inscripcion.Save(inscripcion);
                    return new Response<Inscripcion>(true, "Contrato renovado correctamente."); 
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Error!"); 
            }
        }
    }
}
