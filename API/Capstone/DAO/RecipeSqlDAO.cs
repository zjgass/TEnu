﻿using Capstone.Models;
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

        public Recipe CreateRecipe(Recipe recipe, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "insert into recipe (recipe_name, description, is_public, rating, serves, " +
                        "prep_time, cook_time, total_time, " +
                        "utensils, instructions, img_url, submitted_by)" +
                        "values (@recipe_name, @description, @is_public, @rating, @serves, " +
                        "@prep_time, @cook_time, @total_time, " +
                        "@utensils, @instructions, @img_url, " +
                        "(select username from users where user_id = @user_id));" +
                        "select scope_Identity();";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@recipe_name", recipe.Name);
                    cmd.Parameters.AddWithValue("@description", recipe.Description);
                    cmd.Parameters.AddWithValue("@is_public", recipe.IsPublic ? 1 : 0);
                    cmd.Parameters.AddWithValue("@rating", recipe.Rating);
                    cmd.Parameters.AddWithValue("@serves", recipe.Serves);
                    cmd.Parameters.AddWithValue("@prep_time", recipe.PrepTime);
                    cmd.Parameters.AddWithValue("@cook_time", recipe.CookTime);
                    cmd.Parameters.AddWithValue("@total_time", recipe.TotalTime);
                    cmd.Parameters.AddWithValue("@utensils", recipe.Utensils);
                    cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                    cmd.Parameters.AddWithValue("@img_url", recipe.ImgUrl);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    recipe.RecipeId = Convert.ToInt32(cmd.ExecuteScalar());

                    sqlText = "insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty) " +
                        "values ";

                    for (int i = 0; i < recipe.Ingredients.Count; i++)
                    {
                        sqlText += $"((select ingredient_id from ingredient where ingredient_name = @ingredient_name{i}), " +
                                    $"@recipe_id{i}, " +
                                    $"(select unit_id from unit where unit_name = @unit_name{i}), @qty{i}) " + 
                                    (i == recipe.Ingredients.Count - 1 ? "" : ",");
                    }
                    cmd = new SqlCommand(sqlText, conn);
                    for (int i = 0; i < recipe.Ingredients.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@ingredient_name{i}", recipe.Ingredients[i].Name);
                        cmd.Parameters.AddWithValue($"@recipe_id{i}", recipe.RecipeId);
                        cmd.Parameters.AddWithValue($"@unit_name{i}", recipe.Ingredients[i].Unit);
                        cmd.Parameters.AddWithValue($"@qty{i}", recipe.Ingredients[i].Qty);
                    }
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return recipe;
                    }

                    throw new Exception("Adding ingredients sequentially through list is not yet working.");
                }
            }
            //TODO needs better exception handling
            catch (SqlException e)
            {
                throw e;
            }
            //TODO what should we return here?  revisit when working on front-end
        }

        public List<Recipe> GetPublicRecipes()
        {
            List<Recipe> recipes = new List<Recipe>() { };
            Recipe currentRecipe = new Recipe();
            Recipe previousRecipe = new Recipe();
            Ingredient ingredient = new Ingredient();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select recipe.recipe_id, recipe_name, description, is_public, rating, serves, " +
                        "prep_time, cook_time, total_time, " +
                        "utensils, instructions, img_url, submitted_by," +
                        "ingredient.ingredient_id, ingredient_name, qty, unit_name " +
                        "from recipe " +
                        "join recipe_users on recipe_users.recipe_id = recipe.recipe_id " +
                        "join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id " +
                        "join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id " +
                        "join unit on unit.unit_id = ingredient_recipe_unit.unit_id " +
                        "where is_public = 1 " +
                        "order by rating, recipe.recipe_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int previousId = 0;
                    while (reader.Read())
                    {
                        int currentId = Convert.ToInt32(reader["recipe_id"]);

                        if (currentId != previousId)
                        {
                            previousRecipe = currentRecipe;
                            currentRecipe = GetRecipeFromReader(reader);

                            if (previousRecipe.RecipeId != 0)
                            {
                                recipes.Add(previousRecipe);
                            }
                        }

                        ingredient = GetIngredientFromReader(reader);
                        currentRecipe.Ingredients.Add(ingredient);

                        previousId = currentId;
                    }
                    recipes.Add(currentRecipe);

                    return recipes;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Recipe> GetRecipes(int userId)
        {
            List<Recipe> recipes = new List<Recipe>() { };
            Recipe currentRecipe = new Recipe();
            Recipe previousRecipe = new Recipe();
            Ingredient ingredient = new Ingredient();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select recipe.recipe_id, recipe_name, description, is_public, rating, serves, " +
                        "prep_time, cook_time, total_time, " +
                        "utensils, instructions, img_url, submitted_by," +
                        "ingredient.ingredient_id, ingredient_name, qty, unit_name " +
                        "from recipe " +
                        "join recipe_users on recipe_users.recipe_id = recipe.recipe_id " +
                        "join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id " +
                        "join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id " +
                        "join unit on unit.unit_id = ingredient_recipe_unit.unit_id " +
                        "where user_id = @user_id " +
                        "order by rating, recipe.recipe_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int previousId = 0;
                    while (reader.Read())
                    {
                        int currentId = Convert.ToInt32(reader["recipe_id"]);

                        if (currentId != previousId)
                        {
                            previousRecipe = currentRecipe;
                            currentRecipe = GetRecipeFromReader(reader);

                            if (previousRecipe.RecipeId != 0)
                            {
                                recipes.Add(previousRecipe);
                            }
                        }

                        ingredient = GetIngredientFromReader(reader);
                        currentRecipe.Ingredients.Add(ingredient);

                        previousId = currentId;
                    }
                    recipes.Add(currentRecipe);

                    return recipes;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Recipe> SearchRecipes(Query args)
        {
            List<Recipe> recipes = new List<Recipe>() { };
            Recipe currentRecipe = new Recipe();
            Recipe previousRecipe = new Recipe();
            Ingredient ingredient = new Ingredient();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select recipe.recipe_id, recipe_name, description, is_public, rating, serves, " +
                        "prep_time, cook_time, total_time, " +
                        "utensils, instructions, img_url, submitted_by," +
                        "ingredient.ingredient_id, ingredient_name, qty, unit_name " +
                        "from recipe " +
                        "join recipe_users on recipe_users.recipe_id = recipe.recipe_id " +
                        "join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id " +
                        "join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id " +
                        "join unit on unit.unit_id = ingredient_recipe_unit.unit_id ";

                    // TODO
                    // Trying to implement the ability to search for multiple ingredients, and fuzzy searching.
                    // Similar to this link.
                    // https://www.svenbit.com/2014/08/using-sqlparameter-with-sqls-in-clause-in-csharp/
                    List<string> ParamList = new List<string>();
                    int index = 0;
                    foreach (string query in args.Queries)
                    {
                        string paramName = "@queryParam" + index;
                        if (args.Fuzzy)
                        {
                            sqlText += $"where ingredient_name like '%@{paramName}%' ";
                        }
                        else
                        {
                            sqlText += $"where ingredient_name = @{paramName} ";
                        }
                        ParamList.Add(paramName);
                        
                        index++;
                    }
                                            
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    for (int i = 0; i < args.Queries.Count(); i++)
                    {
                        cmd.Parameters.AddWithValue(ParamList[i], args.Queries[i]);
                    }
                    SqlDataReader reader = cmd.ExecuteReader();

                    int previousId = 0;
                    while (reader.Read())
                    {
                        int currentId = Convert.ToInt32(reader["recipe_id"]);

                        if (currentId != previousId)
                        {
                            previousRecipe = currentRecipe;
                            currentRecipe = GetRecipeFromReader(reader);

                            if (previousRecipe.RecipeId != 0)
                            {
                                recipes.Add(previousRecipe);
                            }
                        }

                        ingredient = GetIngredientFromReader(reader);
                        currentRecipe.Ingredients.Add(ingredient);

                        previousId = currentId;
                    }
                    recipes.Add(currentRecipe);

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
            Recipe returnRecipe = new Recipe();
            Ingredient ingredient = new Ingredient();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select recipe.recipe_id, recipe_name, description, is_public, rating, serves, " +
                        "prep_time, cook_time, total_time, " +
                        "utensils, instructions, img_url, submitted_by," +
                        "ingredient.ingredient_id, ingredient_name, qty, unit_name " +
                        "from recipe " +
                        "join recipe_users on recipe_users.recipe_id = recipe.recipe_id " +
                        "join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id " +
                        "join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id " +
                        "join unit on unit.unit_id = ingredient_recipe_unit.unit_id " +
                        "where recipe.recipe_id = @recipe_id " +
                        "order by recipe.recipe_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int previousId = 0;
                    while (reader.Read())
                    {
                        int currentId = Convert.ToInt32(reader["recipe_id"]);

                        if (currentId != previousId)
                        {
                            returnRecipe = GetRecipeFromReader(reader);
                        }

                        ingredient = GetIngredientFromReader(reader);
                        returnRecipe.Ingredients.Add(ingredient);

                        previousId = currentId;
                    }
                }

                return returnRecipe;
            }
            //TODO implement better exception handling
            catch (SqlException)
            {
                throw;
            }
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
                        "is_public = @is_public, " +
                        "rating = @rating," +
                        "serves = @serves, " +
                        "prep_time = @prep_time, " +
                        "cook_time = @cook_time, " +
                        "total_time = @total_time, " +
                        "utensils = @utensils, " +
                        "instructions = @instructions, " +
                        "img_url = @img_url " +
                        "where recipe_id = @recipe_id;";

                    //TODO Need to finish select statement and params
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@recipe_name", recipe.Name);
                    cmd.Parameters.AddWithValue("@description", recipe.Description);
                    cmd.Parameters.AddWithValue("@is_public", recipe.IsPublic ? 1 : 0);
                    cmd.Parameters.AddWithValue("@rating", recipe.Rating);
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
            catch(SqlException e)
            {
                throw e;
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
                        "delete from ingredient_recipe_unit " +
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
            catch (Exception e)
            {

                throw e;
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
                Rating = Convert.ToInt32(reader["rating"]),
                PrepTime = Convert.ToString(reader["prep_time"]),
                CookTime = Convert.ToString(reader["cook_time"]),
                TotalTime = Convert.ToString(reader["total_time"]),
                //Ingredients = Convert.ToString(reader["ingredients"]),
                Utensils = Convert.ToString(reader["utensils"]),
                Instructions = Convert.ToString(reader["instructions"]),
                ImgUrl = Convert.ToString(reader["img_url"]),
                SubmittedBy = Convert.ToString(reader["submitted_by"]),
            };
            return r;
        }

        private Ingredient GetIngredientFromReader(SqlDataReader reader)
        {
            Ingredient i = new Ingredient()
            {
                IngredientId = Convert.ToInt32(reader["ingredient_id"]),
                Name = Convert.ToString(reader["ingredient_name"]),
                Qty = Convert.ToDouble(reader["qty"]),
                Unit = Convert.ToString(reader["unit_name"]),
            };

            return i;
        }
    }
}
