using Entidades;
using Logica;
using System;

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

            //Hola amigos de youtube pipipipipipi

            ///////////////////////////////////////////////////////<  DECLARACIONES  >/////////////////////////////////////////////////////////////////


            DateTime time = new DateTime();
            ServicioContrato servicioContrato = new ServicioContrato(); 
            ServicioSupervisor servicioSupervisor = new ServicioSupervisor();
            ServicioCliente servicioCliente = new ServicioCliente();
            ServicioPlan servicioPlan = new ServicioPlan();

            var plan_Semipersonalizado = new PlanGimnasio("5", "Semipersonalizado", 20000, "aaaaaa", 60);
            var plan_Dirigido = new PlanGimnasio("6", "Dirigido", 50000, "bbbbbbbb", 30);

            var Coach1 = new Supervisor("1", "Nathan", "Masculino", "3023018355", 1.55, 98, time.ToUniversalTime(), time.ToUniversalTime(), true);
            var Coach2 = new Supervisor("2", "Diego", "Otro", "3023018355", 1.55, 98, time.ToUniversalTime(), time.ToUniversalTime(), true);

            var cliente1 = new Cliente("3", "Melo", "Mujer", "3023018355", 1.70, 77, time.ToUniversalTime(), "sida xd", time.ToUniversalTime(), false);
            cliente1.imc = servicioCliente.CalculateIMC(77, 1.7);
            var cliente2 = new Cliente("4", "Aisaac", "Masculino", "3023018355", 1.66, 78, time.ToUniversalTime(), "TDA", time.ToUniversalTime(), false);
            cliente2.imc = servicioCliente.CalculateIMC(78, 1.66);


            //////////////////////////////////////////////////////>  FIN_DECLARACIONES  <//////////////////////////////////////////////////////////////


            //-----------------------------------------------------------------------------------------------------------------------------------------------//


            //////////////////////////////////////////////////////////<  EJECUCION  >//////////////////////////////////////////////////////////////////


                                        Console.WriteLine("//////////////////  __INICIO_PROYECTO__  //////////////////\n");


            Console.WriteLine("Presiona una tecla para continuar... \n");                                                             Console.ReadKey();

            //servicioPlan.Save(plan_Semipersonalizado);
            //servicioPlan.Save(plan_Dirigido);

            //servicioSupervisor.Save(Coach1);
            //servicioSupervisor.Save(Coach2);

            //servicioCliente.Save(cliente1);
            //servicioCliente.Save(cliente2);



            ConsultarPlan();                    Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();

            //CrearSupervisor();                  Console.WriteLine("\n///////////////////  FIN_CREAR  ///////////////////      \n");     Console.ReadKey();
            ConsultarSupervisor();              Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();

            //CrearCliente();                     Console.WriteLine("\n///////////////////  FIN_CREAR  ///////////////////      \n");     Console.ReadKey(); 
            ConsultarCliente();                 Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();

            //CrearContrato();                    Console.WriteLine("\n///////////////////  FIN_CREAR  ///////////////////      \n");     Console.ReadKey();
            ConsultarContratoHistorico();       Console.WriteLine("\n/////////////  FIN_CONSTULA_HISTORICA  ////////////      \n");     Console.ReadKey();
            /*RenovarContrato();                  Console.WriteLine("\n///////////////////  FIN_RENOVAR  ///////////////////    \n");     Console.ReadKey();
            ConsultarContratoVigente();         Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();
            ConsultarContratoHistorico();       Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();
            Consultar_ClientesDeSupervisor();   Console.WriteLine("\n///////////////////  FIN_CONSULTA  ///////////////////   \n");     Console.ReadKey();*/


            Console.WriteLine("\n//////////////////  __FIN_PROYECTO__  //////////////////");               Console.ReadKey();


            /////////////////////////////////////////////////////////>  FIN_EJECUCION  <//////////////////////////////////////////////////////////////////


        //-------------------------------------------------------------------------------------------------------------------------------------------------//


            ///////////////////////////////////////////////////////////<  FUNCIONES  >///////////////////////////////////////////////////////////////////


            void ConsultarPlan()
            {
                if (servicioPlan.GetLista() != null)
                {
                    foreach (var item in servicioPlan.GetLista())
                    {
                        Console.WriteLine("PLAN: ");
                        Console.WriteLine("ID: " + item.id);
                        Console.WriteLine("NOMBRE: " + item.nombre);
                        Console.WriteLine("PRECIO: " + item.precio);
                        Console.WriteLine("-------------------------------------");
                    }
                }

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
                    switch (msg)
                    {
                        case 0:
                            Console.WriteLine("Se ha guardado correctamente. ");
                            break;
                        case 1:
                            Console.WriteLine("ingrese una altura valida ");
                            break;
                        case 2:
                            Console.WriteLine("ingrese un peso valido. ");
                            break;
                        case 3:
                            Console.WriteLine("fecha de nacimiento invalida");
                            break;
                        case 4:
                            Console.WriteLine("ID repetido ");
                            break;
                        default:
                            Console.WriteLine("ERROR.Excepcion");
                            break;
                    }
                    Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                } while (op == 1);
            }

            void ConsultarSupervisor()
            {
                if (servicioSupervisor.GetLista() != null)
                {
                    foreach (var item in servicioSupervisor.GetLista())
                    {
                        Console.WriteLine("SUPERVISOR: ");
                        Console.WriteLine("ID: " + item.id);
                        Console.WriteLine("NOMBRE: " + item.nombre);
                        Console.WriteLine("GENERO: " + item.genero);
                        Console.WriteLine("ALTURA: " + item.altura);
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
                    cliente.imc = servicioCliente.CalculateIMC(cliente.peso, cliente.altura);
                    cliente.estado = false;
                    cliente.discapacidad = "a";
                    cliente.fecha_ingreso = time.ToUniversalTime(); cliente.fecha_nacimiento = time.ToUniversalTime();
                    var msg = servicioCliente.Save(cliente);
                    switch (msg)
                    {
                        case 0:
                            Console.WriteLine("Se ha guardado correctamente. ");
                            break;
                        case 1:
                            Console.WriteLine("ingrese una altura valida ");
                            break;
                        case 2:
                            Console.WriteLine("ingrese un peso valido. ");
                            break;
                        case 3:
                            Console.WriteLine("fecha de nacimiento invalida");
                            break;
                        case 4:
                            Console.WriteLine("ID repetido ");
                            break;
                        default:
                            Console.WriteLine("ERROR.Excepcion");
                            break;
                    }
                    Console.WriteLine("Desea continuar?"); op = int.Parse(Console.ReadLine());
                } while (op == 1);
            }

            void ConsultarCliente()
            {
                if (servicioCliente.GetLista() != null)
                {
                    foreach (var item in servicioCliente.GetLista())
                    {
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
                        var contrato = new Contrato();
                        Console.Write("Digite la id del contrato: "); contrato.Id = Console.ReadLine();
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
                        switch (msg)
                        {
                            case 0:
                                Console.WriteLine("Se ha guardado correctamente. ");
                                break;
                            case 1:
                                Console.WriteLine("No se ha encontrado al cliente. ");
                                break;
                            case 2:
                                Console.WriteLine("No se ha encontrado al supervisor. ");
                                break;
                            case 3:
                                Console.WriteLine("No se ha encontrado el plan.");
                                break;
                            case 4:
                                Console.WriteLine("descuento fuera de rango. ");
                                break;
                            case 5:
                                Console.WriteLine("Cliente menor de 18 años. ");
                                break;
                            case 6:
                                Console.WriteLine("Cliente ya contratado. ");
                                break;
                            case 7:
                                Console.WriteLine("ID repetida ");
                                break;
                            default:
                                Console.WriteLine("ERROR.Excepcion");
                                break;
                        }
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
                        if (servicioContrato.GetLista() != null)
                        {
                            foreach (var item in servicioContrato.GetLista())
                            {
                                servicioContrato.ValidateStatus();
                                Console.WriteLine("CONTRATO: ");
                                Console.WriteLine("ID: " + item.Id);
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
                            Console.WriteLine("ID: " + item.Id);
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
                    servicioContrato.ValidateStatus();
                    int msg = servicioContrato.Renovate(id_contrato, dias, id_supervisor, id_plan, descuentopercentage);
                    switch (msg)
                    {
                        case 0:
                            Console.WriteLine("Se renovo el contrato");
                            break;
                        case 1:
                            Console.WriteLine("No hay contratos en la lista.");
                            break;
                        case 2:
                            Console.WriteLine("No se encontro el contrato");
                            break;
                        case 3:
                            Console.WriteLine("No se encontro el coach");
                            break;
                        case 4:
                            Console.WriteLine("No se encontro el plan");
                            break;
                        case 5:
                            Console.WriteLine("el descuento se encuentra en un rango incorrecto");
                            break;
                        case 6:
                            Console.WriteLine("Este contrato todavia esta vigente");
                            break;
                        default:
                            Console.WriteLine("ERROR NO ESPECIFICADO");
                            break;
                    }
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
                    if (sup.ListaCliente_Supervisor.Count != 0)
                    {
                        foreach (var item in sup.ListaCliente_Supervisor)
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


            ///////////////////////////////////////////////////////////> FIN_FUNCIONES </////////////////////////////////////////////////////////////////

        }
    }
}
