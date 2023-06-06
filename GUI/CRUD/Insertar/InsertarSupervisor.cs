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
    public partial class InsertarSupervisor : Form
    {
        public InsertarSupervisor()
        {
            InitializeComponent();
            cmbGenero.SelectedIndex = 0;
            txtCorreo.Text = "ejemplo@example.com";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Supervisoress supervisor = new Supervisoress();
            ServicioSupervisores servSupervisor = new ServicioSupervisores();

            supervisor.Id = txtCedula.Text;
            supervisor.Nombre = txtNombre.Text;
            supervisor.Apellido = txtApellido.Text;
            supervisor.Genero = cmbGenero.SelectedItem.ToString();
            supervisor.Telefono = txtTelefono.Text;
            supervisor.Fecha_nacimiento = dtmFechaNacimiento.Value;
            supervisor.Correo = txtCorreo.Text;

            MessageBox.Show(servSupervisor.Crear(supervisor).Msg);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir caracteres alfanuméricos, la tecla de retroceso y los caracteres '.' y '@'
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '@')
            {
                e.Handled = true; // Cancelar el evento KeyPress si se ingresa un carácter no válido
            }

            // Validar que se ingrese solo un carácter '@'
            if (e.KeyChar == '@')
            {
                // Validar que no haya más de un carácter '@'
                if (txtCorreo.Text.Contains('@'))
                {
                    e.Handled = true; // Cancelar el evento KeyPress si ya hay un carácter '@'
                }
            }

            // Validar que se ingrese solo un carácter '.'
            if (e.KeyChar == '.')
            {
                // Validar que no haya más de un carácter '.'
                if (txtCorreo.Text.Contains('.'))
                {
                    e.Handled = true; // Cancelar el evento KeyPress si ya hay un carácter '.'
                }
            }
        }

        private void dtmFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtmFechaNacimiento.Value;
            DateTime fechaActual = DateTime.Now;

            if (fechaSeleccionada > fechaActual)
            {
                MessageBox.Show("No se permite seleccionar una fecha mayor a la fecha actual.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtmFechaNacimiento.Value = fechaActual;
            }
        }
    }
}
