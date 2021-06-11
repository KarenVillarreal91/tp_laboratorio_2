using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Mouse : Periferico
    {
        public int cantBotones;

        #region Constructor
        public Mouse()
        { }

        public Mouse(EColor color, EMarca marca, bool inalambrico, int botones) 
            : base(color, marca, inalambrico)
        {
            this.cantBotones = botones;
        }
        #endregion

        #region Propiedad
        public int CantBotones
        {
            get { return this.cantBotones; }
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Mouse a, Mouse b)
        {
            return a.cantBotones == b.cantBotones && (Periferico)a == b;
        }
        public static bool operator !=(Mouse a, Mouse b)
        {
            return !(a == b);
        }
        #endregion

        #region Overrides
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
