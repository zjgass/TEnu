using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class MealSqlDAO :IMealDAO
    {
        private readonly string connectionString;
        public MealSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Meal CreateMeal(Meal meal, int userId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "insert into meal (meal_name, user_id) " +
                        "values (@meal_name, @user_id);" +
                        "select scope_Identity();";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@meal_name", meal.Name);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    meal.MealId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw ;
            }
            return meal;
        }
        public Meal AddRecipeToMeal(Meal meal,int recipeId)
        {
            try
            {
             using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert INTO meal_recipe(meal_id, recipe_id) Values(@meal_id @recipe_id);", conn);
                    cmd.Parameters.AddWithValue("@meal_id", meal.MealId);
                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return GetMeal(meal.MealId); 
        }
        public Meal GetMeal(int mealId)
        {
            Meal returnMeal = null;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "select meal.meal_id, meal_name, recipe_name, user_id " +
                        "from meal " +
                        "join meal_recipe on meal_recipe.meal_id = meal.meal_id " +
                        "join recipe on recipe.recipe_id = meal_recipe.recipe_id " +
                        "where meal.meal_id = @meal_id;";
                    //TODO Complete SELECT and Parameters statement
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@meal_id", mealId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.HasRows&& reader.Read())
                    {
                            returnMeal = GetMealFromReader(reader);
                    }
                }
            }
            //TODO Implement better error catching
            catch(SqlException)
            {
                throw;
            }

            return returnMeal;
        }
        public List<Meal> GetMeals(int userId)
        {
            
            List<Meal> returnMeals = new List<Meal>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    string sqlText = "SELECT meal.meal_id, meal_name, recipe_name, user_id " +
                        "from meal " +
                        "join meal_recipe on meal_recipe.meal_id = meal.meal_id " +
                        "join recipe on recipe.recipe_id = meal_recipe.recipe_id " +
                        "where user_id = @user_id;";
                    //TODO Create joint query
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Meal m = GetMealFromReader(reader);
                            returnMeals.Add(m);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return returnMeals;
            
            throw new NotImplementedException();
        }
        public Meal UpdateMeal(Meal meal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlText = "update meal " +
                    "set meal_name = @meal_name " +
                    "where meal_id = @meal_id;";
                SqlCommand cmd = new SqlCommand(sqlText, conn);
                cmd.Parameters.AddWithValue("@meal_name", meal.Name);
                cmd.Parameters.AddWithValue("@meal_id", meal.MealId);
                cmd.ExecuteNonQuery();
            }
            return GetMeal(meal.MealId);
        }
        public bool DeleteMeal(int mealId)
        {
            try
            {
               using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "delete from meal_recipe " +
                        "where meal_id = @meal_id; " +
                        "delete from meal_mplan " +
                        "where meal_id = @meal_id; " +
                        "delete from meal " +
                        "where meal_id = @meal_id;";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@meal_id", mealId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Meal GetMealFromReader(SqlDataReader reader)
        {
            Meal m = new Meal()
            {
                MealId = Convert.ToInt32(reader["meal_id"]),
                Name = Convert.ToString(reader["meal_name"]),
                UserId = Convert.ToInt32(reader["user_id"])
            };
            return m;
        }
        
        
    }
}
