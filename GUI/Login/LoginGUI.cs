using Logica.Operaciones.Servicio_Administrador;
using System;
using System.Linq;

namespace GUI.Login
{
    public class LoginGUI : Protected_Administrador
    {
        public void SignUp_Usuario()
        {
            Console.Clear();
            Console.SetCursorPosition(38, 7); Console.Write("---REGISTRAR USUARIO--- ");
            Console.SetCursorPosition(20, 9); Console.Write("Para registrar un usuario primero debe iniciar sesion.");
            Console.SetCursorPosition(20, 11); Console.WriteLine("Presiona cualquier tecla..."); Console.ReadKey();
            Console.Clear();

            string userLogin;
            string passwordLogin = "";
            string RealPasswordLogin = "";
            ConsoleKeyInfo key;
            Console.SetCursorPosition(46, 7); Console.Write("---INICIO DE SESION---");
            Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");
            Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
            Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
            Console.SetCursorPosition(51, 10); userLogin = Console.ReadLine().ToUpper();
            do
            {
                Console.Clear();
                Console.SetCursorPosition(46, 7); Console.Write("---INICIO DE SESION---");
                Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");
                Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
                Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
                Console.SetCursorPosition(51, 10); Console.Write(userLogin);
                Console.SetCursorPosition(54, 12); Console.Write(passwordLogin); key = Console.ReadKey();

                if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsPunctuation(key.KeyChar))
                {
                    passwordLogin += "*";
                    RealPasswordLogin += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Backspace && passwordLogin.Length > 0)
                {
                    passwordLogin = passwordLogin.Remove(passwordLogin.Length - 1);
                    RealPasswordLogin = RealPasswordLogin.Remove(RealPasswordLogin.Length - 1);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    passwordLogin = "";
                    RealPasswordLogin = "";
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    var response = SignIn(userLogin, RealPasswordLogin);
                    if (response.Success)
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
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(42, 11); Console.WriteLine(response.Msg); Console.ReadKey();
                        return;
                    }
                }
            } while (true); 
        }
        public bool LogIn_Usuario()
        {
            Console.Clear();
            string user;
            string password = "";
            string RealPassword = "";
            ConsoleKeyInfo key;
            Console.SetCursorPosition(46, 7); Console.Write("---INICIO DE SESION---");
            Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");
            Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
            Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
            Console.SetCursorPosition(51, 10);  user = Console.ReadLine().ToUpper();
            do
            {
                Console.Clear();
                Console.SetCursorPosition(46, 7); Console.Write("---INICIO DE SESION---");
                Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");
                Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
                Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
                Console.SetCursorPosition(51, 10); Console.Write(user);
                Console.SetCursorPosition(54, 12); Console.Write(password); key = Console.ReadKey();

                if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsPunctuation(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsLetterOrDigit(key.KeyChar))
                {
                    password += "*";
                    RealPassword += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    RealPassword = RealPassword.Remove(RealPassword.Length - 1);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    password = "";
                    RealPassword = "";
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    var response = SignIn(user, RealPassword);
                    if (response.Success)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(42, 11); Console.WriteLine(response.Msg);
                        Console.SetCursorPosition(42, 13); Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        PrincipalGUI MenuPrincipal = new PrincipalGUI();
                        MenuPrincipal.MenuPrincipal();
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(42, 11); Console.WriteLine(response.Msg); Console.ReadKey();
                        return false;
                    }
                }
            } while (true);
        }
        public void Delete_Usuario()
        {
            Console.Clear();
            string user;
            string password = "";
            string RealPassword = "";
            ConsoleKeyInfo key;
            Console.SetCursorPosition(46, 7); Console.Write("---ELIMINAR USUARIO---");
            Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");
            Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
            Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
            Console.SetCursorPosition(51, 10); user = Console.ReadLine().ToUpper();
            do
            {
                Console.Clear();
                Console.SetCursorPosition(46, 7); Console.Write("---ELIMINAR USUARIO---");
                Console.SetCursorPosition(35, 16); Console.Write("Por favor ingrese los datos requeridos...");
                Console.SetCursorPosition(42, 10); Console.Write("USUARIO: ");
                Console.SetCursorPosition(42, 12); Console.Write("CONTRASEÑA: ");
                Console.SetCursorPosition(51, 10); Console.Write(user);
                Console.SetCursorPosition(54, 12); Console.Write(password); key = Console.ReadKey();
                if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsPunctuation(key.KeyChar))
                {
                    password += "*";
                    RealPassword += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length>0)
                {
                    password = password.Remove(password.Length - 1);
                    RealPassword = RealPassword.Remove(RealPassword.Length - 1);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    password = "";
                    RealPassword = "";
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.SetCursorPosition(42, 11); Console.Write(Delete(user, RealPassword).Msg);
                    Console.SetCursorPosition(42, 13); Console.WriteLine("Presiona cualquier tecla...");
                    Console.ReadKey();
                    return;
                }
            } while (true);
        }
    }
}
