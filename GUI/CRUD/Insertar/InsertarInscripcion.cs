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
    public partial class InsertarInscripcion : Form
    {
        public InsertarInscripcion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ServicioInscripcion servInscripcion = new ServicioInscripcion();
            Inscripcion inscripcion = new Inscripcion();

            inscripcion.ClienteId = txtIDCliente.Text;
            inscripcion.SupervisorId = txtIDSupervisor.Text;
            inscripcion.PlanId = int.Parse(txtIDPlan.Text);
            inscripcion.Descuento = int.Parse(txtDescuento.Text);

            MessageBox.Show(servInscripcion.Crear(inscripcion));
        }
    }
}
