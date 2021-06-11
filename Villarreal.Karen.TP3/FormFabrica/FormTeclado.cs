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
    public partial class FormTeclado : FormPeriferico
    {
        private Teclado teclado;

        public Teclado TecladoDelForm
        {
            get { return this.teclado; }
        }

        public override Periferico PerifericoDelForm
        {
            get { return this.TecladoDelForm; }
        }

        public FormTeclado()
        {
            InitializeComponent();

            foreach(ETipoTeclado item in Enum.GetValues(typeof(ETipoTeclado)))
            {
                this.cmbTeclas.Items.Add(item);
            }

            this.cmbTeclas.SelectedIndex = 0;
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.teclado = new Teclado((EColor)base.cmbColor.SelectedItem, (EMarca)base.cmbMarca.SelectedItem, base.chbInalambrico.Checked,
                                    (ETipoTeclado)this.cmbTeclas.SelectedItem);

            if(base.txbNroSerie.Text != "")
            {
                this.teclado.NroSerie = base.txbNroSerie.Text;
            }

            base.btnAceptar_Click(sender, e);
        }
    }
}
