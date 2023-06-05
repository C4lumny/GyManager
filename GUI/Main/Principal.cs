using GUI.Imprimir;
using GUI.pruba;
using Logica.Clases;
using System.Windows.Forms;


namespace GUI.Main
{
    internal class Principal
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServicioFacturas servicio = new ServicioFacturas(); 
            Impresion login = new Impresion(servicio.GetObjectById("23"));
            Application.Run(login);
        }
    }
}
