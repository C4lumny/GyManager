using Entidades;
using Logica;
using Logica.Operaciones.AccesoPublico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GUI
{
    public class SupervisorGUI : Turno_AtencionGUI // En esta clase se modela la interfaz grafica relacionada a los coaches por medio de metodos de la clase ServicioCoaches. 
    {
        Public_Inscripciones Public_Inscripciones = new Public_Inscripciones();
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void registrarSupervisor()
        {
            char op;
            do
            {
                Console.Clear();
                Supervisor supervisores = new Supervisor();
                CRUD_Supervisor servSupervisor = new CRUD_Supervisor();

                Console.SetCursorPosition(43, 5); Console.Write("---REGISTRAR NUEVO SUPERVISOR---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del supervisor: "); supervisores.Id = Console.ReadLine();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del supervisor: "); supervisores.Nombre = Console.ReadLine();
                    Console.SetCursorPosition(35, 11); Console.Write("Ingrese el telefono del supervisor: "); supervisores.Telefono = Console.ReadLine();
                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese el sexo del supervisor(M o F): "); supervisores.Genero = Console.ReadLine().ToUpper()[0].ToString();
                    Console.SetCursorPosition(35, 13); Console.Write("Ingrese el peso del supervisor(Kg): "); supervisores.Peso = double.Parse(Console.ReadLine().Replace(".", ","));
                    Console.SetCursorPosition(35, 14); Console.Write("Ingrese la altura del supervisor(metros): "); supervisores.Altura = double.Parse(Console.ReadLine().Replace(".", ","));
                    Console.SetCursorPosition(43, 16); Console.Write("Fecha de nacimiento");
                    Console.SetCursorPosition(35, 18); Console.Write("Dia: "); int dia = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(45, 18); Console.Write("Mes: "); int mes = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(55, 18); Console.Write("Año: "); int anio = int.Parse(Console.ReadLine());
                    supervisores.Fecha_nacimiento = new DateTime(anio, mes, dia);

                    supervisores.Fecha_ingreso = DateTime.Now;
                    var response = servSupervisor.Save(supervisores);
                    Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir agregando supervisores?[S/N]: ");
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
        protected void actualizarSupervisor()
        {
            string id_supervisorU;
            char op = 'x';
            do
            {
                Console.Clear();
                Supervisor supervisores = new Supervisor();
                try
                {
                    Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR SUPERVISOR---");
                    Mostrar(servicioSupervisor.GetAll(), 9);
                    Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del supervisor que desea actualizar: "); id_supervisorU = Console.ReadLine();
                    Console.Clear();
                    if (servicioSupervisor.ReturnSupervisor(id_supervisorU) == null)
                    {
                        Console.SetCursorPosition(35, 9); Console.WriteLine("El supervisor que desea actualizar, no se encuentra en la base de datos");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR SUPERVISOR---");
                        Console.SetCursorPosition(35, 9); Console.Write("Ingrese la identificación del supervisor: "); supervisores.Id = Console.ReadLine();
                        Console.SetCursorPosition(35, 10); Console.Write("Ingrese el nombre del supervisor: "); supervisores.Nombre = Console.ReadLine();
                        Console.SetCursorPosition(35, 11); Console.Write("Ingrese el telefono del supervisor: "); supervisores.Telefono = Console.ReadLine();
                        Console.SetCursorPosition(35, 12); Console.Write("Ingrese el sexo del supervisor(M o F): "); supervisores.Genero = Console.ReadLine().ToUpper()[0].ToString();
                        Console.SetCursorPosition(35, 13); Console.Write("Ingrese el peso del supervisor(Kg): "); supervisores.Peso = double.Parse(Console.ReadLine().Replace(".", ","));
                        Console.SetCursorPosition(35, 14); Console.Write("Ingrese la altura del supervisor(metros): "); supervisores.Altura = double.Parse(Console.ReadLine().Replace(".", ","));
                        Console.SetCursorPosition(43, 16); Console.Write("Fecha de nacimiento");
                        Console.SetCursorPosition(35, 18); Console.Write("Dia: "); int dia = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(45, 18); Console.Write("Mes: "); int mes = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(55, 18); Console.Write("Año: "); int anio = int.Parse(Console.ReadLine());
                        supervisores.Fecha_nacimiento = new DateTime(anio, mes, dia);

                        supervisores.Fecha_ingreso = servicioSupervisor.ReturnSupervisor(id_supervisorU).Fecha_ingreso;
                        var response = servicioSupervisor.Update(supervisores, id_supervisorU);
                        Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);
                        Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir actualizando supervisores?[S/N]: ");
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
        protected void eliminarSupervisor()
        {
            string id_supervisorD;
            char op = 'x';
            do
            {

                Console.Clear();
                Console.SetCursorPosition(43, 5); Console.Write("---ELIMINAR SUPERVISOR---");
                Mostrar(servicioSupervisor.GetAll(), 9);
                Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del supervisor que desea eliminar: "); id_supervisorD = Console.ReadLine();
                Console.Clear();

                if (servicioSupervisor.ReturnSupervisor(id_supervisorD) == null)
                {
                    Console.SetCursorPosition(35, 9); Console.WriteLine("El supervisor que desea eliminar no se encuentra en la base de datos");
                    Console.ReadKey();
                }
                else
                {
                    var response = servicioSupervisor.Delete(id_supervisorD);
                    Console.SetCursorPosition(35, 9); Console.WriteLine(response.Msg);
                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir eliminando supervisores?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());
                }
            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void ClientesDeSupervisor()
        {
            int i = 7;
            string id_supervisorD;
            Console.Clear();
            Console.SetCursorPosition(41, 5); Console.Write("---LISTA DE CLIENTES DEL SUPERVISOR---");
            Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del supervisor: "); id_supervisorD = Console.ReadLine();
            var supervisor = servicioSupervisor.ReturnSupervisor(id_supervisorD);
            if (supervisor == null)
            {
                Console.SetCursorPosition(35, 9); Console.WriteLine("El supervisor no se encuentra en la base de datos");
                Console.ReadKey();
                return;
            }
            Console.Clear();
            Console.SetCursorPosition(41, 5); Console.WriteLine("---LISTA DE CLIENTES DEL SUPERVISOR:---");
            if (Public_Inscripciones.ClientesPorSupervisor(supervisor) != null)
            {
                Console.SetCursorPosition(19, i); Console.WriteLine("CC".PadRight(15) + "NOMBRE".PadRight(15) + "SEXO".PadRight(10) + "TELEFONO".PadRight(15) + "IMC".PadRight(12) + "FECHA INGRESO:");
                foreach (var item in Public_Inscripciones.ClientesPorSupervisor(supervisor).Take(15))
                {
                    Console.SetCursorPosition(19, i + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Genero.PadRight(10) + item.Telefono.PadRight(15) + item.Imc.ToString().PadRight(12) + item.Fecha_ingreso.ToShortDateString());
                    i++;
                }
            }
            else
            {
                Console.SetCursorPosition(10, 7); Console.WriteLine("Este supervisor no posee clientes asociandos.");
                Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
            }
            Console.ReadKey();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void Mostrar(List<Supervisor> list, int pos)
        {
            if (servicioSupervisor.GetAll() != null)
            {
                Console.SetCursorPosition(30, pos); Console.WriteLine("CC".PadRight(15) + "NOMBRE".PadRight(15) + "SEXO".PadRight(9) + "TELEFONO".PadRight(15));
                foreach (var supervisor in list)
                {
                    Console.SetCursorPosition(30, pos + 2);
                    Console.WriteLine(supervisor.Id.ToString().PadRight(15) + supervisor.Nombre.PadRight(15) + supervisor.Genero.PadRight(9) + supervisor.Telefono.PadRight(10));
                    pos++;
                }

            }
            else
            {
                Console.SetCursorPosition(10, 9); Console.WriteLine("No se han registrado supervisores");
                Console.SetCursorPosition(10, 11); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
                return;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void ConsultaDinamica()
        {
            string search = "";
            Console.Clear();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            void Izquierda()
            {
                do
                {
                    Console.Clear();
                    Console.SetCursorPosition(4, 1); Console.WriteLine("Pulse derecha(->) para visualizar los turnos o ESC para salir.");
                    Console.SetCursorPosition(35, 4); Console.Write("Ingrese el id, nombre o telefono del supervisor: " + search);
                    Console.SetCursorPosition(46, 6); Console.WriteLine("---LISTA DE SUPERVISORES---");
                    Mostrar(servicioSupervisor.GetBySearch(search), 8);
                    Console.SetCursorPosition(84, 4); key = Console.ReadKey();
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

                } while (key.Key != ConsoleKey.Escape || key.Key != ConsoleKey.LeftArrow);
            }
            void Derecha()
            {
                do
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 6); Console.WriteLine("---LISTA DE TURNOS---");
                    Console.SetCursorPosition(4, 1); Console.WriteLine("Pulse izquierda(<-) para visualizar los supervisores o ESC para salir.");
                    Console.SetCursorPosition(26, 4); Console.Write("Ingrese el dia o la hora del turno o el id del supervisor: " + search);
                    int i = 9;
                    if (servicioSupervisor.GetAll() != null)
                    {
                        Console.SetCursorPosition(20, i); Console.WriteLine("SUPERVISOR CC:".PadRight(19) + "DIA DE SEMANA:".PadRight(19) + "HORA DE ENTRADA:".PadRight(20) + "HORA DE SALIDA:");
                        var turnosSearch = servicioSupervisor.GetTurnoBySearch(search);
                        if (turnosSearch != null)
                        {
                            turnosSearch.Sort((z1, z2) => z1.Id_supervisor.CompareTo(z2.Id_supervisor));
                            foreach (var turno in turnosSearch)
                            {
                                Console.SetCursorPosition(20, i + 2); Console.WriteLine(turno.Id_supervisor.PadRight(19) + turno.Dia.PadRight(19) + turno.Hora_Inicio.ToShortTimeString().PadRight(20) + turno.Hora_Salida.ToShortTimeString());
                                i++;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(45, 6); Console.WriteLine("---LISTA DE TURNOS---");
                            Console.SetCursorPosition(4, 1); Console.WriteLine("Pulse izquierda(<-) para visualizar los supervisores o ESC para salir.");
                            Console.SetCursorPosition(44, 8); Console.WriteLine("No hay turnos asignados");
                            Console.SetCursorPosition(41, 10); Console.WriteLine("Pulse ESC para volver al menu.");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 9); Console.WriteLine("No se han registrado supervisores");
                        Console.SetCursorPosition(10, 11); Console.WriteLine("Pulse ESC para volver al menu");
                    }
                    Console.SetCursorPosition(95, 4); key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.Backspace && search.Length > 0)
                    {
                        search = search.Remove(search.Length - 1);
                    }
                    else if (Char.IsLetterOrDigit(key.KeyChar) || (key.Modifiers & ConsoleModifiers.Shift) != 0 && key.Key == ConsoleKey.OemPeriod)
                    {
                        search += key.KeyChar.ToString();
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        Izquierda();
                        break;
                    }
                } while (key.Key != ConsoleKey.Escape || key.Key != ConsoleKey.LeftArrow);
            }
            Izquierda();
            if (key.Key != ConsoleKey.Escape)
            {
                Derecha();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
}
