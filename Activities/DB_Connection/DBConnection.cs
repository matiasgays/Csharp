using ConexionBaseDatos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace DataBaseConnection
{
    public class DBConnection
    {
        private SqlConnection connection;
        private string Server { get; set; }
        private string DataBase { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        public DBConnection(string server, string dataBase, string username, string password)
        {
            Server = server;
            DataBase = dataBase;
            UserName = username;
            Password = password;
        }

        public void Connect()
        {
            string connectionString = $"Server = {Server}; " +
                $"Database = {DataBase}; " +
                $"User Id = {UserName}; " +
                $"Password = {Password}";
            connection = new SqlConnection(connectionString);
            Console.WriteLine("The data base has been successfully connected");
        }

        public void QueryTable(string tableName)
        {
            string query = $"select * from {tableName}";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            Console.WriteLine("Connection open");
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Console.WriteLine(query);
            if (reader.HasRows)
            {
                switch (tableName)
                {
                    case "Usuario":
                        List<Users> userList = new List<Users>();
                        while (reader.Read())
                        {
                            userList.Add(Users.LoadUser(reader));
                        }
                        Users.PrintUsers(userList);
                        break;

                    case "Producto":
                        List<Products> productsList = new List<Products>();
                        while (reader.Read())
                        {
                            productsList.Add(Products.LoadProduct(reader));
                        }
                        Products.PrintProducts(productsList);
                        break;

                    case "ProductoVendido":
                        List<ProductsSold> productsSoldList = new List<ProductsSold>();
                        while (reader.Read())
                        {
                            productsSoldList.Add(ProductsSold.LoadProductsSold(reader));
                        }
                        ProductsSold.PrintProductsSold(productsSoldList);
                        break;

                    case "Venta":
                        List<Sales> salesList = new List<Sales>();
                        while (reader.Read())
                        {
                            salesList.Add(Sales.LoadSales(reader));
                        }
                        Sales.PrintSales(salesList);
                        break;

                    default: break;
                }
                Thread.Sleep(5000);
                Console.WriteLine("Connection closed");
                connection.Close();
                return;
            }
        }

        public void InsertSale(Sales sale)
        {
            string query = "Insert into Venta (Comentarios) " +
                "values (@Comentarios);";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Insert into Venta (Comentarios)" +
                $"values({sale.Comments})");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = sale.Comments });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }

        public void InsertProductSold(ProductsSold productSold)
        {
            string query = "Insert into ProductoVendido (Stock,IdProducto,IdVenta) " +
                "values (@Stock,@IdProducto,@IdVenta);";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Insert into ProductoVendido(Stock,IdProducto,IdVenta)" +
                $"values({productSold.ProductId},{productSold.Stock},{productSold.SaleId})");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productSold.Stock });
            command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productSold.ProductId });
            command.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productSold.SaleId });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }

        public void InsertUser(Users user)
        {
            string query = "Insert into Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) " +
                "values (@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail);";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Insert into Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail)" +
                $"values({user.Name},{user.LastName},{user.UserName},{user.Password},{user.Mail})");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = user.Name });
            command.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = user.LastName });
            command.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = user.UserName });
            command.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = user.Password });
            command.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = user.Mail });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }

        public void InsertProduct(Products product)
        {
            string query = "Insert into Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) " +
                "values (@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario);";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Insert into Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" +
                $"values({product.Description},{product.Cost},{product.SalePrice},{product.Stock},{product.UserID})");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = product.Description });
            command.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = product.Cost });
            command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = product.SalePrice });
            command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = product.Stock });
            command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = product.UserID });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }

        public void Delete(string table, long id)
        {
            string query = $"Delete from {table} " +
                "where Id = @Id;";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Delete from {table} " +
                $"where Id = {id};");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }

        public void UpdateSale(Sales sale)
        {
            string query = "Update Venta " +
                "set Comentarios = @Comentarios " +
                "where Id = @Id";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Update Venta " +
                $"set Comentarios = {sale.Comments} " +
                $"where Id = {sale.Id}");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = sale.Id });
            command.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = sale.Comments });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }

        public void UpdateProducSold(ProductsSold productSold)
        {
            string query = "Update ProductoVendido " +
                "set Stock = @Stock," +
                    "IdProducto = @IdProducto," +
                    "IdVenta = @IdVenta " +
                "where Id = @Id";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Update ProductoVendido " +
                $"set Stock = {productSold.Stock}," +
                    $"IdProducto = {productSold.ProductId}," +
                    $"IdVenta = {productSold.SaleId} " +
                $"where Id = {productSold.Id}");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = productSold.Id });
            command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productSold.Stock });
            command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productSold.ProductId });
            command.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productSold.SaleId });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }

        public void UpdateProduct(Products product)
        {
            string query = "Update Producto " +
                "set Descripciones = @Descripciones," +
                    "Costo = @Costo," +
                    "PrecioVenta = @PrecioVenta, " +
                    "Stock = @Stock," +
                    "IdUsuario = @IdUsuario " +
                "where Id = @Id";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Update ProductoVendido " +
                $"set Descripciones = {product.Description}," +
                    $"Costo = {product.Cost}," +
                    $"PrecioVenta = {product.SalePrice}, " +
                    $"Stock = {product.Stock}," +
                    $"IdUsuario = {product.UserID} " +
                $"where Id = {product.Id}");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = product.Id });
            command.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = product.Description });
            command.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = product.Cost });
            command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = product.SalePrice });
            command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = product.Stock });
            command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = product.UserID });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }

        public void UpdateUser(Users user)
        {
            string query = "Update Usuario " +
                "set Nombre = @Nombre," +
                    "Apellido = @Apellido," +
                    "NombreUsuario = @NombreUsuario, " +
                    "Contraseña = @Contraseña," +
                    "Mail = @Mail " +
                "where Id = @Id";
            connection.Open();
            Console.WriteLine("Connection open");
            Console.WriteLine("Update ProductoVendido " +
                $"set Nombre = {user.Name}, " +
                    $"Apellido = {user.LastName}," +
                    $"NombreUsuario = {user.UserName}, " +
                    $"Contraseña = {user.Password}," +
                    $"Mail = {user.Mail} " +
                $"where Id = {user.Id}");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = user.Id });
            command.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = user.Name });
            command.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = user.LastName });
            command.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = user.UserName });
            command.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = user.Password });
            command.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = user.Mail });
            Console.WriteLine("Rows affected: " + command.ExecuteNonQuery());
            Console.WriteLine("Connection closed");
            Thread.Sleep(2000);
            connection.Close();
            return;
        }
    }
}