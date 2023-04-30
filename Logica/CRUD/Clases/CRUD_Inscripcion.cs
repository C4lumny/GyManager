using Entidades;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class CRUD_Inscripcion : Public_Inscripciones, I_CRUD<Inscripcion>
    {
        public CRUD_Inscripcion()
        {

        }
        public Response<Inscripcion> Delete(string id_inscripcion)
        {
            var Inscripciones = GetMainList();
            if (Inscripciones == null)
            {
                return new Response<Inscripcion>(false, "No se han encontrado inscripciones."); // Lista vacia.
            }
            else
            {
                int pos = Inscripciones.FindIndex(item => item.Id == id_inscripcion);
                Inscripcion inscripcion = ReturnInscripcion(id_inscripcion);
                if (inscripcion == null)
                {
                    return new Response<Inscripcion>(false, "No se encontro el id del contrato que desea eliminar");
                }
                Inscripciones.RemoveAt(pos);
                Repositorio_Inscripciones.Update(Inscripciones);
                return new Response<Inscripcion>(true, "Inscripcion eliminada correctamente", null, inscripcion);
            }
        }
        public List<Inscripcion> GetBySearch(string search)
        {
            if (GetMainList() == null)
            {
                return null;
            }
            else
            {
                return GetMainList().FindAll(item => item.Id.StartsWith(search) || item.cliente.Nombre.Contains(search) || item.cliente.Id.StartsWith(search));
            }
        }
        public Response<Inscripcion> Save(Inscripcion inscripcion)
        {
            try
            {
                var lista = GetMainList();
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
                else if (inscripcion.Descuento < 0 || inscripcion.Descuento > 100)
                {
                    return new Response<Inscripcion>(false, "Descuento fuera de rango");
                }
                else if (inscripcion.cliente.Fecha_nacimiento.AddYears(18) > DateTime.Now)
                {
                    return new Response<Inscripcion>(false, "El cliente es menor de edad.");
                }
                else if (lista == null)
                {
                    inscripcion.Precio = inscripcion.plan.Precio * (100 - inscripcion.Descuento) / 100;
                    Repositorio_Historial.Save(inscripcion);
                    return Repositorio_Inscripciones.Save(inscripcion);
                }
                else if (!isClienteValid(inscripcion.cliente.Id))
                {
                    return new Response<Inscripcion>(false, "El cliente ya esta inscrito");
                }
                else if (Exist(inscripcion.Id))
                {
                    return new Response<Inscripcion>(false, "El ID de la inscripcion ya se encuentra registrado.");
                }
                else
                {
                    inscripcion.Precio = inscripcion.plan.Precio * (100 - inscripcion.Descuento) / 100;
                    Repositorio_Historial.Save(inscripcion);
                    return Repositorio_Inscripciones.Save(inscripcion);
                }
            }
            catch (Exception)
            {
                return new Response<Inscripcion>(false, "Error!");
            }
        }
        public Response<Inscripcion> Update(Inscripcion inscipcion_modificada, string id_inscripcion)
        {
            try
            {
                var list = GetMainList();
                if (list == null) { return new Response<Inscripcion>(true, "No se han encontrado inscripciones."); }
                else
                {
                    var inscripcion = ReturnInscripcion(id_inscripcion);
                    if (inscripcion == null)
                    {
                        return new Response<Inscripcion>(false, "No se encontro la inscripcion que se desea actualizar.");
                    }
                    else if (inscipcion_modificada.cliente == null)
                    {
                        return new Response<Inscripcion>(false, "El cliente ingresado no existe");
                    }
                    else if (inscipcion_modificada.supervisor == null)
                    {
                        return new Response<Inscripcion>(false, "El supervisor ingresado no existe");
                    }
                    else if (inscipcion_modificada.plan == null)
                    {
                        return new Response<Inscripcion>(false, "El plan ingresado no existe");
                    }
                    else if (inscipcion_modificada.Descuento < 0 || inscipcion_modificada.Descuento > 100)
                    {
                        return new Response<Inscripcion>(false, "Descuento fuera de rango");
                    }
                    else if (ReturnInscripcion(inscipcion_modificada.Id) == null)
                    {
                        return new Response<Inscripcion>(false, "El ID ingresado ya esta registrado. Por favor ingrese otro");
                    }
                    else
                    {
                        inscripcion.Id = inscipcion_modificada.Id;
                        inscripcion.Fecha_inicio = inscipcion_modificada.Fecha_inicio;
                        inscripcion.Fecha_finalizacion = inscipcion_modificada.Fecha_finalizacion;
                        inscripcion.Precio = inscipcion_modificada.Precio;
                        inscripcion.cliente = inscipcion_modificada.cliente;
                        inscripcion.plan = inscipcion_modificada.plan;
                        inscripcion.supervisor = inscipcion_modificada.supervisor;
                        Repositorio_Historial.Save(inscripcion);
                        if (Repositorio_Inscripciones.Update(list))
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
            var Inscripciones = GetMainList();
            if (Inscripciones == null) { return null; }
            return Inscripciones;
        }
        public Response<Inscripcion> Renovate(string id_inscripcion, int dias, string id_supervisor, string id_plan, double descuento)
        {
            try
            {
                Inscripcion inscripcion = ReturnInscripcion(id_inscripcion);
                Supervisor supervisor = Op_supervisor.ReturnSupervisor(id_supervisor);
                PlanGimnasio plan = Op_planes.ReturnPlan(id_plan);

                var response = isRenovationValid(inscripcion, supervisor, plan, descuento);
                if (!response.Success)
                {
                    return response;
                }
                else
                {
                    inscripcion.supervisor = supervisor;
                    inscripcion.plan = plan;
                    inscripcion.Descuento = descuento;
                    inscripcion.Precio = plan.Precio * (100 - descuento) / 100;
                    inscripcion.Fecha_inicio = DateTime.Now;
                    inscripcion.Fecha_finalizacion = inscripcion.Fecha_inicio.AddDays(dias);
                    inscripcion.Estado = true;
                    Repositorio_Historial.Save(inscripcion);
                    Repositorio_Inscripciones.Save(inscripcion);
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
