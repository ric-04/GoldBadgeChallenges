using Komodo_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Komodo_Cafe_Tests
{
    [TestClass]
    public class UnitTest1
    {
        ElementoMenu pollo;
        MenuRepository _menuRepo;
        List<ElementoMenu> menu;

        [TestInitialize]
        public void Arrange()
        {
            pollo = new ElementoMenu(1, "Sobroso Pollo y Parrilla", "Muy sobroso!", 3.99m);

             _menuRepo = new MenuRepository();
            _menuRepo.CrearElementoNuevo(pollo);
           
            menu = _menuRepo.ConseguirTodasComidas();
        }

        [TestMethod]
        public void CrearElementoNuevo()
        {
            //Arrange (SEED Method)
            // This is the repo we are adding ^ menu item to

            //Act
            
            bool containsItem = menu.Contains(pollo);

            //Assert
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void ConseguirTodasComidas()
        {
            //Arrange
            int expected = 2;
           ElementoMenu pollo2 = new ElementoMenu(1, "Sobroso Pollo y Parrilla", "Muy sobroso!", 3.99m);
            //Act
            _menuRepo.CrearElementoNuevo(pollo2);
            Console.WriteLine(menu.Count);
            //Assert
            Assert.AreEqual(expected, menu.Count);
        }

        [TestMethod]
        public void ConseguirComidasById()
        {
            //Arrange
            string expected = "Sobroso Pollo y Parrilla";
            //Act
            ElementoMenu item = _menuRepo.ConseguirComidasById(1);
            //Assert
            Assert.AreEqual(expected, item.NombreDeComida);
        }

        [TestMethod]
        public void EliminarComidaExistente()
        {
            //Arrange
            int expected = 0;
            //Act
            _menuRepo.EliminarComidaExistente(1);
            //Assert
            Assert.AreEqual(expected, menu.Count);
        }
    }
}