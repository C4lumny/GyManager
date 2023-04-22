using Datos;
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
    public class Protected_Inscripciones : AbsGetListas<Inscripcion>
    {
        protected Public_Clientes op_Clientes;
        protected Public_Supervisores op_supervisor;
        protected Public_Planes op_plan;
        protected RepositorioInscripcion ar_inscripcion;
        protected Protected_Inscripciones()
        {
            ar_inscripcion = new RepositorioInscripcion();
            op_Clientes = new Public_Clientes();
            op_supervisor = new Public_Supervisores();
            op_plan = new Public_Planes();
        }
        protected Response<Inscripcion> isRenovationValid(Inscripcion inscripcion, Supervisor supervisor, PlanGimnasio plan, double descuento)
        {
            var lista = GetLista();
            if (lista == null)
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
                ValidateStatus();
                foreach (var item in lista)
                {
                    if (item.id == inscripcion.id && item.estado == true)
                    {
                        return new Response<Inscripcion>(false, "No es necesaria una renovacion", null, null); // El estado del id_inscripcion esta vigente, por ende no necesita renovacion.
                    }
                }
                return new Response<Inscripcion>(true, null, null, inscripcion); 
            }
        }
        protected override bool Exist(string id_inscripcion)
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
        protected bool ValidateCliente(string id)
        {
            if (GetLista().FirstOrDefault(item => item.cliente.id == id) == null)
            {
                return true;
            }
            return false;
        }
        protected override List<Inscripcion> GetLista()
        {
            var lista = ar_inscripcion.Load();
            if (lista == null) { return null; }
            return lista;  // retorna la lista de contratos, privada para esta clase.
        }
        protected void ValidateStatus()
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
                ar_inscripcion.Update(lista);
            }
        }
    }
}
