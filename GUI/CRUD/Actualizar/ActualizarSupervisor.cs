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
    public partial class ActualizarSupervisor : Form
    {

        private string supervisorId;
        public ActualizarSupervisor(string Id)
        {
            InitializeComponent();
            supervisorId = Id;

            cargarTextBoxes(supervisorId);
        }

        private void cargarTextBoxes(string id)
        {
            ServicioSupervisores serv = new ServicioSupervisores();
            Supervisoress supervisor = serv.GetObjectById(id);

            txtCedula.Text = supervisor.Id;
            txtNombre.Text = supervisor.Nombre;
            txtApellido.Text = supervisor.Apellido;
            txtTelefono.Text = supervisor.Telefono;
            txtCorreo.Text = supervisor.Correo;
            dtmFechaNacimiento.Value = supervisor.Fecha_nacimiento;
            cmbGenero.SelectedItem = supervisor.Genero;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ServicioSupervisores serv = new ServicioSupervisores();
            Supervisoress supervisor = serv.GetObjectById(supervisorId);
            try
            {
                Supervisoress supervisorAct = new Supervisoress();
                supervisorAct.Id = txtCedula.Text;
                supervisorAct.Nombre = txtNombre.Text;
                supervisorAct.Apellido = txtApellido.Text;
                supervisorAct.Telefono = txtTelefono.Text;
                supervisorAct.Correo = txtCorreo.Text;
                supervisorAct.Genero = cmbGenero.SelectedItem.ToString();
                supervisorAct.Fecha_nacimiento = dtmFechaNacimiento.Value;
                supervisorAct.Fecha_ingreso = supervisor.Fecha_ingreso;


                serv.Actualizar(supervisorAct, supervisorId);

                MessageBox.Show("Supervisor actualizado correctamente", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el supervisor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
