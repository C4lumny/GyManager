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

        private void ReceiveClientesBD_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
