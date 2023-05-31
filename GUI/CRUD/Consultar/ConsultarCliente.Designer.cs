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
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCedula,
            this.clmnNombre,
            this.clmnApellido,
            this.clmnGenero,
            this.clmTelefono,
            this.clmFecha_Nacimiento,
            this.clmnFechaIngreso});
            this.dgvClientes.Location = new System.Drawing.Point(44, 47);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(743, 462);
            this.dgvClientes.TabIndex = 0;
            // 
            // clmCedula
            // 
            this.clmCedula.HeaderText = "Cedula";
            this.clmCedula.Name = "clmCedula";
            // 
            // clmnNombre
            // 
            this.clmnNombre.HeaderText = "Nombre";
            this.clmnNombre.Name = "clmnNombre";
            this.clmnNombre.ReadOnly = true;
            // 
            // clmnApellido
            // 
            this.clmnApellido.HeaderText = "Apellido";
            this.clmnApellido.Name = "clmnApellido";
            this.clmnApellido.ReadOnly = true;
            // 
            // clmnGenero
            // 
            this.clmnGenero.HeaderText = "Genero";
            this.clmnGenero.Name = "clmnGenero";
            // 
            // clmTelefono
            // 
            this.clmTelefono.HeaderText = "Telefono";
            this.clmTelefono.Name = "clmTelefono";
            // 
            // clmFecha_Nacimiento
            // 
            this.clmFecha_Nacimiento.HeaderText = "Fecha_Nacimiento";
            this.clmFecha_Nacimiento.Name = "clmFecha_Nacimiento";
            // 
            // clmnFechaIngreso
            // 
            this.clmnFechaIngreso.HeaderText = "Fecha de Ingreso";
            this.clmnFechaIngreso.Name = "clmnFechaIngreso";
            // 
            // ConsultarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 558);
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
    }
}