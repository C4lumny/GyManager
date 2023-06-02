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

        void CargarGrilla()
        {
            dgvClientes.Rows.Clear();
            var lista = serv.Leer();
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
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica si se hace clic en una fila válida
            {
                string clienteId = (string)dgvClientes.Rows[e.RowIndex].Cells["clmCedula"].Value;
                btnEliminar.Visible = true;
                btnEliminar.Tag = clienteId; // Almacena el ID del cliente en la propiedad Tag del botón
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (btnEliminar.Tag != null && btnEliminar.Tag is string clienteId)
            {
                ServicioClientes serv = new ServicioClientes();
                serv.Eliminar(int.Parse(clienteId));

                btnEliminar.Visible = false;
                CargarGrilla();
            }
        }
    }
}
