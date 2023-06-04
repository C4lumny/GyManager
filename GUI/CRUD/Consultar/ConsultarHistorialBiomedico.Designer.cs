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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHistorialBiomedico = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAltura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnGrasaCorporal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFrecuenciaCardiaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPresionArterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDatosBiomedicos = new System.Windows.Forms.DataGridView();
            this.clmFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnAltura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialBiomedico)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosBiomedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialBiomedico
            // 
            this.dgvHistorialBiomedico.AllowUserToAddRows = false;
            this.dgvHistorialBiomedico.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.dgvHistorialBiomedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialBiomedico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHistorialBiomedico.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialBiomedico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorialBiomedico.ColumnHeadersHeight = 40;
            this.dgvHistorialBiomedico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmnCliente,
            this.clmAltura,
            this.clmnPrecio,
            this.clmnIMC,
            this.clmnGrasaCorporal,
            this.clmnFrecuenciaCardiaca,
            this.clmnPresionArterial});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorialBiomedico.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorialBiomedico.EnableHeadersVisualStyles = false;
            this.dgvHistorialBiomedico.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.dgvHistorialBiomedico.Location = new System.Drawing.Point(32, 52);
            this.dgvHistorialBiomedico.Name = "dgvHistorialBiomedico";
            this.dgvHistorialBiomedico.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialBiomedico.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistorialBiomedico.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            this.dgvHistorialBiomedico.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistorialBiomedico.RowTemplate.Height = 30;
            this.dgvHistorialBiomedico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHistorialBiomedico.Size = new System.Drawing.Size(605, 242);
            this.dgvHistorialBiomedico.TabIndex = 4;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Width = 72;
            // 
            // clmnCliente
            // 
            this.clmnCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnCliente.HeaderText = "Cliente";
            this.clmnCliente.Name = "clmnCliente";
            this.clmnCliente.ReadOnly = true;
            // 
            // clmAltura
            // 
            this.clmAltura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmAltura.HeaderText = "Altura";
            this.clmAltura.Name = "clmAltura";
            this.clmAltura.ReadOnly = true;
            // 
            // clmnPrecio
            // 
            this.clmnPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPrecio.HeaderText = "Precio";
            this.clmnPrecio.Name = "clmnPrecio";
            this.clmnPrecio.ReadOnly = true;
            // 
            // clmnIMC
            // 
            this.clmnIMC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnIMC.HeaderText = "IMC";
            this.clmnIMC.Name = "clmnIMC";
            this.clmnIMC.ReadOnly = true;
            // 
            // clmnGrasaCorporal
            // 
            this.clmnGrasaCorporal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnGrasaCorporal.HeaderText = "Grasa Corporal";
            this.clmnGrasaCorporal.Name = "clmnGrasaCorporal";
            this.clmnGrasaCorporal.ReadOnly = true;
            // 
            // clmnFrecuenciaCardiaca
            // 
            this.clmnFrecuenciaCardiaca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnFrecuenciaCardiaca.HeaderText = "Frecuencia Cardiaca";
            this.clmnFrecuenciaCardiaca.Name = "clmnFrecuenciaCardiaca";
            this.clmnFrecuenciaCardiaca.ReadOnly = true;
            // 
            // clmnPresionArterial
            // 
            this.clmnPresionArterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPresionArterial.HeaderText = "Presion Arterial";
            this.clmnPresionArterial.Name = "clmnPresionArterial";
            this.clmnPresionArterial.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.dgvDatosBiomedicos);
            this.panel1.Controls.Add(this.dgvHistorialBiomedico);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 399);
            this.panel1.TabIndex = 5;
            // 
            // dgvDatosBiomedicos
            // 
            this.dgvDatosBiomedicos.AllowUserToAddRows = false;
            this.dgvDatosBiomedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatosBiomedicos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.dgvDatosBiomedicos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatosBiomedicos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDatosBiomedicos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatosBiomedicos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDatosBiomedicos.ColumnHeadersHeight = 40;
            this.dgvDatosBiomedicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmFechaRegistro,
            this.dataGridViewTextBoxColumn1,
            this.clmnAltura,
            this.clmnPeso,
            this.clmCategoria,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvDatosBiomedicos.EnableHeadersVisualStyles = false;
            this.dgvDatosBiomedicos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.dgvDatosBiomedicos.Location = new System.Drawing.Point(21, 109);
            this.dgvDatosBiomedicos.Name = "dgvDatosBiomedicos";
            this.dgvDatosBiomedicos.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            this.dgvDatosBiomedicos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatosBiomedicos.RowTemplate.Height = 30;
            this.dgvDatosBiomedicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDatosBiomedicos.Size = new System.Drawing.Size(644, 241);
            this.dgvDatosBiomedicos.TabIndex = 5;
            // 
            // clmFechaRegistro
            // 
            this.clmFechaRegistro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmFechaRegistro.HeaderText = "Fecha Registro";
            this.clmFechaRegistro.Name = "clmFechaRegistro";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
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
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "IMC";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Grasa Corporal(%)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Frecuencia Cardiaca";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Presion Arterial";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // ConsultarHistorialBiomedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 399);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultarHistorialBiomedico";
            this.Text = "Historial Biomedico";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialBiomedico)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosBiomedicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialBiomedico;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAltura;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnGrasaCorporal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFrecuenciaCardiaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPresionArterial;
        private System.Windows.Forms.DataGridView dgvDatosBiomedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnAltura;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}