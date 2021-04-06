using Capstone.Models;
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO meal_plan (meal_plan_name, user_id) VALUES (@meal_plan_name, @user_id)", conn);
                    cmd.Parameters.AddWithValue("@meal_plan_name", plan.Name);
                    cmd.Parameters.AddWithValue("@user_id", plan.UserId);
                    cmd.ExecuteNonQuery();
                }
            }
            //TODO Implement better exception handling
            catch (SqlException)
            {
                throw;
            }
            return GetPlan(plan.PlanId);
        }

        public Plan GetPlan(int planId)
        {

            Plan returnPlan = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT meal_plan_id, meal_plan_name, user_id FROM meal_plan WHERE meal_plan_id = @meal_plan_id ", conn);
                    cmd.Parameters.AddWithValue("@meal_plan_id", planId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.HasRows && reader.Read())
                    {
                        returnPlan = GetPlanFromReader(reader);
                    }
                }
            }
            //TODO Implement better error catching
            catch(SqlException)
            {
                throw;
            }

            return returnPlan;
        }

        public List<Plan> GetPlans(int userId)
        {
            List<Plan> returnPlans = new List<Plan>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT meal_plan_id, meal_plan_name, user_id FROM meal_plan", conn);
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

        public Plan UpdatePlan(Plan plan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE meal_plan SET meal_plan_name = @meal_plan_name WHERE meal_plan_id = @meal_plan_id ", conn);
                cmd.Parameters.AddWithValue("@meal_plan_name", plan.Name);
                cmd.Parameters.AddWithValue("@meal_plan_id", plan.PlanId);
                cmd.ExecuteNonQuery();
            }
            return GetPlan(plan.PlanId);
        }

        private Plan GetPlanFromReader(SqlDataReader reader)
        {
            Plan u = new Plan()
            {
                PlanId = Convert.ToInt32(reader["meal_plan_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                Name = Convert.ToString(reader["meal_plan_name"]),
            };

            return u;
        }
    }
}
