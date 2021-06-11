using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivos<T>
    {
        bool Escribir(string path, T contenido);

        T Leer(string path);
    }
}
