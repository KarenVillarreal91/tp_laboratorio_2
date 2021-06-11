using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PerifericosException : Exception
    {
        public PerifericosException(string mensaje)
            : base(mensaje)
        { }

        public PerifericosException(Exception innerException)
            : this(innerException.Message)
        { }

        public PerifericosException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        { }
    }
}
