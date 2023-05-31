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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmnFechaFInal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnNombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIdSupervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnNombreSupervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEstadoPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnFechaFInal,
            this.clmnPrecio,
            this.clmnIdCliente,
            this.clmnNombreCliente,
            this.clmnIdSupervisor,
            this.clmnNombreSupervisor,
            this.clmnPlan,
            this.clmnEstadoPlan,
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(844, 426);
            this.dataGridView1.TabIndex = 0;
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
            // clmnNombreCliente
            // 
            this.clmnNombreCliente.HeaderText = "Nombre C";
            this.clmnNombreCliente.Name = "clmnNombreCliente";
            // 
            // clmnIdSupervisor
            // 
            this.clmnIdSupervisor.HeaderText = "Id S";
            this.clmnIdSupervisor.Name = "clmnIdSupervisor";
            // 
            // clmnNombreSupervisor
            // 
            this.clmnNombreSupervisor.HeaderText = "Nombre S";
            this.clmnNombreSupervisor.Name = "clmnNombreSupervisor";
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
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ReceiveInscripcionBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReceiveInscripcionBD";
            this.Text = "ReceiveInscripcionBD";
            this.Load += new System.EventHandler(this.ReceiveInscripcionBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFechaFInal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombreSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEstadoPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}