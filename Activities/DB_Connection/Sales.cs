using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBaseDatos
{
    public class Sales
    {
        public long Id { get; set; }
        public string Comments { get; set; }

        public Sales() { }

        public Sales(string comments)
        {
            Comments= comments;
        }

        public Sales(long id, string comments)
        {
            Id = id;
            Comments = comments;
        }

        public static Sales LoadSales(SqlDataReader reader)
        {
            Sales sales = new Sales();
            sales.Id = Convert.ToInt64(reader["Id"]);
            sales.Comments = reader["Comentarios"].ToString();

            return sales;
        }

        public static void PrintSales(List<Sales> list)
        {
            foreach (Sales sale in list)
            {
                Console.WriteLine("\t{0}\t{1}",
                    sale.Id,
                    sale.Comments
                    );
            }
            return;
        }
    }
}
