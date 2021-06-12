using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase hija de Periferico
    /// </summary>
    public class Teclado : Periferico
    {
        public ETipoTeclado tipo;

        #region Constructor
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Teclado()
        { }

        /// <summary>
        /// Constructor con parametros heredados y el propio.
        /// </summary>
        /// <param name="color">Color a asignar.</param>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="inalambrico">Valor a asignar.</param>
        /// <param name="tipo">Tipo a asignar.</param>
        public Teclado(EColor color, EMarca marca, bool inalambrico, ETipoTeclado tipo)
            : base(color, marca, inalambrico)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad del atributo propio Tipo.
        /// </summary>
        public ETipoTeclado Teclas
        {
            get { return this.tipo; }
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Compara dos teclados por tipo y llama a la comparación por perifericos.
        /// </summary>
        /// <param name="a">Primer teclado a comparar.</param>
        /// <param name="b">Segundo teclado a comparar.</param>
        /// <returns>True si son iguales, false si no.</returns>
        public static bool operator ==(Teclado a, Teclado b)
        {
            return a.tipo == b.tipo && (Periferico)a == b;
        }

        /// <summary>
        /// Compara dos teclados.
        /// </summary>
        /// <param name="a">Primer teclado a comparar.</param>
        /// <param name="b">Segundo teclado a comparar.</param>
        /// <returns>True si son diferentes, false si no.</returns>
        public static bool operator !=(Teclado a, Teclado b)
        {
            return !(a == b);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Verifica que el parametro sea de tipo Teclado.
        /// </summary>
        /// <param name="obj">Teclado a verificar.</param>
        /// <returns>True si se verifica, false si no.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Teclado)
            {
                return this == (Teclado)obj;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Convierte el objeto actual en una lista de toda su información.
        /// </summary>
        /// <returns>Cadena con toda la información.</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.ToString());
            cadena.AppendLine($"- Teclas: {this.Teclas}");

            return cadena.ToString();
        }
        #endregion
    }
}
