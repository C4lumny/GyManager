using Entidades;
using Entidades.Informacion_Persona;
using Entidades.Pagos_y_Facturas;
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
                    dgvDatosBiomedicos.Rows.Add(dato.Id, dato.FechaRegistro.ToShortDateString(), dato.id_cliente.ToString(), dato.Altura.ToString(), dato.Peso.ToString(), dato.IdCategoriaPeso.ToString(), dato.Imc.ToString(), dato.GrasaCorporal.ToString(), dato.FrecuenciaCardiaca.ToString(), dato.PresionArterial.ToString());
                }
            }

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string buscado = txtBusqueda.Text;
            dgvDatosBiomedicos.Rows.Clear();
            if (buscado.All(char.IsDigit))
            {
                List<DatosBiomedicos> datosBuscados = serv.GetListBySearch(buscado);
                if (datosBuscados != null)
                {
                    foreach (DatosBiomedicos dato in datosBuscados)
                    {
                        dgvDatosBiomedicos.Rows.Add(dato.Id, dato.FechaRegistro.ToShortDateString(), dato.id_cliente.ToString(), dato.Altura.ToString(), dato.Peso.ToString(), dato.IdCategoriaPeso.ToString(), dato.Imc.ToString(), dato.GrasaCorporal.ToString(), dato.FrecuenciaCardiaca.ToString(), dato.PresionArterial.ToString());
                    }
                }
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dgvDatosBiomedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica si se hace clic en una fila válida
            {
                int datoId = Convert.ToInt32(dgvDatosBiomedicos.Rows[e.RowIndex].Cells["clmnId"].Value);

                btnActualizar.Tag = datoId; //Almaceno el id en el boton actualizar
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (btnActualizar.Tag != null && btnActualizar.Tag is int datoId)
            {
                ActualizarDatosBiomedicos actDato = new ActualizarDatosBiomedicos(datoId.ToString());
                actDato.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ActualizarDatosBiomedicos_FormClosed);
                actDato.Show();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún Dato Biomedico para actualizar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarDatosBiomedicos_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarGrilla();
        }
    }
}
