using System;

namespace GUI.Menus
{
    public class InscripcionMENU : InscripcionGUI
    {
        public void menu()
        {
            int op;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(43, 5); Console.Write("---ADMINISTRAR INSCRIPCIONES DEL GYM---");
                Console.SetCursorPosition(39, 7); Console.Write("1. Registrar inscripcion");
                Console.SetCursorPosition(39, 8); Console.Write("2. Consulta de inscripciones por busqueda");
                Console.SetCursorPosition(39, 9); Console.Write("3. Actualizar inscripcion");
                Console.SetCursorPosition(39, 10); Console.Write("4. Eliminar inscripcion");
                Console.SetCursorPosition(39, 11); Console.Write("5. Consultar historial de cambios de inscripciones");
                Console.SetCursorPosition(39, 12); Console.Write("6. Consultar inscripciones vigentes");
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
                        registrarInscripcion();
                        break;
                    case 2:
                        ConsultaDinamica();
                        break;
                    case 3:
                        actualizarInscripcion();
                        break;
                    case 4:
                        eliminarInscripcion();
                        break;
                    case 5:
                        consultarInscripcion(servicioInscripcion.Historial_Inscripciones(), "---HISTORIAL DE INSCRIPCIONES---");
                        break;
                    case 6:
                        consultarInscripcion(servicioInscripcion.GetInscripcionesVigentes(), "---INSCRIPCIONES VIGENTES---");
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
    }
}
