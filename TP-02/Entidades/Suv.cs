using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo //Arreglado herencia de Vehiculo
    {
        /// <summary>
        /// Constructor que asigna los atributos heredados.
        /// </summary>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="chasis">Chasis a asignar.</param>
        /// <param name="color">Color a asignar.</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio //Arreglado retorno a ETamanio
        {
            get
            {
                return ETamanio.Grande; //Retorna enumerado .Grande
            }
        }

        /// <summary>
        /// Retorna todos los datos del SUV junto con sus atributos heredados
        /// </summary>
        /// <returns>Los datos en un string.</returns>
        public override string Mostrar() //Eliminado sealed
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar()); //Arreglado .Mostrar()
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio); //Arreglado AppendFormat
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //Arreglado .ToString()
        }
    }
}
