using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Turno_AtencionGUI
    {
        protected CRUD_Supervisor servicioSupervisor = new CRUD_Supervisor();
        public Turno_AtencionGUI()
        {
            
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void registrarTurno()
        {
            char op;
            do
            {
                Console.Clear();
                Turno_Atencion turnos;

                Console.SetCursorPosition(43, 5); Console.Write("---ASIGNAR NUEVO TURNO---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el ID del supervisor a asignar: "); String supervisorS = Console.ReadLine();

                    if (servicioSupervisor.ReturnSupervisor(supervisorS) == null)
                    {
                        Console.SetCursorPosition(35, 11); Console.WriteLine("El supervisor que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }

                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el dia del turno: "); String dia = Console.ReadLine().ToUpper();
                    Console.SetCursorPosition(35, 11); Console.Write("Ingrese la hora inicio del plan(HH:mm): "); String fechaI = Console.ReadLine();
                    DateTime horaI = DateTime.Parse(fechaI);
                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese la hora fin del plan(HH:mm): "); String fechaF = Console.ReadLine();
                    DateTime horaF = DateTime.Parse(fechaF);

                    turnos = new Turno_Atencion(supervisorS, dia, horaI, horaF);
                    var response = servicioSupervisor.SaveTurno(turnos);
                    if (response == true)
                    {
                        Console.SetCursorPosition(35, 22); Console.WriteLine("El turno se asigno correctamente");
                    }
                    else
                    {
                        Console.SetCursorPosition(35, 22); Console.WriteLine("El turno no se pudo asignar");
                    }

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir asignando turnos?[S/N]: ");
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
        protected void actualizarTurno()
        {
            Turno_Atencion turnoN;
            char op = 'x';
            do
            {
                Console.Clear();
                try
                {
                    Console.SetCursorPosition(46, 3); Console.Write("---ACTUALIZAR TURNO---");
                    Mostrar(false);
                    Console.SetCursorPosition(35, 5); Console.Write("Ingrese el ID supervisor del turno: "); string id_supervisorS = Console.ReadLine();
                    Console.Clear();
                    if (servicioSupervisor.ReturnSupervisor(id_supervisorS) == null)
                    {
                        Console.SetCursorPosition(35, 9); Console.WriteLine("El supervisor que desea actualizar, no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el dia del turno: "); string diaT = Console.ReadLine().ToUpper();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese hora inicio u hora final(HH:mm): "); DateTime horaIF = DateTime.Parse(Console.ReadLine());

                    var turnoV = servicioSupervisor.ReturnTurno(id_supervisorS, diaT, horaIF);

                    Console.SetCursorPosition(35, 11); Console.Write("Ingrese el ID del nuevo supervisor: "); string id_supervisorN = Console.ReadLine();
                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese el nuevo dia: "); string diaN = Console.ReadLine().ToUpper();
                    Console.SetCursorPosition(35, 13); Console.Write("Ingrese la nueva hora inicio: "); DateTime horaI = DateTime.Parse(Console.ReadLine());
                    Console.SetCursorPosition(35, 14); Console.Write("Ingrese la nueva hora fin: "); DateTime horaF = DateTime.Parse(Console.ReadLine());
                    turnoN = new Turno_Atencion(id_supervisorN, diaN, horaI, horaF);

                    var response = servicioSupervisor.UpdateTurno(turnoV, turnoN);

                    if (response == true)
                    {
                        Console.SetCursorPosition(35, 22); Console.WriteLine("El turno fue actualizado correctamente");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.SetCursorPosition(35, 22); Console.WriteLine("El turno no pudo ser actualizado, intente de nuevo");
                        Console.ReadKey();
                    }

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir actualizando supervisores?[S/N]: ");
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
        protected void eliminarTurno()
        {
            Turno_Atencion turno;
            string id_supervisorD;
            char op = 'x';
            do
            {

                Console.Clear();
                Console.SetCursorPosition(46, 3); Console.Write("---ELIMINAR TURNO---");
                Mostrar(false);
                Console.SetCursorPosition(35, 5); Console.Write("Ingrese el ID del supervisor asignado al turno que desea eliminar: "); id_supervisorD = Console.ReadLine();
                Console.Clear();
                if (servicioSupervisor.ReturnSupervisor(id_supervisorD) == null)
                {
                    Console.SetCursorPosition(35, 9); Console.WriteLine("El supervisor que desea eliminar, no se encuentra en la base de datos");
                    Console.ReadKey();
                    return;
                }

                Console.SetCursorPosition(35, 9); Console.Write("Ingrese el dia del turno: "); string diaT = Console.ReadLine().ToUpper();
                Console.SetCursorPosition(35, 10); Console.Write("Ingrese hora inicio u hora final(HH:mm): "); DateTime horaIF = DateTime.Parse(Console.ReadLine());

                turno = servicioSupervisor.ReturnTurno(id_supervisorD, diaT, horaIF);

                var response = servicioSupervisor.DeleteTurno(turno);

                if (response == true)
                {
                    Console.SetCursorPosition(35, 22); Console.WriteLine("El turno fue eliminado correctamente");
                    Console.ReadKey();
                }
                else
                {
                    Console.SetCursorPosition(35, 22); Console.WriteLine("El turno no pudo ser eliminado, intente de nuevo");
                    Console.ReadKey();
                }

                Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir eliminando turnos?[S/N]: ");
                op = char.Parse(Console.ReadLine().ToLower());

            } while (op == 's');
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        protected void consultarTurno()
        {
            Console.Clear();
            Console.SetCursorPosition(46, 5); Console.WriteLine("---LISTA DE TURNOS---");
            Mostrar(true);
        }
        void Mostrar(bool @static)
        {
            int i = 8;
            if (servicioSupervisor.GetAll() != null)
            {
                foreach (var supervisor in servicioSupervisor.GetAll())
                {
                    if (supervisor.Horarios != null)
                    {
                        Console.SetCursorPosition(40, i); Console.Write("---TURNOS DE ATENCION DE: " + supervisor.Nombre + "---");
                        i = i + 2;
                        Console.SetCursorPosition(33, i); Console.WriteLine("DIA DE SEMANA:".PadRight(19) + "HORA DE ENTRADA:".PadRight(20) + "HORA DE SALIDA:");
                        i = i + 2;
                        foreach (var turno in supervisor.Horarios)
                        {
                            Console.SetCursorPosition(33, i); Console.WriteLine(turno.Dia.PadRight(19) + turno.Hora_Inicio.ToShortTimeString().PadRight(20) + turno.Hora_Salida.ToShortTimeString());
                            i++;
                        }
                        i+=2;
                    }
                }
            }
            else
            {
                Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado supervisores");
                Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
            }
            if (@static == true)
            {
                Console.ReadKey();
            }
        }
    }
}
