using Entidades;
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

namespace GUI.CRUD.Actualizar
{
    public partial class ActualizarInscripcion : Form
    {
        private string inscripcionId;
        ServicioInscripcion servicioInscripcion = new ServicioInscripcion();
        ServicioClientes servicioCliente = new ServicioClientes();
        ServicioPlanGimnasio servicioPlan = new ServicioPlanGimnasio();
        ServicioSupervisores servicioSupervisor = new ServicioSupervisores();

        public ActualizarInscripcion(string id, string titulo)
        {
            InitializeComponent();
            lblActualizarInscripcion.Text = titulo;
            inscripcionId = id;
        }

        private void ActualizarInscripcion_Load(object sender, EventArgs e)
        {
            List<Supervisoress> ListSupervisor = servicioSupervisor.GetAll();
            List<PlanGimnasio> ListPlan = servicioPlan.GetAll();

            foreach (Supervisoress supervisor in ListSupervisor)
            {
                cmbSupervisores.Items.Add(supervisor.Id);
            }

            foreach (PlanGimnasio plan in ListPlan)
            {
                cmbPlanes.Items.Add(plan.Nombre);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ServicioInscripcion serv = new ServicioInscripcion();
            Inscripcion inscripcion = servicioInscripcion.GetObjectById(inscripcionId);
            if(lblActualizarInscripcion.Text == "Actualizar Inscripcion")
            {
                try
                {
                    Inscripcion inscripcionAct = new Inscripcion();
                    inscripcionAct.Plan = servicioPlan.GetObjectById(cmbPlanes.Text);
                    inscripcionAct.Supervisor = servicioSupervisor.GetObjectById(cmbSupervisores.Text);
                    inscripcionAct.Descuento = int.Parse(txtDescuento.Text);
                    inscripcionAct.FechaInicio = inscripcion.FechaInicio;
                    inscripcionAct.Cliente = inscripcion.Cliente;

                    

                    MessageBox.Show(serv.Actualizar(inscripcionAct, inscripcionId).Msg, "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la inscripcion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    Inscripcion inscripcionAct = new Inscripcion();
                    inscripcionAct.Plan = servicioPlan.GetObjectById(cmbPlanes.Text);
                    inscripcionAct.Supervisor = servicioSupervisor.GetObjectById(cmbSupervisores.Text);
                    inscripcionAct.Descuento = int.Parse(txtDescuento.Text);
                    inscripcionAct.FechaInicio = DateTime.Now;
                    inscripcionAct.Cliente = inscripcion.Cliente;

                    

                    MessageBox.Show(serv.Renovar(inscripcionAct, inscripcionId).Msg, "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la inscripcion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
