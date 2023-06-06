namespace GUI.Imprimir
{
    partial class Impresion
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.btnImpresion = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(220, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(58, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escoja su\r\nmetodo de impresion :";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.btnImpresion);
            this.panel.Controls.Add(this.comboBox1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(457, 203);
            this.panel.TabIndex = 3;
            // 
            // btnImpresion
            // 
            this.btnImpresion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImpresion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(136)))), ((int)(((byte)(158)))));
            this.btnImpresion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(194)))));
            this.btnImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImpresion.ForeColor = System.Drawing.SystemColors.Window;
            this.btnImpresion.Location = new System.Drawing.Point(177, 123);
            this.btnImpresion.Name = "btnImpresion";
            this.btnImpresion.Size = new System.Drawing.Size(90, 30);
            this.btnImpresion.TabIndex = 28;
            this.btnImpresion.Text = "Actualizar";
            this.btnImpresion.UseVisualStyleBackColor = false;
            this.btnImpresion.Click += new System.EventHandler(this.btnImpresion_Click);
            // 
            // Impresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 203);
            this.Controls.Add(this.panel);
            this.Name = "Impresion";
            this.Text = "Impresion";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnImpresion;
    }
}