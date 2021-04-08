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
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            if(this.cmbOperador.Text != null && this.cmbOperador.Text != "")
            {
                resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
                this.lblResultado.Text = resultado.ToString();
            }
            else
            {
                this.lblResultado.Text = "Elija un operador.";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero();

            this.lblResultado.Text = resultado.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero();

            if(this.lblResultado.Text != null && this.lblResultado.Text != "")
            {
                this.lblResultado.Text = resultado.BinarioDecimal(this.lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "No hay resultado.";
            }
        }

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numero1Obj = new Numero(numero1);
            Numero numero2Obj = new Numero(numero2);

            return Calculadora.Operar(numero1Obj, numero2Obj, operador);
        }
    }
}
