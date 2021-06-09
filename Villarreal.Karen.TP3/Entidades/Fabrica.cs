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

        public int CantidadMouse
        {
            get { return this.ObtenerCantidad(ETipoPeriferico.Mouse); }
        }
        public int CantidadTeclado
        {
            get { return this.ObtenerCantidad(ETipoPeriferico.Teclado); }
        }
        public int CantidadAuricular
        {
            get { return this.ObtenerCantidad(ETipoPeriferico.Auricular); }
        }
        #endregion

        #region Métodos
        public int ObtenerCantidad(ETipoPeriferico periferico)
        {
            int mouse = 0;
            int teclados = 0;
            int auriculares = 0;

            foreach(Periferico item in this.perifericos)
            {
                if(item is Mouse)
                {
                    mouse++;
                }

                if(item is Teclado)
                {
                    teclados++;
                }

                if(item is Auricular)
                {
                    auriculares++;
                }
            }

            switch(periferico)
            {
                case ETipoPeriferico.Mouse:
                    return mouse;

                case ETipoPeriferico.Teclado:
                    return teclados;

                default:
                    return auriculares;
            }
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"-- Fábrica de Perifericos {this.nombre} --");
            cadena.AppendLine($"Total fabricados: {this.perifericos.Count}");
            cadena.AppendLine($"");
            cadena.AppendLine($"Listado de {typeof(Periferico).Name}");

            foreach(Periferico item in this.perifericos)
            {
                if(item is Mouse)
                {
                    cadena.AppendLine(item.ToString());
                }

                if(item is Teclado)
                {
                    cadena.AppendLine(item.ToString());
                }

                if(item is Auricular)
                {
                    cadena.AppendLine(item.ToString());
                }
            }

            return cadena.ToString();
        }
        #endregion
    }
}
