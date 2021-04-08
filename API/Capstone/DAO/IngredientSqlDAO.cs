using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class IngredientSqlDAO : IIngredientDAO
    {
        private readonly string connectionString;

        public IngredientSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Ingredient CreateIngredient(Ingredient ingredient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "insert into ingredient (ingredient_name) " +
                        "values (@ingredient_name); " +
                        "select scope_Identity();";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@ingredient_name", ingredient.Name.ToLower());
                    ingredient.IngredientId = Convert.ToInt32(cmd.ExecuteScalar());

                    return ingredient;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select ingredient.ingredient_id, ingredient_name " +
                        "from ingredient " +
                        "join ingredient_recipe_unit on ingredient_recipe_unit.ingredient_id = ingredient.ingredient_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ingredients.Add(GetIngredientFromReader(reader));
                    }

                    return ingredients;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Ingredient GetIngredientFromReader(SqlDataReader reader)
        {
            Ingredient i = new Ingredient()
            {
                IngredientId = Convert.ToInt32(reader["ingredient_id"]),
                Name = Convert.ToString(reader["ingredient_name"]),
            };

            return i;
        }
    }
}
