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
    public partial class ConsultarSupervisorBD : Form
    {

        ServicioSupervisores serv;
        public ConsultarSupervisorBD()
        {
            InitializeComponent();
            serv = new ServicioSupervisores();
        }

        void CargarGrilla()
        {
            dgvSupervisor.Rows.Clear();
            var lista = serv.Leer();
            if (lista != null)
            {
                foreach (Supervisoress supervisor in lista)
                {
                    dgvSupervisor.Rows.Add(supervisor.Id, supervisor.Nombre, supervisor.Apellido, supervisor.Genero, supervisor.Telefono, supervisor.Correo);
                }
            }

        }

        private void ConsultarSupervisorBD_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
