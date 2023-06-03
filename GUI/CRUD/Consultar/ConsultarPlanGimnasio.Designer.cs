namespace GUI.Pureba
{
    partial class ConsultarPlanGimnasio
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
            this.dgvPlanGimnasio = new System.Windows.Forms.DataGridView();
            this.clmnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanGimnasio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlanGimnasio
            // 
            this.dgvPlanGimnasio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanGimnasio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnNombre,
            this.clmnPrecio,
            this.clmnDias});
            this.dgvPlanGimnasio.Location = new System.Drawing.Point(252, 12);
            this.dgvPlanGimnasio.Name = "dgvPlanGimnasio";
            this.dgvPlanGimnasio.Size = new System.Drawing.Size(343, 411);
            this.dgvPlanGimnasio.TabIndex = 0;
            // 
            // clmnNombre
            // 
            this.clmnNombre.HeaderText = "Nombre";
            this.clmnNombre.Name = "clmnNombre";
            // 
            // clmnPrecio
            // 
            this.clmnPrecio.HeaderText = "Precio";
            this.clmnPrecio.Name = "clmnPrecio";
            // 
            // clmnDias
            // 
            this.clmnDias.HeaderText = "Dias";
            this.clmnDias.Name = "clmnDias";
            // 
            // ConsultarPlanGimnasioBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPlanGimnasio);
            this.Name = "ConsultarPlanGimnasioBD";
            this.Text = "ReceivePlanGimnasioBD";
            this.Load += new System.EventHandler(this.ConsultarPlanGimnasioBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanGimnasio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanGimnasio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDias;
    }
}