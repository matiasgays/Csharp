using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBaseDatos
{
    public class ProductsSold
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public long Stock { get; set; }
        public long SaleId { get; set; }

        public ProductsSold() { }

        public ProductsSold(int productId, long stock, long saleId)
        {
            ProductId = productId;
            Stock = stock;
            SaleId = saleId;
        }

        public ProductsSold(long id, int productId, long stock, long saleId)
        {
            Id = id;
            ProductId = productId;
            Stock = stock;
            SaleId = saleId;
        }

        public static ProductsSold LoadProductsSold(SqlDataReader reader)
        {
            ProductsSold productsSold = new ProductsSold();
            productsSold.Id = Convert.ToInt64(reader["Id"]);
            productsSold.ProductId = Convert.ToInt16(reader["IdProducto"]);
            productsSold.Stock = Convert.ToInt64(reader["Stock"]);
            productsSold.SaleId = Convert.ToInt64(reader["IdVenta"]);

            return productsSold;
        }

        public static void PrintProductsSold(List<ProductsSold> list)
        {
            foreach (ProductsSold productSold in list)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}",
                    productSold.Id,
                    productSold.ProductId,
                    productSold.Stock,
                    productSold.SaleId
                    );
            }
            return;
        }
    }
}
