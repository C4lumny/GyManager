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
    public partial class ConsultarPago : Form
    {
        ServicioPago serv;
        public ConsultarPago()
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
            dgvPago.Rows.Clear();
            var lista = serv.GetAll();
            if (lista != null)
            {
                foreach (Pago pago in lista)
                {
                    dgvPago.Rows.Add(pago.ValorIngresado, pago.FechaPago, pago.Inscripcion.Id);
                }
            }

        }
    }
}
