using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPlanDAO
    {

        Plan GetPlan(int planId);

        Plan CreatePlan(Plan plan);

        Plan UpdatePlan(Plan plan);

        List<Plan> GetPlans(int userId);

        bool DeletePlan(int planID);
    }
}
