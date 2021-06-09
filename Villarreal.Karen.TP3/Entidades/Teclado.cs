using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Teclado : Periferico
    {
        private ETipoTeclado tipo;

        #region Constructor
        public Teclado(EColor color, EMarca marca, bool inalambrico, ETipoTeclado tipo)
            : base(color, marca, inalambrico)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.ToString());
            cadena.Append($"Tipo: {this.tipo}");

            return cadena.ToString();
        }
        #endregion
    }
}
