using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Karen Villarreal 2A TP - Test Consola";

            Fabrica f1 = new Fabrica("Karen V");

            //SE CREAN LOS PRODUCTOS DIFERENTES 
            Mouse m1 = new Mouse(EColor.Blanco, EMarca.Logitech, true, 5);
            Mouse m2 = new Mouse(EColor.Negro, EMarca.Razer, false, 7);
            Teclado t1 = new Teclado(EColor.Rojo, EMarca.Redragon, true, ETipoTeclado.Mecanico);
            Teclado t2 = new Teclado(EColor.Verde, EMarca.Razer, false, ETipoTeclado.Optico);
            Auricular a1 = new Auricular(EColor.Rosa, EMarca.Logitech, true, true);

            //SE AGREGAN A LA FABRICA

            try
            {
                if (f1 + m1)
                {
                    Console.WriteLine($"Se fabricó el periférico...");
                }

                if (f1 + m2)
                {
                    Console.WriteLine($"Se fabricó el periférico...");
                }

                if (f1 + t1)
                {
                    Console.WriteLine($"Se fabricó el periférico...");
                }

                if (f1 + t2)
                {
                    Console.WriteLine($"Se fabricó el periférico...");
                }

                if (f1 + a1)
                {
                    Console.WriteLine($"Se fabricó el periférico...");
                }

                //EXCEPCION
                if (f1 + a1)
                { }
            }
            catch (PerifericosException ex)
            {
                Console.WriteLine(ex.InformarPerifericoRepetido());
            }

            //MUESTRO
            Console.WriteLine(f1);
            Console.WriteLine($"Toque enter para continuar...");
            Console.ReadLine();
            Console.Clear();

            //SE MARCA M1 Y A1 COMO DEFECTUOSOS
            m1.Defectuoso = true;
            a1.Defectuoso = true;

            Console.WriteLine(f1); //MUESTRO

            Console.WriteLine($"Toque enter para continuar...");
            Console.ReadLine();
            Console.Clear();

            try
            {
                //ELIMINO M1 - EXITOSO
                if (f1 - m1)
                {
                    Console.WriteLine($"Se desechó el periférico...");
                }

                //ELIMINO M2 - FALLIDO (NO ES DEFECTUOSO)
                if (f1 - m2)
                { }
            }
            catch(PerifericosException ex)
            {
                Console.WriteLine(ex.InformarPerifericoNoDefectuoso());
            }

            Console.WriteLine(f1); //MUESTRO

            Console.WriteLine($"Toque enter para continuar...");
            Console.ReadLine();
            Console.Clear();

            try
            {
                if (Fabrica.Escribir(f1, "datos.xml"))
                {
                    Console.WriteLine($"Se guardaron los datos en XML...");
                }

                Console.WriteLine($"Toque enter para continuar...");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"LECTURA DE ARCHIVO .xml");

                Fabrica f2;

                f2 = Fabrica.Leer("datos.xml");

                Console.WriteLine(f2);
            }
            catch (ArchivosException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }
}
