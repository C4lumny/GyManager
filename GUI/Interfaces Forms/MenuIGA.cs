﻿using GUI.CRUD.Insertar;
using GUI.Pureba;
using GUI.Pureba.Insertar;
using Logica.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.pruba
{
    public partial class MenuIGA : Form
    {
        private Form activo = null;

        public MenuIGA()
        {
            InitializeComponent();
            customizeDesign();
            // Carga de datos antes de ejecucion para rediucir el lag dentro del programa
            ServicioInscripcion serInscripcion = new ServicioInscripcion();
            serInscripcion.GetAll();
            ServicioClientes serClientes = new ServicioClientes();
            serClientes.GetAll();
            ServicioDatosBiomedicos serDatos = new ServicioDatosBiomedicos();
            serDatos.GetAll();
            ServicioPago serPago = new ServicioPago();
            serPago.GetAll();
            ServicioSupervisores serSupervisores = new ServicioSupervisores();
            serSupervisores.GetAll();
            ServicioPlanGimnasio serPlanes = new ServicioPlanGimnasio();
            serPlanes.GetAll();

        }

        private void MenuIGA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit(); // Cierra la aplicación cuando se presiona el botón "X"
            }
        }

        private void customizeDesign()
        {
            pnlClientesSbmn.Visible = false;
            pnlInscripcionesSbmn.Visible = false;
            pnlSupervisoresSbmn.Visible = false;
            pnlPlanes.Visible = false;
        }

        private void openForms(Form formHijo)
        {
            if (activo != null)
            {
                activo.Close();
                activo = null;
            }

            if (formHijo != null)
            {
                lblRetorno.Visible = true;
                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;
                pnlChild.Controls.Add(formHijo);
                pnlChild.Tag = formHijo;
                formHijo.BringToFront();
                formHijo.Show();

                activo = formHijo;
            }
        }

        private void hideSubMenu()
        {
            if(pnlInscripcionesSbmn.Visible == true)
            {
                pnlInscripcionesSbmn.Visible = false;
            }

            if(pnlClientesSbmn.Visible == true)
            {
                pnlClientesSbmn.Visible = false;
            }

            if(pnlSupervisoresSbmn.Visible == true)
            {
                pnlSupervisoresSbmn.Visible = false;
            }
            if (pnlPlanes.Visible == true)
            {
                pnlPlanes.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlInscripcionesSbmn);
        }

        private void btnAgregarInscripcion_Click(object sender, EventArgs e)
        {
            InsertarInscripcion ver = new InsertarInscripcion();
            openForms(ver);
            hideSubMenu();
        }

        private void btnConsultarInscripcion_Click(object sender, EventArgs e)
        {
            ConsultarInscripcion ver = new ConsultarInscripcion();
            openForms(ver);
            hideSubMenu();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlClientesSbmn);
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            InsertarCliente insertar = new InsertarCliente();
            openForms(insertar);
            hideSubMenu();
        }

        private void btnConsultarCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente consulta = new ConsultarCliente();
            openForms(consulta);
            hideSubMenu();
        }

        private void btnConsultarDatosBD_Click_1(object sender, EventArgs e)
        {
            ConsultarDatosBiomedicos con = new ConsultarDatosBiomedicos();
            openForms(con);
            hideSubMenu();
        }

        private void btnSupervisores_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSupervisoresSbmn);
        }

        private void btnAgregarSupervisor_Click(object sender, EventArgs e)
        {
            InsertarSupervisor insertarSup = new InsertarSupervisor();
            openForms(insertarSup);

            hideSubMenu();
        }

        private void btnConsultarSupervisor_Click(object sender, EventArgs e)
        {
            ConsultarSupervisor consultarSup = new ConsultarSupervisor();
            openForms(consultarSup);
            
            hideSubMenu();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlPlanes);
        }

        private void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            InsertarPlanGimnasio insertarplan = new InsertarPlanGimnasio();
            openForms(insertarplan);
            hideSubMenu();
        }

        private void btnConsultarPlan_Click(object sender, EventArgs e)
        {
            ConsultarPlanGimnasio consultarplan = new ConsultarPlanGimnasio();
            openForms(consultarplan);
            hideSubMenu();
        }

        private void picLogo_Click_1(object sender, EventArgs e)
        {
            openForms(null);
            lblRetorno.Visible = false;
        }

        private void btnHistorialBiomedico_Click(object sender, EventArgs e)
        {
            ConsultarHistorialBiomedico consultarHB = new ConsultarHistorialBiomedico();
            openForms(consultarHB);
            hideSubMenu();
        }

        private void btnHistorialPagos_Click(object sender, EventArgs e)
        {
            ConsultarHistorialPagos consultarPagos = new ConsultarHistorialPagos();
            openForms(consultarPagos);
            hideSubMenu();
        }

        private void btnConsultarPago_Click(object sender, EventArgs e)
        {
            ConsultarPago consultarPago = new ConsultarPago();
            openForms(consultarPago);
            hideSubMenu();
        }
    }
}
