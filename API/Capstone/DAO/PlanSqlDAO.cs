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
                    //TODO Complete SELECT statment and parameters
                    SqlCommand cmd = new SqlCommand("", conn);
                }
            }
            throw new NotImplementedException();
        }

        public Plan GetPlan(int planId)
        {

            Plan returnPlan = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    //TODO Complete SELECT and Parameters statement
                    SqlCommand cmd = new SqlCommand("SELECT ", conn);
                    cmd.Parameters.AddWithValue("", planId);
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
                    //TODO Need to write SELECT and Parameters 
                    SqlCommand cmd = new SqlCommand("", conn);
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
            throw new NotImplementedException();
        }

        private Plan GetPlanFromReader(SqlDataReader reader)
        {
            Plan u = new Plan()
            {
                //TODO Implement this, need table schema
            };

            return u;
        }
    }
}
