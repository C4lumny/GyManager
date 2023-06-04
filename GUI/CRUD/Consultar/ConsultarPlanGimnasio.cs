using Entidades;
using GUI.CRUD.Actualizar;
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
    public partial class ConsultarPlanGimnasio : Form
    {
        ServicioPlanGimnasio serv;
        public ConsultarPlanGimnasio()
        {
            InitializeComponent();
            serv = new ServicioPlanGimnasio();
        }

        void CargarGrilla()
        {
            dgvPlanGimnasio.Rows.Clear();
            var lista = serv.GetAll();
            if (lista != null)
            {
                foreach (PlanGimnasio plan in lista)
                {
                    dgvPlanGimnasio.Rows.Add(plan.Id, plan.Nombre, plan.Precio, plan.Dias);
                }
            }
        }

        private void ConsultarPlanGimnasioBD_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dgvPlanGimnasio.ClearSelection();
        }

        private void dgvPlanGimnasio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica si se hace clic en una fila válida
            {
                string planId = (string)dgvPlanGimnasio.Rows[e.RowIndex].Cells["clmnId"].Value.ToString();
                btnEliminar.Visible = true;
                btnActualizar.Visible = true;

                btnEliminar.Tag = planId; // Almacena el ID del cliente en la propiedad Tag del botón
                btnActualizar.Tag = planId; //Almaceno el id en el boton actualizar
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (btnEliminar.Tag != null && btnEliminar.Tag is string planId)
            {
                ServicioPlanGimnasio serv = new ServicioPlanGimnasio();
                serv.Eliminar(planId);

                btnActualizar.Visible = false;
                btnEliminar.Visible = false;
                CargarGrilla();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (btnActualizar.Tag != null && btnActualizar.Tag is string planId)
            {
                ActualizarPlanGimnasio actPlan = new ActualizarPlanGimnasio(planId);
                actPlan.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ActualizarPlanGimnasio_FormClosed);
                actPlan.Show();

                btnActualizar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void ActualizarPlanGimnasio_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarGrilla();
        }
    }
}
