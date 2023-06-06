namespace GUI.Pureba
{
    partial class ConsultarHistorialBiomedico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dgvHistorialBiomedico = new System.Windows.Forms.DataGridView();
            this.clmnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnAltura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnGrasaCorporal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFrecuenciaCardiaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPresionArterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialBiomedico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBusqueda);
            this.panel1.Controls.Add(this.dgvHistorialBiomedico);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 399);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Busqueda:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(101, 49);
            this.txtBusqueda.Multiline = true;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(192, 24);
            this.txtBusqueda.TabIndex = 17;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // dgvHistorialBiomedico
            // 
            this.dgvHistorialBiomedico.AllowUserToAddRows = false;
            this.dgvHistorialBiomedico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialBiomedico.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.dgvHistorialBiomedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialBiomedico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHistorialBiomedico.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialBiomedico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorialBiomedico.ColumnHeadersHeight = 40;
            this.dgvHistorialBiomedico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnId,
            this.clmFechaRegistro,
            this.clmnCliente,
            this.clmnAltura,
            this.clmnPeso,
            this.clmCategoria,
            this.clmnIMC,
            this.clmnGrasaCorporal,
            this.clmnFrecuenciaCardiaca,
            this.clmnPresionArterial});
            this.dgvHistorialBiomedico.EnableHeadersVisualStyles = false;
            this.dgvHistorialBiomedico.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.dgvHistorialBiomedico.Location = new System.Drawing.Point(19, 96);
            this.dgvHistorialBiomedico.Name = "dgvHistorialBiomedico";
            this.dgvHistorialBiomedico.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            this.dgvHistorialBiomedico.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorialBiomedico.RowTemplate.Height = 30;
            this.dgvHistorialBiomedico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHistorialBiomedico.Size = new System.Drawing.Size(632, 241);
            this.dgvHistorialBiomedico.TabIndex = 5;
            // 
            // clmnId
            // 
            this.clmnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnId.HeaderText = "ID";
            this.clmnId.Name = "clmnId";
            // 
            // clmFechaRegistro
            // 
            this.clmFechaRegistro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmFechaRegistro.HeaderText = "Fecha Registro";
            this.clmFechaRegistro.Name = "clmFechaRegistro";
            // 
            // clmnCliente
            // 
            this.clmnCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnCliente.HeaderText = "Cliente";
            this.clmnCliente.Name = "clmnCliente";
            // 
            // clmnAltura
            // 
            this.clmnAltura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnAltura.HeaderText = "Altura";
            this.clmnAltura.Name = "clmnAltura";
            // 
            // clmnPeso
            // 
            this.clmnPeso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPeso.HeaderText = "Peso";
            this.clmnPeso.Name = "clmnPeso";
            // 
            // clmCategoria
            // 
            this.clmCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCategoria.HeaderText = "Categoria de peso";
            this.clmCategoria.Name = "clmCategoria";
            // 
            // clmnIMC
            // 
            this.clmnIMC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnIMC.HeaderText = "IMC";
            this.clmnIMC.Name = "clmnIMC";
            // 
            // clmnGrasaCorporal
            // 
            this.clmnGrasaCorporal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnGrasaCorporal.HeaderText = "Grasa Corporal(%)";
            this.clmnGrasaCorporal.Name = "clmnGrasaCorporal";
            // 
            // clmnFrecuenciaCardiaca
            // 
            this.clmnFrecuenciaCardiaca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnFrecuenciaCardiaca.HeaderText = "Frecuencia Cardiaca";
            this.clmnFrecuenciaCardiaca.Name = "clmnFrecuenciaCardiaca";
            // 
            // clmnPresionArterial
            // 
            this.clmnPresionArterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPresionArterial.HeaderText = "Presion Arterial";
            this.clmnPresionArterial.Name = "clmnPresionArterial";
            // 
            // ConsultarHistorialBiomedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 399);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultarHistorialBiomedico";
            this.Text = "Historial Biomedico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialBiomedico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvHistorialBiomedico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnAltura;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnGrasaCorporal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFrecuenciaCardiaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPresionArterial;
    }
}