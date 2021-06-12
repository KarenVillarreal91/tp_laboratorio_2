using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace Test_Unitarios
{
    [TestClass]
    public class FabricaTest
    {
        /// <summary>
        /// Verifica la igualdad de dos perifericos.
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadPerifericos_Ok()
        {
            //Arrage
            Mouse m1 = new Mouse(EColor.Negro, EMarca.Razer, false, 7);
            Mouse m2 = new Mouse(EColor.Blanco, EMarca.Razer, true, 7);

            m1.NroSerie = "G506"; //Asigna valores iguales
            m2.NroSerie = "G506";

            //Act
            bool rta = m1 == m2;

            //Assert
            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Verifica que se creen los perifecos y se agregen a la fabrica correctamente. 
        /// </summary>
        [TestMethod]
        public void FabricarPeriferico_Ok()
        {
            //Arrage
            Fabrica f1 = new Fabrica("KV");

            Auricular a1 = new Auricular(EColor.Rosa, EMarca.Redragon, false, true);
            Teclado t1 = new Teclado(EColor.Verde, EMarca.Razer, true, ETipoTeclado.Mecanico);

            //Act
            bool rta = f1 + a1 && f1 + t1; //Se agregan los perifericos

            //Assert
            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Fuerza una excepción de los perifericos al desecharlos.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(PerifericosException))]
        public void DesecharPeriferico_Exception()
        {
            //Arrage
            Fabrica f1 = new Fabrica("KV");

            Mouse m1 = new Mouse(EColor.Blanco, EMarca.Razer, true, 7);
            Auricular a1 = new Auricular(EColor.Rosa, EMarca.Redragon, false, true);

            //Act
            bool rta = f1 + m1 && f1 + a1;
            m1.Defectuoso = true;
            rta = f1 - m1; //Se elimina
            rta = f1 - m1; //Se intenta eliminar el mismo de nuevo
        }
    }
}