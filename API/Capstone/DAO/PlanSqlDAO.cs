﻿ using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PlanSqlDAO : IPlanDAO
    {

        private readonly string connectionString;

        public PlanSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Plan CreatePlan(Plan plan)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "insert into mplan (mplan_name, user_id) " +
                        "values (@mplan_name, @user_id); " +
                        "select scope_Identity();";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@mplan_name", plan.Name);
                    cmd.Parameters.AddWithValue("@user_id", plan.UserId);
                    plan.PlanId = Convert.ToInt32(cmd.ExecuteScalar());

                    sqlText = "insert into meal_mplan (meal_id, mplan_id, meal_day, meal_time) " +
                        "values ";

                    for (int i = 0; i < plan.Meals.Count; i++)
                    {
                        sqlText += $"(@meal_id{i}, @mplan_id{i}, @meal_day{i}, @meal_time{i}) " +
                                    (i == plan.Meals.Count - 1 ? "; " : ",");
                    }

                    cmd = new SqlCommand(sqlText, conn);
                    for (int i = 0; i < plan.Meals.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@meal_id{i}", plan.Meals[i].MealId);
                        cmd.Parameters.AddWithValue($"@mplan_id{i}", plan.PlanId);
                        cmd.Parameters.AddWithValue($"@meal_day{i}", plan.Meals[i].MealDay);
                        cmd.Parameters.AddWithValue($"@meal_time{i}", plan.Meals[i].MealTime);
                    }
                    cmd.ExecuteNonQuery();
                }

                return plan;
            }
            //TODO Implement better exception handling
            catch (SqlException)
            {
                throw;
            }
        }

        //public Plan GetPlan()
        //{

        //    Plan returnPlan = null;
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT mplan_id, mplan_name, user_id FROM mplan WHERE mplan_id = @mplan_id ", conn);
        //            cmd.Parameters.AddWithValue("@mplan_id", 1); // change to planId
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if(reader.HasRows && reader.Read())
        //            {
        //                returnPlan = GetPlanFromReader(reader);
        //            }
        //        }
        //    }
        //    //TODO Implement better error catching
        //    catch(SqlException)
        //    {
        //        throw;
        //    }

        //    return returnPlan;
        //}

        public Plan GetPlan(int planId)
        {
            Plan plan = new Plan();
            MealWithRecipe currentMeal = new MealWithRecipe();
            MealWithRecipe previousMeal = new MealWithRecipe();
            Recipe currentRecipe = new Recipe();
            Recipe previousRecipe = new Recipe();
            Ingredient ingredient = new Ingredient();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select mplan.mplan_id, mplan_name, mplan.user_id, " +
                            "meal.meal_id, meal_name, meal_day, meal_time, " +
                            "recipe.recipe_id, recipe_name, description, is_public, rating, " +
                                "serves, prep_time, cook_time, total_time, utensils, " +
                                "instructions, img_url, submitted_by, " +
                            "ingredient.ingredient_id, ingredient_name, qty, unit_name " +
                        "from mplan " +
                        "join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id " +
                        "join meal on meal.meal_id = meal_mplan.meal_id " +
                        "join meal_recipe on meal_recipe.meal_id = meal_mplan.meal_id " +
                        "join recipe on recipe.recipe_id = meal_recipe.recipe_id " +
                        "join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = meal_recipe.recipe_id " +
                        "join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id " +
                        "join unit on unit.unit_id = ingredient_recipe_unit.unit_id " +
                        "where mplan.mplan_id = @mplan_id " +
                        "order by meal_day, meal_time, recipe.recipe_id, ingredient.ingredient_name;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@mplan_id", planId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int previousMealId = 0;
                    int previousRecipeId = 0;
                    while (reader.Read())
                    {
                        if (previousMealId == 0)
                        {
                            plan = GetPlanFromReader(reader);
                        }

                        int currentMealId = Convert.ToInt32(reader["meal_id"]);
                        int currentRecipeId = Convert.ToInt32(reader["recipe_id"]);

                        if (currentRecipeId != previousRecipeId)
                        {
                            previousRecipe = currentRecipe;
                            currentRecipe = GetRecipeFromReader(reader);

                            if (previousRecipe.RecipeId != 0)
                            {
                                currentMeal.RecipeList.Add(previousRecipe);
                            }
                        }

                        if (currentMealId != previousMealId)
                        {
                            previousMeal = currentMeal;
                            currentMeal = GetMealFromReader(reader);

                            if (previousMeal.MealId != 0)
                            {
                                plan.Meals.Add(previousMeal);
                            }
                        }

                        ingredient = GetIngredientFromReader(reader);
                        currentRecipe.Ingredients.Add(ingredient);

                        previousMealId = currentMealId;
                        previousRecipeId = currentRecipeId;
                    }
                    currentMeal.RecipeList.Add(currentRecipe);
                    plan.Meals.Add(currentMeal);
                }

                return plan;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Plan> GetPlans(int userId)
        {
            List<Plan> returnPlans = new List<Plan>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //TODO needs completed
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT mplan_id, mplan_name, user_id FROM mplan", conn);
                    cmd.Parameters.AddWithValue("", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Plan u = GetPlanFromReader(reader);
                            returnPlans.Add(u);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnPlans;
        }

        public List<Ingredient> GetGroceryList(int planId)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select mplan.mplan_id, mplan_name, " +
                        "ingredient.ingredient_id, ingredient_name, Sum(qty) as qty, unit_name " +
                        "from mplan " +
                        "join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id " +
                        "join meal_recipe on meal_recipe.meal_id = meal_mplan.meal_id " +
                        "join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = meal_recipe.recipe_id " +
                        "join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id " +
                        "join unit on unit.unit_id = ingredient_recipe_unit.unit_id " +
                        "where mplan.mplan_id = @mplan_id " +
                        "group by mplan.mplan_id, mplan_name, ingredient.ingredient_id, ingredient_name, unit_name " +
                        "order by ingredient.ingredient_name;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@mplan_id", planId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ingredients.Add(GetIngredientFromReader(reader));
                    }
                }

                return ingredients;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Plan UpdatePlan(Plan plan)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "update mplan " +
                        "set mplan_name = @mplan_name " +
                        "where mplan_id = @mplan_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@mplan_name", plan.Name);
                    cmd.Parameters.AddWithValue("@mplan_id", plan.PlanId);
                    cmd.ExecuteNonQuery();

                    foreach (MealWithRecipe meal in plan.Meals)
                    {
                        sqlText = "update meal_mplan " +
                            "set meal_id = @meal_id, " +
                                "meal_day = @meal_day, " +
                                "meal_time = @meal_time " +
                            "where mplan_id = @mplan_id;";
                        cmd = new SqlCommand(sqlText, conn);
                        cmd.Parameters.AddWithValue("@meal_id", meal.MealId);
                        cmd.Parameters.AddWithValue("@meal_day", meal.MealDay);
                        cmd.Parameters.AddWithValue("@meal_time", meal.MealTime);
                    }
                }

                return plan; //TODO We should probably get the new plan here
            }
            //TODO Implement better exception handling
            catch (SqlException)
            {
                throw;
            }
        }

        public bool DeletePlan(int PlanId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "delete from meal_mplan " +
                                        "where mplan_id = @mplan_id; " +
                                        "delete from mplan " +
                                        "where mplan_id = @mplan_id; ";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@mplan_id", PlanId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Plan GetPlanFromReader(SqlDataReader reader)
        {
            Plan u = new Plan()
            {
                PlanId = Convert.ToInt32(reader["mplan_id"]),
                Name = Convert.ToString(reader["mplan_name"]),
                UserId = Convert.ToInt32(reader["user_id"]),
               
            };

            return u;
        }

        private MealWithRecipe GetMealFromReader(SqlDataReader reader)
        {
            MealWithRecipe m = new MealWithRecipe()
            {
                MealId = Convert.ToInt32(reader["meal_id"]),
                Name = Convert.ToString(reader["meal_name"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                MealDay = Convert.ToString(reader["meal_day"]),
                MealTime = Convert.ToString(reader["meal_time"])
            };

            return m;
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
