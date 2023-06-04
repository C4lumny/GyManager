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
    public partial class ConsultarInscripcion : Form
    {
        ServicioInscripcion serv;
        public ConsultarInscripcion()
        {
            InitializeComponent();
            serv = new ServicioInscripcion();
        }

        void CargarGrilla()
        {
            dgvInscripcion.Rows.Clear();
            var lista = serv.GetAll();
            if (lista != null)
            {
                string s_nombreCompleto;
                string c_nombreCompleto;
                foreach (Inscripcion inscripcion in lista)
                {
                    c_nombreCompleto = inscripcion.Cliente.Nombre + " " + inscripcion.Cliente.Apellido;
                    s_nombreCompleto = inscripcion.Supervisor.Nombre + " " + inscripcion.Supervisor.Apellido;

                    dgvInscripcion.Rows.Add(inscripcion.FechaInicio, inscripcion.FechaFinal, inscripcion.Precio, inscripcion.Cliente.Id, c_nombreCompleto, inscripcion.Supervisor.Id, s_nombreCompleto, inscripcion.Plan.Nombre, inscripcion.IdEstado);
                }
            }

        }

        private void ConsultarInscripcionBD_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void pnlConsultarDGV_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
