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
    /// <summary>
    /// Form que hereda de FormPeriferico
    /// </summary>
    public partial class FormAuricular : FormPeriferico
    {
        private Auricular auricular;

        /// <summary>
        /// Propiedad de solo lectura del atributo auricular.
        /// </summary>
        public Auricular AuricularDelForm
        {
            get { return this.auricular; }
        }

        /// <summary>
        /// Propiedad de solo lectura heredada.
        /// </summary>
        public override Periferico PerifericoDelForm
        {
            get { return this.AuricularDelForm; }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public FormAuricular()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea el auricular con todos los parametros requeridos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.auricular = new Auricular((EColor)base.cmbColor.SelectedItem, (EMarca)base.cmbMarca.SelectedItem, base.chbInalambrico.Checked,
                                        this.chbMicrofono.Checked);

            //Si no se dejo el TextBox de número de serie vacio se asigna el valor.  
            if (base.txbNroSerie.Text != "")
            {
                this.auricular.NroSerie = base.txbNroSerie.Text;
            }

            base.btnAceptar_Click(sender, e);
        }
    }
}
