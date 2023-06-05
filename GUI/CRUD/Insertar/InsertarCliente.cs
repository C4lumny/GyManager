using Entidades;
using Entidades.Informacion_Persona;
using Logica.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Pureba.Insertar
{
    public partial class InsertarCliente : Form
    {
        public InsertarCliente()
        {
            InitializeComponent();
            cmbGenero.SelectedIndex = 0;
            txtAltura.Text = "1.00";
            txtPeso.Text = "10.00";
            txtGrasa.Text = "1";
            txtFrecuencia.Text = "10";
            txtPresion.Text = "100";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            // Crear un objeto Cliente
            ServicioClientes serv = new ServicioClientes();
            ServicioDatosBiomedicos serv2 = new ServicioDatosBiomedicos();
            // Llenar el objeto Cliente con los valores de los TextBox


            DatosBiomedicos datos = new DatosBiomedicos();

            datos.Altura = double.Parse(txtAltura.Text, System.Globalization.CultureInfo.InvariantCulture);
            datos.Peso = double.Parse(txtPeso.Text, System.Globalization.CultureInfo.InvariantCulture);
            datos.GrasaCorporal = double.Parse(txtGrasa.Text, System.Globalization.CultureInfo.InvariantCulture);
            datos.FrecuenciaCardiaca = int.Parse(txtFrecuencia.Text);
            datos.PresionArterial = int.Parse(txtPresion.Text);
            datos.id_cliente = txtCedula.Text;

            Clientess cliente = new Clientess(datos);
            cliente.Id = txtCedula.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Genero = cmbGenero.SelectedItem.ToString();
            cliente.Telefono = txtTelefono.Text;
            cliente.Fecha_nacimiento = dtmFechaNacimiento.Value;

            MessageBox.Show(serv.Crear(cliente).Msg);
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

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                // Validar que no haya más de un punto
                if (txtAltura.Text.Contains('.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                // Validar que no haya más de un punto
                if (txtPeso.Text.Contains('.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtGrasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                // Validar que no haya más de un punto
                if (txtGrasa.Text.Contains('.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, la tecla de retroceso y el carácter de separación '/'
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Cancelar el evento KeyPress si se ingresa un carácter no válido
            }
        }
    }
}
