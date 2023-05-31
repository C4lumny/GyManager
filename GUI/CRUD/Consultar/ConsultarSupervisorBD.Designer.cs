namespace GUI.Pureba
{
    partial class ConsultarSupervisorBD
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
            this.dgvSupervisor = new System.Windows.Forms.DataGridView();
            this.clmnCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSupervisor
            // 
            this.dgvSupervisor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupervisor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnCedula,
            this.clmnNombre,
            this.clmnApellido,
            this.clmnGenero,
            this.clmnTelefono,
            this.clmnCorreo});
            this.dgvSupervisor.Location = new System.Drawing.Point(86, 41);
            this.dgvSupervisor.Name = "dgvSupervisor";
            this.dgvSupervisor.Size = new System.Drawing.Size(643, 347);
            this.dgvSupervisor.TabIndex = 0;
            // 
            // clmnCedula
            // 
            this.clmnCedula.HeaderText = "Cedula";
            this.clmnCedula.Name = "clmnCedula";
            // 
            // clmnNombre
            // 
            this.clmnNombre.HeaderText = "Nombre";
            this.clmnNombre.Name = "clmnNombre";
            this.clmnNombre.ReadOnly = true;
            // 
            // clmnApellido
            // 
            this.clmnApellido.HeaderText = "Apellidos";
            this.clmnApellido.Name = "clmnApellido";
            this.clmnApellido.ReadOnly = true;
            // 
            // clmnGenero
            // 
            this.clmnGenero.HeaderText = "Genero";
            this.clmnGenero.Name = "clmnGenero";
            this.clmnGenero.ReadOnly = true;
            // 
            // clmnTelefono
            // 
            this.clmnTelefono.HeaderText = "Telefono";
            this.clmnTelefono.Name = "clmnTelefono";
            this.clmnTelefono.ReadOnly = true;
            // 
            // clmnCorreo
            // 
            this.clmnCorreo.HeaderText = "Correo";
            this.clmnCorreo.Name = "clmnCorreo";
            this.clmnCorreo.ReadOnly = true;
            // 
            // ConsultarSupervisorBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSupervisor);
            this.Name = "ConsultarSupervisorBD";
            this.Text = "ReceiveSupervisorBD";
            this.Load += new System.EventHandler(this.ConsultarSupervisorBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCorreo;
    }
}