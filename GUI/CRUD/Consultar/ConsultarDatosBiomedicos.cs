using Entidades.Informacion_Persona;
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

namespace GUI.Pureba
{
    public partial class ConsultarDatosBiomedicos : Form
    {
        ServicioDatosBiomedicos serv;

        public ConsultarDatosBiomedicos()
        {
            InitializeComponent();
            serv = new ServicioDatosBiomedicos();

        }

        private void ConsultarDatosBiomedicos_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dgvDatosBiomedicos.ClearSelection();
        }

        void CargarGrilla()
        {
            dgvDatosBiomedicos.Rows.Clear();
            var lista = serv.GetAll();
            if (lista != null)
            {
                foreach (DatosBiomedicos dato in lista)
                {
                    dgvDatosBiomedicos.Rows.Add(dato.FechaRegistro.ToShortDateString(), dato.id_cliente.ToString(), dato.Altura.ToString(), dato.Peso.ToString(), dato.IdCategoriaPeso.ToString(), dato.Imc.ToString(), dato.GrasaCorporal.ToString(), dato.FrecuenciaCardiaca.ToString(), dato.PresionArterial.ToString());
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
