using Entidades;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class CRUD_Cliente : Public_Clientes, I_CRUD<Cliente> // Proporciona metodos para cumplir los requerimientos minimos del programa relacionados al cliente.
    {
        public CRUD_Cliente() { }
        public Response<Cliente> Delete(string Id_cliente)
        {
            var Clientes = GetMainList();
            if (Clientes == null)
            {
                return new Response<Cliente>(false, "La lista esta vacia");
            }
            else
            {
                int pos = Clientes.FindIndex(item => item.Id == Id_cliente);
                Cliente cliente = ReturnCliente(Id_cliente);
                if (cliente == null) { return new Response<Cliente>(false, "No se ha encontrado el cliente que se desea eliminar."); }
                Clientes.RemoveAt(pos);
                if (Repositorio_Clientes.Update(Clientes))
                {
                    return new Response<Cliente>(true, "El cliente: " + cliente.Nombre +  ". Se ha eliminado correctamente", Clientes, cliente);
                }
                else
                {
                    return new Response<Cliente>(false, "No se ha podido eliminar el cliente.");
                }
            }
        } 
        public List<Cliente> GetBySearch(string search)
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
        public Response<Cliente> Save(Cliente cliente)
        {
            cliente.Imc = Math.Round(CalculateIMC(cliente), 2);
            try
            {
                Dictionary<Func<bool>, Func<Response<Cliente>>> cases = new Dictionary<Func<bool>, Func<Response<Cliente>>>
                {
                    { () => cliente.Altura < 0, () => new Response<Cliente>(false, "La altura es invalida, No se ha podido registrar el cliente") },
                    { () => cliente.Peso < 0, () => new Response<Cliente>(false, "El peso es invalido, No se ha podido registrar el cliente") },
                    { () => cliente.Telefono.FirstOrDefault(@char => !char.IsDigit(@char)) != '\0', () => new Response<Cliente>(false, "Por favor ingrese correctamente el numero telefonico") },
                    { () => cliente.Genero != "M" && cliente.Genero != "F", () => new Response<Cliente>(false, "Por favor ingrese un genero valido. Solo hay dos generos quieras o no") },
                    { () => cliente.Fecha_nacimiento > DateTime.Now, () => new Response<Cliente>(false, "Fecha de nacimiento invalida, No se ha podido registrar el cliente") },
                    { () => Exist(cliente.Id), () => new Response<Cliente>(false, "Ya tiene registrado un cliente con la misma ID") },
                    { () => true, () => Repositorio_Clientes.Save(cliente) }
                };
                return cases.First(entry => entry.Key()).Value();
            }
            catch (Exception)
            {
                return new Response<Cliente>(false, "Error!", null, null);
            }
        }
        public Response<Cliente> Update(Cliente cliente_Modificado, string Id_cliente)
        {
            try
            {
                var Clientes = GetMainList();
                Dictionary<Func<bool>, Func<Response<Cliente>>> cases = new Dictionary<Func<bool>, Func<Response<Cliente>>>
                {
                    { () => Clientes == null, () => new Response<Cliente>(false, "Lista vacia") },
                    { () => !Exist(Id_cliente), () => new Response<Cliente>(false, "No se encontro el id del cliente a actualizar") },
                    { () => cliente_Modificado.Altura < 0, () => new Response<Cliente>(false, "Altura invalida") },
                    { () => cliente_Modificado.Peso < 0, () => new Response<Cliente>(false, "Peso invalido") },
                    { () => cliente_Modificado.Telefono.FirstOrDefault(@char => !char.IsDigit(@char)) != '\0', () => new Response<Cliente>(false, "Por favor ingrese correctamente el numero telefonico") },
                    { () => cliente_Modificado.Genero != "M" && cliente_Modificado.Genero != "F", () => new Response<Cliente>(false, "Por favor ingrese un genero valido. Solo hay dos generos quieras o no") },
                    { () => cliente_Modificado.Fecha_nacimiento > DateTime.Now, () => new Response<Cliente>(false, "Fecha de nacimiento mayor a la fecha actual") },
                    { () => Exist(cliente_Modificado.Id) && cliente_Modificado.Id != Id_cliente, () => new Response<Cliente>(false, "El ID del cliente que desea actualizar ya se encuentra registrado.") },
                    { () => true,  () =>
                    {
                        var cliente = Clientes.Find(item => item.Id == Id_cliente);
                        cliente.Id = cliente_Modificado.Id;
                        cliente.Nombre = cliente_Modificado.Nombre;
                        cliente.Genero = cliente_Modificado.Genero;
                        cliente.Telefono = cliente_Modificado.Telefono;
                        cliente.Altura = cliente_Modificado.Altura;
                        cliente.Peso = cliente_Modificado.Peso;
                        cliente.Fecha_nacimiento = cliente_Modificado.Fecha_nacimiento;
                        cliente.Discapacidad = cliente_Modificado.Discapacidad;
                        cliente.Fecha_ingreso = cliente_Modificado.Fecha_ingreso;
                        if (Repositorio_Clientes.Update(Clientes)) { return new Response<Cliente>(true, "Se ha actualizado el cliente.", Clientes, cliente); }
                        else { return new Response<Cliente>(false, "Error!"); }
                    }
                    }
                };
                return cases.First(entry => entry.Key()).Value();
            }
            catch (Exception)
            {
                return new Response<Cliente>(false, "Error!", null, null);
            }
        }
        public List<Cliente> GetAll()
        {
            var Clientes = GetMainList();
            if (Clientes == null) { return null; }
            return Clientes;
        }
    }
}
