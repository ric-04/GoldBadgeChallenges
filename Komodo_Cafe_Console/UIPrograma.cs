using Komodo_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Console
{
    //CREATE RUN METHOD HERE
    public class UIPrograma
    {
        private readonly MenuRepository _repoComida = new MenuRepository();

        public void Correr()
        {
            Semillas();
            Menu();
        }

        private void Menu()
        {
            bool corriendo = true;
            while (corriendo)
            {

                Console.WriteLine("Bienvedida al Menu de Cafe de Komodo! Por favor, haz una seleccion.\n" +
                    "1] Crear un Nuevo Elemento de Menu\n" +
                    "2] Ver menu total\n" +
                    "3] Conseguir Comidas By Id\n" +
                    "4] Eliminar elemento de menu\n" +
                    "----------------------------------------\n" +
                    "50] Salir de la aplicacion");

                string entradaUsario = Console.ReadLine();
                switch (entradaUsario)
                {
                    case "1":
                        CrearElementoNuevo();
                        break;

                    case "2":
                        VerMenuTotal();
                        break;
                    case "3":
                        ConseguirComidasPorID();
                        break;
                    case "4":
                        EliminarElemento();
                        break;

                    case "50":
                        corriendo = false;
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        private void ConseguirComidasPorID()
        {
            Console.Clear();
            Console.WriteLine("Ingrese un numero de comida.");
            int entradaIDComida = Convert.ToInt32(Console.ReadLine());
            ElementoMenu menuItem = _repoComida.ConseguirComidasById(entradaIDComida);
            VerComidaInfo(menuItem);
        }

        private void CrearElementoNuevo()
        {
            Console.Clear();
            ElementoMenu elementoMenu = new ElementoMenu();
            Console.WriteLine("Ingrese un numero de comida.");
            int entradaIDComida = Convert.ToInt32(Console.ReadLine());
            elementoMenu.NumeroDeComida = entradaIDComida;
          //elementoMenu.NumeroDeComida = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Ingrese nombre de comida.");
            string entradaComidaNombre = Console.ReadLine();
            elementoMenu.NombreDeComida = entradaComidaNombre;

            //Description
            Console.WriteLine("Ingerse una descripcion de comida.");
            string entradaDescripcionComida = Console.ReadLine();
          //Call POCO    Call Property = User Input
            elementoMenu.Descripcion = entradaDescripcionComida;
            //List of Ingredients
            bool tieneIngredientesTodo = false;

            while (tieneIngredientesTodo== false)
            //while the boolean is false run this stuff, while hasallingredients is false
            {
                Console.WriteLine("Quieres agregar algunos ingredientes: y/n?");

                string entradaIngrediente = Console.ReadLine();
                if (entradaIngrediente=="y" || entradaIngrediente=="Y")
                {
                    Console.WriteLine("Ingrese un ingrediente.");
                    string entradaValor = Console.ReadLine();
                    elementoMenu.Ingredientes.Add(entradaValor);
                }
                if (entradaIngrediente == "n" || entradaIngrediente == "N")
                {
                    tieneIngredientesTodo = true;
                }

            }

            //Price
            Console.WriteLine("What is the price?");
            decimal entradaPrecio = decimal.Parse(Console.ReadLine());
            elementoMenu.PrecioDeComida = entradaPrecio;

            _repoComida.CrearElementoNuevo(elementoMenu);
        }

        private void VerMenuTotal()
        {
            Console.Clear();
            List<ElementoMenu> comidas = _repoComida.ConseguirTodasComidas();
            foreach (var comida in comidas)
            {
                VerComidaInfo(comida);
            }
        }

        private void VerComidaInfo(ElementoMenu comida)
        {
           
            Console.WriteLine($"{comida.NumeroDeComida}\n" +
                $"{comida.NombreDeComida}\n" +
                $"{comida.Descripcion}\n" +
                $"{comida.PrecioDeComida}\n");
            Console.WriteLine("-----------------------------------");
        }
        private void EliminarElemento()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el numero de la comida para eliminar.");
            int entradaComidaExistente = Convert.ToInt32(Console.ReadLine());
            bool exitoso = _repoComida.EliminarComidaExistente(entradaComidaExistente);

            if (exitoso)
            {
                Console.WriteLine("La comida ha sido elimando");
            }
            else
            {
                Console.WriteLine("La comida fue eliminada.");
            }
        }
        private void Semillas()
        {
            //We added another constructor because we were only passing two parameters, not 5 or 0.
            ElementoMenu pollo = new ElementoMenu(1, "Sobroso Pollo y Parrilla", "Muy sobroso!", 4.99m);
            ElementoMenu tocino = new ElementoMenu(2, "Tocino Cajun Casero", "Sabor excellente", 4.99m);
            ElementoMenu jamon = new ElementoMenu( 3, "Jamon Ahumado", "Muy delicioso!", 4.99m);
            ElementoMenu rosbif = new ElementoMenu(4, "Rosbif Simple y Aburrido", "Simply, aburrido y perfectamente", 4.99m);
            ElementoMenu pavo = new ElementoMenu(5, "Golpea a Tu Madre Pavo!", "Si, es tan bueno!", 5.99m);

            _repoComida.CrearElementoNuevo(pollo);
            _repoComida.CrearElementoNuevo(tocino);
            _repoComida.CrearElementoNuevo(jamon);
            _repoComida.CrearElementoNuevo(rosbif);  
            _repoComida.CrearElementoNuevo(pavo);
        }
    }
}

/* Console.WriteLine("Bienvedido a Cafe de Komodo! Por favor, seleccione una comida.");
"1] Sobroso Pollo y Parrilla/n" +
"2] Tocino Cajun Casero/n" +
"3] Jamon Ahumado" +
"4] Rosbif Simple y Aburrido\n" +
"5] Golpea a Tu Madre Pavo!/n" +
"-------------------------------\n" +
"50] No tienes hambra ahora");

string seleccionComida = Console.ReadLine();
switch (seleccionComida)
{
    case "1"
        ComidaPollo();
        break;

    case "2"
        ComidaTocino();
        break;

    case "3"
        ComidaJamon();
        break;

    case "4"
        ComidaRosbif();
        break;

    case "5"
        ComidaPavo();
        break;
} */