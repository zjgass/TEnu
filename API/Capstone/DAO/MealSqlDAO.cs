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
                        //TODO Complete SELECT statement and parameters
                        SqlCommand cmd = new SqlCommand("", conn);
                }
            }
            throw new NotImplementedException();
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
                    SqlCommand cmd = new SqlCommand("SELECT", conn);
                    cmd.Parameters.AddWithValue("", mealId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.HasRows && reader.Read())
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
            List<Plan> returnMeals = new List<Plan>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //TODO Need to write SELECT and Parameters
                    SqlCommand cmd = new SqlCommand("", conn);
                    cmd.Parameters.AddWithValue("", userId);
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
            catch (SqlException)
            {
                throw;
            }
            return returnMeals;

        }
        public Meal UpdateMeal(Meal meal)
        {
            throw new NotImplementedException();
        }
        private Meal GetMealFromReader(SqlDataReader reader)
        {
            Meal m = new Meal()
            {
                //TODO implement this,need table schema
            };
            return m;
        }
        
        
    }
}
