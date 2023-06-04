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
    public partial class ConsultarCliente : Form
    {
        ServicioClientes serv; 
        public ConsultarCliente()
        {
            serv = new ServicioClientes();
            InitializeComponent();
        }

        public void CargarGrilla()
        {
            dgvClientes.Rows.Clear();
            var lista = serv.GetAll();
            if (lista != null)
            {
                foreach (Clientess cliente in lista)
                {
                    dgvClientes.Rows.Add(cliente.Id, cliente.Nombre, cliente.Apellido, cliente.Genero, cliente.Telefono, cliente.Fecha_nacimiento, cliente.Fecha_ingreso);
                }
            }

        }

        private void ConsultarCliente_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dgvClientes.ClearSelection();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica si se hace clic en una fila válida
            {
                string clienteId = (string)dgvClientes.Rows[e.RowIndex].Cells["clmCedula"].Value;

                btnEliminar.Tag = clienteId; // Almacena el ID del cliente en la propiedad Tag del botón
                btnActualizarCliente.Tag = clienteId; //Almaceno el id en el boton actualizar
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (btnEliminar.Tag != null && btnEliminar.Tag is string clienteId)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ServicioClientes serv = new ServicioClientes();
                    serv.Eliminar(clienteId);

                    CargarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún cliente para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            if (btnActualizarCliente.Tag != null && btnActualizarCliente.Tag is string clienteId)
            {
                ActualizarPlanG actCliente = new ActualizarPlanG(clienteId);
                actCliente.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ActualizarCliente_FormClosed);
                actCliente.Show();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún cliente para actualizar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ActualizarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarGrilla();
        }
    }
}
