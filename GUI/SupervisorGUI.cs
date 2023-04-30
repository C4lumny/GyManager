using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class SupervisorGUI // En esta clase se modela la interfaz grafica relacionada a los coaches por medio de metodos de la clase ServicioCoaches. 
    {
        CRUD_Supervisor servicioSupervisor = new CRUD_Supervisor();
        //----------------------------------------------------------------------------------------------------------------------------------
        public void menu()
        {
            int op;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(43, 5); Console.Write("---ADMINISTRAR SUPERVISORES DEL GYM---");
                Console.SetCursorPosition(35, 7); Console.Write("1. Registrar supervisor");
                Console.SetCursorPosition(35, 8); Console.Write("2. Consultar supervisores");
                Console.SetCursorPosition(35, 9); Console.Write("3. Actualizar supervisor");
                Console.SetCursorPosition(35, 10); Console.Write("4. Eliminar supervisor");
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
                        registrarSupervisor();
                        break;
                    case 2:
                        consultarSupervisor();
                        break;
                    case 3:
                        actualizarSupervisor();
                        break;
                    case 4:
                        eliminarSupervisor();
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
        void registrarSupervisor()
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

                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir agregando clientes?[S/N]: ");
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
        void consultarSupervisor()
        {
            Console.Clear();
            int i = 7;
            Console.SetCursorPosition(10, 5); Console.WriteLine("---LISTA DE SUPERVISORES---");
            if (servicioSupervisor.GetAll() != null)
            {
                Console.SetCursorPosition(10, i); Console.WriteLine("ID".PadRight(15) + "NOMBRE".PadRight(15) + "SEXO".PadRight(6) + "ALTURA".PadRight(10) + "TELEFONO".PadRight(15));
                foreach (var item in servicioSupervisor.GetAll())
                {
                    Console.SetCursorPosition(10, i + 2); Console.WriteLine(item.Id.ToString().PadRight(15) + item.Nombre.PadRight(15) + item.Genero.PadRight(6) + item.Altura.ToString().PadRight(10) + item.Telefono.PadRight(15));
                    i++;
                }
            }
            else
            {
                Console.SetCursorPosition(10, 7); Console.WriteLine("No se han registrado supervisores");
                Console.SetCursorPosition(10, 8); Console.WriteLine("Pulse cualquier tecla para volver al menu.");
            }
            Console.ReadKey();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        void actualizarSupervisor()
        {
            string id_supervisorU;
            char op = 'x';
            do
            {
                Console.Clear();
                Supervisor supervisores = new Supervisor();
                CRUD_Supervisor servicioSupervisor = new CRUD_Supervisor();
                try
                {
                    Console.SetCursorPosition(43, 5); Console.Write("---ACTUALIZAR SUPERVISOR---");
                    Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del supervisor que desea actualizar: "); id_supervisorU = Console.ReadLine();
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
        void eliminarSupervisor()
        {
            string id_supervisorD;
            char op = 'x';
            do
            {

                Console.Clear();
                Console.SetCursorPosition(43, 5); Console.Write("---ELIMINAR SUPERVISOR---");
                Console.SetCursorPosition(35, 7); Console.Write("Ingrese el ID del supervisor que desea eliminar: "); id_supervisorD = Console.ReadLine();
                if (servicioSupervisor.ReturnSupervisor(id_supervisorD) == null)
                {
                    Console.SetCursorPosition(35, 9); Console.WriteLine("El supervisor que desea actualizar, no se encuentra en la base de datos");
                    Console.ReadKey();
                }
                else
                {
                    var response = servicioSupervisor.Delete(id_supervisorD);
                    Console.SetCursorPosition(35, 9); Console.WriteLine("Se ha eliminado el supervisor: " + response.Object.Nombre);
                    Console.SetCursorPosition(35, 24); Console.Write("¿Desea seguir eliminando supervisores?[S/N]: ");
                    op = char.Parse(Console.ReadLine().ToLower());
                }
            } while (op == 's');
        }
    }
}
