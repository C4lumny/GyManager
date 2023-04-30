using System;

namespace GUI
{
    internal class PrincipalGUI
    {
        static void Main(string[] args)  // Clase Main, desde esta clase seran dadas las instrucciones y orden a seguir para consecuentemente ejecutar el programa.
        {
            int op;
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.SetCursorPosition(43, 5); Console.Write("---MENU PRINCIPAL GYM---");
                Console.SetCursorPosition(35, 7); Console.Write("1. Administrar clientes");
                Console.SetCursorPosition(35, 8); Console.Write("2. Administrar supervisores");
                Console.SetCursorPosition(35, 9); Console.Write("3. Administrar planes");
                Console.SetCursorPosition(35, 10); Console.Write("4. Administrar inscripciones");
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
                        ClienteGUI clienteMenu = new ClienteGUI();
                        clienteMenu.menu();
                        break;
                    case 2:
                        SupervisorGUI supervMenu = new SupervisorGUI();
                        supervMenu.menu();
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        //Finalizar programa
                        break;
                    default:
                        Console.SetCursorPosition(35, 25); Console.Write("Ingrese una opción valida");
                        Console.ReadKey();
                        break;

                }
            } while (op != 5);
        }
    }
}
