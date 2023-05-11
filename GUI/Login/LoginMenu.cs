using System;

namespace GUI.Login
{
    public class LoginMenu : LoginGUI 
    {
        public void Menu() 
        {
            int op;
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.SetCursorPosition(43, 5); Console.Write("---BIENVENIDO A GYMANAGER---");
                Console.SetCursorPosition(39, 7); Console.Write("1. Iniciar sesion");
                Console.SetCursorPosition(39, 8); Console.Write("2. Registrar usuario");
                Console.SetCursorPosition(39, 9); Console.Write("3. Eliminar usuario");
                Console.SetCursorPosition(39, 10); Console.Write("4. Salir");
                Console.SetCursorPosition(35, 25); Console.Write("Nota: Utilizar Usuario SYSTEM para ingresar.");
                Console.SetCursorPosition(35, 26); Console.Write("Usuario: SYSTEM // Contraseña: gymanager");



                Console.SetCursorPosition(39, 12); Console.Write("Escoja la opción de su preferencia: ");
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
                        LogIn_Usuario();
                        break;
                    case 2:
                        SignUp_Usuario();
                        break;
                    case 3:
                        Delete_Usuario();
                        break;
                    case 4:
                        break;
                    default:
                        Console.SetCursorPosition(35, 19); Console.Write("Ingrese una opción valida");
                        Console.ReadKey();
                        break;
                }
            } while (op != 4);
        }
    }
}
