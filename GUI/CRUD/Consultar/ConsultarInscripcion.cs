using Entidades;
using GUI.CRUD.Actualizar;
using GUI.CRUD.Insertar;
using GUI.Imprimir;
using Logica.Clases;
using System;
using System.Collections;
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
    public partial class ConsultarInscripcion : Form
    {
        ServicioInscripcion serv;
        ServicioFacturas servicioFacturas = new ServicioFacturas();

        public ConsultarInscripcion()
        {
            InitializeComponent();
            serv = new ServicioInscripcion();

        }

        void CargarGrilla()
        {
            dgvInscripcion.Rows.Clear();
            var lista = serv.GetAll();
            if (lista != null)
            {
                string s_nombreCompleto;
                string c_nombreCompleto;
                foreach (Inscripcion inscripcion in lista)
                {
                    c_nombreCompleto = inscripcion.Cliente.Nombre + " " + inscripcion.Cliente.Apellido;
                    s_nombreCompleto = inscripcion.Supervisor.Nombre + " " + inscripcion.Supervisor.Apellido;

                    dgvInscripcion.Rows.Add(inscripcion.Id, inscripcion.FechaInicio, inscripcion.FechaFinal, inscripcion.Precio, inscripcion.Cliente.Id, c_nombreCompleto, inscripcion.Supervisor.Id, s_nombreCompleto, inscripcion.Plan.Nombre, inscripcion.IdEstado);
                }
            }

        }

        private void ConsultarInscripcionBD_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            
            Impresion impresion = new Impresion(servicioFacturas.GetObjectById("41"));
            impresion.Show();
        }

        private void dgvInscripcion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica si se hace clic en una fila válida
            {
                int inscripcionId = Convert.ToInt32(dgvInscripcion.Rows[e.RowIndex].Cells["clmnIdInscripcion"].Value);

                btnEliminar.Tag = inscripcionId; // Almacena el ID del cliente en la propiedad Tag del botón
                btnPago.Tag = inscripcionId; //Almaceno el id en el boton actualizar
            }
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            if (btnPago.Tag != null && btnPago.Tag is int inscripcionId)
            {
                InsertarPago pagoInsertado = new InsertarPago(inscripcionId);
                pagoInsertado.FormClosed += new System.Windows.Forms.FormClosedEventHandler(InsertarPago_FormClosed);
                pagoInsertado.Show();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna inscripción para pagar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InsertarPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarGrilla();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string buscado = txtBusqueda.Text;
            dgvInscripcion.Rows.Clear();
            if (buscado.All(char.IsDigit))
            {
                List<Inscripcion> inscripcionBuscada = serv.GetListBySearch(buscado);
                if (inscripcionBuscada != null)
                {
                    string s_nombreCompleto;
                    string c_nombreCompleto;
                    foreach (Inscripcion inscripcion in inscripcionBuscada)
                    {
                        c_nombreCompleto = inscripcion.Cliente.Nombre + " " + inscripcion.Cliente.Apellido;
                        s_nombreCompleto = inscripcion.Supervisor.Nombre + " " + inscripcion.Supervisor.Apellido;

                        dgvInscripcion.Rows.Add(inscripcion.Id, inscripcion.FechaInicio, inscripcion.FechaFinal, inscripcion.Precio, inscripcion.Cliente.Id, c_nombreCompleto, inscripcion.Supervisor.Id, s_nombreCompleto, inscripcion.Plan.Nombre, inscripcion.IdEstado);
                    }
                }
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
