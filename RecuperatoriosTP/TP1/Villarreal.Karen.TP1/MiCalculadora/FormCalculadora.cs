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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar(); //Llama al método para borrar los datos
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            if(this.cmbOperador.Text == null || this.cmbOperador.Text == "")    //Verifica que el operador no esté vácio.
            {
                this.cmbOperador.Text = " ";
            }

            resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text); //Obtiene el resultado
            this.lblResultado.Text = resultado.ToString();  //Lo coloca en el Label
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero();
            
            //Obtiene el resultado y lo coloca en el Label
            this.lblResultado.Text = resultado.DecimalBinario(this.lblResultado.Text); 
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero();

            if(this.lblResultado.Text != null && this.lblResultado.Text != "") //Verifica que el operador no esté vácio.
            {
                //Obtiene el resultado y lo coloca en el Label
                this.lblResultado.Text = resultado.BinarioDecimal(this.lblResultado.Text); 
            }
            else
            {
                this.lblResultado.Text = "No hay resultado.";
            }
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y el Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        /// <summary>
        /// Convierte los dos primeros parametros tipo <see cref="string"/> en <see cref="Numero"/> y
        /// llama al método Operar de la clase <see cref="Calculadora"/> para obtener el resultado.
        /// </summary>
        /// <param name="numero1">Primer operando de tipo <see cref="string"/>.</param>
        /// <param name="numero2">Segundo operando de tipo <see cref="string"/></param>
        /// <param name="operador">Operador de tipo <see cref="string"/>.</param>
        /// <returns>Resultado de la operación realizada tipo <see cref="double"/>.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numero1Obj = new Numero(numero1);
            Numero numero2Obj = new Numero(numero2);

            return Calculadora.Operar(numero1Obj, numero2Obj, operador);
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta;

            respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
