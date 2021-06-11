using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Auricular : Periferico
    {
        public bool conMicrofono;

        #region Constructor
        public Auricular()
        { }

        public Auricular(EColor color, EMarca marca, bool inalambrico, bool microfono)
            : base(color, marca, inalambrico)
        {
            this.conMicrofono = microfono;
        }
        #endregion

        #region Propiedad
        public bool Microfono
        {
            get { return this.conMicrofono; }
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Auricular a, Auricular b)
        {
            return a.conMicrofono == b.conMicrofono && (Periferico)a == b;
        }
        public static bool operator !=(Auricular a, Auricular b)
        {
            return !(a == b);
        }
        #endregion

        #region Overrides
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
