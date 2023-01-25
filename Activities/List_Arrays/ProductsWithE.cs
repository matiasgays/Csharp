using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasMatrices
{
    public class ProductosConE
    {
        private List<Producto> _productosConE;

        public ProductosConE()
        {
            _productosConE = new List<Producto>();
        }

        public void InsertarEnLista(Producto[] arrayProductos)
        {
            foreach (Producto producto in arrayProductos)
            {
                if (producto.Descripcion.ToLower().Contains("e"))
                    _productosConE.Add(producto);
            };
        }

        public void MostrarLista()
        {
            foreach (Producto producto in _productosConE)
            {
                Console.WriteLine($"Codigo: {producto.Codigo} -- Descripcion: {producto.Descripcion}");
            }
        }

        public void LimpiarLista()
        {
            _productosConE.Clear();
            Console.WriteLine(_productosConE.Count);
        }

    }
}
