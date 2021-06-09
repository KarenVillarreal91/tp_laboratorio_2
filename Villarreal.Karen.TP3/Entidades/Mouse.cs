using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mouse : Periferico
    {
        private int cantBotones;

        #region Constructor
        public Mouse(EColor color, EMarca marca, bool inalambrico, int botones) 
            : base(color, marca, inalambrico)
        {
            this.cantBotones = botones;
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.ToString());
            cadena.Append($"Cantidad de botones: {this.cantBotones}");

            return cadena.ToString();
        }
        #endregion
    }
}
