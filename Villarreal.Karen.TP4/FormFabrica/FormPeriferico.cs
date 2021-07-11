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
        /// <summary>
        /// Propiedad virtual de solo lectura.
        /// </summary>
        public virtual Periferico PerifericoDelForm
        {
            get;
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public FormPeriferico()
        {
            InitializeComponent();

            //Se agregan los items al ComboBox de Color
            foreach(EColor item in Enum.GetValues(typeof(EColor)))
            {
                this.cmbColor.Items.Add(item);
            }

            //Se agregan los items al ComboBox de Marca
            foreach(EMarca item in Enum.GetValues(typeof(EMarca)))
            {
                this.cmbMarca.Items.Add(item);
            }

            //Se selecciona el primero de cada uno
            this.cmbColor.SelectedIndex = 0;
            this.cmbMarca.SelectedIndex = 0;
        }

        /// <summary>
        /// Virtual.
        /// Crea el periferico con todos los parametros requeridos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
