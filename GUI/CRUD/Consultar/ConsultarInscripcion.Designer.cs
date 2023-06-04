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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnActualizarCliente = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvInscripcion = new System.Windows.Forms.DataGridView();
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
            this.pnlConsultarDGV.Controls.Add(this.textBox1);
            this.pnlConsultarDGV.Controls.Add(this.btnActualizarCliente);
            this.pnlConsultarDGV.Controls.Add(this.btnEliminar);
            this.pnlConsultarDGV.Controls.Add(this.dgvInscripcion);
            this.pnlConsultarDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsultarDGV.Location = new System.Drawing.Point(0, 0);
            this.pnlConsultarDGV.Name = "pnlConsultarDGV";
            this.pnlConsultarDGV.Size = new System.Drawing.Size(668, 399);
            this.pnlConsultarDGV.TabIndex = 4;
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
            // btnActualizarCliente
            // 
            this.btnActualizarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnActualizarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnActualizarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarCliente.ForeColor = System.Drawing.SystemColors.Window;
            this.btnActualizarCliente.Location = new System.Drawing.Point(151, 333);
            this.btnActualizarCliente.Name = "btnActualizarCliente";
            this.btnActualizarCliente.Size = new System.Drawing.Size(90, 30);
            this.btnActualizarCliente.TabIndex = 5;
            this.btnActualizarCliente.Text = "Actualizar";
            this.btnActualizarCliente.UseVisualStyleBackColor = false;
            this.btnActualizarCliente.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Info;
            this.btnEliminar.Location = new System.Drawing.Point(32, 333);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // 
            // clmnFecha_Inicio
            // 
            this.clmnFecha_Inicio.HeaderText = "Fecha de Inicio";
            this.clmnFecha_Inicio.Name = "clmnFecha_Inicio";
            this.clmnFecha_Inicio.ReadOnly = true;
            // 
            // clmFecha_final
            // 
            this.clmFecha_final.HeaderText = "Fecha final";
            this.clmFecha_final.Name = "clmFecha_final";
            this.clmFecha_final.ReadOnly = true;
            // 
            // clmnPrecios
            // 
            this.clmnPrecios.HeaderText = "Precio";
            this.clmnPrecios.Name = "clmnPrecios";
            this.clmnPrecios.ReadOnly = true;
            // 
            // clmnIdClientes
            // 
            this.clmnIdClientes.HeaderText = "Id Cliente";
            this.clmnIdClientes.Name = "clmnIdClientes";
            this.clmnIdClientes.ReadOnly = true;
            // 
            // clmnNombreCliente
            // 
            this.clmnNombreCliente.HeaderText = "Nombre completo C";
            this.clmnNombreCliente.Name = "clmnNombreCliente";
            this.clmnNombreCliente.ReadOnly = true;
            // 
            // clmnIdSupervisores
            // 
            this.clmnIdSupervisores.HeaderText = "Id Supervisor";
            this.clmnIdSupervisores.Name = "clmnIdSupervisores";
            this.clmnIdSupervisores.ReadOnly = true;
            // 
            // clmnNombreSupervisor
            // 
            this.clmnNombreSupervisor.HeaderText = "Nombre completo S";
            this.clmnNombreSupervisor.Name = "clmnNombreSupervisor";
            this.clmnNombreSupervisor.ReadOnly = true;
            // 
            // clmnPlanN
            // 
            this.clmnPlanN.HeaderText = "Plan";
            this.clmnPlanN.Name = "clmnPlanN";
            this.clmnPlanN.ReadOnly = true;
            // 
            // clmnEstadoPago
            // 
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
        private System.Windows.Forms.Button btnActualizarCliente;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFecha_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha_final;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdSupervisores;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombreSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPlanN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEstadoPago;
    }
}