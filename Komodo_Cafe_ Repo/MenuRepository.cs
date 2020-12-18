
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Repo
{
   public class MenuRepository
    {
        //we need to make a database to hold the info
        private readonly List<ElementoMenu> _menuDirectory = new List<ElementoMenu>();
        // Use Queue here for 2nd Challenge


        // Create
        public void CrearElementoNuevo(ElementoMenu menuItem)
        {
            _menuDirectory.Add(menuItem);
        }
        // Read
        public List<ElementoMenu> ConseguirTodasComidas()
        {
            return _menuDirectory;
        }

        // Helper Method 
        public ElementoMenu ConseguirComidasById(int id)
        {
            foreach (var item in _menuDirectory)
            {
                if (item.NumeroDeComida == id)
                {
                    return item;
                }
            }

            return null;
        }


        //Update

        //Delete
        public bool EliminarComidaExistente(int id)
        {
            ElementoMenu menuItem = ConseguirComidasById(id);

            if (menuItem== null)
            {
                return false;
            }

            int initialCount = _menuDirectory.Count();
            _menuDirectory.Remove(menuItem);

            if (initialCount > _menuDirectory.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
