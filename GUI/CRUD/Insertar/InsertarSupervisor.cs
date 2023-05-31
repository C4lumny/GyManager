using Entidades;
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
    public partial class InsertarSupervisor : Form
    {
        public InsertarSupervisor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Supervisoress supervisor = new Supervisoress();

            supervisor.Id = txtCedula.Text;
            supervisor.Nombre = txtNombre.Text;
            supervisor.Apellido = txtApellido.Text;
            supervisor.Genero = cmbGenero.SelectedItem.ToString();
            supervisor.Telefono = txtTelefono.Text;
            supervisor.Fecha_nacimiento = dtmFechaNacimiento.Value;
            supervisor.Correo = txtCorreo.Text;
        }
    }
}
