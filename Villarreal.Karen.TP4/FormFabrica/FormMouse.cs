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
    public partial class FormMouse : FormPeriferico
    {
        private Mouse mouse;

        /// <summary>
        /// Propiedad de solo lectura del atributo mouse.
        /// </summary>
        public Mouse MouseDelForm
        {
            get { return this.mouse; }
        }

        /// <summary>
        /// Propiedad de solo lectura hererada.
        /// </summary>
        public override Periferico PerifericoDelForm
        {
            get { return this.MouseDelForm; }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public FormMouse()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea el mouse con todos los parametros requeridos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.mouse = new Mouse((EColor)base.cmbColor.SelectedItem, (EMarca)base.cmbMarca.SelectedItem, base.chbInalambrico.Checked,
                                    (int)this.nUDCantBtn.Value);

            //Si no se dejo el TextBox de número de serie vacio se asigna el valor.  
            if (base.txbNroSerie.Text != "")
            {
                this.mouse.NroSerie = base.txbNroSerie.Text;
            }

            base.btnAceptar_Click(sender, e);
        }
    }
}
