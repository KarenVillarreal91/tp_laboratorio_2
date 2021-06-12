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
    public class Auricular : Periferico
    {
        public bool conMicrofono;

        #region Constructor
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Auricular()
        { }

        /// <summary>
        /// Constructor con parametros heredados y el propio.
        /// </summary>
        /// <param name="color">Color a asignar.</param>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="inalambrico">Valor a asignar.</param>
        /// <param name="microfono">Valor a asignar.</param>
        public Auricular(EColor color, EMarca marca, bool inalambrico, bool microfono)
            : base(color, marca, inalambrico)
        {
            this.conMicrofono = microfono;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad del atributo propio Tipo.
        /// </summary>
        public bool Microfono
        {
            get { return this.conMicrofono; }
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Compara dos Auriculares si tiene microfono o no y llama a la comparación por perifericos.
        /// </summary>
        /// <param name="a">Primer auricular a comparar.</param>
        /// <param name="b">Segundo auricular a comparar.</param>
        /// <returns>True si son iguales, false si no.</returns>
        public static bool operator ==(Auricular a, Auricular b)
        {
            return a.conMicrofono == b.conMicrofono && (Periferico)a == b;
        }

        /// <summary>
        /// Compara dos Auriculares.
        /// </summary>
        /// <param name="a">Primer auricular a comparar.</param>
        /// <param name="b">Segundo auricular a comparar.</param>
        /// <returns>True si son diferentes, false si no.</returns>
        public static bool operator !=(Auricular a, Auricular b)
        {
            return !(a == b);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Verifica que el parametro sea de tipo Auricular.
        /// </summary>
        /// <param name="obj">Auricular a verificar.</param>
        /// <returns>True si se verifica, false si no.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Auricular)
            {
                return this == (Auricular)obj;
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
            cadena.AppendLine($"- Tiene micrófono?: {this.Microfono} ");

            return cadena.ToString();
        }
        #endregion
    }
}
