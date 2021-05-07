using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Constructor que asigna los atributos heredados.
        /// </summary>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="chasis">Chasis a asignar.</param>
        /// <param name="color">Color a asignar.</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) 
            : base(chasis, marca, color) //Arreglado llamado a constructor base
        {
        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio //Arreglado override y retorno ETamanio
        {
            get
            {
                return ETamanio.Chico; //Retorna enumerado .Chico
            }
        }

        /// <summary>
        /// Retorna todos los datos del Ciclomotor junto con sus atributos heredados
        /// </summary>
        /// <returns>Los datos en un string.</returns>
        public override string Mostrar() //Eliminado sealed y arreglado public
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar()); //Arreglado base.Mostrar()
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio); //Arreglado AppendFormat
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //Arreglado .ToString()
        }
    }
}
