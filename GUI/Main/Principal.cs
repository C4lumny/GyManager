using GUI.Login;
using System;

namespace GUI.Main
{
    internal class Principal
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.WindowWidth, 1000);
            Console.SetWindowPosition(0, 0);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;

            LoginMenu Main = new LoginMenu();
            Main.Menu();
        }
    }
}
