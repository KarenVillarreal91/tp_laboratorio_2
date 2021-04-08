using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        private double ValidarNumero(string strNumero)
        {
            double numero;
            
            if(double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        private bool EsBinario(string binario)
        {
            int cantCaracteres = 0;

            for(int i = 0; i < binario.Length; i++)
            {
                if(binario[i] == '0' || binario[i] == '1')
                {
                    cantCaracteres++;
                }
            }

            if(cantCaracteres == binario.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Converter
        public string BinarioDecimal(string binario)
        {
            if(EsBinario(binario))
            {
                return (Convert.ToInt32(binario, 2)).ToString();
            }
            else
            {
                return "Valor inválido.";
            }
        }
        public string DecimalBinario(double numero)
        {
            string numeroString = numero.ToString();

            return DecimalBinario(numeroString);
        }
        public string DecimalBinario(string numero)
        {
            int numeroInt;

            if(int.TryParse(numero, out numeroInt) && numeroInt > 0)
            {
                return Convert.ToString(numeroInt, 2);
            }
            else
            {
                return "Valor inválido.";
            }
        }
        #endregion

        #region Sobrecargas de operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n1.numero;
        }
        #endregion

    }
}
