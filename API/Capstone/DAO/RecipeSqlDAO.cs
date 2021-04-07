using Capstone.Models;
using Microsoft.AspNetCore.Http;
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

                    string sqlText = "INSERT INTO recipe (recipe_name, description, is_public, serves, prep_time, cook_time, total_time, " +
                        "ingredients, utensils, instructions, img_url)" +
                        "VALUES (@recipe_name, @description, @is_public, @serves, @prep_time, @cook_time, @total_time, " +
                        "@ingredients, @utensils, @instructions, @img_url);" +
                        "select scope_Identity();";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@recipe_name", recipe.Name);
                    cmd.Parameters.AddWithValue("@description", recipe.Description);
                    cmd.Parameters.AddWithValue("@is_public", recipe.IsPublic ? 1 : 0);
                    cmd.Parameters.AddWithValue("@serves", recipe.Serves);
                    cmd.Parameters.AddWithValue("@prep_time", recipe.PrepTime);
                    cmd.Parameters.AddWithValue("@cook_time", recipe.CookTime);
                    cmd.Parameters.AddWithValue("@total_time", recipe.TotalTime);
                    cmd.Parameters.AddWithValue("@ingredients", recipe.Ingredients);
                    cmd.Parameters.AddWithValue("@utensils", recipe.Utensils);
                    cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                    cmd.Parameters.AddWithValue("@img_url", recipe.ImgUrl);
                    recipe.RecipeId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            //TODO needs better exception handling
            catch (SqlException)
            {
                throw;
            }
            //TODO what should we return here?  revisit when working on front-end
            return recipe;
        }

        public List<Recipe> GetPublicRecipes()
        {
            List<Recipe> recipes = new List<Recipe>() { };

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select recipe.recipe_id, recipe_name, description, is_public, serves, prep_time, cook_time, total_time, " +
                        "ingredients, utensils, instructions, img_url " +
                        "from recipe " +
                        "where is_public = 1;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        recipes.Add(GetRecipeFromReader(reader));
                    }

                    return recipes;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Recipe> GetRecipes(int userId)
        {
            List<Recipe> recipes = new List<Recipe>() { };

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select recipe.recipe_id, recipe_name, description, is_public, serves, prep_time, cook_time, total_time, " +
                        "ingredients, utensils, instructions, img_url " +
                        "from recipe " +
                        "join recipe_users on recipe_users.recipe_id = recipe.recipe_id " +
                        "where user_id = @user_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        recipes.Add(GetRecipeFromReader(reader));
                    }

                    return recipes;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Recipe> SearchRecipes(string[] args, bool fuzzy)
        {
            List<Recipe> recipes = new List<Recipe>() { };

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select recipe.recipe_id, recipe_name, description, is_public, serves, prep_time, cook_time, total_time, " +
                        "ingredients, utensils, instructions, img_url " +
                        "from recipe ";

                    // TODO
                    // Trying to implement the ability to search for multiple ingredients, and fuzzy searching.
                    // Similar to this link.
                    // https://www.svenbit.com/2014/08/using-sqlparameter-with-sqls-in-clause-in-csharp/
                    List<string> ParamList = new List<string>();
                    int index = 0;
                    foreach (string query in args)
                    {
                        string paramName = "@queryParam" + index;
                        if (fuzzy)
                        {
                            sqlText += $"where JSON_Query(ingredients, '$') like '%@{paramName}%' ";
                        }
                        else
                        {
                            sqlText += $"where JSON_Query(ingredients, '$') = @{paramName} ";
                        }
                        
                        index++;
                    }
                                            
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    for (int i = 0; i < args.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(ParamList[i], args[i]);
                    }
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        recipes.Add(GetRecipeFromReader(reader));
                    }

                    return recipes;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Recipe GetRecipe(int recipeId)
        {
            Recipe returnRecipe = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "SELECT recipe_id, recipe_name, description, is_public, serves, prep_time, cook_time, total_time, " +
                        "ingredients, utensils, instructions, img_url " +
                        "FROM recipe " +
                        "WHERE recipe_id = @recipe_id";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
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

                    string sqlText = "update recipe " +
                        "set " +
                        "recipe_name = @recipe_name, " +
                        "description = @description, " +
                        "serves = @serves, " +
                        "prep_time = @prep_time, " +
                        "cook_time = @cook_time, " +
                        "total_time = @total_time, " +
                        "ingredients = @ingredients, " +
                        "utensils = @utensils, " +
                        "instructions = @instructions, " +
                        "img_url = @img_url " +
                        "where recipe_id = @recipe_id;";

                    //TODO Need to finish select statement and params
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@recipe_name", recipe.Name);
                    cmd.Parameters.AddWithValue("@description", recipe.Description);
                    cmd.Parameters.AddWithValue("@is_public", recipe.IsPublic ? 1 : 0);
                    cmd.Parameters.AddWithValue("@serves", recipe.Serves);
                    cmd.Parameters.AddWithValue("@prep_time", recipe.PrepTime);
                    cmd.Parameters.AddWithValue("@cook_time", recipe.CookTime);
                    cmd.Parameters.AddWithValue("@total_time", recipe.TotalTime);
                    cmd.Parameters.AddWithValue("@ingredients", recipe.Ingredients);
                    cmd.Parameters.AddWithValue("@utensils", recipe.Utensils);
                    cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                    cmd.Parameters.AddWithValue("@img_url", recipe.ImgUrl);
                    cmd.Parameters.AddWithValue("@recipe_id", recipe.RecipeId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException)
            {
                throw;
            }
            return GetRecipe(recipe.RecipeId);
        }

        public bool DeleteRecipe(int recipeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "delete from category_recipe " +
                        "where recipe_id = @recipe_id; " +
                        "delete from meal_recipe " +
                        "where recipe_id = @recipe_id; " +
                        "delete from recipe_users " +
                        "where recipe_id = @recipe_id; " +
                        "delete from recipe " +
                        "where recipe_id = @recipe_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Recipe GetRecipeFromReader(SqlDataReader reader)
        {
            Recipe r = new Recipe()
            {
                RecipeId = Convert.ToInt32(reader["recipe_id"]),
                Name = Convert.ToString(reader["recipe_name"]),
                Description = Convert.ToString(reader["description"]),
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
