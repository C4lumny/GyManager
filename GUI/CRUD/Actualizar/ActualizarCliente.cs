using Entidades;
using GUI.pruba;
using GUI.Pureba;
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
    public partial class ActualizarCliente : Form
    {

        private string clienteId;

        public ActualizarCliente(string id)
        {
            InitializeComponent();
            clienteId = id;

            cargarTextBoxes(clienteId);
        }

        private void cargarTextBoxes(string id)
        {
            ServicioClientes serv = new ServicioClientes();
            Clientess cliente = serv.GetObjectById(id);

            txtCedula.Text = cliente.Id;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono;
            dtmFechaNacimiento.Value = cliente.Fecha_nacimiento;
            cmbGenero.SelectedItem = cliente.Genero;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Clientess clienteAct = new Clientess();
                clienteAct.Id = txtCedula.Text;
                clienteAct.Nombre = txtNombre.Text;
                clienteAct.Apellido = txtApellido.Text;
                clienteAct.Telefono = txtTelefono.Text;
                clienteAct.Genero = cmbGenero.SelectedItem.ToString();
                clienteAct.Fecha_nacimiento = dtmFechaNacimiento.Value;

                ServicioClientes serv = new ServicioClientes();
                serv.Actualizar(clienteAct, clienteId);

                MessageBox.Show("Cliente actualizado correctamente", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
