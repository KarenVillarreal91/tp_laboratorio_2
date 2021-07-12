using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extensiones
    {
        /// <summary>
        /// Retorna un mensaje informando la similutud del periferico.
        /// </summary>
        /// <param name="ex">Excepción de perifericos.</param>
        /// <returns></returns>
        public static string InformarPerifericoRepetido(this PerifericosException ex)
        {
            return "El periferico tiene el mismo número de serie y marca que otro en la lista.";
        }

        /// <summary>
        /// Retorna un mensaje informando que el periferico no pudo desecharse.
        /// </summary>
        /// <param name="ex">Excepción de perifericos.</param>
        /// <returns></returns>
        public static string InformarPerifericoNoDefectuoso(this PerifericosException ex)
        {
            return "El periferico tiene que estar defectuoso para desecharlo.";
        }

        /// <summary>
        /// Retorna un mensaje informando que el archivo es erroneo.
        /// </summary>
        /// <param name="ex">Excepción de archivos.</param>
        /// <returns></returns>
        public static string InformarArchivoErroneo(this ArchivosException ex)
        {
            return "Verifique que el archivo seleccionado sea .xml";
        }
    }
}
