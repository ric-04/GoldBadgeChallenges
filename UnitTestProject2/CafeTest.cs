using Komodo_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class CafeTest
    {
        [TestMethod]
        public void SetComidaNombre_EstableceEntradaCorrecto()
        {
            // Parameters here - Just like the SEED method
            ElementoMenu comida = new ElementoMenu();

            List<ElementoMenu> _menuDirectory = new List<ElementoMenu>();

            List<ElementoMenu> menu = _menuDirectory.ConseguirTodasComidas();

            comida.NombreDeComida = "Sandwich";

            string esperado = "Sandwich";
            string real = comida.NombreDeComida;

            Assert.AreEqual(esperado, real);
        }
    }
}
