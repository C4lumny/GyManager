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
                    dgvPlanGimnasio.Rows.Add(plan.Nombre, plan.Precio, plan.Dias);
                }
            }

        }

        private void ConsultarPlanGimnasioBD_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
