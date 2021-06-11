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
    public partial class FormPeriferico : Form
    {
        public virtual Periferico PerifericoDelForm
        {
            get;
        }

        public FormPeriferico()
        {
            InitializeComponent();

            foreach(EColor item in Enum.GetValues(typeof(EColor)))
            {
                this.cmbColor.Items.Add(item);
            }

            foreach(EMarca item in Enum.GetValues(typeof(EMarca)))
            {
                this.cmbMarca.Items.Add(item);
            }

            this.cmbColor.SelectedIndex = 0;
            this.cmbMarca.SelectedIndex = 0;
        }

        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
