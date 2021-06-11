
namespace FormFabrica
{
    partial class frmFabrica
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLeerXml = new System.Windows.Forms.Button();
            this.btnEscribirXml = new System.Windows.Forms.Button();
            this.btnDesechar = new System.Windows.Forms.Button();
            this.lstVisor = new System.Windows.Forms.ListBox();
            this.cmbFabricar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDefectuoso = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCambiarNombre = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLeerXml
            // 
            this.btnLeerXml.Location = new System.Drawing.Point(6, 19);
            this.btnLeerXml.Name = "btnLeerXml";
            this.btnLeerXml.Size = new System.Drawing.Size(108, 27);
            this.btnLeerXml.TabIndex = 2;
            this.btnLeerXml.Text = "Cargar";
            this.btnLeerXml.UseVisualStyleBackColor = true;
            this.btnLeerXml.Click += new System.EventHandler(this.btnLeerXml_Click);
            // 
            // btnEscribirXml
            // 
            this.btnEscribirXml.Location = new System.Drawing.Point(122, 19);
            this.btnEscribirXml.Name = "btnEscribirXml";
            this.btnEscribirXml.Size = new System.Drawing.Size(108, 27);
            this.btnEscribirXml.TabIndex = 4;
            this.btnEscribirXml.Text = "Guardar";
            this.btnEscribirXml.UseVisualStyleBackColor = true;
            this.btnEscribirXml.Click += new System.EventHandler(this.btnEscribirXml_Click);
            // 
            // btnDesechar
            // 
            this.btnDesechar.BackColor = System.Drawing.Color.Transparent;
            this.btnDesechar.Enabled = false;
            this.btnDesechar.ForeColor = System.Drawing.Color.Black;
            this.btnDesechar.Location = new System.Drawing.Point(744, 317);
            this.btnDesechar.Name = "btnDesechar";
            this.btnDesechar.Size = new System.Drawing.Size(108, 27);
            this.btnDesechar.TabIndex = 7;
            this.btnDesechar.Text = "Desechar";
            this.btnDesechar.UseVisualStyleBackColor = false;
            this.btnDesechar.Click += new System.EventHandler(this.btnDesechar_Click);
            // 
            // lstVisor
            // 
            this.lstVisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVisor.BackColor = System.Drawing.Color.Azure;
            this.lstVisor.ColumnWidth = 300;
            this.lstVisor.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVisor.FormattingEnabled = true;
            this.lstVisor.HorizontalScrollbar = true;
            this.lstVisor.ItemHeight = 16;
            this.lstVisor.Location = new System.Drawing.Point(12, 28);
            this.lstVisor.Name = "lstVisor";
            this.lstVisor.Size = new System.Drawing.Size(840, 260);
            this.lstVisor.TabIndex = 8;
            this.lstVisor.SelectedIndexChanged += new System.EventHandler(this.lstVisor_SelectedIndexChanged);
            // 
            // cmbFabricar
            // 
            this.cmbFabricar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFabricar.FormattingEnabled = true;
            this.cmbFabricar.Items.AddRange(new object[] {
            "Mouse",
            "Teclado",
            "Auricular"});
            this.cmbFabricar.Location = new System.Drawing.Point(290, 324);
            this.cmbFabricar.Name = "cmbFabricar";
            this.cmbFabricar.Size = new System.Drawing.Size(121, 21);
            this.cmbFabricar.TabIndex = 9;
            this.cmbFabricar.SelectedIndexChanged += new System.EventHandler(this.cmbFabricar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fabricar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Listado:";
            // 
            // cmbDefectuoso
            // 
            this.cmbDefectuoso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefectuoso.Enabled = false;
            this.cmbDefectuoso.FormattingEnabled = true;
            this.cmbDefectuoso.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmbDefectuoso.Location = new System.Drawing.Point(620, 321);
            this.cmbDefectuoso.Name = "cmbDefectuoso";
            this.cmbDefectuoso.Size = new System.Drawing.Size(108, 21);
            this.cmbDefectuoso.TabIndex = 13;
            this.cmbDefectuoso.SelectedIndexChanged += new System.EventHandler(this.cmbDefectuoso_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(617, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Defectuoso";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEscribirXml);
            this.groupBox1.Controls.Add(this.btnLeerXml);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 58);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML";
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(457, 322);
            this.txbNombre.MaxLength = 20;
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(121, 20);
            this.txbNombre.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(454, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nombre de la fábrica";
            // 
            // btnCambiarNombre
            // 
            this.btnCambiarNombre.Location = new System.Drawing.Point(457, 348);
            this.btnCambiarNombre.Name = "btnCambiarNombre";
            this.btnCambiarNombre.Size = new System.Drawing.Size(66, 22);
            this.btnCambiarNombre.TabIndex = 18;
            this.btnCambiarNombre.Text = "Cambiar";
            this.btnCambiarNombre.UseVisualStyleBackColor = true;
            this.btnCambiarNombre.Click += new System.EventHandler(this.btnCambiarNombre_Click);
            // 
            // frmFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 381);
            this.Controls.Add(this.btnCambiarNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDefectuoso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFabricar);
            this.Controls.Add(this.lstVisor);
            this.Controls.Add(this.btnDesechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFabrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFabrica_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLeerXml;
        private System.Windows.Forms.Button btnEscribirXml;
        private System.Windows.Forms.Button btnDesechar;
        private System.Windows.Forms.ListBox lstVisor;
        private System.Windows.Forms.ComboBox cmbFabricar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDefectuoso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCambiarNombre;
    }
}

