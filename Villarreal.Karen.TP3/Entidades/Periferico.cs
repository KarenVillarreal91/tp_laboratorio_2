using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Periferico
    {
        protected EColor color;
        protected EMarca marca;
        protected bool esInalambrico;

        #region Constructor
        public Periferico(EColor color, EMarca marca, bool inalambrico)
        {
            this.color = color;
            this.marca = marca;
            this.esInalambrico = inalambrico;
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Color: {this.color}");
            cadena.AppendLine($"Marca: {this.marca}");
            cadena.AppendLine($"Inalambrico: {this.esInalambrico}");

            return cadena.ToString();
        }
        #endregion
    }
}
