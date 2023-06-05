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

namespace GUI.CRUD.Insertar
{
    public partial class InsertarPago : Form
    {
        private int inscripcionId;
        ServicioInscripcion servicioInscripcion = new ServicioInscripcion();

        public InsertarPago(int Id)
        {
            InitializeComponent();
            inscripcionId = Id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Pago pago = new Pago();
            ServicioPago servPago = new ServicioPago();
            ServicioInscripcion servicioInscripcion = new ServicioInscripcion();
            pago.ValorIngresado = int.Parse(txtValorIngresado.Text);
            pago.Inscripcion = servicioInscripcion.GetObjectById(inscripcionId.ToString());

            MessageBox.Show(servPago.Crear(pago).Msg);
            this.Close();
        }

        private void txtValorIngresado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
    