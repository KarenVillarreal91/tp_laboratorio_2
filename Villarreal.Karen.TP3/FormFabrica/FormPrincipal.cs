using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormFabrica
{
    public partial class frmFabrica : Form
    {
        private Fabrica fabrica;

        public frmFabrica()
        {
            InitializeComponent();

            this.fabrica = new Fabrica("Mi fábrica");
            this.Text = "Fábrica ";
        }

        private void btnLeerXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();

            try 
            { 
                if(path.ShowDialog() == DialogResult.OK)
                {
                    this.fabrica = Fabrica.Leer(path.FileName);
                    this.Text = "Fábrica " + this.fabrica.nombre;
                }
            }
            catch(ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.MostrarEnVisor();
        }

        private void MostrarEnVisor()
        {
            this.lstVisor.Items.Clear();

            foreach (Periferico item in this.fabrica.Perifericos)
            {
                this.lstVisor.Items.Add(item.ToString());
            }
        }

        private void cmbFabricar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormPeriferico frm = null;
            try
            {
                switch (this.cmbFabricar.SelectedIndex)
                {
                    case 0:
                        frm = new FormMouse();
                        break;
                    case 1:
                        frm = new FormTeclado();
                        break;
                    case 2:
                        frm = new FormAuricular();
                        break;
                }

                frm.StartPosition = FormStartPosition.CenterScreen;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (this.fabrica + frm.PerifericoDelForm)
                    {
                        MessageBox.Show("Se fabricó correctamente!", "Fabricado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.MostrarEnVisor();
                }
            }
            catch(PerifericosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesechar_Click(object sender, EventArgs e)
        {
            int i = this.lstVisor.SelectedIndex;

            if(i > -1)
            {
                try 
                { 
                    if(this.fabrica - this.fabrica.Perifericos[i])
                    {
                        MessageBox.Show("Se desechó correctamente!", "Desechado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.MostrarEnVisor();
                }
                catch(PerifericosException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstVisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnDesechar.Enabled = true;
            this.cmbDefectuoso.Enabled = true;
        }

        private void cmbDefectuoso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = this.lstVisor.SelectedIndex;

            if(i > -1)
            {
                if(this.cmbDefectuoso.SelectedIndex == 0)
                {
                    this.fabrica.Perifericos[i].Defectuoso = true;
                }
                else
                {
                    this.fabrica.Perifericos[i].Defectuoso = false;
                }

                this.MostrarEnVisor();
            }
        }

        private void btnEscribirXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();

            try
            {
                if(path.ShowDialog() == DialogResult.OK)
                {
                    Fabrica.Escribir(this.fabrica, path.FileName);
                }
            }
            catch(ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarNombre_Click(object sender, EventArgs e)
        {
            if(this.txbNombre.Text != "")
            {
                this.Text = "Fábrica " + this.txbNombre.Text;
                this.fabrica.nombre = this.txbNombre.Text;
            }
            else
            {
                MessageBox.Show("Ingrese el nombre primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFabrica_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro de salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if(rta == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
