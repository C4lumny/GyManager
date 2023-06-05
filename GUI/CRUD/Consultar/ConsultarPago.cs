using Entidades;
using Entidades.Pagos_y_Facturas;
using Logica.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    dgvPago.Rows.Add(pago.Id, pago.ValorIngresado, pago.FechaPago, pago.Inscripcion.Id);
                }
            }

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string buscado = txtBusqueda.Text;
            dgvPago.Rows.Clear();
            if (buscado.All(char.IsDigit))
            {
                List<Pago> pagoBuscado = serv.GetListBySearch(buscado);

                foreach (Pago pago in pagoBuscado)
                {
                    dgvPago.Rows.Add(pago.Id, pago.ValorIngresado, pago.FechaPago, pago.Inscripcion.Id);
                }
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
