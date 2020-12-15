using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Repo
{   // CREATED NEW PROJECT (WHERE POCO GOES)
    public class ElementoMenu
    {
        // Key (Everything is attached to this Key)
        public int NumeroDeComida { get; set; }
        public string NombreDeComida { get; set; }

        public string Descripcion { get; set; }
        public List<string> Ingredientes { get; set; } = new List<string>();
        public decimal PrecioDeComida { get; set; }

        public ElementoMenu()
        {

        }
        public ElementoMenu (int numeroDeComida, string nombreDeComida, string descripcion, decimal precioDeComida)
        {
            NumeroDeComida = numeroDeComida;
            NombreDeComida = nombreDeComida;
            Descripcion = descripcion;
            PrecioDeComida = precioDeComida;
        }
        //We made this one, so we didnt have to call all the properties.
        /*public ElementoMenu(int numeroDeComida, string nombreDeComida)
        {
            NumeroDeComida = numeroDeComida;
            NombreDeComida = nombreDeComida;
        }*/
    }
}