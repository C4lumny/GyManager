using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class PlanGUI // En esta clase se modela la interfaz grafica relacionada a los planes por medio de metodos de la clase ServicioPlanes. 
    {
        CRUD_Plan servicioPlan = new CRUD_Plan();
        //----------------------------------------------------------------------------------------------------------------------------------
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
                Console.SetCursorPosition(35, 11); Console.Write("5. Salir");
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
                        //Volver al menu
                        break;
                    default:
                        Console.SetCursorPosition(35, 25); Console.Write("Ingrese una opción valida");
                        Console.ReadKey();
                        break;

                }
            } while (op != 5);
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        void registrarPlan()
        {
            char op;
            do
            {
                Console.Clear();
                PlanGimnasio planes = new PlanGimnasio();
                CRUD_Plan servicioPlan = new CRUD_Plan();

                Console.SetCursorPosition(43, 5); Console.Write("---REGISTRAR NUEVO PLAN---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del plan: "); planes.Id = Console.ReadLine();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del plan: "); planes.Nombre = Console.ReadLine();
                    Console.SetCursorPosition(35, 11); Console.Write("Ingrese el precio del plan: "); planes.Precio = Double.Parse(Console.ReadLine());
                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese la descripción del plan: "); planes.Descripcion = Console.ReadLine();
                    Console.SetCursorPosition(35, 13); Console.Write("Ingrese la duración(dias) del plan: "); planes.Dias = int.Parse(Console.ReadLine());
              
                    var response = servicioPlan.Save(planes);
                    Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir agregando planes?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Error, por favor rectifique los datos");
                    break;
                }
            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        void consultarPlan()
        {
            Console.Clear();
            int i = 7;
            int j = 5;
            Console.SetCursorPosition(10, 5); Console.WriteLine("---LISTA DE PLANES---");
            if (servicioPlan.GetAll() != null)
            {
                Console.SetCursorPosition(10, i); Console.WriteLine("ID".PadRight(15) + "NOMBRE".PadRight(15) + "PRECIO".PadRight(10) + "DIAS".PadRight(15));
                foreach (var item in servicioPlan.GetAll())
                {
                    Console.SetCursorPosition(10, i + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Precio.ToString().PadRight(10) + item.Dias.ToString().PadRight(5));
                    i++;
                }

                Console.SetCursorPosition(10, 3); Console.WriteLine("Pulse derecha(->) para visualizar las descripciones.");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.Clear();
                    Console.SetCursorPosition(10, 5); Console.WriteLine("---DESCRIPCIONES DE PLANES---");
                    
                    foreach (var item in servicioPlan.GetAll())
                    {
                        Console.SetCursorPosition(10, j + 2); Console.WriteLine($"{item.Nombre}: {item.Descripcion}");
                        j++;
                    }
                    Console.SetCursorPosition(10, 3); Console.WriteLine("Pulse la izquierda(<-) para volver a la lista de planes.");
                    ConsoleKeyInfo backKey = Console.ReadKey();
                    if (backKey.Key == ConsoleKey.LeftArrow)
                    {
                        consultarPlan();
                    }
                }
            }
            else
            {
                Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado planes");
                Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
                Console.ReadKey();
            }
        }



        //----------------------------------------------------------------------------------------------------------------------------------
        void actualizarPlan()
        {
            string id_planU;
            char op = 'x';
            do
            {
                Console.Clear();
                PlanGimnasio planes = new PlanGimnasio();
                CRUD_Plan servicioPlan = new CRUD_Plan();
                try
                {
                    Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR PLAN---");
                    Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del plan que desea actualizar: "); id_planU = Console.ReadLine();
                    if (servicioPlan.ReturnPlan(id_planU) == null)
                    {
                        Console.SetCursorPosition(35, 9); Console.WriteLine("El plan que desea actualizar, no se encuentra en la base de datos");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR PLAN---");
                        Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del plan: "); planes.Id = Console.ReadLine();
                        Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del plan: "); planes.Nombre = Console.ReadLine();
                        Console.SetCursorPosition(35, 11); Console.Write("Ingrese el precio del plan: "); planes.Precio = Double.Parse(Console.ReadLine());
                        Console.SetCursorPosition(35, 12); Console.Write("Ingrese la descripción del plan: "); planes.Descripcion = Console.ReadLine();
                        Console.SetCursorPosition(35, 13); Console.Write("Ingrese la duración(dias) del plan: "); planes.Dias = int.Parse(Console.ReadLine());

                        var response = servicioPlan.Update(planes, id_planU);
                        Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);
                        Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir actualizando planes?[S/N]: ");
                        op = char.Parse(Console.ReadLine().ToLower());
                    }
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Error, por favor rectifique los datos");
                    break;
                }
            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        void eliminarPlan()
        {
            string id_planD;
            char op = 'x';
            do
            {

                Console.Clear();
                Console.SetCursorPosition(43, 5); Console.Write("---ELIMINAR PLAN---");
                Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del plan que desea eliminar: "); id_planD = Console.ReadLine();
                if (servicioPlan.ReturnPlan(id_planD) == null)
                {
                    Console.SetCursorPosition(35, 9); Console.WriteLine("El plan que desea actualizar, no se encuentra en la base de datos");
                    Console.ReadKey();
                }
                else
                {
                    var response = servicioPlan.Delete(id_planD);
                    Console.SetCursorPosition(35, 9); Console.WriteLine("Se ha eliminado el plan: " + response.Object.Nombre);
                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir eliminando planes?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());
                }
            } while (op == 's');
        }
    }
}
