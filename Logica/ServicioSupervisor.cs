using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioSupervisor  // Proporciona metodos para cumplir los requerimientos minimos del programa relacionados a los coaches.
    {
        Listas list;
        RepositorioUsuarios ar = new RepositorioUsuarios();
        public ServicioSupervisor() { list = new Listas(); }
        public Response<Supervisor> Delete(string id_supervisor)
        {
            if (GetLista() == null)
            {
                return new Response<Supervisor>(false, "Lista vacia", null, null); // lista vacia
            }
            else
            { 
                int pos = GetLista().FindIndex(item => item.id == id_supervisor); // Devuelve el indice (posicion) de la lista que cumpla con la condicion 

                if (pos < 0) { return new Response<Supervisor>(false, "No se pudo encontrar el supervisor.", null, null); } // No se encontro el id del objeto q desea eliminar.
                
                GetLista().RemoveAt(pos); return new Response<Supervisor>(true, "Eliminado correctamente.", null, null); //Elimino correctamente.
            }
        }
        public List<Supervisor> GetBySearch(string search)
        {
            if (GetLista() == null)
            {
                return null;
            }
            else
            {
                return GetLista().FindAll(item => item.nombre.Contains(search) || item.telefono.StartsWith(search)); // FindAll() devuelve una lista que cumplan la condicion del predicado.
            }
        }
        public List<Supervisor> GetLista()
        {
            if (list.GetListaSupervisor() == null)
            {
                return null;
            }
            return list.GetListaSupervisor(); // retorna la lista de los supervisores de la clase Listas.
        }
        public Response<Supervisor> Save(Supervisor supervisor)
        {
            try
            {
                if (supervisor.altura < 0)
                {
                    return new Response<Supervisor>(false, "Altura invalida", null, null); // altura menor a 0
                }
                else if (supervisor.peso < 0)
                {
                    return new Response<Supervisor>(false, "Peso invalido", null, null); // peso menor a 0
                }
                else if (supervisor.fecha_nacimiento.AddYears(18) > DateTime.Now)
                {
                    return new Response<Supervisor>(false, "Menor de 18 años", null, null); // menor de 18 años.
                }
                else if (GetLista() == null)
                {
                    if (ar.Save(supervisor))
                    {
                        return new Response<Supervisor>(true, "Registrado correctamente", null, null);
                    }
                    else
                    {
                        return new Response<Supervisor>(false, "EXCEPTION", null, null);
                    }
                    // guarda el item en la lista.
                }
                else if (!ValidateID(supervisor.id))
                {
                    return new Response<Supervisor>(false, "ID repetido", null, null); // id repetido
                }
                else
                {
                    if (ar.Save(supervisor))
                    {
                        return new Response<Supervisor>(true, "Guardado", null, null);
                    }
                    else
                    {
                        return new Response<Supervisor>(false, "EXCEPTION", null, null);
                    }
                    //GetLista().Sort((p1, p2) => p1.fecha_ingreso.CompareTo(p2.fecha_ingreso)); //Orgraniza objetos por fecha de ingreso (opcional)
                    //return 0; // guarda el item en la lista.
                }
            }
            catch (Exception)
            {
                return new Response<Supervisor>(false, "EXCEPTION", null, null); //Te jodiste exception xd
            }
        }
        public Response<Supervisor> Update(Supervisor supervisorUpdate, string id_supervisor)
        {
            try
            {
                if (GetLista() == null) { return new Response<Supervisor>(false, "Lista vacia", null, null); } // Lista vacia
                else
                {
                    if (!Exist(id_supervisor))
                    {
                        return new Response<Supervisor>(false, "No se pudo encontrar", null, null); // No se encontro el id del objeto para actualizar.
                    }
                    else if (supervisorUpdate.altura < 0)
                    {
                        return new Response<Supervisor>(false, "Altura invalida", null, null); // altura menor a 0
                    }
                    else if (supervisorUpdate.peso < 0)
                    {
                        return new Response<Supervisor>(false, "Peso invalido", null, null); // peso menor a 0
                    }
                    else if (supervisorUpdate.fecha_nacimiento.AddYears(18) > DateTime.Now)
                    {
                        return new Response<Supervisor>(false, "Edad invalida (Menor de 18)", null, null); // menor de 18 años.
                    }
                    else if (!ValidateID(supervisorUpdate.id))
                    {
                        return new Response<Supervisor>(false, "ID repetido", null, null); //ID repetido al momento de actualizar.
                    }
                    else
                    {
                        var supervisor = ReturnFromList(id_supervisor);
                        supervisor.id = supervisorUpdate.id;
                        supervisor.nombre = supervisorUpdate.nombre;
                        supervisor.genero = supervisorUpdate.genero;
                        supervisor.telefono = supervisorUpdate.telefono;
                        supervisor.altura = supervisorUpdate.altura;
                        supervisor.peso = supervisorUpdate.peso;
                        supervisor.fecha_nacimiento = supervisorUpdate.fecha_nacimiento;
                        supervisor.fecha_ingreso = supervisorUpdate.fecha_ingreso; 
                        supervisor.estado = supervisorUpdate.estado;

                        return new Response<Supervisor>(true, "Reemplazado correctamente", null, null); //Reemplazo correctamente.
                    }
                }
            }
            catch (Exception)
            {
                return new Response<Supervisor>(false, "EXCEPTION", null, null);
            }
        }
        bool ValidateID(string id_supervisor)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_supervisor) == null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                if (GetLista() == null) // tambien valida la id del cliente para saber si un cliente tiene la misma id de un supervisor.
                {
                    return true; // retorna true cuando la id es completamente valida.
                }
                else if (list.GetListaCliente().FirstOrDefault(item => item.id == id_supervisor) == null)
                {
                    return true;
                }
                else
                {
                    return false; // encontro en la lista de clientes una id repetida.
                }
            }
            return false; // encontro una id repetida en los supervisores.
        }
        bool Exist(string id_supervisor)
        {
            if (GetLista().FirstOrDefault(item => item.id == id_supervisor) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true; // encontro una id existente.
            }
            return false; // no encontro.
        }
        public Supervisor ReturnFromList(string id_supervisor) 
        {
            return GetLista().FirstOrDefault(item => item.id == id_supervisor); // devuelve null si no encontro un item, devuelve el item de la lista de supervisores en el cado de que la condicion se cuampla.
        }
    }
}
