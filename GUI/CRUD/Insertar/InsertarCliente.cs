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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            // Crear un objeto Cliente
            Clientess cliente = new Clientess();
            DatosBiomedicos datos = new DatosBiomedicos();
            ServicioClientes serv = new ServicioClientes();
            ServicioDatosBiomedicos serv2 = new ServicioDatosBiomedicos();
            // Llenar el objeto Cliente con los valores de los TextBox
            cliente.Id = txtCedula.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Genero = cmbGenero.SelectedItem.ToString();
            cliente.Telefono = txtTelefono.Text;
            cliente.Fecha_nacimiento = dtmFechaNacimiento.Value;
            datos.Altura = double.Parse(txtAltura.Text);
            datos.Peso = double.Parse(txtPeso.Text);
            datos.GrasaCorporal = double.Parse(txtGrasa.Text);
            datos.FrecuenciaCardiaca = int.Parse(txtFrecuencia.Text);
            datos.PresionArterial = int.Parse(txtPresion.Text);
            datos.IdCliente = txtCedula.Text;
            MessageBox.Show(serv.Crear(cliente));
            serv2.Crear(datos);
        }
    }
}
