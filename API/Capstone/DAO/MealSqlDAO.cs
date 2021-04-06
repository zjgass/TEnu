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
        public Meal CreateMeal(Meal meal)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert INTO meal (meal_name) VALUES (@meal_name);select Scope_Identity() as meal_Identity;" ,conn);
                    
                    cmd.Parameters.AddWithValue("@meal_name", meal.Name);
                    //cmd.Parameters.AddWithValue("@meal_id", meal.MealId);
                    cmd.ExecuteNonQuery();
                        
                        
                }
            }
            catch (SqlException)
            {
                throw ;
            }
            return GetMeal(meal.MealId);
        }
        public Meal AddRecipeToMeal(Meal meal,int RecipeId)
        {
            try
            {
             using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert INTO meal_recipe(meal_id, recipe_id) Values(@meal_id @recipe_id);", conn);
                    cmd.Parameters.AddWithValue("@meal_id", meal.MealId);
                    cmd.Parameters.AddWithValue("@recipe_id",RecipeId);
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

                    //TODO Complete SELECT and Parameters statement
                    SqlCommand cmd = new SqlCommand("SELECT meal_name,meal_id From Meal ", conn);
                    cmd.Parameters.AddWithValue("", mealId);
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
        public List<Meal> GetMeals(int mealId)
        {
            List<Meal> returnMeals = new List<Meal>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                  
                    SqlCommand cmd = new SqlCommand("SELECT meal_name, meal_id From Meal ", conn);
                    cmd.Parameters.AddWithValue("", mealId);
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

        }
        public Meal UpdateMeal(Meal meal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE meal_name SET meal_name = @meal_name WHERE meal_recipe_id = @meal_recipe_id ", conn);
                cmd.Parameters.AddWithValue("@meal_name", meal.Name);
                cmd.Parameters.AddWithValue("@meal_id", meal.MealId);
                cmd.ExecuteNonQuery();
            }
            return GetMeal(meal.MealId);
        }
        private Meal GetMealFromReader(SqlDataReader reader)
        {
            Meal m = new Meal()
            {
                MealId = Convert.ToInt32(reader["meal_id"]),
                Name = Convert.ToString(reader["meal_name"]),
                
            };
            return m;
        }
        
        
    }
}
