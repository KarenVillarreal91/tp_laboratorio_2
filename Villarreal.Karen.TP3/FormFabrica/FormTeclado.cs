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
    public partial class FormTeclado : FormPeriferico
    {
        private Teclado teclado;

        /// <summary>
        /// Propiedad de solo lectura del atributo teclado.
        /// </summary>
        public Teclado TecladoDelForm
        {
            get { return this.teclado; }
        }

        /// <summary>
        /// Propiedad de solo lectura heredada.
        /// </summary>
        public override Periferico PerifericoDelForm
        {
            get { return this.TecladoDelForm; }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public FormTeclado()
        {
            InitializeComponent();

            //Se agregan los items al ComboBox de Teclas
            foreach(ETipoTeclado item in Enum.GetValues(typeof(ETipoTeclado)))
            {
                this.cmbTeclas.Items.Add(item);
            }

            this.cmbTeclas.SelectedIndex = 0; //Se seleciona por defecto el primero
        }

        /// <summary>
        /// Crea el teclado con todos los parametros requeridos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.teclado = new Teclado((EColor)base.cmbColor.SelectedItem, (EMarca)base.cmbMarca.SelectedItem, base.chbInalambrico.Checked,
                                    (ETipoTeclado)this.cmbTeclas.SelectedItem);

            //Si no se dejo el TextBox de número de serie vacio se asigna el valor.  
            if(base.txbNroSerie.Text != "")
            {
                this.teclado.NroSerie = base.txbNroSerie.Text;
            }

            base.btnAceptar_Click(sender, e);
        }
    }
}
