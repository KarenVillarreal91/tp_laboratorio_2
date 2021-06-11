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
    public partial class FormMouse : FormPeriferico
    {
        private Mouse mouse;

        public Mouse MouseDelForm
        {
            get { return this.mouse; }
        }

        public override Periferico PerifericoDelForm
        {
            get { return this.MouseDelForm; }
        }

        public FormMouse()
        {
            InitializeComponent();
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.mouse = new Mouse((EColor)base.cmbColor.SelectedItem, (EMarca)base.cmbMarca.SelectedItem, base.chbInalambrico.Checked,
                                    (int)this.nUDCantBtn.Value);

            if(base.txbNroSerie.Text != "")
            {
                this.mouse.NroSerie = base.txbNroSerie.Text;
            }

            base.btnAceptar_Click(sender, e);
        }
    }
}
