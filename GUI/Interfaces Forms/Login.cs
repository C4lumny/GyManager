using Entidades.Administrador;
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

namespace GUI.pruba
{
    public partial class Login : Form
    {
        ServicioAdministrador servAdmin = new ServicioAdministrador();

        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Administrador admin = new Administrador();
            admin.UserName = txtUsername.Text;
            admin.Password = txtPassword.Text;

            ServicioAdministrador servAdmin = new ServicioAdministrador();
            servAdmin.ValidarAdmin(admin);
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if(txtUsername.Text == "USUARIO")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if(txtUsername.Text == "")
            {
                txtUsername.Text = "USUARIO";
                txtUsername.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            } 
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            admin.UserName = txtUsername.Text;
            admin.Password = txtPassword.Text;

            ServicioAdministrador servAdmin = new ServicioAdministrador();
            if (servAdmin.ValidarAdmin(admin).Success)
            {
                MessageBox.Show(servAdmin.ValidarAdmin(admin).Msg);
                MenuIGA menu = new MenuIGA();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(servAdmin.ValidarAdmin(admin).Msg);
            }
            
        }

        private bool isDragging = false;
        private Point lastMousePosition;
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastMousePosition = e.Location;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;
                this.Location = new Point(this.Left + deltaX, this.Top + deltaY);
            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
