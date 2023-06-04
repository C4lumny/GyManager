namespace GUI.Pureba
{
    partial class ConsultarHistorialFactura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHistorialFactura = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clmnPagoIngresado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIdInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialFactura)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHistorialFactura
            // 
            this.dgvHistorialFactura.AllowUserToAddRows = false;
            this.dgvHistorialFactura.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.dgvHistorialFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialFactura.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHistorialFactura.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorialFactura.ColumnHeadersHeight = 40;
            this.dgvHistorialFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnPagoIngresado,
            this.clmSubtotal,
            this.clmnSaldo,
            this.clmnIdInscripcion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorialFactura.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorialFactura.EnableHeadersVisualStyles = false;
            this.dgvHistorialFactura.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.dgvHistorialFactura.Location = new System.Drawing.Point(34, 106);
            this.dgvHistorialFactura.Name = "dgvHistorialFactura";
            this.dgvHistorialFactura.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialFactura.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistorialFactura.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            this.dgvHistorialFactura.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistorialFactura.RowTemplate.Height = 30;
            this.dgvHistorialFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHistorialFactura.Size = new System.Drawing.Size(605, 242);
            this.dgvHistorialFactura.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.dgvHistorialFactura);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 399);
            this.panel1.TabIndex = 6;
            // 
            // clmnPagoIngresado
            // 
            this.clmnPagoIngresado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPagoIngresado.HeaderText = "Pago Ingresado";
            this.clmnPagoIngresado.Name = "clmnPagoIngresado";
            this.clmnPagoIngresado.ReadOnly = true;
            // 
            // clmSubtotal
            // 
            this.clmSubtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSubtotal.HeaderText = "Subtotal";
            this.clmSubtotal.Name = "clmSubtotal";
            this.clmSubtotal.ReadOnly = true;
            // 
            // clmnSaldo
            // 
            this.clmnSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnSaldo.HeaderText = "Saldo";
            this.clmnSaldo.Name = "clmnSaldo";
            this.clmnSaldo.ReadOnly = true;
            // 
            // clmnIdInscripcion
            // 
            this.clmnIdInscripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnIdInscripcion.HeaderText = "ID Inscripcion";
            this.clmnIdInscripcion.Name = "clmnIdInscripcion";
            this.clmnIdInscripcion.ReadOnly = true;
            // 
            // ConsultarHistorialFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 399);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultarHistorialFactura";
            this.Text = "ReceiveHistorialFacturaBD";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialFactura)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialFactura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPagoIngresado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdInscripcion;
    }
}