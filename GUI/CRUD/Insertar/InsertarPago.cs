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

namespace GUI.CRUD.Insertar
{
    public partial class InsertarPago : Form
    {
        public InsertarPago()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            Pago pago = new Pago();
            ServicioPago servPago = new ServicioPago();

            pago.ValorIngresado = int.Parse(txtValorIngresado.Text);
            pago.IdInscripcion = int.Parse(txtIDInscripcion.Text);


            MessageBox.Show(servPago.Crear(pago));
        }
    }
}
