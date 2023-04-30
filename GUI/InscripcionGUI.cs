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
            char op = 'x';
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
                    

                    Console.SetCursorPosition(35, 14); Console.Write("Ingrese el ID del supervisor asociado: "); String planS = Console.ReadLine();
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
        private void consultarInscripcion()
        {
            Console.Clear();
            int i = 7;
            Console.SetCursorPosition(10, 5); Console.WriteLine("---LISTA DE INSCRIPCIONES---");
            if (servicioInscripcion.GetAll() != null)
            {
                Console.SetCursorPosition(10, i); Console.WriteLine("ID".PadRight(15) + "NOMBRE CLIENTE".PadRight(20) + "NOMBRE SUPERVISOR".PadRight(20) + "PLAN ASIGNADO".PadRight(20));
                foreach (var item in servicioInscripcion.GetAll())
                {
                    Console.SetCursorPosition(10, i + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.cliente.Nombre.PadRight(20) + item.supervisor.Nombre.PadRight(20) + item.plan.Nombre.PadRight(5));
                    i++;
                }
            }
            else
            {
                Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado planes");
                Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void actualizarInscripcion()
        {

        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void eliminarInscripcion()
        {

        }
    }
}
