using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Entidades
{
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Escribe los datos en un archivo tipo Xml.
        /// </summary>
        /// <param name="path">Ruta del archivo.</param>
        /// <param name="datos">Datos a escribir.</param>
        /// <returns>True si fue exitoso, False si no.</returns>
        public bool Escribir(string path, T datos)
        {
            bool rta = false;

            try
            {
                if(Path.GetExtension(path) == ".xml") //Verifica que sea xml
                {
                    using(XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));

                        ser.Serialize(writer, datos); //Serializa los datos
                        rta = true;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                throw new ArchivosException();
            }

            return rta;
        }

        /// <summary>
        /// Lee los datos y deserializa en un objeto.
        /// </summary>
        /// <param name="path">Ruta del archivo.</param>
        /// <returns>Objeto con los datos deserializados.</returns>
        public T Leer(string path)
        {
            T datosObtenidos = default(T);

            try
            {
                if(Path.GetExtension(path) == ".xml") //Verifica que sea xml
                {
                    using(XmlTextReader reader = new XmlTextReader(path))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));

                        datosObtenidos = (T)ser.Deserialize(reader); //Deserializa en el objeto
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                throw new ArchivosException();
            }

            return datosObtenidos;
        }
    }
}
