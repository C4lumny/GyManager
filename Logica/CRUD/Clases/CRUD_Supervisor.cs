using Entidades;
using Logica.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class CRUD_Supervisor : Public_Turno_Supervisor, I_CRUD<Supervisor>
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
                if (supervisor.Horarios.Count > 0)
                {
                    var lista = Repositorio_Turnos.Load();
                    foreach (var item in lista)
                    {
                        if (item.Id_supervisor == id_supervisor)
                        {
                            lista.Remove(item);
                        }
                    }
                    Repositorio_Turnos.Update(lista);
                }
                Supervisores.RemoveAt(pos);
                Repositorio_Supervisores.Update(Supervisores);
                return new Response<Supervisor>(true, "El supervisor: " + supervisor.Nombre + ". Se ha eliminado correctamente", Supervisores, supervisor);
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
                return GetMainList().FindAll(item => item.Nombre.ToUpper().Contains(search.ToUpper()) || item.Telefono.ToUpper().StartsWith(search.ToUpper()) || item.Id.ToUpper().StartsWith(search.ToUpper()));
            }
        }
        public Response<Supervisor> Save(Supervisor supervisor)
        {
            try
            {
                var cases = new Dictionary<Func<bool>, Func<Response<Supervisor>>>
                {
                    { ()=> supervisor.Altura < 0, ()=> new Response<Supervisor>(false, "Altura invalida, ingrese correctamente los datos.") },
                    { ()=> supervisor.Peso < 0,()=>  new Response<Supervisor>(false, "Peso invalido, ingrese correctamente los datos.") },
                    { ()=> supervisor.Genero != "M" && supervisor.Genero != "F",()=>  new Response<Supervisor>(false, "Por favor ingrese un genero valido. Solo hay dos generos quieras o no") },
                    { ()=> supervisor.Fecha_nacimiento.AddYears(18) > DateTime.Now,()=>  new Response<Supervisor>(false, "Menor de 18 años, ingrese correctamente los datos.") },
                    { ()=> supervisor.Telefono.Any(@char => !char.IsDigit(@char)),()=>  new Response<Supervisor>(false, "Por favor ingrese correctamente el numero telefonico") },
                    { ()=> Exist(supervisor.Id),()=>  new Response<Supervisor>(false, "El ID del supervisor ya se encuentra registrado") },
                    { ()=> true, ()=>  Repositorio_Supervisores.Save(supervisor) }
                };
                return cases.First(pair => pair.Key()).Value();
            }
            catch (Exception)
            {
                return new Response<Supervisor>(false, "Error!", null, null);
            }
        }
        public Response<Supervisor> Update(Supervisor supervisor_modificado, string id_supervisor)
        {
            try
            {
                var Supervisores = GetMainList();
                var cases = new Dictionary<Func<bool>, Func<Response<Supervisor>>>
                {
                    { ()=> !Exist(id_supervisor), ()=> new Response<Supervisor>(false, "Altura invalida, ingrese correctamente los datos.") },
                    { ()=> supervisor_modificado.Altura < 0, ()=> new Response<Supervisor>(false, "Altura invalida, ingrese correctamente los datos.") },
                    { ()=> supervisor_modificado.Peso < 0,()=>  new Response<Supervisor>(false, "Peso invalido, ingrese correctamente los datos.") },
                    { ()=> supervisor_modificado.Genero != "M" && supervisor_modificado.Genero != "F",()=>  new Response<Supervisor>(false, "Por favor ingrese un genero valido. Solo hay dos generos quieras o no") },
                    { ()=> supervisor_modificado.Fecha_nacimiento.AddYears(18) > DateTime.Now, ()=>  new Response<Supervisor>(false, "Menor de 18 años, ingrese correctamente los datos.") },
                    { ()=> supervisor_modificado.Telefono.Any(@char => !char.IsDigit(@char)), ()=>  new Response<Supervisor>(false, "Por favor ingrese correctamente el numero telefonico") },
                    { ()=> Exist(supervisor_modificado.Id) && supervisor_modificado.Id != id_supervisor, ()=>  new Response<Supervisor>(false, "El ID del supervisor ya se encuentra registrado") },
                    { ()=> true, () => {
                        var supervisor = Supervisores.Find(item => item.Id == id_supervisor);
                        supervisor.Id = supervisor_modificado.Id;
                        supervisor.Nombre = supervisor_modificado.Nombre;
                        supervisor.Genero = supervisor_modificado.Genero;
                        supervisor.Telefono = supervisor_modificado.Telefono;
                        supervisor.Altura = supervisor_modificado.Altura;
                        supervisor.Peso = supervisor_modificado.Peso;
                        supervisor.Fecha_nacimiento = supervisor_modificado.Fecha_nacimiento;
                        supervisor.Fecha_ingreso = supervisor_modificado.Fecha_ingreso;
                        if (Repositorio_Supervisores.Update(Supervisores))
                        {
                            return new Response<Supervisor>(true, "Actualizo correctamente los datos del supervisor.", Supervisores, supervisor);
                        }
                        else
                        {
                            return new Response<Supervisor>(false, "Error!");
                        }
                    }
                    }
                };
                return cases.First(pair => pair.Key()).Value();
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
