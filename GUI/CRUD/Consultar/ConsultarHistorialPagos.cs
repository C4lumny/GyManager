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
    public partial class ConsultarHistorialPagos : Form
    {
        ServicioPago serv;
        public ConsultarHistorialPagos()
        {
            InitializeComponent();
            serv = new ServicioPago();
        }
        void CargarGrilla()
        {
            dgvHistorialPagos.Rows.Clear();
            var lista = serv.GetHistorial();
            if (lista != null)
            {
                foreach (Pago pago in lista)
                {
                    dgvHistorialPagos.Rows.Add(pago.Id, pago.ValorIngresado, pago.FechaPago, pago.Inscripcion.Id);
                }
            }

        }

        private void ConsultarHistorialPagos_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dgvHistorialPagos.ClearSelection();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string buscado = txtBusqueda.Text;
            dgvHistorialPagos.Rows.Clear();
            if (buscado.All(char.IsDigit))
            {
                List<Pago> pagoBuscado = serv.GetListBySearchPG(buscado);

                foreach (Pago pago in pagoBuscado)
                {
                    dgvHistorialPagos.Rows.Add(pago.Id, pago.ValorIngresado, pago.FechaPago, pago.Inscripcion.Id);
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
