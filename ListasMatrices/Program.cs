using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasMatrices
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductosConE productosConE = new ProductosConE();
            Producto[] productos = {
                new Producto(1, "Leche"),
                new Producto(2, "Yoghurt"),
                new Producto(3, "Manteca"),
                new Producto(4, "Crema"),
                new Producto(5, "Fiambre"),
                new Producto(6, "Queso"),
                new Producto(7, "Dulce de leche"),
                new Producto(8, "Azucar"),
                new Producto(9, "Huevo"),
                new Producto(10, "Cacao")
            };

            productosConE.InsertarEnLista(productos);
            productosConE.MostrarLista();
            productosConE.LimpiarLista();
        }
    } 
}
            
