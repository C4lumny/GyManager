using Entidades;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;

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
                return GetMainList().FindAll(cliente => cliente.Nombre.Contains(search) || cliente.Telefono.StartsWith(search) || cliente.Id.StartsWith(search));
            }
        }
        public Response<Cliente> Save(Cliente cliente)
        {
            try
            {
                if (cliente.Altura < 0)
                {
                    return new Response<Cliente>(false, "La altura es invalida, No se ha podido registrar el cliente");
                }
                else if (cliente.Peso < 0)
                {
                    return new Response<Cliente>(false, "El peso es invalido, No se ha podido registrar el cliente");
                }
                else if (cliente.Genero != "M" && cliente.Genero != "F")
                {
                    return new Response<Cliente>(false, "Por favor ingrese un genero valido. Solo hay dos generos quieras o no");
                }
                else if (cliente.Fecha_nacimiento > DateTime.Now)
                {
                    return new Response<Cliente>(false, "Fecha de nacimiento invalida, No se ha podido registrar el cliente");
                }
                else if (GetMainList() == null)
                {
                    cliente.Imc = Math.Round(CalculateIMC(cliente), 2);
                    return Repositorio_Clientes.Save(cliente);
                }
                else if (Exist(cliente.Id))
                {
                    return new Response<Cliente>(false, "Ya tiene registrado un cliente con la misma ID");
                }
                else
                {
                    cliente.Imc = Math.Round(CalculateIMC(cliente), 2);
                    return Repositorio_Clientes.Save(cliente);
                }
            }
            catch (Exception)
            {
                return new Response<Cliente>(false, "Error!", null, null);
            }
        }
        public Response<Cliente> Update(Cliente Cliente_Modificado, string Id_cliente)
        {
            try
            {
                var Clientes = GetMainList();
                if (Clientes == null) { return new Response<Cliente>(false, "Lista vacia"); } // Lista vacia
                else
                {
                    if (!Exist(Id_cliente))
                    {
                        return new Response<Cliente>(false, "No se encontro el id del cliente a actualizar");
                    }
                    if (Cliente_Modificado.Altura < 0)
                    {
                        return new Response<Cliente>(false, "Altura invalida");
                    }
                    else if (Cliente_Modificado.Peso < 0)
                    {
                        return new Response<Cliente>(false, "Peso invalido");
                    }
                    else if (Cliente_Modificado.Genero != "M" && Cliente_Modificado.Genero != "F")
                    {
                        return new Response<Cliente>(false, "Por favor ingrese un genero valido. Solo hay dos generos quieras o no");
                    }
                    else if (Cliente_Modificado.Fecha_nacimiento > DateTime.Now)
                    {
                        return new Response<Cliente>(false, "Fecha de nacimiento mayor a la fecha actual");
                    }
                    else if (Exist(Cliente_Modificado.Id) && Cliente_Modificado.Id != Id_cliente)
                    {
                        return new Response<Cliente>(false, "El ID del cliente que desea actualizar ya se encuentra registrado.");
                    }
                    else
                    {
                        var cliente = Clientes.Find(item => item.Id == Id_cliente);
                        cliente.Id = Cliente_Modificado.Id;
                        cliente.Nombre = Cliente_Modificado.Nombre;
                        cliente.Genero = Cliente_Modificado.Genero;
                        cliente.Telefono = Cliente_Modificado.Telefono;
                        cliente.Altura = Cliente_Modificado.Altura;
                        cliente.Peso = Cliente_Modificado.Peso;
                        cliente.Fecha_nacimiento = Cliente_Modificado.Fecha_nacimiento;
                        cliente.Discapacidad = Cliente_Modificado.Discapacidad;
                        cliente.Fecha_ingreso = Cliente_Modificado.Fecha_ingreso;
                        if (Repositorio_Clientes.Update(Clientes))
                        {
                            return new Response<Cliente>(true, "Se ha actualizado el cliente.", Clientes, cliente);
                        }
                        else
                        {
                            return new Response<Cliente>(false, "Error!");
                        }

                    }
                }
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
