using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabrica
    {
        private List<Periferico> perifericos;
        public string nombre;

        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa la lista de perifericos.
        /// </summary>
        private Fabrica()
        {
            this.perifericos = new List<Periferico>();
        }

        /// <summary>
        /// Constructor con parametro.
        /// Asigna el nombre de la fabrica.
        /// </summary>
        /// <param name="nombre">Nombre a asignar.</param>
        public Fabrica(string nombre) : this()
        {
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de solo lectura de la lista de perifericos.
        /// </summary>
        public List<Periferico> Perifericos 
        {
            get { return this.perifericos; } 
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Escribe los datos de la fabrica en un archivo xml.
        /// </summary>
        /// <param name="f">Fabrica a escribir.</param>
        /// <param name="path">Ruta del archivo.</param>
        /// <returns>True si fue exitoso, false si no.</returns>
        public static bool Escribir(Fabrica f, string path) 
        {
            Xml<Fabrica> eF = new Xml<Fabrica>();

            return eF.Escribir(path, f);
        }

        /// <summary>
        /// Lee los datos de un archivo xml.
        /// </summary>
        /// <param name="path">Ruta del archivo.</param>
        /// <returns>Fabrica nueva con los datos del archivo.</returns>
        public static Fabrica Leer(string path)
        {
            Xml<Fabrica> lF = new Xml<Fabrica>();

            return lF.Leer(path);
        }

        /// <summary>
        /// Busca el indice de un Periferico.
        /// </summary>
        /// <param name="p">Periferico a buscar.</param>
        /// <returns>Indice del periferico. -1 si no pudo encontrarlo.</returns>
        private int GetIndice(Periferico p)
        {
            int indice = -1;

            for (int i = 0; i < this.Perifericos.Count; i++)
            {
                if (p == this.Perifericos[i])
                {
                    indice = i;
                    break;
                }
            }

            return indice;
        }

        /// <summary>
        /// Convierte la fabrica actual en una lista completa de toda su información.
        /// </summary>
        /// <returns>Lista de información en string.</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            
            cadena.AppendLine($"");
            cadena.AppendLine($"-- Fábrica de Perifericos {this.nombre} --");
            cadena.AppendLine($"Total fabricados: {this.Perifericos.Count}");
            cadena.AppendLine($"");
            cadena.AppendLine($"Listado de Perifericos fabricados:");
            cadena.AppendLine($"");
            cadena.AppendLine(this.Ficha());

            return cadena.ToString();
        }

        /// <summary>
        /// Apartir de la lista de perifericos crea una cadena 
        /// con la información de cada uno.
        /// </summary>
        /// <returns>Listado de información en string.</returns>
        public string Ficha()
        {
            StringBuilder cadena = new StringBuilder();

            foreach(Periferico item in this.Perifericos)
            {
                cadena.AppendLine(item.ToString());
            }

            return cadena.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Verifica si un periferico está en la fábrica.
        /// </summary>
        /// <param name="f">Fabrica en la cual se va a buscar.</param>
        /// <param name="p">Periferico a buscar.</param>
        /// <returns>True si lo encontro, False si no.</returns>
        public static bool operator ==(Fabrica f, Periferico p)
        {
            bool rta = false;

            foreach (Periferico item in f.Perifericos)
            {
                if(item.Equals(p))
                {
                    rta = true;
                    break;
                }
            }

            return rta;
        }

        /// <summary>
        /// Verifica si un periferico no está en la fábrica.
        /// </summary>
        /// <param name="f">Fabrica en la cual se va a buscar.</param>
        /// <param name="p">Periferico a buscar.</param>
        /// <returns>True si no lo encontro, False si lo encontro.</returns>
        public static bool operator !=(Fabrica f, Periferico p)
        {
            return !(f == p);
        }

        /// <summary>
        /// Agrega un periferico a la lista siempre y cuando no esté repetido.
        /// </summary>
        /// <param name="f">Fabrica en la cual se va a agregar.</param>
        /// <param name="a">Periferico a agregar.</param>
        /// <returns>True si lo pudo agregar, False si no.</returns>
        public static bool operator +(Fabrica f, Periferico a)
        {
            bool rta = false;

            try
            {
                if(f != a)
                {
                    f.Perifericos.Add(a);
                    rta = true;
                }
                else
                {
                    throw new PerifericosException("Error: El periferico tiene el mismo número de serie que otro en la lista.");
                }
            }
            catch(Exception ex)
            {
                throw new PerifericosException(ex);
            }

            return rta;
        }

        /// <summary>
        /// Elimina un periferico de la lista siempre y cuando esté defectuoso y exista.
        /// </summary>
        /// <param name="f">Fabrica en la cual se va a eliminar.</param>
        /// <param name="a">Periferico a eliminar.</param>
        /// <returns>True si lo pudo eliminar, False si no.</returns>
        public static bool operator -(Fabrica f, Periferico a)
        {
            int indice = f.GetIndice(a); //Busca el indice
            bool rta = false;

            try 
            { 
                if(a.Defectuoso == true) //Verifica que esté defectuoso
                {
                    f.Perifericos.RemoveAt(indice);
                    rta = true;
                }
                else
                {
                    throw new PerifericosException("Error: El periferico tiene estar defectuoso para desecharlo.");
                }
            }
            catch(Exception ex)
            {
                throw new PerifericosException(ex);
            }
            
            return rta;
        }
        #endregion
    }
}
