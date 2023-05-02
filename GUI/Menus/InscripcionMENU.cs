using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.SetCursorPosition(35, 7); Console.Write("1. Registrar inscripcion");
                Console.SetCursorPosition(35, 8); Console.Write("2. Consultar todas las inscripciones");
                Console.SetCursorPosition(35, 9); Console.Write("3. Actualizar inscripcion");
                Console.SetCursorPosition(35, 10); Console.Write("4. Eliminar inscripcion");
                Console.SetCursorPosition(35, 11); Console.Write("5. Consultar Historial de cambios de Inscripciones");
                Console.SetCursorPosition(35, 12); Console.Write("6. Consultar Inscripciones Vigentes");
                Console.SetCursorPosition(35, 13); Console.Write("7. Consulta por busqueda");
                Console.SetCursorPosition(35, 14); Console.Write("8. Salir");
                Console.SetCursorPosition(35, 16); Console.Write("Escoja la opción de su preferencia: ");
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
                        consultarInscripcion(servicioInscripcion.GetAll(), "---LISTA DE INSCRIPCIONES---");
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
                        ConsultaDinamica();
                        break;
                    case 8:
                        break;
                    default:
                        Console.SetCursorPosition(35, 25); Console.Write("Ingrese una opción valida");
                        Console.ReadKey();
                        break;
                }
            } while (op != 8);
        }
    }
}
