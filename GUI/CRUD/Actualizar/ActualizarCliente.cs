﻿using Entidades;
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
    public partial class ActualizarPlanG : Form
    {

        private string clienteId;

        public ActualizarPlanG(string id)
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
            ServicioClientes serv = new ServicioClientes();
            Clientess cliente = serv.GetObjectById(clienteId);
            try
            {
                Clientess clienteAct = new Clientess();
                clienteAct.Id = txtCedula.Text;
                clienteAct.Nombre = txtNombre.Text;
                clienteAct.Apellido = txtApellido.Text;
                clienteAct.Telefono = txtTelefono.Text;
                clienteAct.Fecha_nacimiento = dtmFechaNacimiento.Value;
                clienteAct.Genero = cmbGenero.SelectedItem.ToString();
                clienteAct.Fecha_ingreso = cliente.Fecha_ingreso;

                
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
