using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    public class Users
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public Users() { }

        public Users(string name, string lastName, string userName,string password, string mail) { 
            Name= name;
            LastName= lastName;
            UserName= userName;
            Password= password;
            Mail= mail;
        }

        public Users(long id, string name, string lastName, string userName, string password, string mail)
        {
            Id= id;
            Name = name;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Mail = mail;
        }

        public static Users LoadUser(SqlDataReader reader)
        {
            Users user = new Users();
            user.Id = Convert.ToInt64(reader["Id"]);
            user.Name = reader["Nombre"].ToString();
            user.LastName = reader["Apellido"].ToString();
            user.UserName = reader["NombreUsuario"].ToString();
            user.Password = reader["Contraseña"].ToString();
            user.Mail = reader["Mail"].ToString();

            return user;
        }

        public static void PrintUsers(List<Users> list)
        {
            foreach (Users user in list)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}     \t{4}    \t{5}",
                    user.Id,
                    user.Name,
                    user.LastName,
                    user.UserName,
                    user.Password,
                    user.Mail
                    );
            }
            return;
        }

    }
}
