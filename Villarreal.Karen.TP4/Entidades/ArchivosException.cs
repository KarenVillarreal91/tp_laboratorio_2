using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor por defecto vacio
        /// </summary>
        public ArchivosException()
        { }

        /// <summary>
        /// Constructor con parametro string.
        /// </summary>
        /// <param name="mensaje">Mensaje de error ingresado</param>
        public ArchivosException(string mensaje)
            : base(mensaje)
        { }

        /// <summary>
        /// Constructor con parametro exception.
        /// Llama al constructor con parametro string y le coloca su mensaje de error.
        /// </summary>
        /// <param name="innerException">Excepción ingresada</param>
        public ArchivosException(Exception innerException)
            : this(innerException.Message)
        { }
    }
}