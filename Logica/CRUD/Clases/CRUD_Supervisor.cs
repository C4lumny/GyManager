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
    public class CRUD_Supervisor: Public_Turno_Supervisor, I_CRUD<Supervisor> 
    {
       
        public CRUD_Supervisor() { }
        public Response<Supervisor> Delete(string id_supervisor)
        {
            var Supervisores = GetMainList();
            if (Supervisores == null)
            {
                return new Response<Supervisor>(false, "Lista vacia"); 
            }
            else
            {
                int pos = Supervisores.FindIndex(item => item.Id == id_supervisor);
                Supervisor supervisor = ReturnSupervisor(id_supervisor);
                if (pos < 0) { return new Response<Supervisor>(false, "No se pudo encontrar el supervisor."); } 
                var lista = Repositorio_Turnos.Load();
                if (supervisor.Horarios.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        if (item.Id_supervisor == id_supervisor)
                        {
                            lista.Remove(item);
                        }
                    }
                }
                Repositorio_Turnos.Update(lista);
                Repositorio_Supervisores.Update(Supervisores);
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
                return GetMainList().FindAll(item => item.Nombre.Contains(search) || item.Telefono.StartsWith(search)); // FindAll() devuelve una lista que cumplan la condicion del predicado.
            }
        }
        public Response<Supervisor> Save(Supervisor supervisor)
        {
            try
            {
                if (supervisor.Altura < 0)
                {
                    return new Response<Supervisor>(false, "Altura invalida, ingrese correctamente los datos."); 
                }
                else if (supervisor.Peso < 0)
                {
                    return new Response<Supervisor>(false, "Peso invalido, ingrese correctamente los datos."); 
                }
                else if (supervisor.Fecha_nacimiento.AddYears(18) > DateTime.Now)
                {
                    return new Response<Supervisor>(false, "Menor de 18 años, ingrese correctamente los datos."); 
                }
                else if (GetMainList() == null)
                {
                        return Repositorio_Supervisores.Save(supervisor);
                }
                else if (Exist(supervisor.Id))
                {
                    return new Response<Supervisor>(false, "El ID del supervisor ya se encuentra registrado");
                }
                else
                {
                    return Repositorio_Supervisores.Save(supervisor);
                }
            }
            catch (Exception)
            {
                return new Response<Supervisor>(false, "Error!", null, null);
            }
        }
        public Response<Supervisor> Update(Supervisor supervosr_modificado, string id_supervisor)
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
                    else if (supervosr_modificado.Altura < 0)
                    {
                        return new Response<Supervisor>(false, "Altura invalida, ingrese correctamente los datos.", null, null); 
                    }
                    else if (supervosr_modificado.Peso < 0)
                    {
                        return new Response<Supervisor>(false, "Peso invalido, ingrese correctamente los datos.", null, null); 
                    }
                    else if (supervosr_modificado.Fecha_nacimiento.AddYears(18) > DateTime.Now)
                    {
                        return new Response<Supervisor>(false, "Edad invalida (Menor de 18)", null, null); 
                    }
                    else if (Exist(supervosr_modificado.Id))
                    {
                        return new Response<Supervisor>(false, "El ID del supervisor ya se encuentra registrado", null, null); 
                    }
                    else
                    {
                        var supervisor = ReturnSupervisor(id_supervisor);
                        supervisor.Id = supervosr_modificado.Id;
                        supervisor.Nombre = supervosr_modificado.Nombre;
                        supervisor.Genero = supervosr_modificado.Genero;
                        supervisor.Telefono = supervosr_modificado.Telefono;
                        supervisor.Altura = supervosr_modificado.Altura;
                        supervisor.Peso = supervosr_modificado.Peso;
                        supervisor.Fecha_nacimiento = supervosr_modificado.Fecha_nacimiento;
                        supervisor.Fecha_ingreso = supervosr_modificado.Fecha_ingreso; 
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
            var Supervisores = GetMainList();
            if (Supervisores == null) { return null; }
            return Supervisores; // retorna la lista de los supervisores de la clase Listas.
        }
    }
}
