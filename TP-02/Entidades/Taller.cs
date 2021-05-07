using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller //Agregado sealed
    {
        //Agregado private en ambos atributos
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos //Enumerados arreglados con sus respectivos nombres.
        }

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto que inicializa la lista.
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor sobrecargado que asigna el espacio disponible 
        /// con el parámetro.
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible) : this() //Agregado this() para que llame al contructor por defecto.
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>Cadena con todos los datos del taller.</returns>
        public override string ToString() //Arreglado override
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="t">Elemento a exponer</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Todos los datos del elemento y su lista en un string.</returns>
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");

            foreach(Vehiculo v in t.vehiculos)
            {
                switch(tipo)
                {
                    //Arreglados los case con su respectivo ETipo
                    case ETipo.Ciclomotor:
                        if(v is Ciclomotor) //Agregado filtrado por Ciclomotor
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if(v is Sedan) //Agregado filtrado por Sedan
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.SUV:
                        if(v is Suv) //Agregado filtrado por SUV
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString(); //Arreglado .ToString()
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="t">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Si se pudo, el Taller con el elemento agregado.
        /// Si no, el Taller sin modificación.</returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            bool repetido = false; //Agregado flag

            //Agregada condición para verificar el espacio disponible
            if(t.vehiculos.Count < t.espacioDisponible)
            {
                foreach (Vehiculo v in t.vehiculos) //Arreglado .vehiculos
                {
                    if(v == vehiculo)
                    {
                        repetido = true; //Si lo encontro, flag en true
                        break;
                    }
                }

                if(!repetido) //Si no lo encontró, lo agrega
                {
                    t.vehiculos.Add(vehiculo);
                }
            }

            return t;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="t">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Si se pudo, el Taller sin el elemento.
        /// Si no, el Taller sin modificación.</returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            foreach(Vehiculo v in t.vehiculos) //Arreglado .vehiculos
            {
                if(v == vehiculo)
                {
                    t.vehiculos.Remove(vehiculo); //Agregado .Remove para que elimine el vehiculo.
                    break;
                }
            }

            return t;
        }
        #endregion
    }
}
