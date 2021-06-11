using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Teclado : Periferico
    {
        public ETipoTeclado tipo;

        #region Constructor
        public Teclado()
        { }

        public Teclado(EColor color, EMarca marca, bool inalambrico, ETipoTeclado tipo)
            : base(color, marca, inalambrico)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedad
        public ETipoTeclado Teclas
        {
            get { return this.tipo; }
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Teclado a, Teclado b)
        {
            return a.tipo == b.tipo && (Periferico)a == b;
        }
        public static bool operator !=(Teclado a, Teclado b)
        {
            return !(a == b);
        }
        #endregion

        #region Overrides
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
