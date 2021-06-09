using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Auricular : Periferico
    {
        private bool conMicrofono;

        #region Constructor
        public Auricular(EColor color, EMarca marca, bool inalambrico, bool microfono)
            : base(color, marca, inalambrico)
        {
            this.conMicrofono = microfono;
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.ToString());
            cadena.Append($"¿Tiene micrófono?: {this.conMicrofono}");

            return cadena.ToString();
        }
        #endregion
    }
}
