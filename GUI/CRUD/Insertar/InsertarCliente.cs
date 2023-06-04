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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            // Crear un objeto Cliente
            ServicioClientes serv = new ServicioClientes();
            ServicioDatosBiomedicos serv2 = new ServicioDatosBiomedicos();
            // Llenar el objeto Cliente con los valores de los TextBox


            DatosBiomedicos datos = new DatosBiomedicos();

            datos.Altura = double.Parse(txtAltura.Text);
            datos.Peso = double.Parse(txtPeso.Text);
            datos.GrasaCorporal = double.Parse(txtGrasa.Text);
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
    }
}
