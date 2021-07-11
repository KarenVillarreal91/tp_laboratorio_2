
namespace FormFabrica
{
    partial class FormMouse
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
            this.nUDCantBtn = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCantBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // nUDCantBtn
            // 
            this.nUDCantBtn.Location = new System.Drawing.Point(50, 212);
            this.nUDCantBtn.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nUDCantBtn.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDCantBtn.Name = "nUDCantBtn";
            this.nUDCantBtn.Size = new System.Drawing.Size(120, 20);
            this.nUDCantBtn.TabIndex = 14;
            this.nUDCantBtn.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Cantidad de botones";
            // 
            // FormMouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 294);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nUDCantBtn);
            this.Name = "FormMouse";
            this.Text = "Mouse";
            this.Controls.SetChildIndex(this.nUDCantBtn, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nUDCantBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUDCantBtn;
        private System.Windows.Forms.Label label5;
    }
}