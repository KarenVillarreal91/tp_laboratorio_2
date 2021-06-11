
namespace FormFabrica
{
    partial class FormTeclado
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
            this.cmbTeclas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTeclas
            // 
            this.cmbTeclas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeclas.FormattingEnabled = true;
            this.cmbTeclas.Location = new System.Drawing.Point(50, 212);
            this.cmbTeclas.Name = "cmbTeclas";
            this.cmbTeclas.Size = new System.Drawing.Size(121, 21);
            this.cmbTeclas.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Teclas";
            // 
            // FormTeclado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 294);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTeclas);
            this.Name = "FormTeclado";
            this.Text = "Teclado";
            this.Controls.SetChildIndex(this.cmbTeclas, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ComboBox cmbTeclas;
        private System.Windows.Forms.Label label5;
    }
}