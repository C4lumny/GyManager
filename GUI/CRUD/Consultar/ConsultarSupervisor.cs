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
    public partial class ConsultarSupervisor : Form
    {

        ServicioSupervisores serv;
        public ConsultarSupervisor()
        {
            InitializeComponent();
            serv = new ServicioSupervisores();
        }

        void CargarGrilla()
        {
            try
            {
                dgvSupervisor.Rows.Clear();
                var lista = serv.GetAll();
                if (lista == null)
                {
                    MessageBox.Show("No se encontraron datos.");
                }
                else
                {
                    foreach (Supervisoress supervisor in lista)
                    {
                        dgvSupervisor.Rows.Add(supervisor.Id, supervisor.Nombre, supervisor.Apellido, supervisor.Genero, supervisor.Telefono, supervisor.Correo, supervisor.Fecha_nacimiento, supervisor.Fecha_ingreso);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex.Message);
            }
        }

        private void ConsultarSupervisor_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dgvSupervisor.ClearSelection();
        }

        private void dgvSupervisor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                string supervisorId = (string)dgvSupervisor.Rows[e.RowIndex].Cells["clmCedula"].Value;
                btnEliminar.Visible = true;
                btnActualizarSupervisor.Visible = true;

                btnEliminar.Tag = supervisorId; 
                btnActualizarSupervisor.Tag = supervisorId; 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (btnEliminar.Tag != null && btnEliminar.Tag is string supervisorId)
            {
                ServicioSupervisores serv = new ServicioSupervisores();
                serv.Eliminar(supervisorId);

                btnActualizarSupervisor.Visible = false;
                btnEliminar.Visible = false;
                CargarGrilla();
            }
        }

        private void btnActualizarSupervisor_Click(object sender, EventArgs e)
        {
            if (btnActualizarSupervisor.Tag != null && btnActualizarSupervisor.Tag is string supervisorId)
            {
                ActualizarSupervisor actSupervisor = new ActualizarSupervisor(supervisorId);
                actSupervisor.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ActualizarSupervisor_FormClosed);
                actSupervisor.Show();

                btnActualizarSupervisor.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void ActualizarSupervisor_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarGrilla();
        }
    }
}
