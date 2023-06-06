namespace GUI.CRUD.Actualizar
{
    partial class ActualizarPlanG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblActualizarCliente = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.dtmFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.panel.Controls.Add(this.btnActualizar);
            this.panel.Controls.Add(this.lblActualizarCliente);
            this.panel.Controls.Add(this.lblFechaNacimiento);
            this.panel.Controls.Add(this.lblTelefono);
            this.panel.Controls.Add(this.lblGenero);
            this.panel.Controls.Add(this.lblApellidos);
            this.panel.Controls.Add(this.lblNombres);
            this.panel.Controls.Add(this.lblCedula);
            this.panel.Controls.Add(this.dtmFechaNacimiento);
            this.panel.Controls.Add(this.txtTelefono);
            this.panel.Controls.Add(this.cmbGenero);
            this.panel.Controls.Add(this.txtApellido);
            this.panel.Controls.Add(this.txtNombre);
            this.panel.Controls.Add(this.txtCedula);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(668, 399);
            this.panel.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(136)))), ((int)(((byte)(158)))));
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnActualizar.Location = new System.Drawing.Point(272, 321);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(90, 30);
            this.btnActualizar.TabIndex = 28;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblActualizarCliente
            // 
            this.lblActualizarCliente.AutoSize = true;
            this.lblActualizarCliente.Font = new System.Drawing.Font("MesloLGM NF", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualizarCliente.ForeColor = System.Drawing.Color.White;
            this.lblActualizarCliente.Location = new System.Drawing.Point(38, 24);
            this.lblActualizarCliente.Name = "lblActualizarCliente";
            this.lblActualizarCliente.Size = new System.Drawing.Size(305, 37);
            this.lblActualizarCliente.TabIndex = 24;
            this.lblActualizarCliente.Text = "Actualizar cliente";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(434, 243);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(184, 23);
            this.txtTelefono.TabIndex = 4;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.White;
            this.lblTelefono.Location = new System.Drawing.Point(337, 248);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(74, 18);
            this.lblTelefono.TabIndex = 15;
            this.lblTelefono.Text = "Telefono: ";
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cmbGenero.Location = new System.Drawing.Point(240, 248);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(70, 21);
            this.cmbGenero.TabIndex = 3;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.ForeColor = System.Drawing.Color.White;
            this.lblGenero.Location = new System.Drawing.Point(42, 248);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(66, 18);
            this.lblGenero.TabIndex = 14;
            this.lblGenero.Text = "Genero: ";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(434, 173);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(184, 23);
            this.txtApellido.TabIndex = 2;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidos.ForeColor = System.Drawing.Color.White;
            this.lblApellidos.Location = new System.Drawing.Point(336, 174);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(75, 18);
            this.lblApellidos.TabIndex = 13;
            this.lblApellidos.Text = "Apellidos: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(126, 169);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(184, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.ForeColor = System.Drawing.Color.White;
            this.lblNombres.Location = new System.Drawing.Point(42, 174);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(78, 18);
            this.lblNombres.TabIndex = 12;
            this.lblNombres.Text = "Nombres: ";
            // 
            // dtmFechaNacimiento
            // 
            this.dtmFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaNacimiento.Location = new System.Drawing.Point(537, 103);
            this.dtmFechaNacimiento.Name = "dtmFechaNacimiento";
            this.dtmFechaNacimiento.Size = new System.Drawing.Size(81, 20);
            this.dtmFechaNacimiento.TabIndex = 5;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaNacimiento.ForeColor = System.Drawing.Color.White;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(337, 100);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(153, 18);
            this.lblFechaNacimiento.TabIndex = 16;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento: ";
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(126, 100);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(184, 23);
            this.txtCedula.TabIndex = 0;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.Color.White;
            this.lblCedula.Location = new System.Drawing.Point(43, 101);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(62, 18);
            this.lblCedula.TabIndex = 11;
            this.lblCedula.Text = "Cedula: ";
            // 
            // ActualizarPlanG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 399);
            this.Controls.Add(this.panel);
            this.Name = "ActualizarPlanG";
            this.Text = "ActualizarCliente";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblActualizarCliente;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.DateTimePicker dtmFechaNacimiento;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCedula;
    }
}