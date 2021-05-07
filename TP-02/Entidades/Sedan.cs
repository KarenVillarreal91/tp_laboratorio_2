using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        private ETipo tipo; //Agregado private al atributo
        public enum ETipo { CuatroPuertas, CincoPuertas }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="chasis">Chasis a asignar.</param>
        /// <param name="color">Color a asignar.</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas) //Llama a la sobrecarga y asigna .CuatroPuertas
        { }
        /// <summary>
        /// Constructor sobrecargado con el parametro ETipo
        /// </summary>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="chasis">Chasis a asignar.</param>
        /// <param name="color">Color a asignar.</param>
        /// <param name="tipo">Tipo a asignar.</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) //Contructor creado con parametro agregado ETipo
            : base(chasis, marca, color) //Llamada al contructor base
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio //Arreglado retorno ETamanio
        {
            get
            {
                return ETamanio.Mediano; //Retorna enumerado .Mediano
            }
        }

        /// <summary>
        /// Retorna todos los datos del Sedan junto con sus atributos heredados
        /// </summary>
        /// <returns>Los datos en un string.</returns>
        public override string Mostrar() //Eliminado sealed
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar()); //Arreglado base.Mostrar()
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio); //Arreglado AppedFormat
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //Arreglado .ToString()
        }
    }
}
