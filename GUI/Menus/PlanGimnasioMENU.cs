using System;

namespace GUI.Menus
{
    public class PlanGimnasioMENU : PlanGUI
    {
        public void menu()
        {
            int op;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ADMINISTRAR PLANES DEL GYM---");
                Console.SetCursorPosition(35, 7); Console.Write("1. Registrar plan");
                Console.SetCursorPosition(35, 8); Console.Write("2. Consulta de planes por busqueda");
                Console.SetCursorPosition(35, 9); Console.Write("3. Actualizar plan");
                Console.SetCursorPosition(35, 10); Console.Write("4. Eliminar plan");
                Console.SetCursorPosition(35, 11); Console.Write("5. Salir");

                Console.SetCursorPosition(35, 13); Console.Write("Escoja la opción de su preferencia: ");
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
                        registrarPlan();
                        break;
                    case 2:
                        ConsultaDinamica();
                        break;
                    case 3:
                        actualizarPlan();
                        break;
                    case 4:
                        eliminarPlan();
                        break;
                    case 5:
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
