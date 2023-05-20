using System;

namespace GUI.Menus
{
    public class SupervisorMENU : SupervisorGUI
    {
        public void menu()
        {
            int op;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ADMINISTRAR SUPERVISORES DEL GYM---");
                Console.SetCursorPosition(39, 7); Console.Write("1. Registrar supervisor");
                Console.SetCursorPosition(39, 8); Console.Write("2. Consulta de supervisores por busqueda");
                Console.SetCursorPosition(39, 9); Console.Write("3. Actualizar supervisor");
                Console.SetCursorPosition(39, 10); Console.Write("4. Eliminar supervisor");
                Console.SetCursorPosition(39, 11); Console.Write("5. Gestionar horarios de atencion");
                Console.SetCursorPosition(39, 12); Console.Write("6. Consultar clientes asociados al supervisor");
                Console.SetCursorPosition(39, 13); Console.Write("7. Salir");

                Console.SetCursorPosition(39, 15); Console.Write("Escoja la opción de su preferencia: ");
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
                        registrarSupervisor();
                        break;
                    case 2:
                        ConsultaDinamica();
                        break;
                    case 3:
                        actualizarSupervisor();
                        break;
                    case 4:
                        eliminarSupervisor();
                        break;
                    case 5:
                        menuTurno();
                        break;
                    case 6:
                        ClientesDeSupervisor();
                        break;
                    case 7:
                        break;
                    default:
                        Console.SetCursorPosition(39, 25); Console.Write("Ingrese una opción valida");
                        Console.ReadKey();
                        break;
                }
            } while (op != 7);
        }

        protected void menuTurno()
        {
            int op;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ADMINISTRAR TURNOS DE ATENCION---");
                Console.SetCursorPosition(39, 7); Console.Write("1. Registrar turno de atencion del supervisor");
                Console.SetCursorPosition(39, 8); Console.Write("2. Actualizar turno del supervisor");
                Console.SetCursorPosition(39, 9); Console.Write("3. Consultar todos los turnos de atencion");
                Console.SetCursorPosition(39, 10); Console.Write("4. Eliminar turno de atencion de supervisor");
                Console.SetCursorPosition(39, 11); Console.Write("5. Salir");
                Console.SetCursorPosition(39, 13); Console.Write("Escoja la opción de su preferencia: ");
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
                        registrarTurno();
                        break;
                    case 2:
                        actualizarTurno();
                        break;
                    case 3:
                        consultarTurno();
                        break;
                    case 4:
                        eliminarTurno();
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

    }
}
