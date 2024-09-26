using Microsoft.Data.SqlClient;
using MVC6Crud.Models;

namespace MVC6Crud.Data
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MVC6CrudConnetionString");
        }

        public User ValidateUser(string username, string password)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT u.UserId, u.Username, r.RoleName FROM Users u JOIN Roles r ON u.RoleId = r.RoleId WHERE u.Username = @Username AND u.PasswordHash = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // You should hash the password and match it with the hashed value in the DB.

                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        user = new User
                        {
                            UserId = (int)rdr["UserId"],
                            Username = rdr["Username"].ToString(),
                            Role = rdr["RoleName"].ToString()
                        };
                    }
                }
            }
            return user;
        }
    }

}
