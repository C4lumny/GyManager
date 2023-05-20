using Entidades;
using Logica;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;

namespace GUI
{
    public class InscripcionGUI
    {

        Inscripcion inscripciones;
        protected CRUD_Inscripcion servicioInscripcion = new CRUD_Inscripcion();

        Public_Clientes public_Cliente = new Public_Clientes();
        Public_Supervisores public_Supervisor = new Public_Supervisores();
        Public_Planes public_Plan = new Public_Planes();

        //----------------------------------------------------------------------------------------------------------------------------------
        protected private void registrarInscripcion()
        {
            char op = 'x';
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---REGISTRAR NUEVA INSCRIPCION---");
                try
                {
                    inscripciones = new Inscripcion();
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el ID de la inscripcion: "); inscripciones.Id = Console.ReadLine();
                    Console.SetCursorPosition(35, 11); Console.Write("Ingrese el ID del cliente asociado: "); String clienteS = Console.ReadLine();
                    if (public_Cliente.ReturnCliente(clienteS) == null)
                    {
                        Console.SetCursorPosition(35, 12); Console.WriteLine("El cliente que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }
                    Console.SetCursorPosition(35, 13); Console.Write("Ingrese el ID del supervisor asociado: "); String supervisorS = Console.ReadLine();
                    if (public_Supervisor.ReturnSupervisor(supervisorS) == null)
                    {
                        Console.SetCursorPosition(35, 14); Console.WriteLine("El supervisor que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }
                    Console.SetCursorPosition(35, 15); Console.Write("Ingrese el ID del plan asociado: "); String planS = Console.ReadLine();
                    if (public_Plan.ReturnPlan(planS) == null)
                    {
                        Console.SetCursorPosition(35, 16); Console.WriteLine("El plan que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }
                    inscripciones.cliente = public_Cliente.ReturnCliente(clienteS);
                    inscripciones.supervisor = public_Supervisor.ReturnSupervisor(supervisorS);
                    inscripciones.plan = public_Plan.ReturnPlan(planS);

                    DateTime fecha_ingreso = DateTime.Today;
                    DateTime fecha_finalizacion = fecha_ingreso.AddDays(inscripciones.plan.Dias);
                    inscripciones.Fecha_inicio = fecha_ingreso;
                    inscripciones.Fecha_finalizacion = fecha_finalizacion;

                    Console.SetCursorPosition(35, 17); Console.Write("Ingrese el descuento de la inscripcion(%): "); string descuento = Console.ReadLine();
                    inscripciones.Descuento = double.Parse(descuento.Replace("%", ""));

                    var response = servicioInscripcion.Save(inscripciones);
                    Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir agregando inscripciones?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());

                }
                catch (Exception)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Error, por favor rectifique los datos"); Console.ReadLine();
                    break;
                }
            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected private void consultarInscripcion(List<Inscripcion> lista, string titulo)
        {
            Console.Clear();
            ConsoleKeyInfo key;
            void izquierda()
            {
                do
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 4); Console.WriteLine(titulo);
                    int i = 6;
                    Console.SetCursorPosition(4, 1); Console.WriteLine("Pulse la derecha(->) para ver mas detalles de la inscripcion o ESC para salir.");
                    if (servicioInscripcion.GetAll() != null)
                    {
                        Console.SetCursorPosition(13, i); Console.WriteLine("ID".PadRight(12) + "ID CLIENTE".PadRight(15) + "ID SUPERVISOR".PadRight(18) + "ID PLAN".PadRight(13) + "FECHA INICIO".PadRight(18) + "FECHA FINALIZACION");
                        foreach (var item in lista)
                        {
                            Console.SetCursorPosition(13, i + 2); Console.WriteLine(item.Id.PadRight(12) + item.cliente.Id.PadRight(15) + item.supervisor.Id.PadRight(18) + item.plan.Id.PadRight(13) + item.Fecha_inicio.ToString("dd/MM/yyyy").PadRight(18) + item.Fecha_finalizacion.ToString("dd/MM/yyyy"));
                            i++;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado inscripciones");
                        Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse ESC para volver al menu...");
                    }
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        Derecha();
                        break;
                    }
                } while (key.Key != ConsoleKey.RightArrow || key.Key != ConsoleKey.Escape);
            }
            void Derecha()
            {
                do
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 4); Console.WriteLine(titulo);
                    int i = 6;
                    Console.SetCursorPosition(4, 1); Console.WriteLine("Pulse la izquierda(<-) para regresar o ESC para salir.");
                    if (servicioInscripcion.GetAll() != null)
                    {
                        Console.SetCursorPosition(9, i); Console.WriteLine("ID".PadRight(12) + "NOMBRE CLIENTE".PadRight(22) + "NOMBRE SUPERVISOR".PadRight(22) + "NOMBRE PLAN".PadRight(20) + "PRECIO".PadRight(13) + "ESTADO");
                        foreach (var item in lista)
                        {
                            Console.SetCursorPosition(9, i + 2); Console.WriteLine(item.Id.PadRight(12) + item.cliente.Nombre.PadRight(22) + item.supervisor.Nombre.PadRight(22) + item.plan.Nombre.PadRight(20) + item.Precio.ToString().PadRight(13) + item.EstadoToString());
                            i++;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 9); Console.WriteLine("No se han registrado inscripciones");
                        Console.SetCursorPosition(10, 11); Console.WriteLine("Pulse ESC para volver al menu...");
                    }
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        izquierda();
                        break;
                    }
                } while (key.Key != ConsoleKey.LeftArrow || key.Key != ConsoleKey.Escape);
            }

            izquierda();
            if (key.Key != ConsoleKey.Escape)
            {
                Derecha();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected private void actualizarInscripcion()
        {
            Inscripcion inscripcionU = new Inscripcion();
            char op = 'x';
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR INSCRIPCION---");
                try
                {
                    if (servicioInscripcion.GetAll() == null)
                    {
                        Console.SetCursorPosition(10, 10); Console.WriteLine("No se han registrado inscripciones");
                        Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
                        return;
                    }
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el ID de la inscripcion que desea actualizar: "); string inscripcion_S = Console.ReadLine();
                    var inscripcion_old = servicioInscripcion.ReturnInscripcion(inscripcion_S);
                    if (inscripcion_old == null)
                    {
                        Console.SetCursorPosition(35, 12); Console.WriteLine("La inscripcion que desea ingresar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }

                    Console.Clear();
                    Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR INSCRIPCION---");
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el nuevo ID de la inscripcion: "); inscripcionU.Id = Console.ReadLine();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el ID del cliente asociado: "); string clienteS = Console.ReadLine();
                    if (public_Cliente.ReturnCliente(clienteS) == null)
                    {
                        Console.SetCursorPosition(35, 12); Console.WriteLine("El cliente que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }


                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese el ID del supervisor asociado: "); string supervisorS = Console.ReadLine();
                    if (public_Supervisor.ReturnSupervisor(supervisorS) == null)
                    {
                        Console.SetCursorPosition(35, 14); Console.WriteLine("El supervisor que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }


                    Console.SetCursorPosition(35, 14); Console.Write("Ingrese el ID del plan asociado: "); string planS = Console.ReadLine();
                    if (public_Plan.ReturnPlan(planS) == null)
                    {
                        Console.SetCursorPosition(35, 16); Console.WriteLine("El plan que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }

                    inscripcionU.cliente = public_Cliente.ReturnCliente(clienteS);
                    inscripcionU.supervisor = public_Supervisor.ReturnSupervisor(supervisorS);
                    inscripcionU.plan = public_Plan.ReturnPlan(planS);

                    DateTime fecha_ingreso = DateTime.Today;
                    DateTime fecha_finalizacion = fecha_ingreso.AddDays(inscripcion_old.plan.Dias);
                    inscripcionU.Fecha_inicio = fecha_ingreso;
                    inscripcionU.Fecha_finalizacion = fecha_finalizacion;
                    inscripcionU.Estado = true;

                    Console.SetCursorPosition(35, 16); Console.Write("Ingrese el descuento de la inscripcion(%): "); string descuento = Console.ReadLine();
                    inscripcionU.Descuento = double.Parse(descuento.Replace("%", ""));
                    double precio;
                    try
                    {
                        Console.SetCursorPosition(35, 18); Console.Write("Ingrese el precio total de la inscripcion: "); precio = double.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        precio = default(double);
                    }
                    inscripcionU.Precio = precio;
                    var response = servicioInscripcion.Update(inscripcionU, inscripcion_S);
                    Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir actualizando inscripciones?[S/N]: ");
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
        protected private void eliminarInscripcion()
        {
            char op = 'x';
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ELIMINAR INSCRIPCION---");
                try
                {
                    if (servicioInscripcion.GetAll() == null)
                    {
                        Console.SetCursorPosition(10, 10); Console.WriteLine("No se han registrado inscripciones");
                        Console.SetCursorPosition(10, 12); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
                        return;
                    }
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el ID de la inscripcion: "); string inscripcion_S = Console.ReadLine();
                    if (servicioInscripcion.ReturnInscripcion(inscripcion_S) == null)
                    {
                        Console.SetCursorPosition(35, 12); Console.WriteLine("La inscripcion que desea ingresar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }

                    var response = servicioInscripcion.Delete(inscripcion_S);
          
                    Console.SetCursorPosition(35, 9); Console.WriteLine(response.Msg);

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir eliminando inscripciones?[S/N]: ");
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
        protected private void ConsultaDinamica()
        {
            int cursor = 94;
            string search = "";
            Console.Clear();
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            void izquierda()
            {
                do
                {
                    int i = 7;
                    Console.Clear();
                    Console.SetCursorPosition(40, 5); Console.WriteLine("---CONSULTA DE INSCRIPCIONES---");
                    if (servicioInscripcion.GetAll() != null && servicioInscripcion.GetBySearch(search) != null)
                    {
                        Console.SetCursorPosition(20, 3); Console.Write("Puede ingresar ID, Nombre del cliente o el Id del cliente para consultar: " + search);
                        Console.SetCursorPosition(13, i); Console.WriteLine("ID".PadRight(12) + "ID CLIENTE".PadRight(15) + "ID SUPERVISOR".PadRight(18) + "ID PLAN".PadRight(13) + "FECHA INICIO".PadRight(18) + "FECHA FINALIZACION");

                        foreach (var item in servicioInscripcion.GetBySearch(search))
                        {
                            Console.SetCursorPosition(13, i + 2); Console.WriteLine(item.Id.PadRight(12) + item.cliente.Id.PadRight(15) + item.supervisor.Id.PadRight(18) + item.plan.Id.PadRight(13) + item.Fecha_inicio.ToString("dd/MM/yyyy").PadRight(18) + item.Fecha_finalizacion.ToString("dd/MM/yyyy"));
                            i++;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(10, 9); Console.WriteLine("No se han registrado inscripciones");
                        Console.SetCursorPosition(10, 11); Console.WriteLine("Pulse cualquier tecla para volver al menu...");
                        Console.ReadKey(); return;
                    }
                    Console.SetCursorPosition(cursor, 3); key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.Backspace && search.Length > 0)
                    {
                        search = search.Remove(search.Length - 1);
                        cursor--;
                    }
                    else if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsPunctuation(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsLetterOrDigit(key.KeyChar))
                    {
                        search += key.KeyChar.ToString();
                        cursor++;
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        Derecha();
                        break;
                    }
                } while (key.Key != ConsoleKey.RightArrow || key.Key != ConsoleKey.Escape);
            }
            void Derecha()
            {
                do
                {
                    int i = 7;
                    Console.Clear();
                    Console.SetCursorPosition(40, 5); Console.WriteLine("---CONSULTA DE INSCRIPCIONES---");
                    if (servicioInscripcion.GetAll() != null && servicioInscripcion.GetBySearch(search) != null)
                    {
                        Console.SetCursorPosition(20, 3); Console.Write("Puede ingresar ID, Nombre del cliente o el Id del cliente para consultar: " + search);
                        Console.SetCursorPosition(11, i); Console.WriteLine("ID".PadRight(12) + "NOMBRE CLIENTE".PadRight(19) + "NOMBRE SUPERVISOR".PadRight(22) + "NOMBRE PLAN".PadRight(20) + "PRECIO".PadRight(13) + "ESTADO");
                        foreach (var item in servicioInscripcion.GetBySearch(search))
                        {
                            Console.SetCursorPosition(11, i + 2); Console.WriteLine(item.Id.PadRight(12) + item.cliente.Nombre.PadRight(19) + item.supervisor.Nombre.PadRight(22) + item.plan.Nombre.PadRight(20) + item.Precio.ToString().PadRight(13) + item.EstadoToString());
                            i++;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado inscripciones");
                        Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier tecla para volver al menu...");
                        Console.ReadKey(); return;
                    }

                    Console.SetCursorPosition(cursor, 3); key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.Backspace && search.Length > 0)
                    {
                        search = search.Remove(search.Length - 1);
                        cursor--;
                    }
                    else if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsSymbol(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsPunctuation(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && char.IsLetterOrDigit(key.KeyChar))
                    {
                        search += key.KeyChar.ToString();
                        cursor++;
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        izquierda();
                        break;
                    }
                } while (key.Key != ConsoleKey.LeftArrow || key.Key != ConsoleKey.Escape);
            }
            izquierda();
            if (key.Key != ConsoleKey.Escape && servicioInscripcion.GetAll() != null)
            {
                Derecha();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
}
