using Entidades;
using Logica;
using System;
using System.Collections.Generic;

namespace GUI
{
    public class PlanGUI // En esta clase se modela la interfaz grafica relacionada a los planes por medio de metodos de la clase ServicioPlanes. 
    {
        CRUD_Plan servicioPlan = new CRUD_Plan();

        //----------------------------------------------------------------------------------------------------------------------------------
        protected void registrarPlan()
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
        protected void consultarPlan()
        {
            Console.Clear();
            Console.SetCursorPosition(25, 5); Console.WriteLine("---LISTA DE PLANES---");
            Mostrar(servicioPlan.GetAll(), 7, 5);
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void Mostrar(List<PlanGimnasio> lista, int Pos_vertical1, int Pos_Vertical2)
        {
            if (servicioPlan.GetAll() != null)
            {
                Console.SetCursorPosition(25, Pos_vertical1); Console.WriteLine("ID".PadRight(15) + "NOMBRE".PadRight(15) + "PRECIO".PadRight(10) + "DIAS".PadRight(15));
                foreach (var item in lista)
                {
                    Console.SetCursorPosition(25, Pos_vertical1 + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Precio.ToString().PadRight(10) + item.Dias.ToString().PadRight(5));
                    Pos_vertical1++;
                }

                Console.SetCursorPosition(20, 3); Console.WriteLine("Pulse derecha(->) para visualizar las descripciones.");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.Clear();
                    Console.SetCursorPosition(20, 5); Console.WriteLine("---DESCRIPCIONES DE PLANES---");

                    foreach (var item in servicioPlan.GetAll())
                    {
                        Console.SetCursorPosition(20, Pos_Vertical2 + 2); Console.WriteLine($"{item.Nombre}: {item.Descripcion}");
                        Pos_Vertical2++;
                    }
                    Console.SetCursorPosition(20, 3); Console.WriteLine("Pulse la izquierda(<-) para volver a la lista de planes.");
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
        protected void actualizarPlan()
        {
            string id_planU;
            char op = 'x';
            do
            {
                Console.Clear();
                PlanGimnasio planes = new PlanGimnasio();
                try
                {
                    Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR PLAN---");
                    Mostrar(servicioPlan.GetAll(), 7, 5); Console.Clear();
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
        protected void eliminarPlan()
        {
            string id_planD;
            char op = 'x';
            do
            {
                Console.Clear();
                Console.SetCursorPosition(43, 5); Console.Write("---ELIMINAR PLAN---");
                Mostrar(servicioPlan.GetAll(), 7, 5); Console.Clear();
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
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void ConsultaDinamica()
        {
            string search = "";
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Console.Clear();

            // Funciones internas;
            void Izquierda()
            {
                do
                {
                    int i = 10;
                    Console.Clear();
                    Console.SetCursorPosition(38, 6); Console.Write("Ingrese el id o nombre del plan: " + search);
                    Console.SetCursorPosition(46, 8); Console.WriteLine("---LISTA DE PLANES---");
                    Console.SetCursorPosition(4, 1); Console.WriteLine("Pulse derecha(->) para visualizar las descripciones o ESC para salir.");

                    if (servicioPlan.GetAll() != null)
                    {
                        Console.SetCursorPosition(32, i); Console.WriteLine("ID".PadRight(15) + "NOMBRE".PadRight(15) + "PRECIO".PadRight(10) + "DIAS".PadRight(15));
                        foreach (var item in servicioPlan.GetBySearch(search))
                        {
                            Console.SetCursorPosition(32, i + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Precio.ToString().PadRight(10) + item.Dias.ToString().PadRight(5));
                            i++;
                        }
                        Console.SetCursorPosition(71, 6); key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        if (key.Key == ConsoleKey.Backspace && search.Length > 0)
                        {
                            search = search.Remove(search.Length - 1);
                        }
                        else if (Char.IsLetterOrDigit(key.KeyChar))
                        {
                            search += key.KeyChar.ToString();
                        }
                        else if (key.Key == ConsoleKey.RightArrow)
                        {
                            Derecha();
                            break;
                        }
                    }
                } while (key.Key != ConsoleKey.RightArrow || key.Key != ConsoleKey.Escape);

            }
            void Derecha()
            {
                do
                {
                    int j = 8;
                    Console.Clear();
                    Console.SetCursorPosition(4, 1); Console.WriteLine("Pulse la izquierda(<-) para volver a la lista de planes o ESC para salir.");
                    Console.SetCursorPosition(35, 6); Console.Write("Ingrese el id o nombre del plan: " + search);
                    Console.SetCursorPosition(43, 8); Console.WriteLine("---DESCRIPCIONES DE PLANES---");

                    foreach (var item in servicioPlan.GetBySearch(search))
                    {
                        Console.SetCursorPosition(20, j + 2); Console.WriteLine($"{item.Nombre}: {item.Descripcion}");
                        j++;
                    }

                    Console.SetCursorPosition(71, 6); key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    if (key.Key == ConsoleKey.Backspace && search.Length > 0)
                    {
                        search = search.Remove(search.Length - 1);
                    }
                    else if (Char.IsLetterOrDigit(key.KeyChar))
                    {
                        search += key.KeyChar.ToString();
                    }
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        Izquierda();
                        break;
                    }
                } while (key.Key != ConsoleKey.Escape || key.Key != ConsoleKey.Escape);
            }

            //Aplicacion;
            Izquierda();
            if (key.Key != ConsoleKey.Escape)
            {
                Derecha();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
}
