using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Imprimir
{
    public class HerramientasTickets
    {
        public static System.Drawing.Font printFont;
        public static StreamReader streamToPrint;

        public class CreaTicket
        {
            public static StringBuilder line = new StringBuilder();
            string ticket = "";
            string parte1, parte2;

            public static int max = 40;
            int cort;
            private string[] cadenaserver;

            public byte[] Serverbyte { get; private set; }

            public static string LineasGuion()
            {
                string LineaGuion = "----------------------------------------";  

                return line.AppendLine(LineaGuion).ToString();
            }

            public void TextoIzquierda(string par1)                         
            {
                max = par1.Length;
                if (max > 40)                                 
                {
                    cort = max - 40;
                    parte1 = par1.Remove(40, cort);       
                }
                else { parte1 = par1; }                     

            }
            public void TextoDerecha(string par1)
            {
                ticket = "";
                max = par1.Length;
                if (max > 40)                                 
                {
                    cort = max - 40;
                    parte1 = par1.Remove(40, cort);           
                }
                else { parte1 = par1; }                      
                max = 40 - par1.Length;                     
                for (int i = 0; i < max; i++)
                {
                    ticket += " ";                          
                }
                line.AppendLine(ticket += parte1 + "\n");                

            }
            public void TextoCentro(string par1)
            {
                ticket = "";
                max = par1.Length;
                if (max > 40)                                
                {
                    cort = max - 40;
                    parte1 = par1.Remove(40, cort);         
                }
                else { parte1 = par1; }                      
                max = (int)(40 - parte1.Length) / 2;         
                for (int i = 0; i < max; i++)                
                {
                    ticket += " ";                           
                }                                            
                line.AppendLine(ticket += parte1 + "\n");

            }
            public void TextoExtremos(string par1, string par2)
            {
                max = par1.Length;
                if (max > 18)                                 
                {
                    cort = max - 18;
                    parte1 = par1.Remove(18, cort);          
                }
                else { parte1 = par1; }                     
                ticket = parte1;                            
                max = par2.Length;
                if (max > 18)                                 
                {
                    cort = max - 18;
                    parte2 = par2.Remove(18, cort);         
                }
                else { parte2 = par2; }
                max = 40 - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)                
                {
                    ticket += " ";                           
                }                                            
                line.AppendLine(ticket += parte2 + "\n");                  

            }
            public void AgregaTotales(string par1, double total)
            {
                max = par1.Length;
                if (max > 25)                                
                {
                    cort = max - 25;
                    parte1 = par1.Remove(25, cort);          
                }
                else { parte1 = par1; }                     
                ticket = parte1;
                parte2 = total.ToString() + "$";
                max = 40 - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)               
                {
                    ticket += " ";                          
                }                                           
                line.AppendLine(ticket += parte2 + "\n");

            }

            public void AgregaArticulo(string Articulo, double precio, int cant, double subtotal)
            {
                if (cant.ToString().Length <= 3 && precio.ToString("c").Length <= 10 && subtotal.ToString("c").Length <= 11) 
                {
                    string elementos = "", espacios = "";
                    bool bandera = false;
                    int nroEspacios = 0;

                    if (Articulo.Length > 40)                                
                    {
       
                        nroEspacios = (3 - cant.ToString().Length);
                        espacios = "";
                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }
                        elementos += espacios + cant.ToString();

                        nroEspacios = (10 - precio.ToString().Length);
                        espacios = "";

                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }
                        elementos += espacios + precio.ToString();

                        nroEspacios = (11 - subtotal.ToString().Length);
                        espacios = "";

                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }
                        elementos += espacios + subtotal.ToString();

                        int CaracterActual = 0;
                        for (int Longtext = Articulo.Length; Longtext > 16; Longtext++)
                        {
                            if (bandera == false)
                            {
                                line.AppendLine(Articulo.Substring(CaracterActual, 16) + elementos);
                                bandera = true;
                            }
                            else
                            {
                                line.AppendLine(Articulo.Substring(CaracterActual, 16));

                            }
                            CaracterActual += 16;
                        }
                        line.AppendLine(Articulo.Substring(CaracterActual, Articulo.Length - CaracterActual));


                    }
                    else
                    {
                        for (int i = 0; i < (16 - Articulo.Length); i++)
                        {
                            espacios += " ";

                        }
                        elementos = Articulo + espacios;
                        nroEspacios = (3 - cant.ToString().Length);
                        espacios = "";
                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }
                        elementos += espacios + cant.ToString();

                        nroEspacios = (10 - precio.ToString().Length);
                        espacios = "";

                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }
                        elementos += espacios + precio.ToString();

                        nroEspacios = (11 - subtotal.ToString().Length);
                        espacios = "";

                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }
                        elementos += espacios + subtotal.ToString();
                        line.AppendLine(elementos);

                    }
                }
                else
                {

                }
            }

            public void ImprimirTiket(string Impresora)
            {
                File.WriteAllText("Factura.txt", line.ToString());


                line = new StringBuilder();

                try
                {
                    streamToPrint = new StreamReader
                       ("Factura.txt");
                    try
                    {
                        printFont = new System.Drawing.Font("Arial", 10);
                        PrintDocument pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler
                           (this.pd_PrintPage);
                       
                        pd.PrinterSettings.PrinterName = Impresora;

                        pd.DocumentName = "Factura" + DateTime.Now.ToString();

                        pd.Print();
                    }
                    finally
                    {
                        streamToPrint.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Elija impresora valida");
                }


            }
            public void pd_PrintPage(object sender, PrintPageEventArgs ev)
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                string line = null;



                linesPerPage = ev.MarginBounds.Height /
                   printFont.GetHeight(ev.Graphics);

                while (count < linesPerPage &&
                   ((line = streamToPrint.ReadLine()) != null))
                {
                    yPos = topMargin + (count *
                       printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black,
                       leftMargin, yPos, new StringFormat());
                    count++;

                }

                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            }


        }
    }
}
