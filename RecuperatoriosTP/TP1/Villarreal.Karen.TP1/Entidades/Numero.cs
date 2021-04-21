using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero; //Atributo privado 

        #region Constructores
        /// <summary>
        /// Constructor por defecto, setea el atributo en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Contructor con parametro, setea el atributo con el parametro obtenido
        /// </summary>
        /// <param name="numero">Parametro a asignar tipo double</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Contructor con parametro, setea el atributo con el parametro obtenido
        /// </summary>
        /// <param name="strNumero">Parametro a asignar tipo string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        /// <summary>
        /// Valida que el parámetro recibido sea un número.
        /// </summary>
        /// <param name="strNumero">Parámetro a validar tipo string.</param>
        /// <returns>Es un número: Retorna el número tipo <see langword="double"/> -
        ///          No es un número: Retorna <see langword="0"/>. </returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            
            if(double.TryParse(strNumero, out numero)) //Intenta parsear el string a double
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida y setea un número en el atributo "numero".
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida que el parámetro obtenido esté compuesto solamente por '0' y '1'.
        /// </summary>
        /// <param name="binario">Parámetro tipo <see langword="string"/> a validar.</param>
        /// <returns><see langword="true"/> si es binario - <see langword="false"/>  si no lo es.</returns>
        private bool EsBinario(string binario)
        {
            int cantCaracteres = 0;

            for(int i = 0; i < binario.Length; i++)
            {
                if(binario[i] == '0' || binario[i] == '1')  //Recorre cada caracter buscando 0 o 1
                {
                    cantCaracteres++;   //Suma los caracteres correctos
                }
            }

            if(cantCaracteres == binario.Length)    //Compara la cantidad de caracteres correctos con la cantidad del string binario
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Converter
        /// <summary>
        /// Valida y convierte el número binario recibido por parámetro a decimal.
        /// </summary>
        /// <param name="binario">Parámetro a conventir tipo string.</param>
        /// <returns>Si el número es binario: Retorna su decimal equivalente tipo string -
        ///          Caso contrario: Retorna "Valor inválido."</returns>
        public string BinarioDecimal(string binario)
        {
            if(EsBinario(binario))  //Verifica que el parametro sea binario
            {
                return (Convert.ToInt32(binario, 2)).ToString();    //Lo convierte a decimal y lo transforma a string
            }
            else
            {
                return "Valor inválido.";
            }
        }
        /// <summary>
        /// Convierte el número decimal recibido por parámetro a binario.
        /// </summary>
        /// <param name="numero">Parámetro a convertir tipo double.</param>
        /// <returns>Si el número es válido: Retorna su equivalente binario en tipo string -
        ///          Caso contrario: Retorna "Valor inválido."</returns>
        public string DecimalBinario(double numero)
        {
            string numeroString = numero.ToString();    //Convierte el número a string

            return DecimalBinario(numeroString);    //Llama al método con parametro string y lo convierte
        }
        /// <summary>
        /// Convierte el número decimal recibido por parámetro a binario.
        /// </summary>
        /// <param name="numero">Parámetro a convertir tipo string.</param>
        /// <returns>Si el número es válido: Retorna su equivalente binario en tipo string -
        ///          Caso contrario: Retorna "Valor inválido."</returns>
        public string DecimalBinario(string numero)
        {
            int numeroInt;

            if(int.TryParse(numero, out numeroInt) && numeroInt > 0)    //Intenta parsear a int el número tipo string y verifica que sea mayor a 0
            {
                return Convert.ToString(numeroInt, 2);  //Convierte el número tipo int a un número binario tipo string
            }
            else
            {
                return "Valor inválido.";
            }
        }
        #endregion

        #region Sobrecargas de operadores
        /// <summary>
        /// Sobrecarga del operador +.
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>Resultado de la suma entre los operandos tipo <see cref="Numero"/>.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador -.
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>Resultado de la resta entre los operandos tipo <see cref="Numero"/>.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador /.
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>Resultado de la división entre los operandos tipo <see cref="Numero"/>
        ///          - En el caso que la division sea por <see langword="0"/>, retorna
        ///             el menor valor posible de un <see langword="double"/>.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero != 0)  //Compara el segundo parámetro con 0
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
        /// <summary>
        /// Sobrecarga del operador *.
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>Resultado de la multiplicación entre los operandos tipo <see cref="Numero"/>.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        #endregion

    }
}
