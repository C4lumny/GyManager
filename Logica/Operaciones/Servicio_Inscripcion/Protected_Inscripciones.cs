using Datos;
using Datos.Archivos;
using Entidades;
using Logica.Operaciones.AccesoProtegido;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Protected_Inscripciones : Protected_GetArchivo
    {
        protected Response<Inscripcion> isRenovationValid(Inscripcion inscripcion, Supervisor supervisor, PlanGimnasio plan, double descuento)
        {
            var lista = GetMainList();
            if (lista == null)
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
            else
            {
                ValidateStatus();
                foreach (var item in lista)
                {
                    if (item.id == inscripcion.id && item.estado == true)
                    {
                        return new Response<Inscripcion>(false, "El cliente ya posee una inscripcion vigente.", null, null); 
                    }
                }
                return new Response<Inscripcion>(true, null, null, inscripcion); 
            }
        }
        protected bool ValidateCliente(string id)
        {
            if (GetMainList().FirstOrDefault(item => item.cliente.id == id) == null)
            {
                return true;
            }
            return false;
        }
        protected void ValidateStatus()
        {
            var lista = GetMainList();
            if (lista != null)
            {
                foreach (var item in lista)
                {
                    if (DateTime.Now >= item.fecha_finalizacion)
                    {
                        item.estado = false;
                    }
                }
                ar_inscripcion.Update(lista);
            }
        }
    }
}
