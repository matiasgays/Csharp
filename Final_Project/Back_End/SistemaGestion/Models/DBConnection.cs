using System.Data;
using System.Data.SqlClient;

namespace WebAPI.Models
{
    public class DBConnection
    {
        private string Server { get; set; }
        private string DataBase { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        public DBConnection()
        {
            Server = "sql.bsite.net\\MSSQL2016";
            DataBase = "matias_c#";
            UserName = "matias_c#";
            Password= "TWG3zHLuFZ8fc@9";
        }

        public SqlConnection Connect()
        {
            string connectionString = $"Server = {Server}; " +
                $"Database = {DataBase}; " +
                $"User Id = {UserName}; " +
                $"Password = {Password}";
            try
            {
                return new SqlConnection(connectionString);
            }
            catch
            {
                throw new Exception("The Data Base was unable to connect to SQL Server");
            }
        }
    }
}
