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

        #region Override

        /// <summary>
        /// Convierte el objeto actual en una lista de toda su información.
        /// </summary>
        /// <returns>Cadena con toda la información.</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.ToString());
            cadena.AppendLine($"- Tiene micrófono?: {this.conMicrofono} ");

            return cadena.ToString();
        }
        #endregion
    }
}
