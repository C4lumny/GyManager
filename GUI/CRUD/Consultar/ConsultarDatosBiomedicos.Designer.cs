namespace GUI.Pureba
{
    partial class ConsultarDatosBiomedicos
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
            this.clmFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnAltura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnGrasaCorporal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFrecuenciaCardiaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPresionArterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmFechaRegistro,
            this.clmnCliente,
            this.clmnAltura,
            this.clmnPeso,
            this.clmCategoria,
            this.clmnIMC,
            this.clmnGrasaCorporal,
            this.clmnFrecuenciaCardiaca,
            this.clmnPresionArterial});
            this.dataGridView1.Location = new System.Drawing.Point(34, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(943, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // clmFechaRegistro
            // 
            this.clmFechaRegistro.HeaderText = "Fecha Registro";
            this.clmFechaRegistro.Name = "clmFechaRegistro";
            // 
            // clmnCliente
            // 
            this.clmnCliente.HeaderText = "Cliente";
            this.clmnCliente.Name = "clmnCliente";
            // 
            // clmnAltura
            // 
            this.clmnAltura.HeaderText = "Altura";
            this.clmnAltura.Name = "clmnAltura";
            // 
            // clmnPeso
            // 
            this.clmnPeso.HeaderText = "Peso";
            this.clmnPeso.Name = "clmnPeso";
            // 
            // clmCategoria
            // 
            this.clmCategoria.HeaderText = "Categoria de peso";
            this.clmCategoria.Name = "clmCategoria";
            // 
            // clmnIMC
            // 
            this.clmnIMC.HeaderText = "IMC";
            this.clmnIMC.Name = "clmnIMC";
            // 
            // clmnGrasaCorporal
            // 
            this.clmnGrasaCorporal.HeaderText = "Grasa Corporal(%)";
            this.clmnGrasaCorporal.Name = "clmnGrasaCorporal";
            // 
            // clmnFrecuenciaCardiaca
            // 
            this.clmnFrecuenciaCardiaca.HeaderText = "Frecuencia Cardiaca";
            this.clmnFrecuenciaCardiaca.Name = "clmnFrecuenciaCardiaca";
            // 
            // clmnPresionArterial
            // 
            this.clmnPresionArterial.HeaderText = "Presion Arterial";
            this.clmnPresionArterial.Name = "clmnPresionArterial";
            // 
            // ConsultarDatosBiomedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 506);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ConsultarDatosBiomedicos";
            this.Text = "ReceiveDatosBiomedicosBD";
            this.Load += new System.EventHandler(this.ConsultarDatosBiomedicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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