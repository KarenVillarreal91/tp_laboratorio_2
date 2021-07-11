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

        #region Override

        /// <summary>
        /// Convierte el objeto actual en una lista de toda su información.
        /// </summary>
        /// <returns>Cadena con toda la información.</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.ToString());
            cadena.AppendLine($"- Teclas: {this.tipo}");

            return cadena.ToString();
        }
        #endregion
    }
}
