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
    public class Mouse : Periferico
    {
        public int cantBotones;

        #region Constructor
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Mouse()
        { }

        /// <summary>
        /// Constructor con parametros heredados y el propio.
        /// </summary>
        /// <param name="color">Color a asignar.</param>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="inalambrico">Valor a asignar.</param>
        /// <param name="botones">Cantidad a asignar.</param>
        public Mouse(EColor color, EMarca marca, bool inalambrico, int botones) 
            : base(color, marca, inalambrico)
        {
            this.cantBotones = botones;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad del atributo propio Tipo.
        /// </summary>
        public int CantBotones
        {
            get { return this.cantBotones; }
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Compara dos Mouse por cantidad de botones y llama a la comparación por perifericos.
        /// </summary>
        /// <param name="a">Primer mouse a comparar.</param>
        /// <param name="b">Segundo mouse a comparar.</param>
        /// <returns>True si son iguales, false si no.</returns>
        public static bool operator ==(Mouse a, Mouse b)
        {
            return a.cantBotones == b.cantBotones && (Periferico)a == b;
        }

        /// <summary>
        /// Compara dos Mouse.
        /// </summary>
        /// <param name="a">Primer mouse a comparar.</param>
        /// <param name="b">Segundo mouse a comparar.</param>
        /// <returns>True si son diferentes, false si no.</returns>
        public static bool operator !=(Mouse a, Mouse b)
        {
            return !(a == b);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Verifica que el parametro sea de tipo Mouse.
        /// </summary>
        /// <param name="obj">Mouse a verificar.</param>
        /// <returns>True si se verifica, false si no.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Mouse)
            {
                return this == (Mouse)obj;
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
            cadena.AppendLine($"- Cantidad de botones: {this.CantBotones}");

            return cadena.ToString();
        }
        #endregion
    }
}
