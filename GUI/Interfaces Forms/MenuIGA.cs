using GUI.CRUD.Insertar;
using GUI.Pureba;
using GUI.Pureba.Insertar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.pruba
{
    public partial class MenuIGA : Form
    {
        public MenuIGA()
        {
            InitializeComponent();
            customizeDesign();
        }
            
        private void customizeDesign()
        {
            pnlClientesSbmn.Visible = false;
            pnlInscripcionesSbmn.Visible = false;
            pnlProductosSbmn.Visible = false;
            pnlSupervisoresSbmn.Visible = false;
            panelPlanes.Visible = false;
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

            if(pnlProductosSbmn.Visible == true)
            {
                pnlProductosSbmn.Visible = false;
            }
            if (panelPlanes.Visible == true)
            {
                panelPlanes.Visible = false;
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

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlInscripcionesSbmn);
        }

        private void btnAgregarInscripcion_Click(object sender, EventArgs e)
        {
            InsertarInscripcion ver = new InsertarInscripcion();
            ver.Show();
            hideSubMenu();
        }

        private void btnConsultarInscripcion_Click(object sender, EventArgs e)
        {
            ConsultarInscripcionBD ver = new ConsultarInscripcionBD();
            ver.Show();
            hideSubMenu();
        }

        private void btnActualizarInscripcion_Click(object sender, EventArgs e)
        {
            /*
             Codigo
             */
            hideSubMenu();
        }

        private void btnEliminarInscripcion_Click(object sender, EventArgs e)
        {
            /*
             Codigo
             */
            hideSubMenu();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlClientesSbmn);
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            InsertarCliente insertar = new InsertarCliente();
            insertar.Show();
            hideSubMenu();
        }

        private void btnConsultarCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente consulta = new ConsultarCliente();
            consulta.Show();
            hideSubMenu();
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            /*
             Codigo
             */
            hideSubMenu();
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            /*
             Codigo
             */
            hideSubMenu();
        }

        private void btnSupervisores_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSupervisoresSbmn);
        }

        private void btnAgregarSupervisor_Click(object sender, EventArgs e)
        {
            InsertarSupervisor insertarSup = new InsertarSupervisor();
            insertarSup.Show();

            hideSubMenu();
        }

        private void btnConsultarSupervisor_Click(object sender, EventArgs e)
        {
            ConsultarSupervisorBD consultarSup = new ConsultarSupervisorBD();
            consultarSup.Show();
            
            hideSubMenu();
        }

        private void btnActualizarSupervisor_Click(object sender, EventArgs e)
        {
            /*
             Codigo
             */
            hideSubMenu();
        }

        private void btnEliminarSupervisor_Click(object sender, EventArgs e)
        {
            /*
             Codigo
             */
            hideSubMenu();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlProductosSbmn);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            InsertarPago ver = new InsertarPago();
            ver.Show();
            hideSubMenu();
        }

        private void btnConsultarProducto_Click(object sender, EventArgs e)
        {
            ConsultarPagoBD ver = new ConsultarPagoBD();
            ver.Show();
            hideSubMenu();
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            /*
             Codigo
             */
            hideSubMenu();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            /*
             Codigo
             */
            hideSubMenu();
        }

        private void MenuIGA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit(); // Cierra la aplicación cuando se presiona el botón "X"
            }
        }


        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPlanes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            InsertarPlanGimnasio insertarplan = new InsertarPlanGimnasio();
            insertarplan.Show();
        }

        private void btnConsultarPlan_Click(object sender, EventArgs e)
        {
            ConsultarPlanGimnasioBD ver = new ConsultarPlanGimnasioBD();
            ver.Show();
        }

        private void btnActualizarPlan_Click(object sender, EventArgs e)
        {
            /*
            Codigo
            */
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlanes);
        }

        private void btnEliminarPlan_Click_1(object sender, EventArgs e)
        {
            /*
                Codigo
            */
            hideSubMenu();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ConsultarDatosBiomedicos con = new ConsultarDatosBiomedicos();
            con.Show();
            hideSubMenu();

        }
    }
}
