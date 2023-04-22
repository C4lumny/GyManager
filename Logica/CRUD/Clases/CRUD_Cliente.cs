using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Logica.Operaciones;
using Logica.Operaciones.AccesoPublico;

namespace Logica
{
    public class CRUD_Cliente : Public_Clientes, ICRUD<Cliente> // Proporciona metodos para cumplir los requerimientos minimos del programa relacionados al cliente.
    {
        public CRUD_Cliente() { }
        public Response<Cliente> Delete(string id_cliente)
        {
            if (GetLista() == null)
            {
                return new Response<Cliente>(false, "La lista esta vacia", null, null); // Lista vacia
            }
            else
            {
                int pos = GetLista().FindIndex(item => item.id == id_cliente); // Devuelve el indice (posicion) de la lista que cumpla con la condicion.

                if (pos < 0)  { return new Response<Cliente>(false, "No se ha encontrado el cliente que se desea eliminar.", null, null); } // No se encontro el id del objeto q desea eliminar.

                GetLista().RemoveAt(pos); return new Response<Cliente>(true, "El cliente se ha eliminado correctamente", null, null); // Elimino correctamente.
            }
        }
        public List<Cliente> GetBySearch(string search)
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
        public Response<Cliente> Save(Cliente cliente)
        {
            try
            {
                if (cliente.altura < 0)
                {
                    return new Response<Cliente>(false, "La altura es menos a cero, No se ha podido registrar el cliente", null, null); // altura menor a 0
                }
                else if (cliente.peso < 0)
                {
                    return new Response<Cliente>(false, "La altura es menos a cero, No se ha podido registrar el cliente", null, null); // peso menor a 0
                }
                else if (cliente.fecha_nacimiento > DateTime.Now)
                {
                    return new Response<Cliente>(false, "La altura es menos a cero, No se ha podido registrar el cliente", null, null); // fecha de nacimiento mayor a la fecha actual.
                }
                else if (GetLista() == null)
                {
                    if (ar.Save(cliente))
                    {
                        return new Response<Cliente>(true, "Se ha guardado correctamente", null, null); ;
                    }
                    else
                    {
                        return new Response<Cliente>(false, "La altura es menos a cero, No se ha podido registrar el cliente", null, null);
                    }
                    // guarda correctamente en la lista.
                }
                else if (Exist(cliente.id))
                {
                    return new Response<Cliente>(false, "La altura es menos a cero, No se ha podido registrar el cliente", null, null); // id repetida.
                }
                else
                {
                    if (ar.Save(cliente))
                    {
                        return new Response<Cliente>(true, "Se ha guardado correctamente", null, null);
                    }
                        return new Response<Cliente>(false, "La altura es menos a cero, No se ha podido registrar el cliente", null, null);
                    //GetLista().Sort((p1, p2) => p1.fecha_ingreso.CompareTo(p2.fecha_ingreso)); //Orgraniza clientes por fecha de ingreso (opcional)
                    //return 0; // guarda correctamente en la lista.
                }
            }
            catch (Exception)
            {
                return new Response<Cliente>(false, "Exception", null, null); ; // Te jodiste exception xd
            }
        }
        public Response<Cliente> Update(Cliente clienteUpdate, string id_cliente)
        {
            try
            {
                if (GetLista() == null) { return new Response<Cliente>(false, "Lista vacia", null, null); } // Lista vacia

                else
                {
                    if (!Exist(id_cliente))
                    {
                        return new Response<Cliente>(false, "No se encontro el id del cliente a actualizar", null, null); // No se encontro el id del objeto a actualizar
                    }
                    if (clienteUpdate.altura < 0)
                    {
                        return new Response<Cliente>(false, "Altura invalida", null, null); // altura menor a 0
                    }
                    else if (clienteUpdate.peso < 0)
                    {
                        return new Response<Cliente>(false, "Peso invalido", null, null); // peso menor a 0
                    }
                    else if (clienteUpdate.fecha_nacimiento > DateTime.Now)
                    {
                        return new Response<Cliente>(false, "Fecha de nacimiento mayor a la fecha actual", null, null); // fecha de nacimiento mayor a la fecha actual.
                    }
                    else if (Exist(clienteUpdate.id))
                    {
                        return new Response<Cliente>(false, "ID repetido", null, null); ; //ID repetido.
                    }
                    else
                    {
                        var cliente = ReturnFromList(id_cliente);
                        cliente.id = clienteUpdate.id;
                        cliente.nombre = clienteUpdate.nombre;
                        cliente.genero = clienteUpdate.genero;
                        cliente.telefono = clienteUpdate.telefono;
                        cliente.altura = clienteUpdate.altura;
                        cliente.peso = clienteUpdate.peso;
                        cliente.fecha_nacimiento = clienteUpdate.fecha_nacimiento;
                        cliente.discapacidad = clienteUpdate.discapacidad;
                        cliente.fecha_ingreso = clienteUpdate.fecha_ingreso;

                        return new Response<Cliente>(true, "Se ha guardado correctamente", null, null); ; //Reemplazo correctamente.

                    }
                }
            }
            catch (Exception)
            {
                return new Response<Cliente>(false, "Exception", null, null); ; // excepion
            }
        }
        public List<Cliente> GetAll()
        {
            var lista = list.GetListaCliente();
            if (lista == null)
            {
                return null;
            }
            return lista; 
        }

        //bool ValidateID(string id_cliente)
        //{
        //    if (GetLista() == null) // valida si el id del cliente se encuentra en una lista de supervisores.
        //    {
        //        return true;
        //    }
        //    else if (GetLista().FirstOrDefault(item => item.id == id_cliente) == null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
        //    {
        //        return true;
        //    }
        //    return false; // encontro en la lista de clientes una id repetida.
        //}

    }
}
