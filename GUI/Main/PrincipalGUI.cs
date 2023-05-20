using GUI.Menus;
using System;

namespace GUI
{
    public class PrincipalGUI
    { 
        public void MenuPrincipal()
        {
            Console.SetBufferSize(Console.WindowWidth, 1000);
            Console.SetWindowPosition(0, 0);
            int op;
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.SetCursorPosition(48, 5); Console.Write("---MENU PRINCIPAL GYM---");
                Console.SetCursorPosition(42, 7); Console.Write("1. Administrar clientes");
                Console.SetCursorPosition(42, 8); Console.Write("2. Administrar supervisores");
                Console.SetCursorPosition(42, 9); Console.Write("3. Administrar planes");
                Console.SetCursorPosition(42, 10); Console.Write("4. Administrar inscripciones");
                Console.SetCursorPosition(42, 11); Console.Write("5. Cerrar Sesion");
                Console.SetCursorPosition(42, 14); Console.Write("Escoja la opción de su preferencia: ");
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
                        ClienteMENU clienteMENU = new ClienteMENU();
                        clienteMENU.menu();
                        break;
                    case 2:
                        SupervisorMENU supervisorMENU = new SupervisorMENU();
                        supervisorMENU.menu();
                        break;
                    case 3:
                        PlanGimnasioMENU planGimnasioMENU = new PlanGimnasioMENU();
                        planGimnasioMENU.menu();
                        break;
                    case 4:
                        InscripcionMENU inscripcionMENU = new InscripcionMENU();
                        inscripcionMENU.menu();
                        break;
                    case 5:
                        Console.Clear();
                        Console.SetCursorPosition(38, 11); Console.Write("¿Esta seguro de cerrar sesion? [S/N] "); char cs = Console.ReadKey().KeyChar;
                        if (cs != 's' && cs != 'S')
                        {
                            MenuPrincipal();
                        }
                        break;
                    default:
                        Console.SetCursorPosition(42, 25); Console.Write("Ingrese una opción valida");
                        Console.ReadKey();
                        break;
                }
            } while (op != 5);
        }
    }
}
