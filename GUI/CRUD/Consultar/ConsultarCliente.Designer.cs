namespace GUI.Pureba
{
    partial class ConsultarCliente
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
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.clmCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFecha_Nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCedula,
            this.clmnNombre,
            this.clmnApellido,
            this.clmnGenero,
            this.clmTelefono,
            this.clmFecha_Nacimiento,
            this.clmnFechaIngreso});
            this.dgvClientes.Location = new System.Drawing.Point(12, 73);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(644, 269);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            // 
            // clmCedula
            // 
            this.clmCedula.FillWeight = 116.4726F;
            this.clmCedula.HeaderText = "Cedula";
            this.clmCedula.Name = "clmCedula";
            // 
            // clmnNombre
            // 
            this.clmnNombre.FillWeight = 109.29F;
            this.clmnNombre.HeaderText = "Nombre";
            this.clmnNombre.Name = "clmnNombre";
            this.clmnNombre.ReadOnly = true;
            this.clmnNombre.Width = 94;
            // 
            // clmnApellido
            // 
            this.clmnApellido.FillWeight = 103.3025F;
            this.clmnApellido.HeaderText = "Apellido";
            this.clmnApellido.Name = "clmnApellido";
            this.clmnApellido.ReadOnly = true;
            this.clmnApellido.Width = 89;
            // 
            // clmnGenero
            // 
            this.clmnGenero.FillWeight = 98.31133F;
            this.clmnGenero.HeaderText = "Genero";
            this.clmnGenero.Name = "clmnGenero";
            this.clmnGenero.Width = 84;
            // 
            // clmTelefono
            // 
            this.clmTelefono.FillWeight = 94.15061F;
            this.clmTelefono.HeaderText = "Telefono";
            this.clmTelefono.Name = "clmTelefono";
            this.clmTelefono.Width = 81;
            // 
            // clmFecha_Nacimiento
            // 
            this.clmFecha_Nacimiento.FillWeight = 90.68218F;
            this.clmFecha_Nacimiento.HeaderText = "Fecha_Nacimiento";
            this.clmFecha_Nacimiento.Name = "clmFecha_Nacimiento";
            this.clmFecha_Nacimiento.Width = 78;
            // 
            // clmnFechaIngreso
            // 
            this.clmnFechaIngreso.FillWeight = 87.79087F;
            this.clmnFechaIngreso.HeaderText = "Fecha de Ingreso";
            this.clmnFechaIngreso.Name = "clmnFechaIngreso";
            this.clmnFechaIngreso.Width = 75;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(12, 364);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ConsultarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 399);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvClientes);
            this.Name = "ConsultarCliente";
            this.Text = "ReceiveBD";
            this.Load += new System.EventHandler(this.ConsultarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha_Nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFechaIngreso;
        private System.Windows.Forms.Button btnEliminar;
    }
}