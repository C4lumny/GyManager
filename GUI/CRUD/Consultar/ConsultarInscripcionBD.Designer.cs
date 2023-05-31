namespace GUI.Pureba
{
    partial class ConsultarInscripcionBD
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
            this.dgvInscripcion = new System.Windows.Forms.DataGridView();
            this.clmFecha_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFechaFInal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIdSupervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEstadoPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInscripcion
            // 
            this.dgvInscripcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripcion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmFecha_Inicio,
            this.clmnFechaFInal,
            this.clmnPrecio,
            this.clmnIdCliente,
            this.clmnIdSupervisor,
            this.clmnPlan,
            this.clmnEstadoPlan});
            this.dgvInscripcion.Location = new System.Drawing.Point(12, 12);
            this.dgvInscripcion.Name = "dgvInscripcion";
            this.dgvInscripcion.Size = new System.Drawing.Size(744, 426);
            this.dgvInscripcion.TabIndex = 0;
            // 
            // clmFecha_Inicio
            // 
            this.clmFecha_Inicio.HeaderText = "Fecha_Inicio";
            this.clmFecha_Inicio.Name = "clmFecha_Inicio";
            // 
            // clmnFechaFInal
            // 
            this.clmnFechaFInal.HeaderText = "Fecha Final";
            this.clmnFechaFInal.Name = "clmnFechaFInal";
            this.clmnFechaFInal.ReadOnly = true;
            // 
            // clmnPrecio
            // 
            this.clmnPrecio.HeaderText = "Precio";
            this.clmnPrecio.Name = "clmnPrecio";
            // 
            // clmnIdCliente
            // 
            this.clmnIdCliente.HeaderText = "Id C";
            this.clmnIdCliente.Name = "clmnIdCliente";
            // 
            // clmnIdSupervisor
            // 
            this.clmnIdSupervisor.HeaderText = "Id S";
            this.clmnIdSupervisor.Name = "clmnIdSupervisor";
            // 
            // clmnPlan
            // 
            this.clmnPlan.HeaderText = "Plan";
            this.clmnPlan.Name = "clmnPlan";
            // 
            // clmnEstadoPlan
            // 
            this.clmnEstadoPlan.HeaderText = "Estado";
            this.clmnEstadoPlan.Name = "clmnEstadoPlan";
            this.clmnEstadoPlan.ReadOnly = true;
            // 
            // ConsultarInscripcionBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 450);
            this.Controls.Add(this.dgvInscripcion);
            this.Name = "ConsultarInscripcionBD";
            this.Text = "ReceiveInscripcionBD";
            this.Load += new System.EventHandler(this.ConsultarInscripcionBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFechaFInal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEstadoPlan;
    }
}