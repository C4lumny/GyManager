using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class ClienteGUI // En esta clase se modela la interfaz grafica relacionada al cliente por medio de metodos de la clase ServicioClientes. 
    {
        Listas list = new Listas();
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

                        break;
                    case 4:

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
                Cliente clientes = new Cliente();
                ServicioCliente servCliente = new ServicioCliente();

                Console.SetCursorPosition(43, 5); Console.Write("---REGISTRAR NUEVO CLIENTE---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del cliente: "); clientes.id = Console.ReadLine();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del cliente: "); clientes.nombre = Console.ReadLine();
                    Console.SetCursorPosition(35, 11); Console.Write("Ingrese el telefono del cliente: "); clientes.telefono = Console.ReadLine();
                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese el sexo del cliente(M o F): "); clientes.genero = Console.ReadLine().ToUpper()[0].ToString();
                    Console.SetCursorPosition(35, 13); Console.Write("Ingrese el peso del cliente (Kg): "); clientes.peso = double.Parse(Console.ReadLine());
                    Console.SetCursorPosition(35, 14); Console.Write("Ingrese la altura del cliente (metros): "); clientes.altura = double.Parse(Console.ReadLine());
                    Console.SetCursorPosition(43, 16); Console.Write("Fecha de nacimiento");
                    Console.SetCursorPosition(35, 18); Console.Write("Dia: "); int dia = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(45, 18); Console.Write("Mes: "); int mes = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(55, 18); Console.Write("Año: "); int anio = int.Parse(Console.ReadLine());
                    clientes.fecha_nacimiento = new DateTime(anio, mes, dia);
                    Console.SetCursorPosition(35, 20); Console.Write("¿El cliente sufre de alguna discapacidad?[S/N]: ");
                    char disc = char.Parse(Console.ReadLine().ToLower());
                    if (disc == 's')
                    {
                        Console.SetCursorPosition(35, 21); Console.Write("Ingrese la discapacidad del cliente: "); clientes.discapacidad = Console.ReadLine();
                    }
                    else if (disc == 'n')
                    {
                        clientes.discapacidad = " ";
                    }
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Error, por favor rectifique los datos");
                    break;
                }

                clientes.estado = false;
                clientes.fecha_ingreso = DateTime.Now;
                clientes.imc = servCliente.CalculateIMC(clientes.peso, clientes.altura);
                var validation = servCliente.Save(clientes);
                ////switch (validation)
                ////{
                ////    case 0:
                ////        Console.SetCursorPosition(35, 22); Console.Write("El cliente fue guardado correctamente");
                ////        Console.ReadKey();
                ////        break;
                ////    case 1:

                ////        break;

                ////}

                Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir agregando clientes?[S/N]: ");
                op = char.Parse(Console.ReadLine().ToLower());
            } while (op == 's');
        }

        //----------------------------------------------------------------------------------------------------------------------------------

        void consultarCliente()
        {
            Console.Clear();
            int i = 7;
            ////    if (!list.ClienteListEmpty())
            ////    {
            ////        Console.SetCursorPosition(10, 5); Console.WriteLine("---LISTA DE CLIENTES---");

            ////        Console.SetCursorPosition(13, i); Console.WriteLine("Id");
            ////        Console.SetCursorPosition(25, i); Console.WriteLine("Nombre");
            ////        Console.SetCursorPosition(35, i); Console.WriteLine("Genero");
            ////        Console.SetCursorPosition(45, i); Console.WriteLine("Altura");
            ////        Console.SetCursorPosition(52, i); Console.WriteLine("Telefono");
            ////        Console.SetCursorPosition(65, i); Console.WriteLine("IMC");

            ////        foreach (var item in list.GetListaCliente())
            ////        {
            ////            Console.SetCursorPosition(10, i + 2); Console.WriteLine(item.id);
            ////            Console.SetCursorPosition(25, i + 2); Console.WriteLine(item.nombre);
            ////            Console.SetCursorPosition(38, i + 2); Console.WriteLine(item.genero);
            ////            Console.SetCursorPosition(47, i + 2); Console.WriteLine(item.altura);
            ////            Console.SetCursorPosition(55, i + 2); Console.WriteLine(item.telefono);
            ////            Console.SetCursorPosition(70, i + 2); Console.WriteLine(item.imc);
            ////            i++;
            ////        }
            ////    }
            ////    else { Console.WriteLine("vacio"); }
            ////    Console.ReadKey();
            ////}
        }
    }
}
