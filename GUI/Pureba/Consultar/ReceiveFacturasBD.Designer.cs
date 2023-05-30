namespace GUI.Pureba
{
    partial class ReceiveFacturasBD
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
            this.clmnPagoIngresado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIdInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnPagoIngresado,
            this.clmnSubtotal,
            this.clmnSaldo,
            this.clmnIdInscripcion});
            this.dataGridView1.Location = new System.Drawing.Point(165, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(445, 367);
            this.dataGridView1.TabIndex = 0;
            // 
            // clmnPagoIngresado
            // 
            this.clmnPagoIngresado.HeaderText = "Pago Ingresado";
            this.clmnPagoIngresado.Name = "clmnPagoIngresado";
            this.clmnPagoIngresado.ReadOnly = true;
            // 
            // clmnSubtotal
            // 
            this.clmnSubtotal.HeaderText = "Subtotal";
            this.clmnSubtotal.Name = "clmnSubtotal";
            this.clmnSubtotal.ReadOnly = true;
            // 
            // clmnSaldo
            // 
            this.clmnSaldo.HeaderText = "Saldo";
            this.clmnSaldo.Name = "clmnSaldo";
            this.clmnSaldo.ReadOnly = true;
            // 
            // clmnIdInscripcion
            // 
            this.clmnIdInscripcion.HeaderText = "ID Inscripcion";
            this.clmnIdInscripcion.Name = "clmnIdInscripcion";
            this.clmnIdInscripcion.ReadOnly = true;
            // 
            // ReceiveFacturasBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReceiveFacturasBD";
            this.Text = "ReceiveFacturasBD";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPagoIngresado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdInscripcion;
    }
}