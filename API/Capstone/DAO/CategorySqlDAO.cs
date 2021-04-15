using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class CategorySqlDAO : ICategoryDAO
    {
        private readonly string connectionString;

        public CategorySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select category_id, category_name " +
                        "from category " +
                        "order by category_name;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categories.Add(GetCategoryFromReader(reader));
                    }

                    return categories;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Category CreateCategory(Category category)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "insert into category (category_name) " +
                        "values (@category_name); " +
                        "select scope_identity();";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@category_name", category.Name);
                    category.CategoryId = Convert.ToInt32(cmd.ExecuteScalar());

                    return category;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Category UpdateCategory(Category category)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "update category " +
                        "set category_name = @category_name " +
                        "where category_id = @category_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@category_name", category.Name);
                    cmd.Parameters.AddWithValue("@category_id", category.CategoryId);
                    cmd.ExecuteNonQuery();

                    return category;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Category GetCategoryFromReader(SqlDataReader reader)
        {
            Category c = new Category()
            {
                CategoryId = Convert.ToInt32(reader["category_id"]),
                Name = Convert.ToString(reader["category_name"]),
            };

            return c;
        }
    }
}
