
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLeerXml = new System.Windows.Forms.Button();
            this.btnEscribirXml = new System.Windows.Forms.Button();
            this.btnDesechar = new System.Windows.Forms.Button();
            this.cmbFabricar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDefectuoso = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCambiarNombre = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardarBD = new System.Windows.Forms.Button();
            this.btnCargarBD = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.pBBasura = new System.Windows.Forms.PictureBox();
            this.pBPerifericos = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBBasura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBPerifericos)).BeginInit();
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
            this.btnEscribirXml.Location = new System.Drawing.Point(6, 54);
            this.btnEscribirXml.Name = "btnEscribirXml";
            this.btnEscribirXml.Size = new System.Drawing.Size(108, 27);
            this.btnEscribirXml.TabIndex = 3;
            this.btnEscribirXml.Text = "Guardar";
            this.btnEscribirXml.UseVisualStyleBackColor = true;
            this.btnEscribirXml.Click += new System.EventHandler(this.btnEscribirXml_Click);
            // 
            // btnDesechar
            // 
            this.btnDesechar.BackColor = System.Drawing.Color.Transparent;
            this.btnDesechar.Enabled = false;
            this.btnDesechar.ForeColor = System.Drawing.Color.Black;
            this.btnDesechar.Location = new System.Drawing.Point(617, 504);
            this.btnDesechar.Name = "btnDesechar";
            this.btnDesechar.Size = new System.Drawing.Size(108, 27);
            this.btnDesechar.TabIndex = 8;
            this.btnDesechar.Text = "Desechar";
            this.btnDesechar.UseVisualStyleBackColor = false;
            this.btnDesechar.Click += new System.EventHandler(this.btnDesechar_Click);
            // 
            // cmbFabricar
            // 
            this.cmbFabricar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFabricar.FormattingEnabled = true;
            this.cmbFabricar.Items.AddRange(new object[] {
            "Mouse",
            "Teclado",
            "Auricular"});
            this.cmbFabricar.Location = new System.Drawing.Point(287, 469);
            this.cmbFabricar.Name = "cmbFabricar";
            this.cmbFabricar.Size = new System.Drawing.Size(121, 21);
            this.cmbFabricar.TabIndex = 4;
            this.cmbFabricar.SelectedIndexChanged += new System.EventHandler(this.cmbFabricar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 450);
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
            this.cmbDefectuoso.Location = new System.Drawing.Point(617, 469);
            this.cmbDefectuoso.Name = "cmbDefectuoso";
            this.cmbDefectuoso.Size = new System.Drawing.Size(108, 21);
            this.cmbDefectuoso.TabIndex = 7;
            this.cmbDefectuoso.SelectedIndexChanged += new System.EventHandler(this.cmbDefectuoso_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(614, 453);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 450);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 88);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML";
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(441, 470);
            this.txbNombre.MaxLength = 20;
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(121, 20);
            this.txbNombre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(438, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nombre de la fábrica";
            // 
            // btnCambiarNombre
            // 
            this.btnCambiarNombre.Location = new System.Drawing.Point(441, 495);
            this.btnCambiarNombre.Name = "btnCambiarNombre";
            this.btnCambiarNombre.Size = new System.Drawing.Size(66, 22);
            this.btnCambiarNombre.TabIndex = 6;
            this.btnCambiarNombre.Text = "Cambiar";
            this.btnCambiarNombre.UseVisualStyleBackColor = true;
            this.btnCambiarNombre.Click += new System.EventHandler(this.btnCambiarNombre_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardarBD);
            this.groupBox2.Controls.Add(this.btnCargarBD);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(148, 450);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 88);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base de datos";
            // 
            // btnGuardarBD
            // 
            this.btnGuardarBD.Location = new System.Drawing.Point(6, 55);
            this.btnGuardarBD.Name = "btnGuardarBD";
            this.btnGuardarBD.Size = new System.Drawing.Size(108, 27);
            this.btnGuardarBD.TabIndex = 3;
            this.btnGuardarBD.Text = "Guardar";
            this.btnGuardarBD.UseVisualStyleBackColor = true;
            this.btnGuardarBD.Click += new System.EventHandler(this.btnGuardarBD_Click);
            // 
            // btnCargarBD
            // 
            this.btnCargarBD.Location = new System.Drawing.Point(6, 19);
            this.btnCargarBD.Name = "btnCargarBD";
            this.btnCargarBD.Size = new System.Drawing.Size(108, 27);
            this.btnCargarBD.TabIndex = 2;
            this.btnCargarBD.Text = "Cargar";
            this.btnCargarBD.UseVisualStyleBackColor = true;
            this.btnCargarBD.Click += new System.EventHandler(this.btnCargarBD_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeColumns = false;
            this.dgvListado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvListado.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dgvListado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListado.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvListado.Location = new System.Drawing.Point(12, 28);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListado.RowHeadersWidth = 29;
            this.dgvListado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(713, 416);
            this.dgvListado.TabIndex = 18;
            this.dgvListado.SelectionChanged += new System.EventHandler(this.dgvListado_SelectionChanged);
            // 
            // pBBasura
            // 
            this.pBBasura.InitialImage = null;
            this.pBBasura.Location = new System.Drawing.Point(565, 495);
            this.pBBasura.Name = "pBBasura";
            this.pBBasura.Size = new System.Drawing.Size(46, 43);
            this.pBBasura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pBBasura.TabIndex = 19;
            this.pBBasura.TabStop = false;
            // 
            // pBPerifericos
            // 
            this.pBPerifericos.InitialImage = null;
            this.pBPerifericos.Location = new System.Drawing.Point(287, 496);
            this.pBPerifericos.Name = "pBPerifericos";
            this.pBPerifericos.Size = new System.Drawing.Size(121, 51);
            this.pBPerifericos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pBPerifericos.TabIndex = 20;
            this.pBPerifericos.TabStop = false;
            // 
            // frmFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 550);
            this.Controls.Add(this.pBPerifericos);
            this.Controls.Add(this.pBBasura);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCambiarNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDefectuoso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFabricar);
            this.Controls.Add(this.btnDesechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFabrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFabrica_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBBasura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBPerifericos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLeerXml;
        private System.Windows.Forms.Button btnEscribirXml;
        private System.Windows.Forms.Button btnDesechar;
        private System.Windows.Forms.ComboBox cmbFabricar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDefectuoso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCambiarNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardarBD;
        private System.Windows.Forms.Button btnCargarBD;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.PictureBox pBBasura;
        private System.Windows.Forms.PictureBox pBPerifericos;
    }
}

