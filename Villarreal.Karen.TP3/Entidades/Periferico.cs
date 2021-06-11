using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Mouse))]
    [XmlInclude(typeof(Teclado))]
    [XmlInclude(typeof(Auricular))]
    public class Periferico : IFicha
    {
        public EColor color;
        public EMarca marca;
        public bool esInalambrico;
        protected static Random generadorNroSerie;
        protected string nroSerie;
        protected bool defectuoso;

        #region Constructor
        static Periferico()
        {
            generadorNroSerie = new Random();
        }

        public Periferico()
        { }

        public Periferico(EColor color, EMarca marca, bool inalambrico)
        {
            this.color = color;
            this.marca = marca;
            this.esInalambrico = inalambrico;
            this.defectuoso = false;
        }
        #endregion

        #region Propiedades
        public string Tipo
        {
            get { return this.GetType().Name; }
        }

        public string NroSerie
        {
            get
            {
                if (this.nroSerie == null)
                {
                    int numero = generadorNroSerie.Next(26);
                    this.nroSerie = ((char)(((int)'A') + numero)).ToString() + numero * 100;
                }

                return this.nroSerie;
            }
            set
            {
                this.nroSerie = value;
            }
        }

        public EColor Color
        {
            get { return this.color; }
        }

        public EMarca Marca
        {
            get { return this.marca; }
        }

        public bool Inalambrico
        {
            get { return this.esInalambrico; }
        }

        public bool Defectuoso
        {
            get { return this.defectuoso; }
            set { this.defectuoso = value; }
        }
        #endregion

        #region Métodos

        public string Ficha()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Tipo: {this.Tipo} ");
            cadena.AppendLine($"- Color: {this.Color} ");
            cadena.AppendLine($"- Marca: {this.Marca} ");
            cadena.AppendLine($"- Inalambrico: {this.Inalambrico} ");
            cadena.Append($"- Número de Serie: {this.NroSerie} ");
            cadena.Append($"- Defectuoso: {this.Defectuoso} ");

            return cadena.ToString();
        }
        public override string ToString()
        {
            return this.Ficha();
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Periferico a, Periferico b)
        {
            return a.NroSerie == b.NroSerie && a.marca == b.marca;
        }
        public static bool operator !=(Periferico a, Periferico b)
        {
            return !(a == b);
        }
        #endregion
    }
}
