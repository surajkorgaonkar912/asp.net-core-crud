using Microsoft.Data.SqlClient;
using MVC6Crud.Models;
using MVC6Crud.ViewModel;
using System.Collections.Generic;

namespace MVC6Crud.Data
{
    public class clsDB_Product
    {
        private readonly string _connectionString;
        public clsDB_Product(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MVC6CrudConnetionString");
        }

        public List<ProductListViewModel> GetProductList()
        {
            ProductListViewModel model;
            List <ProductListViewModel> modelList = new List<ProductListViewModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * from Products a left join Categories b on a.CategoryId=b.CategoryId ";
                SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@Username", username);
                //cmd.Parameters.AddWithValue("@Password", password); // You should hash the password and match it with the hashed value in the DB.

                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        model = new ProductListViewModel
                        {
                            Id = rdr.GetInt32(rdr.GetOrdinal("Id")), // Assuming "Id" is an int
                            Name = rdr.IsDBNull(rdr.GetOrdinal("Name")) ? null : rdr.GetString(rdr.GetOrdinal("Name")),
                            Description = rdr.IsDBNull(rdr.GetOrdinal("Description")) ? null : rdr.GetString(rdr.GetOrdinal("Description")),
                            Price = rdr.GetDecimal(rdr.GetOrdinal("Price")), // Assuming "Price" is decimal
                            Color = rdr.IsDBNull(rdr.GetOrdinal("Color")) ? null : rdr.GetString(rdr.GetOrdinal("Color")),
                            Image = rdr.IsDBNull(rdr.GetOrdinal("Image")) ? null : rdr.GetString(rdr.GetOrdinal("Image")),
                            CategoryId = rdr.GetInt32(rdr.GetOrdinal("CategoryId")), // Assuming "CategoryId" is an int
                            CategoryName = rdr.IsDBNull(rdr.GetOrdinal("CategoryName")) ? null : rdr.GetString(rdr.GetOrdinal("CategoryName"))
                        };
                        
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
    }
}
