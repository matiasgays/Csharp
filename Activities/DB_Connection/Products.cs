using DataBaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBaseDatos
{
    public class Products
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public double SalePrice { get; set; }
        public int Stock { get; set; }
        public long UserID { get; set; }

        public Products() { }

        public Products(string description, double cost, double salePrice, int stock, long userID)
        {
            Description = description;
            Cost = cost;
            SalePrice = salePrice;
            Stock = stock;
            UserID = userID;
        }

        public Products(long id, string description, double cost, double salePrice, int stock, long userID)
        {
            Id = id;
            Description = description;
            Cost = cost;
            SalePrice = salePrice;
            Stock = stock;
            UserID = userID;
        }

        public static Products LoadProduct(SqlDataReader reader)
        {
            Products products = new Products();
            products.Id = Convert.ToInt64(reader["Id"]);
            products.Description = reader["Descripciones"].ToString();
            products.Cost = Convert.ToInt32(reader["Costo"]);
            products.SalePrice = Convert.ToInt32(reader["PrecioVenta"]);
            products.Stock = Convert.ToInt16(reader["Stock"]);
            products.UserID = Convert.ToInt64(reader["IdUsuario"]);

            return products;
        }

        public static void PrintProducts(List<Products> list)
        {
            foreach (Products product in list)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}     \t{4}    \t{5}",
                    product.Id,
                    product.Description,
                    product.Cost,
                    product.SalePrice,
                    product.Stock,
                    product.UserID
                    );
            }
            return;
        }
    }
}
