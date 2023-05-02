using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.SetCursorPosition(35, 8); Console.Write("2. Consultar planes");
                Console.SetCursorPosition(35, 9); Console.Write("3. Actualizar plan");
                Console.SetCursorPosition(35, 10); Console.Write("4. Eliminar plan");
                Console.SetCursorPosition(35, 11); Console.Write("5. Consulta por busqueda");
                Console.SetCursorPosition(35, 12); Console.Write("6. Salir");
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
                        registrarPlan();
                        break;
                    case 2:
                        consultarPlan();
                        break;
                    case 3:
                        actualizarPlan();
                        break;
                    case 4:
                        eliminarPlan();
                        break;
                    case 5:
                        ConsultaDinamica();
                        break;
                    case 6:
                        //Volver al menu
                        break;
                    default:
                        Console.SetCursorPosition(35, 25); Console.Write("Ingrese una opción valida");
                        Console.ReadKey();
                        break;

                }
            } while (op != 6);
        }

    }
}
