using Entidades;
using Logica;
using System;
using System.Globalization;

namespace Pureba
{
    internal class Program 
    {
        static void Main(string[] args)
        {

            
            // Iniciamos un hilo para ejecutar el método en bucle mientras se ejecuta el otro proceso de abajo
            // Permite validar en tiempo real si un contrato es vigente o esta caducado.
            //Thread hilo1 = new Thread(servicioContrato.ValidateStatus);
            //hilo1.Start();


            ///////////////////////////////////////////////////////<  DECLARACIONES  >/////////////////////////////////////////////////////////////////

            DateTime time = new DateTime();
            CRUD_Inscripcion servicioContrato = new CRUD_Inscripcion(); 
            CRUD_Supervisor servicioSupervisor = new CRUD_Supervisor();
            CRUD_Cliente servicioCliente = new CRUD_Cliente();
            CRUD_Plan servicioPlan = new CRUD_Plan();

            var plan_Semipersonalizado = new PlanGimnasio("5", "Semipersonalizado", 20000, "aaaaaa", 60);
            var plan_Dirigido = new PlanGimnasio("6", "Dirigido", 50000, "bbbbbbbb", 30);

            var Coach1 = new Supervisor("1", "Nathan", "Masculino", "3023018355", 1.55, 98, time.ToUniversalTime(), time.ToUniversalTime(),true);
            var Coach2 = new Supervisor("2", "Diego", "Otro", "3023018355", 1.55, 98, time.ToUniversalTime(), time.ToUniversalTime(), true);
            Coach1.Horarios.Add(new Turno_Atencion(DateTime.Now, DateTime.Now.AddHours(3)));
            Coach1.Horarios.Add(new Turno_Atencion(DateTime.Now, DateTime.Now.AddHours(6)));

            var cliente1 = new Cliente("3", "Melo", "Mujer", "3023018355", 1.70, 77, 23, time.ToUniversalTime(), "", time.ToUniversalTime());
            var cliente2 = new Cliente("4", "Aisaac", "Masculino", "3023018355", 1.66, 78, 23, time.ToUniversalTime(), "TDA", time.ToUniversalTime());

            //////////////////////////////////////////////////////>  FIN_DECLARACIONES  <//////////////////////////////////////////////////////////////


            //-----------------------------------------------------------------------------------------------------------------------------------------------//


            //////////////////////////////////////////////////////////<  EJECUCION  >//////////////////////////////////////////////////////////////////


                                        Console.WriteLine("//////////////////  __INICIO_PROYECTO__  //////////////////\n");


            Console.WriteLine("Presiona una tecla para continuar... \n");                                                             Console.ReadKey();

            servicioPlan.Save(plan_Semipersonalizado);
            servicioPlan.Save(plan_Dirigido);

            servicioSupervisor.Save(Coach1);
            servicioSupervisor.Save(Coach2);

            servicioCliente.Save(cliente1);
            servicioCliente.Save(cliente2);



            ConsultarPlan();                    Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();

            //CrearSupervisor();                  Console.WriteLine("\n///////////////////  FIN_CREAR  ///////////////////      \n");     Console.ReadKey();
            ConsultarSupervisor();              Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();

            //CrearCliente();                     Console.WriteLine("\n///////////////////  FIN_CREAR  ///////////////////      \n");     Console.ReadKey(); 
            ConsultarCliente();                 Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();

            //AñadirTurno();
            //EliminarTurno();
            //ConsultarSupervisor(); Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n"); Console.ReadKey();
            //CrearContrato();                    Console.WriteLine("\n///////////////////  FIN_CREAR  ///////////////////      \n");     Console.ReadKey();
            eliminarCliente();
            ConsultarContratoHistorico();       Console.WriteLine("\n/////////////  FIN_CONSTULA_HISTORICA  ////////////      \n");     Console.ReadKey();
            //RenovarContrato();                  Console.WriteLine("\n///////////////////  FIN_RENOVAR  ///////////////////    \n");     Console.ReadKey();
            ConsultarContratoVigente();         Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();
            //ConsultarContratoHistorico();       Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();
            //Consultar_ClientesDeSupervisor();   Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();


            Console.WriteLine("\n//////////////////  __FIN_PROYECTO__  //////////////////");               Console.ReadKey();


            /////////////////////////////////////////////////////////>  FIN_EJECUCION  <//////////////////////////////////////////////////////////////////


        //-------------------------------------------------------------------------------------------------------------------------------------------------//


            ///////////////////////////////////////////////////////////<  FUNCIONES  >///////////////////////////////////////////////////////////////////


            void ConsultarPlan()
            {
                if (servicioPlan.GetAll() != null)
                {
                    foreach (var item in servicioPlan.GetAll())
                    {
                        Console.WriteLine("PLAN: ");
                        Console.WriteLine("ID: " + item.id);
                        Console.WriteLine("NOMBRE: " + item.nombre);
                        Console.WriteLine("PRECIO: " + item.precio);
                        Console.WriteLine("-------------------------------------");
                    }
                }

            }

            void eliminarCliente()
            {
                string id_clienteU;
                char op = 'x';
                do
                {

                    Console.Clear();
                    Console.SetCursorPosition(43, 5); Console.Write("---ELIMINAR CLIENTE---");
                    Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del cliente que desea eliminar: "); id_clienteU = Console.ReadLine();
                    if (servicioCliente.ReturnFromList(id_clienteU) == null)
                    {
                        Console.SetCursorPosition(35, 9); Console.WriteLine("El cliente que desea actualizar, no se encuentra en la base de datos");
                        Console.ReadKey();
                    }
                    else
                    {
                        var response = servicioCliente.Delete(id_clienteU);
                        if (response.success)
                        {
                            Console.SetCursorPosition(35, 9); Console.WriteLine("Se ha eliminado el cliente: " + response.value.nombre);
                        }
                        else
                        {
                            Console.SetCursorPosition(35, 9); Console.WriteLine(response.msg);

                        }
                        Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir eliminando clientes?[S/N]: ");
                        op = char.Parse(Console.ReadLine().ToLower());
                    }

                    Console.ReadKey();
                } while (op == 's');
            }

            void CrearSupervisor()
            {
                int op;
                do
                {
                    Console.Clear();
                    var Coach = new Supervisor();
                    Console.Write("Digite la id del coach: "); Coach.id = Console.ReadLine();
                    Console.Write("Digite el Nombre del coach: "); Coach.nombre = Console.ReadLine();
                    Console.Write("Digite el Genero del coach: "); Coach.genero = Console.ReadLine();
                    Console.Write("Digite la altura del coach: "); Coach.altura = double.Parse(Console.ReadLine());
                    Console.Write("Digite el peso del coach: "); Coach.peso = double.Parse(Console.ReadLine());
                    Coach.fecha_ingreso = time.ToUniversalTime(); Coach.fecha_nacimiento = time.ToUniversalTime();

                    var msg = servicioSupervisor.Save(Coach);
                   
                            Console.WriteLine(msg.msg);
          
                    Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                } while (op == 1);
            }

            void ConsultarSupervisor()
            {
                if (servicioSupervisor.GetAll() != null)
                {
                    foreach (var item in servicioSupervisor.GetAll())
                    {
                        Console.WriteLine("SUPERVISOR: ");
                        Console.WriteLine("ID: " + item.id);
                        Console.WriteLine("NOMBRE: " + item.nombre);
                        Console.WriteLine("GENERO: " + item.genero);
                        Console.WriteLine("ALTURA: " + item.altura);
                        Console.WriteLine("HORIO DE ATENCION:");
                        foreach (var horario in item.Horarios)
                        {
                            Console.WriteLine("HORA DE ATENCION: " + horario.Hora_Inicio.ToShortTimeString() + "  >>  " + horario.Hora_Salida.ToShortTimeString());
                            Console.WriteLine("TURNO: " + horario.Jornada);

                        }
                        Console.WriteLine("-------------------------------------");
                    }
                }
                else { Console.WriteLine("vacio"); }
            }

            void CrearCliente()
            {
                int op = 0;
                do
                {
                    Console.Clear();
                    var cliente = new Cliente();
                    Console.Write("Digite la id del cliente: "); cliente.id = Console.ReadLine();
                    Console.Write("Digite el Nombre del cliente: "); cliente.nombre = Console.ReadLine();
                    Console.Write("Digite el Genero del cliente: "); cliente.genero = Console.ReadLine();
                    Console.Write("Digite el Telefono del cliente: "); cliente.telefono = Console.ReadLine();
                    Console.Write("Digite la altura del cliente: "); cliente.altura = double.Parse(Console.ReadLine());
                    Console.Write("Digite el peso del cliente: "); cliente.peso = double.Parse(Console.ReadLine());
                    cliente.discapacidad = "a";
                    cliente.fecha_ingreso = time.ToUniversalTime(); cliente.fecha_nacimiento = time.ToUniversalTime();
                    var msg = servicioCliente.Save(cliente);
                    Console.WriteLine(msg.msg);

                    Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                } while (op == 1);
            }

            void ConsultarCliente()
            {
                if (servicioCliente.GetAll() != null)
                {
                    foreach (var item in servicioCliente.GetAll())
                    {
                        Console.WriteLine("CLIENTE: ");
                        Console.WriteLine("ID: " + item.id);
                        Console.WriteLine("NOMBRE: " + item.nombre);
                        Console.WriteLine("GENERO: " + item.genero);
                        Console.WriteLine("ALTURA: " + item.altura);
                        Console.WriteLine("PESO: " + item.peso);
                        Console.WriteLine("TELEFONO: " + item.telefono);
                        Console.WriteLine("IMC: " + item.imc);
                        Console.WriteLine("-------------------------------------");
                    }
                }
                else { Console.WriteLine("vacio"); }
            }

            void CrearContrato()
            {
                int op = 0;
                try
                {
                    do
                    {
                        Console.Clear();
                        var contrato = new Inscripcion();
                        Console.Write("Digite la id del contrato: "); contrato.id = Console.ReadLine();
                        Console.Write("Digite el id del cliente: "); string id_cliente = Console.ReadLine();
                        Console.Write("Digite el id del supervisor asignado: "); string id_supervisor = Console.ReadLine();
                        Console.Write("Digite el id del plan asignado: "); string id_plan = Console.ReadLine();
                        contrato.cliente = servicioCliente.ReturnFromList(id_cliente);
                        contrato.supervisor = servicioSupervisor.ReturnFromList(id_supervisor);
                        contrato.plan = servicioPlan.ReturnFromList(id_plan);
                        Console.Write("Digite el descuento (%): ");
                        string descuento = Console.ReadLine();
                        contrato.descuento = double.Parse(descuento.Replace("%", ""));
                        contrato.fecha_inicio = DateTime.Now;
                        contrato.estado = true;
                        contrato.fecha_finalizacion = contrato.fecha_inicio.AddSeconds(20);
                        var msg = servicioContrato.Save(contrato);
                        Console.WriteLine(msg.msg);

                        Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                    } while (op == 1);
                }
                catch (Exception)
                {
                    op = 1;
                }
            }

            void ConsultarContratoHistorico()
            {
                int op = 0;
                try
                {    
                    do
                    {
                        if (servicioContrato.GetAll() != null)
                        {
                            foreach (var item in servicioContrato.GetAll())
                            {
                                Console.WriteLine("CONTRATO: ");
                                Console.WriteLine("ID: " + item.id);
                                Console.Write("FECHA INICIAL: " + item.fecha_inicio.ToShortDateString() + "  ");
                                Console.WriteLine("HORA INICIAL: " + item.fecha_inicio.ToShortTimeString());
                                Console.Write("FECHA DE FINALIZACION: " + item.fecha_finalizacion.ToShortDateString() + "  ");
                                Console.WriteLine("HORA DE FINALIZACION: " + item.fecha_finalizacion.ToShortTimeString());
                                Console.WriteLine("ID CLIENTE: " + item.cliente.id);
                                Console.WriteLine("NOMBRE CLIENTE: " + item.cliente.nombre);
                                Console.WriteLine("ID SUPERVISOR: " + item.supervisor.id);
                                Console.WriteLine("NOMBRE SUPERVISOR: " + item.supervisor.nombre);
                                Console.WriteLine("ID PLAN: " + item.plan.id);
                                Console.WriteLine("NOMBRE PLAN: " + item.plan.nombre);
                                Console.WriteLine("PRECIO: " + item.precio);
                                if (item.estado == true) { Console.WriteLine("ESTADO: VIGENTE"); }
                                else { Console.WriteLine("ESTADO: CADUCADO"); }
                                Console.WriteLine("-------------------------------------");
                            }
                            Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                        }
                        else { Console.WriteLine("vacio"); }
                    } while (op == 1);
                }
                catch (Exception)
                {
                    op = 1;
                }
            }

            void ConsultarContratoVigente()
            {
                int op = 0;
                do
                {
                    if (servicioContrato.GetListaVigentes() != null)
                    {
                        foreach (var item in servicioContrato.GetListaVigentes())
                        {
                            Console.WriteLine("CONTRATO: ");
                            Console.WriteLine("ID: " + item.id);
                            Console.Write("FECHA INICIAL: " + item.fecha_inicio.ToShortDateString() + "  ");
                            Console.WriteLine("HORA INICIAL: " + item.fecha_inicio.ToShortTimeString());
                            Console.Write("FECHA DE FINALIZACION: " + item.fecha_finalizacion.ToShortDateString() + "  ");
                            Console.WriteLine("HORA DE FINALIZACION: " + item.fecha_finalizacion.ToShortTimeString());
                            Console.WriteLine("ID CLIENTE: " + item.cliente.id);
                            Console.WriteLine("NOMBRE CLIENTE: " + item.cliente.nombre);
                            Console.WriteLine("ID SUPERVISOR: " + item.supervisor.id);
                            Console.WriteLine("NOMBRE SUPERVISOR: " + item.supervisor.nombre);
                            Console.WriteLine("ID PLAN: " + item.plan.id);
                            Console.WriteLine("NOMBRE PLAN: " + item.plan.nombre);
                            Console.WriteLine("PRECIO: " + item.precio);
                            if (item.estado == true) { Console.WriteLine("ESTADO: VIGENTE"); }
                            else { Console.WriteLine("ESTADO: CADUCADO"); }
                            Console.WriteLine("-------------------------------------");
                            }
                        Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                    }
                    else { Console.WriteLine("vacio"); }
                } while (op == 1);
            }

            void RenovarContrato()
            {
                // Renovar contrato
                int op;

                do
                {
                    Console.WriteLine("RENOVAR CONTRATO: ");
                    Console.Write("Digite la id del contrato: "); string id_contrato = Console.ReadLine();
                    string descuento;
                    double descuentopercentage = 0;
                    int dias;
                    Console.WriteLine("Por favor ingrese el id del supervisor: "); String id_supervisor = Console.ReadLine();
                    Console.WriteLine("Por favor ingrese el id del plan asignado: "); String id_plan = Console.ReadLine();
                    Console.WriteLine("desea renovar los dias del plan? sino se ejecutara de forma manual"); String question = Console.ReadLine().ToLower();
                    if (question == "si" || question == "s")
                    {
                        dias = servicioPlan.ReturnPlanDays(id_plan);
                    }
                    else
                    {
                        Console.WriteLine("digite los dias que desea agregar al contrato"); dias = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Desea aplicar algun descuento? "); String question2 = Console.ReadLine();
                    if (question2 == "si" || question2 == "s")
                    {
                        Console.WriteLine("digite el descuento "); descuento = Console.ReadLine().ToLower();
                        descuentopercentage = double.Parse(descuento.Replace("%", ""));
                    }
                    var msg = servicioContrato.Renovate(id_contrato, dias, id_supervisor, id_plan, descuentopercentage);
                    Console.WriteLine(msg.msg);
                    Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                } while (op == 1);
            }

            void Consultar_ClientesDeSupervisor()
            {
                int op = 0;
                do
                {
                    op = 0;

                    Console.WriteLine("Digite la id del Supervirsor: "); string id_supervisor = Console.ReadLine();
                    var sup = servicioSupervisor.ReturnFromList(id_supervisor);
                    if (op == 0)
                    {
                        foreach (var item in servicioContrato.ClientesPorSupuervisor(sup))
                        {
                            Console.WriteLine("SUPERVISOR ENCARGADO: " + sup.nombre);
                            Console.WriteLine("CLIENTE: ");
                            Console.WriteLine("ID: " + item.id);
                            Console.WriteLine("NOMBRE: " + item.nombre);
                            Console.WriteLine("GENERO: " + item.genero);
                            Console.WriteLine("ALTURA: " + item.altura);
                            Console.WriteLine("TELEFONO: " + item.telefono);
                            Console.WriteLine("IMC: " + item.imc);
                            Console.WriteLine("-------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vacio");
                    }
                    Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                } while (op == 1);
            }

            void AñadirTurno()
            {
                Console.Clear();
                string id_sup;
                Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del sup que desea agregar turno: "); id_sup = Console.ReadLine();
                if (servicioSupervisor.ReturnFromList(id_sup) == null)
                {
                    Console.SetCursorPosition(35, 9); Console.WriteLine("El sup que desea actualizar, no se encuentra en la base de datos");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ingresa la hora inicial: "); DateTime horaInicial = DateTime.ParseExact(Console.ReadLine(), "H:mm", CultureInfo.InvariantCulture);
                    Console.WriteLine("Ingresa la hora de salida: "); DateTime horasalida = DateTime.ParseExact(Console.ReadLine(), "H:mm", CultureInfo.InvariantCulture);

                    servicioSupervisor.SaveTurno(id_sup, horaInicial, horasalida);
                }
                
            }

            void EliminarTurno()
            {
                Console.Clear();
                string id_sup;
                Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del sup que desea eliminar turno: "); id_sup = Console.ReadLine();
                if (servicioSupervisor.ReturnFromList(id_sup) == null)
                {
                    Console.SetCursorPosition(35, 9); Console.WriteLine("El sup que desea actualizar, no se encuentra en la base de datos");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ingresa la hora inicial o de salida del supervisor: "); DateTime horaInicial = DateTime.ParseExact(Console.ReadLine(), "H:mm", CultureInfo.InvariantCulture);
                    servicioSupervisor.DeleteTurno(id_sup, horaInicial);
                }
            }


            ///////////////////////////////////////////////////////////> FIN_FUNCIONES </////////////////////////////////////////////////////////////////
        }
    }
}
