using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivos<T>
    {
        /// <summary>
        /// Escribe los datos en un archivo.
        /// </summary>
        /// <param name="path">Ruta del archivo.</param>
        /// <param name="datos">Datos a escribir.</param>
        /// <returns>True si fue exitoso, False si no.</returns>
        bool Escribir(string path, T datos);

        /// <summary>
        /// Lee los datos y deserializa en un objeto.
        /// </summary>
        /// <param name="path">Ruta del archivo.</param>
        /// <returns>Objeto con los datos deserializados.</returns>
        T Leer(string path);
    }
}
