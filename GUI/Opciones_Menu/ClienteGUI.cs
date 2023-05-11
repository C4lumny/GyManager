using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GUI
{
    public class ClienteGUI // En esta clase se modela la interfaz grafica relacionada al cliente por medio de metodos de la clase ServicioClientes. 
    {
        CRUD_Cliente servicioCliente = new CRUD_Cliente();
        Cliente clientes;

        //----------------------------------------------------------------------------------------------------------------------------------
        protected void registrarCliente()
        {
            char op;
            do
            {
                Console.Clear();
                clientes = new Cliente();

                Console.SetCursorPosition(43, 5); Console.Write("---REGISTRAR NUEVO CLIENTE---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del cliente: "); clientes.Id = Console.ReadLine();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del cliente: "); clientes.Nombre = Console.ReadLine();
                    Console.SetCursorPosition(35, 11); Console.Write("Ingrese el telefono del cliente: "); clientes.Telefono = Console.ReadLine();
                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese el sexo del cliente(M o F): "); clientes.Genero = Console.ReadKey().KeyChar.ToString().ToUpper();
                    Console.SetCursorPosition(35, 13); Console.Write("Ingrese el peso del cliente(Kg): "); clientes.Peso = double.Parse(Console.ReadLine().Replace(".", ","));
                    Console.SetCursorPosition(35, 14); Console.Write("Ingrese la altura del cliente(metros): "); clientes.Altura = double.Parse(Console.ReadLine().Replace(".", ","));
                    Console.SetCursorPosition(43, 16); Console.Write("Fecha de nacimiento");
                    Console.SetCursorPosition(35, 18); Console.Write("Dia: "); int dia = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(45, 18); Console.Write("Mes: "); int mes = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(55, 18); Console.Write("Año: "); int anio = int.Parse(Console.ReadLine());
                    clientes.Fecha_nacimiento = new DateTime(anio, mes, dia);
                    Console.SetCursorPosition(35, 20); Console.Write("¿El cliente sufre de alguna discapacidad?[S/N]: ");
                    char disc = char.Parse(Console.ReadLine().ToLower());
                    if (disc == 's')
                    {
                        Console.SetCursorPosition(35, 21); Console.Write("Ingrese la discapacidad del cliente: "); clientes.Discapacidad = Console.ReadLine();
                    }
                    else if (disc == 'n')
                    {
                        clientes.Discapacidad = " ";
                    }
                    clientes.Fecha_ingreso = DateTime.Now;
                    var response = servicioCliente.Save(clientes);
                    Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir agregando clientes?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Error, por favor rectifique los datos"); Console.ReadKey();
                    break;
                }
            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected bool Mostrar(List<Cliente> lista, int Pos_vertical)
        {
            Console.Clear();
            Console.SetCursorPosition(44, 6); Console.WriteLine("---CLIENTES REGISTRADOS---");
            if (servicioCliente.GetAll() != null)
            {
                Console.SetCursorPosition(19, Pos_vertical); Console.WriteLine("CC".PadRight(15) + "NOMBRE".PadRight(15) + "SEXO".PadRight(10) + "TELEFONO".PadRight(15) + "IMC".PadRight(12) + "FECHA INGRESO:");
                foreach (var item in lista.Take(15))
                {
                    Console.SetCursorPosition(19, Pos_vertical + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Genero.PadRight(10) + item.Telefono.PadRight(15) + item.Imc.ToString().PadRight(12) + item.Fecha_ingreso.ToShortDateString());
                    Pos_vertical++;
                }
                return true;
            }
            else
            {
                Console.SetCursorPosition(10, 10); Console.WriteLine("No se han registrado clientes");
                Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
                return false;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void consultarCliente(bool @static)
        { 
            Mostrar(servicioCliente.GetAll(), 8);
            if (@static == true)
            {
                Console.ReadKey();
            }

        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void actualizarCliente()
        {
            string id_clienteU;
            Cliente clientes = new Cliente();
            CRUD_Cliente servCliente = new CRUD_Cliente();
            char op = 'x';
            do
            {
                try
                {
                    Console.Clear();
                    Console.SetCursorPosition(43, 2); Console.Write("---ACTUALIZAR CLIENTE---");
                    if (!Mostrar(servicioCliente.GetAll(), 8))
                    {
                        Console.ReadKey();
                        return;
                    }
                    Console.SetCursorPosition(35, 4); Console.Write("Ingrese el ID del cliente que desea actualizar: "); id_clienteU = Console.ReadLine();
                    Console.Clear();
                    if (servCliente.ReturnCliente(id_clienteU) == null)
                    {
                        Console.SetCursorPosition(28, 9); Console.WriteLine("El cliente que desea actualizar, no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR CLIENTE---");
                        Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del cliente: "); clientes.Id = Console.ReadLine();
                        Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del cliente: "); clientes.Nombre = Console.ReadLine();
                        Console.SetCursorPosition(35, 11); Console.Write("Ingrese el telefono del cliente: "); clientes.Telefono = Console.ReadLine();
                        Console.SetCursorPosition(35, 12); Console.Write("Ingrese el sexo del cliente(M o F): "); clientes.Genero = Console.ReadKey().KeyChar.ToString().ToUpper();
                        Console.SetCursorPosition(35, 13); Console.Write("Ingrese el peso del cliente (Kg): "); clientes.Peso = double.Parse(Console.ReadLine().Replace(".", ","));
                        Console.SetCursorPosition(35, 14); Console.Write("Ingrese la altura del cliente (metros): "); clientes.Altura = double.Parse(Console.ReadLine().Replace(".", ","));
                        Console.SetCursorPosition(43, 16); Console.Write("Fecha de nacimiento");
                        Console.SetCursorPosition(35, 18); Console.Write("Dia: "); int dia = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(45, 18); Console.Write("Mes: "); int mes = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(55, 18); Console.Write("Año: "); int anio = int.Parse(Console.ReadLine());
                        clientes.Fecha_nacimiento = new DateTime(anio, mes, dia);
                        Console.SetCursorPosition(35, 20); Console.Write("¿El cliente sufre de alguna discapacidad?[S/N]: ");
                        char disc = char.Parse(Console.ReadLine().ToLower());
                        if (disc == 's')
                        {
                            Console.SetCursorPosition(35, 21); Console.Write("Ingrese la discapacidad del cliente: "); clientes.Discapacidad = Console.ReadLine();
                        }
                        else if (disc == 'n')
                        {
                            clientes.Discapacidad = " ";
                        }
                        clientes.Fecha_ingreso = servCliente.ReturnCliente(id_clienteU).Fecha_ingreso;
                        var response = servCliente.Update(clientes, id_clienteU);
                        Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);
                        Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir actualizando clientes?[S/N]: ");
                        op = char.Parse(Console.ReadLine().ToLower());
                    }
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Error, por favor rectifique los datos");
                    break;
                }
            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void eliminarCliente()
        {

            string id_clienteD;
            char op = 'x';
            do
            {
                Console.Clear();
                Console.SetCursorPosition(43, 2); Console.Write("---ELIMINAR CLIENTE---");
                if (!Mostrar(servicioCliente.GetAll(), 8))
                {
                    Console.ReadKey();
                    return;
                }
                Console.SetCursorPosition(35, 4); Console.Write("Ingrese el ID del cliente que desea eliminar: "); id_clienteD = Console.ReadLine();
                Console.Clear();
                if (servicioCliente.ReturnCliente(id_clienteD) == null)
                {
                    Console.SetCursorPosition(28, 9); Console.WriteLine("El cliente que desea eliminar, no se encuentra en la base de datos");
                    Console.ReadKey();
                    
                }
                else
                {
                    var response = servicioCliente.Delete(id_clienteD);
                    Console.SetCursorPosition(35, 9); Console.WriteLine(response.Msg);
                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir eliminando clientes?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());
                }

            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void ConsultaDinamica()
        {
            int cursor = 81;
            string search = "";
            Console.Clear();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                if (!Mostrar(servicioCliente.GetBySearch(search), 8))
                {
                    Console.ReadKey();
                    return;
                }
                Console.SetCursorPosition(35, 4); Console.Write("Ingrese el id, nombre o telefono del cliente: " + search);
                

                Console.SetCursorPosition(cursor, 4); key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && search.Length > 0)
                {
                    search = search.Remove(search.Length - 1);
                    cursor--;
                }
                else if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsPunctuation(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsLetterOrDigit(key.KeyChar))
                {
                    search += key.KeyChar.ToString();
                    cursor++;
                }

            } while (true);
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
}

