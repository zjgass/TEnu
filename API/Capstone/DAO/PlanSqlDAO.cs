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
                    SqlCommand cmd = new SqlCommand("INSERT INTO mplan (mplan_name, user_id) VALUES (@mplan_name, @user_id)", conn);
                    cmd.Parameters.AddWithValue("@mplan_name", plan.Name);
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

                    SqlCommand cmd = new SqlCommand("SELECT mplan_id, mplan_name, user_id FROM mplan WHERE mplan_id = @mplan_id ", conn);
                    cmd.Parameters.AddWithValue("@mplan_id", planId);
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

        public Plan UpdatePlan(Plan plan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE meal_plan SET meal_plan_name = @meal_plan_name WHERE meal_plan_id = @meal_plan_id ", conn);
                cmd.Parameters.AddWithValue("@mplan_name", plan.Name);
                cmd.Parameters.AddWithValue("@mplan_id", plan.PlanId);
                cmd.ExecuteNonQuery();
            }
            return GetPlan(plan.PlanId);
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
    }
}
