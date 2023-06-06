namespace GUI.Pureba
{
    partial class ConsultarSupervisor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnActualizarSupervisor = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvSupervisor = new System.Windows.Forms.DataGridView();
            this.clmCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBusqueda);
            this.panel1.Controls.Add(this.btnActualizarSupervisor);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.dgvSupervisor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 399);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(30, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Busqueda:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(117, 51);
            this.txtBusqueda.Multiline = true;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(192, 24);
            this.txtBusqueda.TabIndex = 13;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // btnActualizarSupervisor
            // 
            this.btnActualizarSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizarSupervisor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnActualizarSupervisor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnActualizarSupervisor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarSupervisor.ForeColor = System.Drawing.SystemColors.Window;
            this.btnActualizarSupervisor.Location = new System.Drawing.Point(157, 332);
            this.btnActualizarSupervisor.Name = "btnActualizarSupervisor";
            this.btnActualizarSupervisor.Size = new System.Drawing.Size(90, 30);
            this.btnActualizarSupervisor.TabIndex = 7;
            this.btnActualizarSupervisor.Text = "Actualizar";
            this.btnActualizarSupervisor.UseVisualStyleBackColor = false;
            this.btnActualizarSupervisor.Visible = false;
            this.btnActualizarSupervisor.Click += new System.EventHandler(this.btnActualizarSupervisor_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Info;
            this.btnEliminar.Location = new System.Drawing.Point(33, 332);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvSupervisor
            // 
            this.dgvSupervisor.AllowUserToAddRows = false;
            this.dgvSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSupervisor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.dgvSupervisor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSupervisor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSupervisor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupervisor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupervisor.ColumnHeadersHeight = 40;
            this.dgvSupervisor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCedula,
            this.clmNombre,
            this.clmApellido,
            this.clmGenero,
            this.clmTelefono,
            this.clmCorreo,
            this.clmFechaNacimiento,
            this.clmFechaIngreso});
            this.dgvSupervisor.EnableHeadersVisualStyles = false;
            this.dgvSupervisor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.dgvSupervisor.Location = new System.Drawing.Point(33, 99);
            this.dgvSupervisor.Name = "dgvSupervisor";
            this.dgvSupervisor.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupervisor.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSupervisor.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            this.dgvSupervisor.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSupervisor.RowTemplate.Height = 30;
            this.dgvSupervisor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSupervisor.Size = new System.Drawing.Size(605, 213);
            this.dgvSupervisor.TabIndex = 4;
            this.dgvSupervisor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupervisor_CellClick);
            // 
            // clmCedula
            // 
            this.clmCedula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCedula.FillWeight = 116.4726F;
            this.clmCedula.HeaderText = "Cedula";
            this.clmCedula.Name = "clmCedula";
            this.clmCedula.ReadOnly = true;
            // 
            // clmNombre
            // 
            this.clmNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmNombre.FillWeight = 109.29F;
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            // 
            // clmApellido
            // 
            this.clmApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmApellido.FillWeight = 103.3025F;
            this.clmApellido.HeaderText = "Apellido";
            this.clmApellido.Name = "clmApellido";
            this.clmApellido.ReadOnly = true;
            // 
            // clmGenero
            // 
            this.clmGenero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmGenero.FillWeight = 98.31133F;
            this.clmGenero.HeaderText = "Genero";
            this.clmGenero.Name = "clmGenero";
            this.clmGenero.ReadOnly = true;
            // 
            // clmTelefono
            // 
            this.clmTelefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmTelefono.FillWeight = 94.15061F;
            this.clmTelefono.HeaderText = "Telefono";
            this.clmTelefono.Name = "clmTelefono";
            this.clmTelefono.ReadOnly = true;
            // 
            // clmCorreo
            // 
            this.clmCorreo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCorreo.HeaderText = "Correo";
            this.clmCorreo.Name = "clmCorreo";
            this.clmCorreo.ReadOnly = true;
            // 
            // clmFechaNacimiento
            // 
            this.clmFechaNacimiento.HeaderText = "Fecha de nacimiento";
            this.clmFechaNacimiento.Name = "clmFechaNacimiento";
            this.clmFechaNacimiento.ReadOnly = true;
            // 
            // clmFechaIngreso
            // 
            this.clmFechaIngreso.HeaderText = "Fecha de ingreso";
            this.clmFechaIngreso.Name = "clmFechaIngreso";
            this.clmFechaIngreso.ReadOnly = true;
            // 
            // ConsultarSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 399);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultarSupervisor";
            this.Text = "Consultar supervisor";
            this.Load += new System.EventHandler(this.ConsultarSupervisor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaIngreso;
        private System.Windows.Forms.Button btnActualizarSupervisor;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusqueda;
    }
}