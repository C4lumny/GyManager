namespace GUI.Pureba
{
    partial class ConsultarInscripcion
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
            this.pnlConsultarDGV = new System.Windows.Forms.Panel();
            this.btnRenovar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnPago = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnActualizarInscripcion = new System.Windows.Forms.Button();
            this.dgvInscripcion = new System.Windows.Forms.DataGridView();
            this.clmnIdInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFecha_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFecha_final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPrecios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIdClientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnNombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIdSupervisores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnNombreSupervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPlanN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEstadoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlConsultarDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlConsultarDGV
            // 
            this.pnlConsultarDGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.pnlConsultarDGV.Controls.Add(this.btnRenovar);
            this.pnlConsultarDGV.Controls.Add(this.label1);
            this.pnlConsultarDGV.Controls.Add(this.txtBusqueda);
            this.pnlConsultarDGV.Controls.Add(this.btnPago);
            this.pnlConsultarDGV.Controls.Add(this.btnFactura);
            this.pnlConsultarDGV.Controls.Add(this.textBox1);
            this.pnlConsultarDGV.Controls.Add(this.btnActualizarInscripcion);
            this.pnlConsultarDGV.Controls.Add(this.dgvInscripcion);
            this.pnlConsultarDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsultarDGV.Location = new System.Drawing.Point(0, 0);
            this.pnlConsultarDGV.Name = "pnlConsultarDGV";
            this.pnlConsultarDGV.Size = new System.Drawing.Size(668, 399);
            this.pnlConsultarDGV.TabIndex = 4;
            // 
            // btnRenovar
            // 
            this.btnRenovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRenovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnRenovar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnRenovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenovar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnRenovar.Location = new System.Drawing.Point(149, 333);
            this.btnRenovar.Name = "btnRenovar";
            this.btnRenovar.Size = new System.Drawing.Size(90, 30);
            this.btnRenovar.TabIndex = 15;
            this.btnRenovar.Text = "Renovar";
            this.btnRenovar.UseVisualStyleBackColor = false;
            this.btnRenovar.Click += new System.EventHandler(this.btnRenovar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(31, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Busqueda:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(116, 48);
            this.txtBusqueda.Multiline = true;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(192, 24);
            this.txtBusqueda.TabIndex = 13;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // btnPago
            // 
            this.btnPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnPago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPago.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPago.Location = new System.Drawing.Point(397, 333);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(120, 30);
            this.btnPago.TabIndex = 9;
            this.btnPago.Text = "Realizar pago";
            this.btnPago.UseVisualStyleBackColor = false;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnFactura.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFactura.ForeColor = System.Drawing.SystemColors.Window;
            this.btnFactura.Location = new System.Drawing.Point(534, 333);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(103, 30);
            this.btnFactura.TabIndex = 7;
            this.btnFactura.Text = "Imprimir factura";
            this.btnFactura.UseVisualStyleBackColor = false;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Location = new System.Drawing.Point(32, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 6;
            // 
            // btnActualizarInscripcion
            // 
            this.btnActualizarInscripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizarInscripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnActualizarInscripcion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnActualizarInscripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarInscripcion.ForeColor = System.Drawing.SystemColors.Window;
            this.btnActualizarInscripcion.Location = new System.Drawing.Point(34, 333);
            this.btnActualizarInscripcion.Name = "btnActualizarInscripcion";
            this.btnActualizarInscripcion.Size = new System.Drawing.Size(90, 30);
            this.btnActualizarInscripcion.TabIndex = 5;
            this.btnActualizarInscripcion.Text = "Actualizar";
            this.btnActualizarInscripcion.UseVisualStyleBackColor = false;
            this.btnActualizarInscripcion.Click += new System.EventHandler(this.btnActualizarInscripcion_Click);
            // 
            // dgvInscripcion
            // 
            this.dgvInscripcion.AllowUserToAddRows = false;
            this.dgvInscripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInscripcion.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.dgvInscripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInscripcion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvInscripcion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInscripcion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInscripcion.ColumnHeadersHeight = 40;
            this.dgvInscripcion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnIdInscripcion,
            this.clmnFecha_Inicio,
            this.clmFecha_final,
            this.clmnPrecios,
            this.clmnIdClientes,
            this.clmnNombreCliente,
            this.clmnIdSupervisores,
            this.clmnNombreSupervisor,
            this.clmnPlanN,
            this.clmnEstadoPago});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInscripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInscripcion.EnableHeadersVisualStyles = false;
            this.dgvInscripcion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.dgvInscripcion.Location = new System.Drawing.Point(32, 91);
            this.dgvInscripcion.Name = "dgvInscripcion";
            this.dgvInscripcion.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInscripcion.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInscripcion.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            this.dgvInscripcion.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInscripcion.RowTemplate.Height = 30;
            this.dgvInscripcion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInscripcion.Size = new System.Drawing.Size(605, 213);
            this.dgvInscripcion.TabIndex = 3;
            this.dgvInscripcion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInscripcion_CellClick);
            // 
            // clmnIdInscripcion
            // 
            this.clmnIdInscripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnIdInscripcion.HeaderText = "ID";
            this.clmnIdInscripcion.Name = "clmnIdInscripcion";
            this.clmnIdInscripcion.ReadOnly = true;
            // 
            // clmnFecha_Inicio
            // 
            this.clmnFecha_Inicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnFecha_Inicio.HeaderText = "Fecha de Inicio";
            this.clmnFecha_Inicio.Name = "clmnFecha_Inicio";
            this.clmnFecha_Inicio.ReadOnly = true;
            // 
            // clmFecha_final
            // 
            this.clmFecha_final.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmFecha_final.HeaderText = "Fecha final";
            this.clmFecha_final.Name = "clmFecha_final";
            this.clmFecha_final.ReadOnly = true;
            // 
            // clmnPrecios
            // 
            this.clmnPrecios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPrecios.HeaderText = "Precio";
            this.clmnPrecios.Name = "clmnPrecios";
            this.clmnPrecios.ReadOnly = true;
            // 
            // clmnIdClientes
            // 
            this.clmnIdClientes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnIdClientes.HeaderText = "Id Cliente";
            this.clmnIdClientes.Name = "clmnIdClientes";
            this.clmnIdClientes.ReadOnly = true;
            // 
            // clmnNombreCliente
            // 
            this.clmnNombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnNombreCliente.HeaderText = "Nombre completo C";
            this.clmnNombreCliente.Name = "clmnNombreCliente";
            this.clmnNombreCliente.ReadOnly = true;
            // 
            // clmnIdSupervisores
            // 
            this.clmnIdSupervisores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnIdSupervisores.HeaderText = "Id Supervisor";
            this.clmnIdSupervisores.Name = "clmnIdSupervisores";
            this.clmnIdSupervisores.ReadOnly = true;
            // 
            // clmnNombreSupervisor
            // 
            this.clmnNombreSupervisor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnNombreSupervisor.HeaderText = "Nombre completo S";
            this.clmnNombreSupervisor.Name = "clmnNombreSupervisor";
            this.clmnNombreSupervisor.ReadOnly = true;
            // 
            // clmnPlanN
            // 
            this.clmnPlanN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPlanN.HeaderText = "Plan";
            this.clmnPlanN.Name = "clmnPlanN";
            this.clmnPlanN.ReadOnly = true;
            // 
            // clmnEstadoPago
            // 
            this.clmnEstadoPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnEstadoPago.HeaderText = "Estado";
            this.clmnEstadoPago.Name = "clmnEstadoPago";
            this.clmnEstadoPago.ReadOnly = true;
            // 
            // ConsultarInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 399);
            this.Controls.Add(this.pnlConsultarDGV);
            this.Name = "ConsultarInscripcion";
            this.Text = "ReceiveInscripcionBD";
            this.Load += new System.EventHandler(this.ConsultarInscripcionBD_Load);
            this.pnlConsultarDGV.ResumeLayout(false);
            this.pnlConsultarDGV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConsultarDGV;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnActualizarInscripcion;
        private System.Windows.Forms.DataGridView dgvInscripcion;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFecha_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha_final;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdSupervisores;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombreSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPlanN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEstadoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnRenovar;
    }
}