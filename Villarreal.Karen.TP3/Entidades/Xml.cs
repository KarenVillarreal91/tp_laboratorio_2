﻿using System;
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
