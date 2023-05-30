using Entidades;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class CRUD_Cliente : Public_Clientes, I_CRUD<Clientess> // Proporciona metodos para cumplir los requerimientos minimos del programa relacionados al cliente.
    {
        public CRUD_Cliente() { }
        public Response<Clientess> Delete(string Id_cliente)
        {
            var Clientes = GetMainList();
            if (Clientes == null)
            {
                return new Response<Clientess>(false, "La lista esta vacia");
            }
            else
            {
                int pos = Clientes.FindIndex(item => item.Id == Id_cliente);
                Clientess cliente = ReturnCliente(Id_cliente);
                if (cliente == null) { return new Response<Clientess>(false, "No se ha encontrado el cliente que se desea eliminar."); }
                Clientes.RemoveAt(pos);
                if (Repositorio_Clientes.Update(Clientes))
                {
                    return new Response<Clientess>(true, "El cliente: " + cliente.Nombre +  ". Se ha eliminado correctamente", Clientes, cliente);
                }
                else
                {
                    return new Response<Clientess>(false, "No se ha podido eliminar el cliente.");
                }
            }
        } 
        public List<Clientess> GetBySearch(string search)
        {
            if (GetMainList() == null)
            {
                return null;
            }
            else
            {
                return GetMainList().FindAll(cliente => cliente.Nombre.ToUpper().Contains(search.ToUpper()) || cliente.Telefono.ToUpper().StartsWith(search.ToUpper()) || cliente.Id.ToUpper().StartsWith(search.ToUpper()));
            }
        }
        public Response<Clientess> Save(Clientess cliente)
        {
            try
            {
                Dictionary<Func<bool>, Func<Response<Clientess>>> cases = new Dictionary<Func<bool>, Func<Response<Clientess>>>
                {
                    { () => cliente.Telefono.Any(@char => !char.IsDigit(@char)), () => new Response<Clientess>(false, "Por favor ingrese correctamente el numero telefonico") },
                    { () => cliente.Genero != "M" && cliente.Genero != "F", () => new Response<Clientess>(false, "Por favor ingrese un genero valido. Solo hay dos generos quieras o no") },
                    { () => cliente.Fecha_nacimiento > DateTime.Now, () => new Response<Clientess>(false, "Fecha de nacimiento invalida, No se ha podido registrar el cliente") },
                    { () => Exist(cliente.Id), () => new Response<Clientess>(false, "Ya tiene registrado un cliente con la misma ID") },
                    { () => true, () => Repositorio_Clientes.Insert(cliente) }
                };
                return cases.First(entry => entry.Key()).Value();
            }
            catch (Exception)
            {
                return new Response<Clientess>(false, "Error!", null, null);
            }
        }
        public Response<Clientess> Update(Clientess cliente_Modificado, string Id_cliente)
        {
            try
            {
                var Clientes = GetMainList();
                Dictionary<Func<bool>, Func<Response<Clientess>>> cases = new Dictionary<Func<bool>, Func<Response<Clientess>>>
                {
                    { () => Clientes == null, () => new Response<Clientess>(false, "Lista vacia") },
                    { () => !Exist(Id_cliente), () => new Response<Clientess>(false, "No se encontro el id del cliente a actualizar") },
                    { () => cliente_Modificado.Telefono.Any(@char => !char.IsDigit(@char)), () => new Response<Clientess>(false, "Por favor ingrese correctamente el numero telefonico") },
                    { () => cliente_Modificado.Genero != "M" && cliente_Modificado.Genero != "F", () => new Response<Clientess>(false, "Por favor ingrese un genero valido. Solo hay dos generos quieras o no") },
                    { () => cliente_Modificado.Fecha_nacimiento > DateTime.Now, () => new Response<Clientess>(false, "Fecha de nacimiento mayor a la fecha actual") },
                    { () => Exist(cliente_Modificado.Id) && cliente_Modificado.Id != Id_cliente, () => new Response<Clientess>(false, "El ID del cliente que desea actualizar ya se encuentra registrado.") },
                    { () => true,  () => {

                        var cliente = Clientes.Find(item => item.Id == Id_cliente);
                        cliente.Id = cliente_Modificado.Id;
                        cliente.Nombre = cliente_Modificado.Nombre;
                        cliente.Apellido = cliente_Modificado.Apellido;
                        cliente.Genero = cliente_Modificado.Genero;
                        cliente.Telefono = cliente_Modificado.Telefono;
                        cliente.Fecha_nacimiento = cliente_Modificado.Fecha_nacimiento;
                        cliente.Fecha_ingreso = cliente_Modificado.Fecha_ingreso;
                        if (Repositorio_Clientes.Update(Clientes)) { return new Response<Clientess>(true, "Se ha actualizado el cliente.", Clientes, cliente); }
                        else { return new Response<Clientess>(false, "Error!"); } }  }
                };
                return cases.First(entry => entry.Key()).Value();
            }
            catch (Exception)
            {
                return new Response<Clientess>(false, "Error!", null, null);
            }
        }
        public List<Clientess> GetAll()
        {
            var Clientes = GetMainList();
            if (Clientes == null) { return null; }
            return Clientes;
        }
    }
}
