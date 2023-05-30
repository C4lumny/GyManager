using Entidades;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;

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
                return new Response<Inscripcion>(false, "No se han encontrado inscripciones.");
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
                return new Response<Inscripcion>(true, "La inscripcion: " + inscripcion.Id + ". Se ha eliminado correctamente", Inscripciones, inscripcion);
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
                return GetMainList().FindAll(item => item.Id.ToString().StartsWith(search.ToUpper()) || item.C.Nombre.ToUpper().Contains(search.ToUpper()) ||
                item.cliente.Id.ToUpper().StartsWith(search.ToUpper()) || item.supervisor.Id.ToUpper().StartsWith(search.ToUpper()) || item.plan.Id.ToUpper().StartsWith(search.ToUpper()) ||
                item.Precio.ToString().Contains(search) || item.EstadoToString().ToUpper().Contains(search.ToUpper()));
            }
        }
        public Response<Inscripcion> Save(Inscripcion inscripcion)
        {
            try
            {
                inscripcion.Estado = DateTime.Now >= inscripcion.Fecha_finalizacion ? false : true;
                inscripcion.Precio = inscripcion.plan.Precio * (100 - inscripcion.Descuento) / 100;
                var cases = new Dictionary<Func<bool>, Func<Response<Inscripcion>>>
                {
                    { () => inscripcion.cliente == null, () => new Response<Inscripcion>(false, "El cliente ingresado no existe") },
                    { () => inscripcion.supervisor == null, () => new Response<Inscripcion>(false, "El supervisor ingresado no existe") },
                    { () => inscripcion.plan == null, () => new Response<Inscripcion>(false, "El plan ingresado no existe") },
                    { () => inscripcion.Descuento < 0 || inscripcion.Descuento > 100, () => new Response<Inscripcion>(false, "Descuento fuera de rango") },
                    { () => inscripcion.cliente.Fecha_nacimiento.AddYears(18) > DateTime.Now, () => new Response<Inscripcion>(false, "El cliente es menor de edad") },
                    { () => Exist(inscripcion.Id), () => new Response<Inscripcion>(false, "El ID de la inscripcion ya se encuentra registrado") },
                    { () => true, () => { Repositorio_Historial.Save(inscripcion); return Repositorio_Inscripciones.Save(inscripcion); }}
                };
                return cases.First(entry => entry.Key()).Value();
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
                var Inscripciones = GetMainList();
                var cases = new Dictionary<Func<bool>, Func<Response<Inscripcion>>>
                {
                    { () => Inscripciones == null, () => new Response<Inscripcion>(true, "No se han encontrado inscripciones") },
                    { () => inscipcion_modificada == null, () => new Response<Inscripcion>(false, "No se encontró la inscripción que se desea actualizar") },
                    { () => inscipcion_modificada.cliente == null, () => new Response<Inscripcion>(false, "El cliente ingresado no existe") },
                    { () => inscipcion_modificada.supervisor == null, () => new Response<Inscripcion>(false, "El supervisor ingresado no existe") },
                    { () => inscipcion_modificada.plan == null, () => new Response<Inscripcion>(false, "El plan ingresado no existe") },
                    { () => inscipcion_modificada.Descuento < 0 || inscipcion_modificada.Descuento > 100, () => new Response<Inscripcion>(false, "Descuento fuera de rango") },
                    { () => Exist(inscipcion_modificada.Id) && inscipcion_modificada.Id != id_inscripcion, () => new Response<Inscripcion>(false, "El ID ingresado ya está registrado. Por favor, ingrese otro") },
                    { () => true,  () =>
                        {
                            var inscripcion = Inscripciones.Find(item => item.Id == id_inscripcion);
                            inscripcion.Id = inscipcion_modificada.Id;
                            inscripcion.Fecha_inicio = inscipcion_modificada.Fecha_inicio;
                            inscripcion.Fecha_finalizacion = inscipcion_modificada.Fecha_finalizacion;
                            inscripcion.Precio = inscipcion_modificada.Precio;
                            inscripcion.cliente = inscipcion_modificada.cliente;
                            inscripcion.plan = inscipcion_modificada.plan;
                            inscripcion.supervisor = inscipcion_modificada.supervisor;
                            inscripcion.Estado = DateTime.Now >= inscripcion.Fecha_finalizacion ? false : true;
                            Repositorio_Historial.Save(inscripcion);
                            if (Repositorio_Inscripciones.Update(Inscripciones)) { return new Response<Inscripcion>(true, "Se ha actualizado la inscripción", Inscripciones, inscripcion); }
                            else { return new Response<Inscripcion>(false, "Error!"); }
                        }
                    }
                };
                return cases.First(entry => entry.Key()).Value();
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
        public Response<Inscripcion> Renovate(string id_inscripcion, int dias, string id_supervisor, int id_plan, int descuento)
        {
            try
            {
                Inscripcion inscripcion = ReturnInscripcion(id_inscripcion);
                Supervisoress supervisor = Op_supervisor.ReturnSupervisor(id_supervisor);
                PlanGimnasio plan = Op_planes.ReturnPlan(id_plan);

                var response = isRenovationValid(inscripcion, supervisor, plan, descuento);
                if (!response.Success)
                {
                    return response;
                }
                else
                {
                    inscripcion.SupervisorId = id_supervisor;
                    inscripcion.PlanId = id_plan;
                    inscripcion.Descuento = descuento;
                    inscripcion.Precio = plan.Precio * (100 - descuento) / 100;
                    inscripcion.FechaInicio = DateTime.Now;
                    inscripcion.FechaFinal = inscripcion.FechaInicio.AddDays(dias);
                    inscripcion.IdEstado = 0;
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
