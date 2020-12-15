using Komodo_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Komodo_Cafe_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearElementoNuevo()
        {
            //Arrange (SEED Method)
            ElementoMenu pollo = new ElementoMenu(1, "Sobroso Pollo y Parrilla", "Muy sobroso!", 3.99m);
            // This is the repo we are adding ^ menu item to
            MenuRepository _menuRepo = new MenuRepository();

            List<ElementoMenu> menu = _menuRepo.ConseguirTodasComidas();

            //Act
            _menuRepo.CrearElementoNuevo(pollo);
            bool containsItem = menu.Contains(pollo);

            //Assert
            Assert.IsTrue(containsItem);
        }
        //Arrange
    }
}