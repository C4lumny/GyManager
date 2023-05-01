using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class InscripcionGUI
    {

        Inscripcion inscripciones = new Inscripcion();
        PlanGimnasio planes = new PlanGimnasio();
        Cliente clientes = new Cliente();
        Supervisor supervisores = new Supervisor();

        CRUD_Cliente servicioCliente = new CRUD_Cliente();
        CRUD_Supervisor servicioSupervisor = new CRUD_Supervisor();
        CRUD_Inscripcion servicioInscripcion = new CRUD_Inscripcion();
        CRUD_Plan servicioPlan = new CRUD_Plan();

        //----------------------------------------------------------------------------------------------------------------------------------
        public void menu()
        {
            int op;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ADMINISTRAR INSCRIPCIONES DEL GYM---");
                Console.SetCursorPosition(35, 7); Console.Write("1. Registrar inscripcion");
                Console.SetCursorPosition(35, 8); Console.Write("2. Consultar inscripciones");
                Console.SetCursorPosition(35, 9); Console.Write("3. Actualizar inscripcion");
                Console.SetCursorPosition(35, 10); Console.Write("4. Eliminar inscripcion");
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
                        registrarInscripcion();
                        break;
                    case 2:
                        consultarInscripcion();
                        break;
                    case 3:
                        actualizarInscripcion();
                        break;
                    case 4:
                        eliminarInscripcion();
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
        private void registrarInscripcion()
        {
            ; char op = 'x';
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---REGISTRAR NUEVA INSCRIPCION---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el ID de la inscripcion: "); inscripciones.Id = Console.ReadLine();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el ID del cliente asociado: "); String clienteS = Console.ReadLine();
                    if (servicioCliente.ReturnCliente(clienteS) == null)
                    {
                        Console.SetCursorPosition(35, 12); Console.WriteLine("El cliente que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }


                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese el ID del supervisor asociado: "); String supervisorS = Console.ReadLine();
                    if (servicioSupervisor.ReturnSupervisor(supervisorS) == null)
                    {
                        Console.SetCursorPosition(35, 14); Console.WriteLine("El supervisor que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }


                    Console.SetCursorPosition(35, 14); Console.Write("Ingrese el ID del plan asociado: "); String planS = Console.ReadLine();
                    if (servicioPlan.ReturnPlan(planS) == null)
                    {
                        Console.SetCursorPosition(35, 16); Console.WriteLine("El plan que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }

                    inscripciones.cliente = servicioCliente.ReturnCliente(clienteS);
                    inscripciones.supervisor = servicioSupervisor.ReturnSupervisor(supervisorS);
                    inscripciones.plan = servicioPlan.ReturnPlan(planS);

                    DateTime fecha_ingreso = DateTime.Today;
                    DateTime fecha_finalizacion = fecha_ingreso.AddDays(inscripciones.plan.Dias);
                    inscripciones.Fecha_inicio = fecha_ingreso;
                    inscripciones.Fecha_finalizacion = fecha_finalizacion;
                    inscripciones.Estado = true;

                    Console.SetCursorPosition(35, 16); Console.Write("Ingrese el descuento de la inscripcion(%): "); string descuento = Console.ReadLine();
                    inscripciones.Descuento = double.Parse(descuento.Replace("%", ""));

                    var response = servicioInscripcion.Save(inscripciones);
                    Console.SetCursorPosition(35, 22); Console.WriteLine(response.Msg);

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir agregando inscripciones?[S/N]: ");
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
        private void consultarInscripcion()
        {
            Console.Clear();
            ConsoleKeyInfo keys;
            int i = 7;

            Console.SetCursorPosition(10, 3); Console.WriteLine("Pulse ESC para volver al menu // Pulse → para visualizar la información completa");
            Console.SetCursorPosition(10, 5); Console.WriteLine("---LISTA DE INSCRIPCIONES---");

            if (servicioInscripcion.GetAll() != null)
            {
                Console.SetCursorPosition(10, i); Console.WriteLine("ID".PadRight(15) + "ID CLIENTE".PadRight(15) + "ID SUPERVISOR".PadRight(15) + "ID PLAN".PadRight(10) + "FECHA FIN");
                foreach (var item in servicioInscripcion.GetAll())
                {
                    Console.SetCursorPosition(10, i + 2); Console.WriteLine(item.Id.PadRight(15) + item.cliente.Id.PadRight(15) + item.supervisor.Id.PadRight(15) + item.plan.Id.PadRight(10) + item.Fecha_finalizacion.ToString("dd/MM/yyyy"));
                    i++;
                }

            }
            else
            {
                Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado planes");
                Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier ESC para volver al menu.");
                Console.ReadKey();
            }
            do
            {
                keys = Console.ReadKey(true);
                if (keys.Key == ConsoleKey.Escape)
                {
                    return;
                }
            } while (keys.Key != ConsoleKey.Escape);
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void actualizarInscripcion()
        {
            Inscripcion inscripcionU = new Inscripcion();
            CRUD_Inscripcion servicioInscripcion = new CRUD_Inscripcion();
            char op = 'x';
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR INSCRIPCION---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el ID de la inscripcion: "); string inscripcion_S = Console.ReadLine();
                    if (servicioInscripcion.ReturnInscripcion(inscripcion_S) == null)
                    {
                        Console.SetCursorPosition(35, 12); Console.WriteLine("La inscripcion que desea ingresar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }

                    Console.Clear();
                    Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR INSCRIPCION---");
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el ID de la inscripcion: "); inscripcionU.Id = Console.ReadLine();
                    Console.SetCursorPosition(35, 10); Console.Write("Ingrese el ID del cliente asociado: "); string clienteS = Console.ReadLine();
                    if (servicioCliente.ReturnCliente(clienteS) == null)
                    {
                        Console.SetCursorPosition(35, 12); Console.WriteLine("El cliente que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }


                    Console.SetCursorPosition(35, 12); Console.Write("Ingrese el ID del supervisor asociado: "); string supervisorS = Console.ReadLine();
                    if (servicioSupervisor.ReturnSupervisor(supervisorS) == null)
                    {
                        Console.SetCursorPosition(35, 14); Console.WriteLine("El supervisor que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }


                    Console.SetCursorPosition(35, 14); Console.Write("Ingrese el ID del plan asociado: "); string planS = Console.ReadLine();
                    if (servicioPlan.ReturnPlan(planS) == null)
                    {
                        Console.SetCursorPosition(35, 16); Console.WriteLine("El plan que desea asociar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }

                    inscripcionU.cliente = servicioCliente.ReturnCliente(clienteS);
                    inscripcionU.supervisor = servicioSupervisor.ReturnSupervisor(supervisorS);
                    inscripcionU.plan = servicioPlan.ReturnPlan(planS);

                    DateTime fecha_ingreso = DateTime.Today;
                    DateTime fecha_finalizacion = fecha_ingreso.AddDays(inscripciones.plan.Dias);
                    inscripcionU.Fecha_inicio = fecha_ingreso;
                    inscripcionU.Fecha_finalizacion = fecha_finalizacion;
                    inscripcionU.Estado = true;

                    Console.SetCursorPosition(35, 16); Console.Write("Ingrese el descuento de la inscripcion(%): "); string descuento = Console.ReadLine();
                    inscripcionU.Descuento = double.Parse(descuento.Replace("%", ""));

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
        private void eliminarInscripcion()
        {
            char op = 'x';
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ELIMINAR INSCRIPCION---");
                try
                {
                    Console.SetCursorPosition(35, 9); Console.Write("Ingrese el ID de la inscripcion: "); string inscripcion_S = Console.ReadLine();
                    if (servicioInscripcion.ReturnInscripcion(inscripcion_S) == null)
                    {
                        Console.SetCursorPosition(35, 12); Console.WriteLine("La inscripcion que desea ingresar no se encuentra en la base de datos");
                        Console.ReadKey();
                        return;
                    }

                    var response = servicioInscripcion.Delete(inscripcion_S);
                    Console.SetCursorPosition(35, 9); Console.WriteLine("Se ha eliminado la inscripcion: " + response.Object.Id);

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
    }
}
