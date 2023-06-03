﻿using Entidades;
using Entidades.Pagos_y_Facturas;
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
    public partial class InsertarInscripcion : Form
    {
        public InsertarInscripcion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ServicioInscripcion servInscripcion = new ServicioInscripcion();
            ServicioClientes servicioClientes = new ServicioClientes();
            ServicioPlanGimnasio servicioplan = new ServicioPlanGimnasio();
            ServicioSupervisores serviciosupervisor = new ServicioSupervisores();

            Inscripcion inscripcion = new Inscripcion();

            inscripcion.Cliente = servicioClientes.GetObjectById(txtIDCliente.Text);
            inscripcion.Supervisor = serviciosupervisor.GetObjectById(txtIDSupervisor.Text);
            inscripcion.Plan = servicioplan.GetObjectById(txtIDPlan.Text);
            inscripcion.Descuento = int.Parse(txtDescuento.Text);

            MessageBox.Show(servInscripcion.Crear(inscripcion));
        }

        private void txtIDCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtIDSupervisor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtIDPlan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}