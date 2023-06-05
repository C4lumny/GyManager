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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.CRUD.Insertar
{
    public partial class InsertarInscripcion : Form
    {
        ServicioInscripcion servicioInscripcion = new ServicioInscripcion();
        ServicioClientes servicioCliente = new ServicioClientes();
        ServicioPlanGimnasio servicioPlan = new ServicioPlanGimnasio();
        ServicioSupervisores servicioSupervisor = new ServicioSupervisores();
        public InsertarInscripcion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            

            Inscripcion inscripcion = new Inscripcion();

            inscripcion.Cliente = servicioCliente.GetObjectById(cmbClientes.Text);
            inscripcion.Supervisor = servicioSupervisor.GetObjectById(cmbSupervisores.Text);
            inscripcion.Plan = servicioPlan.GetObjectById(cmbPlanes.Text);
            inscripcion.Descuento = int.Parse(txtDescuento.Text);

            MessageBox.Show(servicioInscripcion.Crear(inscripcion).Msg);
        }

        private void InsertarInscripcion_Load(object sender, EventArgs e)
        {
            List<Clientess> ListCliente = servicioCliente.GetAll();
            List<Supervisoress> ListSupervisor = servicioSupervisor.GetAll();
            List<PlanGimnasio> ListPlan = servicioPlan.GetAll();

            foreach (Clientess cliente in ListCliente)
            {
                cmbClientes.Items.Add(cliente.Id);
            }

            foreach (Supervisoress supervisor in ListSupervisor)
            {
                cmbSupervisores.Items.Add(supervisor.Id);
            }

            foreach (PlanGimnasio plan in ListPlan)
            {
                cmbPlanes.Items.Add(plan.Nombre);
            }

            if (cmbClientes.Items.Count > 0)
            {
                cmbClientes.SelectedIndex = 0;
            }

            if (cmbSupervisores.Items.Count > 0)
            {
                cmbSupervisores.SelectedIndex = 0;
            }

            if (cmbPlanes.Items.Count > 0)
            {
                cmbPlanes.SelectedIndex = 0;
            }
        }

        private void cmbSupervisores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
