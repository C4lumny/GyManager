namespace GUI.Pureba
{
    partial class ConsultarPagoBD
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
            this.clmnValorIngresado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIDInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnValorIngresado,
            this.clmnFechaPago,
            this.clmnIDInscripcion});
            this.dataGridView1.Location = new System.Drawing.Point(231, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(346, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // clmnValorIngresado
            // 
            this.clmnValorIngresado.HeaderText = "Valor Ingresado";
            this.clmnValorIngresado.Name = "clmnValorIngresado";
            // 
            // clmnFechaPago
            // 
            this.clmnFechaPago.HeaderText = "Fecha Pago";
            this.clmnFechaPago.Name = "clmnFechaPago";
            // 
            // clmnIDInscripcion
            // 
            this.clmnIDInscripcion.HeaderText = "ID Inscripcion";
            this.clmnIDInscripcion.Name = "clmnIDInscripcion";
            // 
            // ReceivePagosBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReceivePagosBD";
            this.Text = "ReceivePagosBD";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnValorIngresado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIDInscripcion;
    }
}