using ConexionBaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBConnection newConnection = new DBConnection("sql.bsite.net\\MSSQL2016",
                "matias_c#",
                "matias_c#",
                "TWG3zHLuFZ8fc@9");
            try
            {
                newConnection.Connect();
                newConnection.UpdateUser(new Users(4, "Matias Eduardo", "Gays", "mellogays", "123456", "mellogays@gmail.com"));
                newConnection.UpdateProduct(new Products(7, "crocs", 1000, 2000, 50, 3));
                newConnection.UpdateProducSold(new ProductsSold(1, 1, 222, 1));
                newConnection.UpdateSale(new Sales(5, "update comment"));
                newConnection.Delete("Usuario", 4);
                newConnection.Delete("Venta", 10);
                newConnection.Delete("ProductoVendido", 10);
                newConnection.Delete("Producto", 11);
                newConnection.InsertProduct(new Products("i am a flip flip", 12.32, 23.22, 14, 4));
                newConnection.InsertUser(new Users("Matias Eduardo", "Gays", "mellogays", "asd", "mellogays@gmail.com"));
                newConnection.InsertProductSold(new ProductsSold(3, 12, 8));
                newConnection.InsertSale(new Sales("this is my second insert"));
                newConnection.QueryTable("Usuario");
                newConnection.QueryTable("Producto");
                newConnection.QueryTable("ProductoVendido");
                newConnection.QueryTable("Venta");
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}
