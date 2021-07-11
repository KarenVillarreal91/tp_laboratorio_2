using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PerifericosException : Exception
    {
        /// <summary>
        /// Constructor por defecto vacio
        /// </summary>
        public PerifericosException()
        { }

        /// <summary>
        /// Constructor con parametro string.
        /// </summary>
        /// <param name="mensaje">Mensaje de error ingresado</param>
        public PerifericosException(string mensaje)
            : base(mensaje)
        { }

        /// <summary>
        /// Constructor con parametro exception.
        /// Llama al constructor con parametro string y le coloca su mensaje de error.
        /// </summary>
        /// <param name="innerException">Excepción ingresada</param>
        public PerifericosException(Exception innerException)
            : this(innerException.Message)
        { }
    }
}
