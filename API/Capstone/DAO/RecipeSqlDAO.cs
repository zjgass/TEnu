using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class RecipeSqlDAO : IRecipeDAO
    {

        private readonly string connectionString;

        public RecipeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Recipe CreateRecipe(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO recipe (recipe_name, is_public, serves, prep_time, cook_time, total_time, ingredients, utensils, instructions, img_url)" +
                                                     " VALUES (@recipe_name, @is_public, @serves, @prep_time, @cook_time, @total_time, @ingredients, @utensils, @instructions, @img_url)", conn);
                    cmd.Parameters.AddWithValue("@recipe_name", recipe.Name);
                    //need to convert bool to bit for is_public column in DB
                    cmd.Parameters.AddWithValue("@is_public", recipe.IsPublic ? 1 : 0);
                    cmd.Parameters.AddWithValue("@serves", recipe.Serves);
                    cmd.Parameters.AddWithValue("@prep_time", recipe.PrepTime);
                    cmd.Parameters.AddWithValue("@cook_time", recipe.CookTime);
                    cmd.Parameters.AddWithValue("@total_time", recipe.TotalTime);
                    cmd.Parameters.AddWithValue("@ingredients", recipe.Ingredients);
                    cmd.Parameters.AddWithValue("@utensils", recipe.Utensils);
                    cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                    cmd.Parameters.AddWithValue("@img_url", recipe.ImgUrl);
                    cmd.ExecuteNonQuery();
                }
            }
            //TODO needs better exception handling
            catch (SqlException)
            {
                throw;
            }
            //TODO needs fixed, will need to grab id when execting sql statement to use it here
            return GetRecipe();
        }

        public Recipe GetRecipe(int recipeId)
        {
            Recipe returnRecipe = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipe_id, recipe_name, is_public, servings, prep_time, cook_time, total_time, ingredients, utensils, instructions, img_url FROM recipe WHERE recipe_id = @recipe_id", conn);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.HasRows && reader.Read())
                    {
                        returnRecipe = GetRecipeFromReader(reader);
                    }
                }
            }
            //TODO implement better exception handling
            catch (SqlException)
            {
                throw;
            }
            return returnRecipe;     
        }

        //TODO needs implemented
        public Recipe UpdateRecipe(Recipe recipe)
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //TODO Need to finish select statement and params
                    SqlCommand cmd = new SqlCommand("", conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException)
            {
                throw;
            }
            return GetRecipe(recipe.RecipeId);
        }

        private Recipe GetRecipeFromReader(SqlDataReader reader)
        {
            Recipe r = new Recipe()
            {
                RecipeId = Convert.ToInt32(reader["recipe_id"]),
                Name = Convert.ToString(reader["recipe_name"]),
                //TODO probably needs changed to covert 1 to true, 0 to false from bit
                IsPublic = Convert.ToBoolean(reader["is_public"]),
                Serves = Convert.ToInt32(reader["serves"]),
                PrepTime = Convert.ToString(reader["prep_time"]),
                CookTime = Convert.ToString(reader["cook_time"]),
                TotalTime = Convert.ToString(reader["total_time"]),
                Ingredients = Convert.ToString(reader["ingredients"]),
                Utensils = Convert.ToString(reader["utensils"]),
                Instructions = Convert.ToString(reader["instructions"]),
                ImgUrl = Convert.ToString(reader["img_url"]),

            };
            return r;
        }


    }
}
