using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo //Arreglado abstract
    {
        //Arreglados modificadores de visibilidad a public 
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        //Agregados private para los atributos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Contructor parametrizado que inicializa todos los atributos de la clase.
        /// </summary>
        /// <param name="chasis">Chasis a asignar.</param>
        /// <param name="marca">Marca a asignar.</param>
        /// <param name="color">Color asignar.</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color) //Contructor creado
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; } //Arreglado protected y eliminado set.

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar() //Arreglado public y virtual 
        {
            return (string)this; //Agregado conversión explicita a string.
        }

        /// <summary>
        /// Conversión explicita a string de Vehiculo.
        ///  Devuelve el chasis, marca y color del vehiculo.
        /// </summary>
        /// <param name="p">Vehiculo a ser convertido.</param>
        public static explicit operator string(Vehiculo p) //Arreglado public
        {
            StringBuilder sb = new StringBuilder();

            //AppendLine no toma 2 argumentos, arreglado AppendFormat
            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString(); //Agregado .ToString()
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer vehiculo.</param>
        /// <param name="v2">Segundo vehiculo.</param>
        /// <returns>True si son iguales, False si no.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer vehiculo.</param>
        /// <param name="v2">Segundo vehiculo.</param>
        /// <returns>True si no son iguales, False si son iguales.</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2); //Arreglado llamar a la sobrecarga == y negar el resultado.
        }
    }
}
