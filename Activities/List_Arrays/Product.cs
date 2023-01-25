using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasMatrices
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public Producto()
        {

        }

        public Producto(int Codigo, string Descripcion)
        {
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
        }
    }

}
