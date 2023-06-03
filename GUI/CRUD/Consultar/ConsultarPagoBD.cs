using Entidades;
using Entidades.Pagos_y_Facturas;
using Logica.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Pureba
{
    public partial class ConsultarPagoBD : Form
    {
        ServicioPago serv;
        public ConsultarPagoBD()
        {
            InitializeComponent();
            serv = new ServicioPago();
        }

        private void ConsultarPagoBD_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        void CargarGrilla()
        {
            dataGridView1.Rows.Clear();
            var lista = serv.GetAll();
            if (lista != null)
            {
                foreach (Pago pago in lista)
                {
                    dataGridView1.Rows.Add(pago.ValorIngresado, pago.FechaPago, pago.Inscripcion.Id);
                }
            }

        }
    }
}
