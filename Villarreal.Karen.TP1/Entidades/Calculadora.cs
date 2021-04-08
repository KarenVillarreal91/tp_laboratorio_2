using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            switch(ValidarOperador(char.Parse(operador)))
            {
                case "+":
                    return num1 + num2;

                case "-":
                    return num1 - num2;

                case "/":
                    return num1 / num2;

                default:
                    return num1 * num2;
            }
        }

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
