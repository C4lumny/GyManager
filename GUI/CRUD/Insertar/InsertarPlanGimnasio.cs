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

namespace GUI.CRUD.Insertar
{
    public partial class InsertarPlanGimnasio : Form
    {
        public InsertarPlanGimnasio()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PlanGimnasio plan = new PlanGimnasio();
            ServicioPlanGimnasio servPlan = new ServicioPlanGimnasio();

            plan.Nombre = txtNombrePlan.Text;
            plan.Precio = double.Parse(txtPrecio.Text);
            plan.Dias = int.Parse(txtDias.Text);
            plan.Descripcion = txtDescripcion.Text;

            servPlan.Crear(plan);
        }
    }
}
