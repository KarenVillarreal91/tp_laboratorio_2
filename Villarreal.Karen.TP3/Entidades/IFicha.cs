using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IFicha
    {
        /// <summary>
        /// Propiedad de lectura y escritura de atributo Defectuoso.
        /// </summary>
        bool Defectuoso { get; set; }

        /// <summary>
        /// Crea una cadena con una lista de información.
        /// </summary>
        /// <returns>Cadena con la información.</returns>
        string Ficha();
    }
}
