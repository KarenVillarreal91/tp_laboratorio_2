using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    //Se incluyen en Xml las clases que hereda Periferico
    [XmlInclude(typeof(Mouse))]
    [XmlInclude(typeof(Teclado))]
    [XmlInclude(typeof(Auricular))]
    public class Periferico : IFicha
    {
        protected EColor color;
        protected EMarca marca;
        protected bool esInalambrico;
        protected static Random generadorNroSerie;
        protected string nroSerie;
        protected bool defectuoso;

        #region Constructor
        /// <summary>
        /// Constructor estatico que inicializa el atributo tipo Random.
        /// </summary>
        static Periferico()
        {
            generadorNroSerie = new Random();
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Periferico()
        { }

        /// <summary>
        /// Constructor con parametros.
        /// Asigna los parametros y setea el atributo Defectuoso en false.
        /// </summary>
        /// <param name="color">Color a asignar.</param>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="inalambrico">Valor a asignar.</param>
        public Periferico(EColor color, EMarca marca, bool inalambrico)
        {
            this.color = color;
            this.marca = marca;
            this.esInalambrico = inalambrico;
            this.defectuoso = false;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que retorna el nombre del miembro.
        /// </summary>
        public string Tipo
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Propiedad del atributo NroSerie.
        /// Si el atributo es null genera un nuevo numero y lo asigna.
        /// Si no, retorna el valor actual.
        /// </summary>
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

        /// <summary>
        /// Propiedad del atributo propio Defectuoso.
        /// </summary>
        public bool Defectuoso
        {
            get { return this.defectuoso; }
            set { this.defectuoso = value; }
        }

        /// <summary>
        /// Propiedad del atributo propio Color.
        /// </summary>
        public EColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        /// <summary>
        /// Propiedad del atributo propio Marca.
        /// </summary>
        public EMarca Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        /// <summary>
        /// Propiedad del atributo propio Inalambrico.
        /// </summary>
        public bool Inalambrico
        {
            get { return this.esInalambrico; }
            set { this.esInalambrico = value; }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Apartir del periferico crea una cadena con una lista de toda su información.
        /// </summary>
        /// <returns>Cadena con la información.</returns>
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

        /// <summary>
        /// Llama al método Ficha.
        /// </summary>
        /// <returns>Cadena con la información.</returns>
        public override string ToString()
        {
            return this.Ficha();
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Compara dos perifericos por Nro de serie y Marca.
        /// </summary>
        /// <param name="a">Primer periferico a comparar.</param>
        /// <param name="b">Segundo periferico a comparar.</param>
        /// <returns>True si son iguales, false si no.</returns>
        public static bool operator ==(Periferico a, Periferico b)
        {
            return a.NroSerie == b.NroSerie && a.marca == b.marca;
        }

        /// <summary>
        /// Compara dos perifericos.
        /// </summary>
        /// <param name="a">Primer periferico a comparar.</param>
        /// <param name="b">Segundo periferico a comparar.</param>
        /// <returns>True si son diferentes, false si no.</returns>
        public static bool operator !=(Periferico a, Periferico b)
        {
            return !(a == b);
        }
        #endregion
    }
}
