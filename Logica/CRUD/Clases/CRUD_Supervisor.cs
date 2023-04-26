using Datos;
using Entidades;
using Logica.CRUD;
using Logica.Operaciones;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CRUD_Supervisor: Public_Supervisores, I_CRUD<Supervisor>  // Proporciona metodos para cumplir los requerimientos minimos del programa relacionados a los coaches.
    {
       
        public CRUD_Supervisor() { }
        public Response<Supervisor> Delete(string id_supervisor)
        {

            if (GetMainList() == null)
            {
                return new Response<Supervisor>(false, "Lista vacia"); // lista vacia
            }
            else
            {
                int pos = GetMainList().FindIndex(item => item.id == id_supervisor); 

                if (pos < 0) { return new Response<Supervisor>(false, "No se pudo encontrar el supervisor."); } 

                Supervisor supervisor = ReturnFromList(id_supervisor);

                GetMainList().RemoveAt(pos); return new Response<Supervisor>(true, "Eliminado correctamente.", null, supervisor); 
            }
        }
        public List<Supervisor> GetBySearch(string search)
        {
            if (GetMainList() == null)
            {
                return null;
            }
            else
            {
                return GetMainList().FindAll(item => item.nombre.Contains(search) || item.telefono.StartsWith(search)); // FindAll() devuelve una lista que cumplan la condicion del predicado.
            }
        }
        public Response<Supervisor> Save(Supervisor supervisor)
        {
            try
            {
                if (supervisor.altura < 0)
                {
                    return new Response<Supervisor>(false, "Altura invalida, ingrese correctamente los datos."); 
                }
                else if (supervisor.peso < 0)
                {
                    return new Response<Supervisor>(false, "Peso invalido, ingrese correctamente los datos."); 
                }
                else if (supervisor.fecha_nacimiento.AddYears(18) > DateTime.Now)
                {
                    return new Response<Supervisor>(false, "Menor de 18 años, ingrese correctamente los datos."); 
                }
                else if (GetMainList() == null)
                {
                        return ar_supervisor.Save(supervisor);
                }
                else if (Exist(supervisor.id))
                {
                    return new Response<Supervisor>(false, "El ID del supervisor ya se encuentra registrado");
                }
                else
                {
                    return ar_supervisor.Save(supervisor);
                    //GetMainList().Sort((p1, p2) => p1.fecha_ingreso.CompareTo(p2.fecha_ingreso)); //Orgraniza objetos por fecha de ingreso (opcional)
                    //return 0; // guarda el item en la lista.
                }
            }
            catch (Exception)
            {
                return new Response<Supervisor>(false, "Error!", null, null);
            }
        }
        public Response<Supervisor> Update(Supervisor supervisorUpdate, string id_supervisor)
        {
            try
            {
                if (GetMainList() == null) { return new Response<Supervisor>(false, "No se encuentra registrado ningun supervisor", null, null); } 
                else
                {
                    if (!Exist(id_supervisor))
                    {
                        return new Response<Supervisor>(false, "No se encontro el supervisor", null, null); 
                    }
                    else if (supervisorUpdate.altura < 0)
                    {
                        return new Response<Supervisor>(false, "Altura invalida, ingrese correctamente los datos.", null, null); 
                    }
                    else if (supervisorUpdate.peso < 0)
                    {
                        return new Response<Supervisor>(false, "Peso invalido, ingrese correctamente los datos.", null, null); 
                    }
                    else if (supervisorUpdate.fecha_nacimiento.AddYears(18) > DateTime.Now)
                    {
                        return new Response<Supervisor>(false, "Edad invalida (Menor de 18)", null, null); 
                    }
                    else if (Exist(supervisorUpdate.id))
                    {
                        return new Response<Supervisor>(false, "El ID del supervisor ya se encuentra registrado", null, null); 
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

                        return new Response<Supervisor>(true, "Actualizo correctamente los datos del supervisor.", null, supervisor);
                    }
                }
            }
            catch (Exception)
            {
                return new Response<Supervisor>(false, "Error!", null, null);
            }
        }
        public List<Supervisor> GetAll()
        {
            var lista = GetMainList();
            if (lista == null) { return null; }
            return lista; // retorna la lista de los supervisores de la clase Listas.
        }
    }
}
