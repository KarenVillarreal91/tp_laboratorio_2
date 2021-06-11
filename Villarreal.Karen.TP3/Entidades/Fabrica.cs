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
        private Fabrica()
        {
            this.perifericos = new List<Periferico>();
        }

        public Fabrica(string nombre) : this()
        {
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        public List<Periferico> Perifericos 
        {
            get { return this.perifericos; } 
        }
        #endregion

        #region Métodos
        public static bool Escribir(Fabrica f, string path) 
        {
            Xml<Fabrica> eF = new Xml<Fabrica>();

            return eF.Escribir(path, f);
        }

        public static Fabrica Leer(string path)
        {
            Xml<Fabrica> lF = new Xml<Fabrica>();

            return lF.Leer(path);
        }

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
        public static bool operator !=(Fabrica f, Periferico p)
        {
            return !(f == p);
        }

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

        public static bool operator -(Fabrica f, Periferico a)
        {
            int indice = f.GetIndice(a);
            bool rta = false;

            try 
            { 
                if(a.Defectuoso == true)
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
