using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extensiones
    {
        public static string InformarPerifericoRepetido(this PerifericosException ex)
        {
            return "El periferico tiene el mismo número de serie y marca que otro en la lista.";
        }

        public static string InformarPerifericoNoDefectuoso(this PerifericosException ex)
        {
            return "El periferico tiene que estar defectuoso para desecharlo.";
        }

        public static string InformarArchivoErroneo(this ArchivosException ex)
        {
            return "Verifique que el archivo seleccionado sea .xml";
        }
    }
}
