using Entidades;
using Entidades.Pagos_y_Facturas;
using Logica.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.Imprimir
{
    public partial class Impresion : Form
    {
        Facturas factura;
        ServicioFacturas servicioFacturas = new ServicioFacturas();
        public Impresion(Facturas factura)
        {
            this.factura = factura;
            if (factura.Saldo < 0)
            {
                factura.Saldo = 0;
            }
            InitializeComponent();
            InstalledPrintersCombo();
            comboBox1.SelectedIndex = 0;
        }
        public Impresion()
        {
            InitializeComponent();
            InstalledPrintersCombo();
            comboBox1.SelectedIndex = 0;
        }
        private void InstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboBox1.Items.Add(pkInstalledPrinters);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea imprimir esta factura?", "Impresion!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var validacion = servicioFacturas.validar_factura(factura);
                if (!validacion.Success)
                {
                    MessageBox.Show(validacion.Msg);
                    return;
                }
                HerramientasTickets.CreaTicket Ticket1 = new HerramientasTickets.CreaTicket();

                Ticket1.TextoCentro("Empresa xxxxxxxxx "); //imprime una linea de descripcion
                Ticket1.TextoCentro("*************************************");

                Ticket1.TextoIzquierda("Dirc: xxxx");
                Ticket1.TextoIzquierda("Tel:xxxx ");


                Ticket1.TextoIzquierda("");
                Ticket1.TextoCentro("Factura de Inscripcion"); 
                Ticket1.TextoIzquierda("No Factura:" + factura.Id.ToString());
                Ticket1.TextoIzquierda("No Inscripcion:" + factura.Inscripcion.Id.ToString());
                
                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("*****************************************");

                Ticket1.TextoIzquierda("> Cliente CC/TI: " + factura.Inscripcion.Cliente.Id);
                Ticket1.TextoIzquierda("> Cliente Nombres: " + factura.Inscripcion.Cliente.Nombre);
                Ticket1.TextoIzquierda("> Cliente Apellidos: " + factura.Inscripcion.Cliente.Apellido);
                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoIzquierda("> Plan contratado: " + factura.Inscripcion.Plan.Nombre);
                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoIzquierda("> Fecha:" + DateTime.Now.ToShortDateString());
                Ticket1.TextoIzquierda("> Hora:" + DateTime.Now.ToShortTimeString());
                Ticket1.TextoIzquierda(" ");

                HerramientasTickets.CreaTicket.LineasGuion();

                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("> Valor de inscripcion", double.Parse(factura.Inscripcion.Plan.Precio.ToString()));
                Ticket1.TextoIzquierda("> Descuento                         " + factura.Inscripcion.Descuento.ToString() + "%");
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("> Valor a pagar", double.Parse(factura.Inscripcion.Precio.ToString()));

                HerramientasTickets.CreaTicket.LineasGuion();

                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("> Pago realizado", double.Parse(factura.PagoIngresado.ToString()));
                Ticket1.AgregaTotales("> Sub-Total", double.Parse(factura.Subtotal.ToString()));
                Ticket1.AgregaTotales("> Saldo Pendiente", double.Parse(factura.Saldo.ToString()));


                // Ticket1.LineasTotales(); // imprime linea 

                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("*****************************************");
                Ticket1.TextoCentro(" *      ¡Gracias por preferirnos!    *");
                Ticket1.TextoIzquierda("  *    GyManager Soft. Company  *   ");
                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("*****************************************");

                Ticket1.ImprimirTiket(comboBox1.Text); //Imprimir

                MessageBox.Show("Gracias por preferirnos");
            }     
        }

        private void Impresion_Load(object sender, EventArgs e)
        {
        }
    }
}
