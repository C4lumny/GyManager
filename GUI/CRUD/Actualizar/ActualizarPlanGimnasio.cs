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
    public partial class ActualizarPlanGimnasio : Form
    {
        private string planId;
        public ActualizarPlanGimnasio(string id)
        {
            InitializeComponent();
            planId = id;

            cargarTextBoxes(planId);
        }

        private void cargarTextBoxes(string id)
        {
            ServicioPlanGimnasio serv = new ServicioPlanGimnasio();
            PlanGimnasio plan = serv.GetObjectById(id);

            txtNombre.Text = plan.Nombre;
            txtPrecio.Text = plan.Precio.ToString();
            txtDias.Text = plan.Dias.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ServicioPlanGimnasio serv = new ServicioPlanGimnasio();
            PlanGimnasio plan = serv.GetObjectById(planId);
            try
            {
                PlanGimnasio planAct = new PlanGimnasio();
                planAct.Nombre = txtNombre.Text;
                planAct.Precio = double.Parse(txtPrecio.Text);
                planAct.Dias = (int.Parse(txtDias.Text));
                planAct.Descripcion = plan.Descripcion;


                serv.Actualizar(planAct, planId);

                MessageBox.Show("Plan actualizado correctamente", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el plan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
