using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operación requerida según el operador obtenido.
        /// </summary>
        /// <param name="num1">Primer operando tipo <see cref="Numero"/>.</param>
        /// <param name="num2">Segundo operando tipo <see cref="Numero"/>.</param>
        /// <param name="operador">Operador tipo <see cref="char"/>.</param>
        /// <returns>Resultado de la operación realizada tipo <see cref="double"/>.</returns>
        public static double Operar(Numero num1, Numero num2, char operador)
        {
            switch(ValidarOperador(operador))
            {
                case "*":
                    return num1 * num2;

                case "-":
                    return num1 - num2;

                case "/":
                    return num1 / num2;

                default:
                    return num1 + num2;
            }
        }

        /// <summary>
        /// Valida que el parámetro sea uno de los operadores +, -, / o *.
        /// </summary>
        /// <param name="operador">Operador a validar de tipo <see cref="char"/>.</param>
        /// <returns>Si el operador es correcto: El mismo operador de tipo <see cref="string"/>. 
        ///        De lo contrario: El operador "+" de tipo <see cref="string"/>.</returns>
        private static string ValidarOperador(char operador)
        {
            if(operador != '+' && operador != '-' && operador != '/' && operador != '*')
            {
                return "+";
            }
            else
            {
                return operador.ToString();
            }
        }
    }
}
