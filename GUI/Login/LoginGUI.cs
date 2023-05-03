using Logica.Operaciones.Servicio_Administrador;
using System;

namespace GUI.Login
{
    public class LoginGUI : Protected_Administrador
    {
        public void SignUp_Usuario()
        {
            Console.Clear();
            Console.SetCursorPosition(38, 7); Console.Write("---INGRESE SUS DATOS DEL REGISTRO--- ");
            Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");

            Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
            Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
            Console.SetCursorPosition(51, 10); string user = Console.ReadLine().ToUpper();
            Console.SetCursorPosition(54, 12); string password = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(42, 11); Console.WriteLine(SignUp(user, password).Msg);
            Console.SetCursorPosition(42, 13); Console.WriteLine("Presiona cualquier tecla...");
            Console.ReadKey();
        }
        public bool LogIn_Usuario()
        {
            Console.Clear();
            Console.SetCursorPosition(46, 7); Console.Write("---INICIO DE SESION---");
            Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");
            Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
            Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
            Console.SetCursorPosition(51, 10); string user = Console.ReadLine().ToUpper();
            Console.SetCursorPosition(54, 12); string password = Console.ReadLine();
            if (SignIn(user, password).Success)
            {
                Console.Clear();
                Console.SetCursorPosition(42, 11); Console.WriteLine(SignIn(user, password).Msg);
                Console.SetCursorPosition(42, 13); Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                PrincipalGUI MenuPrincipal = new PrincipalGUI();
                MenuPrincipal.MenuPrincipal();
                return true;
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(42, 11); Console.WriteLine(SignIn(user, password).Msg); Console.ReadKey();
                return false;
            }
        }
        public void Delete_Usuario()
        {
            Console.Clear();
            Console.SetCursorPosition(42, 7); Console.Write("---ELIMINAR USUARIO---");
            Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");
            Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
            Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
            Console.SetCursorPosition(51, 10); string user = Console.ReadLine().ToUpper();
            Console.SetCursorPosition(54, 12); string password = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(42, 11); Console.Write(Delete(user, password).Msg);
            Console.SetCursorPosition(42, 13); Console.WriteLine("Presiona cualquier tecla...");
            Console.ReadKey();
        }
    }
}
