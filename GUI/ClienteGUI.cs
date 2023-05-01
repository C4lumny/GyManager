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
        Cliente clientes = new Cliente();
        //----------------------------------------------------------------------------------------------------------------------------------
        public void menu()
        {
            int op;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ADMINISTRAR CLIENTES DEL GYM---");
                Console.SetCursorPosition(35, 7); Console.Write("1. Registrar cliente");
                Console.SetCursorPosition(35, 8); Console.Write("2. Consultar cliente");
                Console.SetCursorPosition(35, 9); Console.Write("3. Actualizar cliente");
                Console.SetCursorPosition(35, 10); Console.Write("4. Eliminar cliente");
                Console.SetCursorPosition(35, 11); Console.Write("5. Salir");
                Console.SetCursorPosition(35, 14); Console.Write("Escoja la opción de su preferencia: ");
                try
                {
                    op = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    op = 0;
                }


                switch (op)
                {
                    case 1:
                        registrarCliente();
                        break;
                    case 2:
                        consultarCliente();
                        break;
                    case 3:
                        actualizarCliente();
                        break;
                    case 4:
                        eliminarCliente();
                        break;
                    case 5:
                        //Volver al menu
                        break;
                    default:
                        Console.SetCursorPosition(35, 25); Console.Write("Ingrese una opción valida");
                        Console.ReadKey();
                        break;

                }
            } while (op != 5);
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        void registrarCliente()
        {
            char op;
            do
            {
                Console.Clear();
                clientes = new Cliente();
                CRUD_Cliente servCliente = new CRUD_Cliente();

                Console.SetCursorPosition(43, 5); Console.Write("---REGISTRAR NUEVO CLIENTE---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del cliente: "); clientes.Id = Console.ReadLine();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del cliente: "); clientes.Nombre = Console.ReadLine();
                    Console.SetCursorPosition(35, 11); Console.Write("Ingrese el telefono del cliente: "); clientes.Telefono = Console.ReadLine();
                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese el sexo del cliente(M o F): "); clientes.Genero = Console.ReadLine().ToUpper()[0].ToString();
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
                    var response = servCliente.Save(clientes);
                    Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir agregando clientes?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Error, por favor rectifique los datos");
                    break;
                }
            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        //void consultarCliente()
        //{
        //    int i = 7;
        //    var clientes = servicioCliente.GetAll();
        //    Console.Clear();
        //    Console.SetCursorPosition(10, 5); Console.WriteLine("---LISTA DE CLIENTES---");

        //    if (servicioCliente.GetAll() != null)
        //    {
        //        Console.SetCursorPosition(10, i); Console.WriteLine("ID".PadRight(15) + "NOMBRE".PadRight(15) + "SEXO".PadRight(6) + "ALTURA".PadRight(10) + "TELEFONO".PadRight(15) + "IMC");
        //        foreach (var item in servicioCliente.GetAll().Take(15))
        //        {
        //            Console.SetCursorPosition(10, i + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Genero.PadRight(6) + item.Altura.ToString().PadRight(10) + item.Telefono.PadRight(15) + item.Imc);
        //            i++;
        //        }
        //        if(clientes.Count() >= 15)
        //        {
        //            Console.SetCursorPosition(10, 25); Console.WriteLine("Pulse ↓ para seguir visualizando clientes");
        //            ConsoleKeyInfo keys = Console.ReadKey();
        //            if (keys.Key == ConsoleKey.DownArrow)
        //            {
        //                Console.Clear();
        //                Console.SetCursorPosition(10, 5); Console.WriteLine("---LISTA DE CLIENTES---");
        //                clientes = servicioCliente.GetAll().Skip(15).ToList(); // Obtener clientes restantes
        //                i = 7;
        //                Console.SetCursorPosition(10, i); Console.WriteLine("ID".PadRight(15) + "NOMBRE".PadRight(15) + "SEXO".PadRight(6) + "ALTURA".PadRight(10) + "TELEFONO".PadRight(15) + "IMC");
        //                foreach (var item in clientes)
        //                {
        //                    Console.SetCursorPosition(10, i + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Genero.PadRight(6) + item.Altura.ToString().PadRight(10) + item.Telefono.PadRight(15) + item.Imc);
        //                    i++;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado clientes");
        //        Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
        //    }
        //    Console.ReadKey();
        //}
        //----------------------------------------------------------------------------------------------------------------------------------
        void consultarCliente()
        {
            int inicio = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 3); Console.WriteLine("Pulse ESC para volver al menu");
                Console.SetCursorPosition(10, 5); Console.WriteLine("---LISTA DE CLIENTES---");

                var clientes = servicioCliente.GetAll();
                if (clientes != null)
                {
                    Console.SetCursorPosition(10, 7); Console.WriteLine("ID".PadRight(15) + "NOMBRE".PadRight(15) + "SEXO".PadRight(6) + "ALTURA".PadRight(10) + "TELEFONO".PadRight(15) + "IMC");
                    for (int i = inicio; i < Math.Min(clientes.Count(), inicio + 15); i++)
                    {
                        var item = clientes.ElementAt(i);
                        Console.SetCursorPosition(10, i - inicio + 9); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Genero.PadRight(6) + item.Altura.ToString().PadRight(10) + item.Telefono.PadRight(15) + item.Imc);
                    }

                    if (clientes.Count() > inicio + 15)
                    {
                        Console.SetCursorPosition(10, 25); Console.WriteLine("Pulse ↓ para seguir visualizando clientes");
                    }
                    if (inicio > 0)
                    {
                        Console.SetCursorPosition(10, 4); Console.WriteLine("Pulse ↑ para ver la pagina anterior");
                    }

                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.DownArrow && clientes.Count() > inicio + 15)
                    {
                        inicio += 15;
                    }
                    else if (key.Key == ConsoleKey.UpArrow && inicio > 0)
                    {
                        inicio -= 15;
                    }
                }
                else
                {
                    Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado clientes");
                    Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
                    Console.ReadKey();
                    break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }




        void actualizarCliente()
        {
            string id_clienteU;
            char op = 'x';
            do
            {
                Console.Clear();
                Cliente clientes = new Cliente();
                CRUD_Cliente servCliente = new CRUD_Cliente();
                try
                {
                    Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR CLIENTE---");
                    Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del cliente que desea actualizar: "); id_clienteU = Console.ReadLine();
                    if (servCliente.ReturnCliente(id_clienteU) == null) 
                    {
                        Console.SetCursorPosition(35, 9); Console.WriteLine("El cliente que desea actualizar, no se encuentra en la base de datos");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR CLIENTE---");
                        Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del cliente: "); clientes.Id = Console.ReadLine();
                        Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del cliente: "); clientes.Nombre = Console.ReadLine();
                        Console.SetCursorPosition(35, 11); Console.Write("Ingrese el telefono del cliente: "); clientes.Telefono = Console.ReadLine();
                        Console.SetCursorPosition(35, 12); Console.Write("Ingrese el sexo del cliente(M o F): "); clientes.Genero = Console.ReadLine().ToUpper()[0].ToString();
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
        void eliminarCliente()
        {
            string id_clienteD;
            char op = 'x';
            do
            {
       
                Console.Clear();
                Console.SetCursorPosition(43, 5); Console.Write("---ELIMINAR CLIENTE---");
                Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del cliente que desea eliminar: "); id_clienteD = Console.ReadLine();
                if (servicioCliente.ReturnCliente(id_clienteD) == null)
                {
                    Console.SetCursorPosition(35, 9); Console.WriteLine("El cliente que desea actualizar, no se encuentra en la base de datos");
                    Console.ReadKey();
                }
                else
                {
                    var response = servicioCliente.Delete(id_clienteD);
                    Console.SetCursorPosition(35, 9); Console.WriteLine("Se ha eliminado el cliente: " + response.Object.Nombre);
                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir eliminando clientes?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());
                }
            } while (op == 's');
        }
    }
}

