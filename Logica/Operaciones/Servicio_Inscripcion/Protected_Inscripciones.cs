using Datos;
using Datos.Archivos.Repositorio;
using Entidades;
using Logica.Operaciones.AccesoProtegido;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica.Operaciones
{
    public class Protected_Inscripciones : Abs_ProtectedClass<Inscripcion>
    { 
        protected RepositorioInscripcionHistorica Repositorio_Historial = new RepositorioInscripcionHistorica();
        protected RepositorioInscripcion Repositorio_Inscripciones;
        protected Public_Clientes Op_clientes;
        protected Public_Supervisores Op_supervisor;
        protected Public_Planes Op_planes;
        public Protected_Inscripciones()
        {
            Repositorio_Inscripciones = new RepositorioInscripcion();
            Op_clientes = new Public_Clientes();
            Op_supervisor = new Public_Supervisores();
            Op_planes = new Public_Planes();
        }
        protected override bool Exist(string id_inscripcion)
        {
            if (GetMainList() != null)
            {
                return GetMainList().Any(item => item.Id == id_inscripcion);
            }
            else { return false; }
        }
        protected override List<Inscripcion> GetMainList()
        {
            var Inscripciones = Repositorio_Inscripciones.Load();
            if (Inscripciones == null)
            {
                return null;
            }
            else
            {
                var Inscripciones_actualizadas = new List<Inscripcion>(Inscripciones);
                foreach (var inscripcion in Inscripciones)
                {
                    if (inscripcion.cliente == null || inscripcion.supervisor == null || inscripcion.plan == null)
                    {
                        Inscripciones_actualizadas.Remove(inscripcion);
                    }
                    if (DateTime.Now >= inscripcion.Fecha_finalizacion)
                    {
                        inscripcion.Estado = false;
                    }
                }
                Repositorio_Inscripciones.Update(Inscripciones_actualizadas);
                return Inscripciones_actualizadas;
            }
        }
        protected Response<Inscripcion> isRenovationValid(Inscripcion inscripcion, Supervisor supervisor, PlanGimnasio plan, double descuento)
        {
            var Inscripciones = GetMainList();
            if (Inscripciones == null)
            {
                return new Response<Inscripcion>(false, "No se han registrado inscripciones.");
            }
            else if (inscripcion == null)
            {
                return new Response<Inscripcion>(false, "No se ha encontrado la inscripcion que desea renovar.");
            }
            else if (supervisor == null)
            {
                return new Response<Inscripcion>(false, "No se encontro el supervisor ingresado");
            }
            else if (plan == null)
            {
                return new Response<Inscripcion>(false, "No se encontro el plan ingresado");
            }
            else if (descuento > 100 || descuento < 0)
            {
                return new Response<Inscripcion>(false, "Descuento fuera de rango");
            }
            else if (inscripcion.Fecha_finalizacion <= DateTime.Now)
            {
                return new Response<Inscripcion>(false, "Hora de vencimiento invalida.");
            }
            else
            {
                foreach (var item in Inscripciones)
                {
                    if (item.Id == item.Id && item.Estado == true)
                    {
                        return new Response<Inscripcion>(false, "El cliente ya posee una inscripcion vigente.", null, null);
                    }
                }
                return new Response<Inscripcion>(true, null, null, inscripcion);
            }
        }
        protected bool isClienteValid(string id)
        {
            if (GetMainList().FirstOrDefault(item => item.cliente.Id == id) == null)
            {
                return true;
            }
            return false;
        }
    }
}
