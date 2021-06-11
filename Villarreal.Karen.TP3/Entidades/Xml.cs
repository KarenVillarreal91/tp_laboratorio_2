using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    public class Xml<T> : IArchivos<T>
    {
        public bool Escribir(string path, T datos)
        {
            bool rta = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);
                    rta = true;
                }
            }
            catch(Exception ex)
            {
                throw new ArchivosException("Verifique que el archivo seleccionado sea .xml", ex);
            }

            return rta;
        }

        public T Leer(string path)
        {
            T datosObtenidos = default(T);

            try
            {
                using(XmlTextReader reader = new XmlTextReader(path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datosObtenidos = (T)ser.Deserialize(reader);
                }
            }
            catch(Exception ex)
            {
                throw new ArchivosException("Verifique que el archivo seleccionado sea .xml", ex);
            }

            return datosObtenidos;
        }
    }
}
