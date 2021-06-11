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
    public partial class FormAuricular : FormPeriferico
    {
        private Auricular auricular;

        public Auricular AuricularDelForm
        {
            get { return this.auricular; }
        }

        public override Periferico PerifericoDelForm
        {
            get { return this.AuricularDelForm; }
        }

        public FormAuricular()
        {
            InitializeComponent();
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.auricular = new Auricular((EColor)base.cmbColor.SelectedItem, (EMarca)base.cmbMarca.SelectedItem, base.chbInalambrico.Checked,
                                        this.chbMicrofono.Checked);

            if(base.txbNroSerie.Text != "")
            {
                this.auricular.NroSerie = base.txbNroSerie.Text;
            }

            base.btnAceptar_Click(sender, e);
        }
    }
}
