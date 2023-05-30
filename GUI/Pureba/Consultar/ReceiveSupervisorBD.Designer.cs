namespace GUI.Pureba
{
    partial class ReceiveSupervisorBD
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
            this.clmnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnNombre,
            this.clmnApellido,
            this.clmnGenero,
            this.clmnTelefono,
            this.clmnCorreo});
            this.dataGridView1.Location = new System.Drawing.Point(116, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 347);
            this.dataGridView1.TabIndex = 0;
            // 
            // clmnNombre
            // 
            this.clmnNombre.HeaderText = "Nombre";
            this.clmnNombre.Name = "clmnNombre";
            this.clmnNombre.ReadOnly = true;
            // 
            // clmnApellido
            // 
            this.clmnApellido.HeaderText = "Apellidos";
            this.clmnApellido.Name = "clmnApellido";
            this.clmnApellido.ReadOnly = true;
            // 
            // clmnGenero
            // 
            this.clmnGenero.HeaderText = "Genero";
            this.clmnGenero.Name = "clmnGenero";
            this.clmnGenero.ReadOnly = true;
            // 
            // clmnTelefono
            // 
            this.clmnTelefono.HeaderText = "Telefono";
            this.clmnTelefono.Name = "clmnTelefono";
            this.clmnTelefono.ReadOnly = true;
            // 
            // clmnCorreo
            // 
            this.clmnCorreo.HeaderText = "Correo";
            this.clmnCorreo.Name = "clmnCorreo";
            this.clmnCorreo.ReadOnly = true;
            // 
            // ReceiveSupervisorBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReceiveSupervisorBD";
            this.Text = "ReceiveSupervisorBD";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCorreo;
    }
}