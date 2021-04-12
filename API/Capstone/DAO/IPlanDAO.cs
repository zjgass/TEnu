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

        Plan CreatePlan(Plan plan, int userId);

        Plan UpdatePlan(Plan plan);

        List<Plan> GetPlans(int userId);

        List<Ingredient> GetGroceryList(int planId);

        bool AddMealToPlan(int planId, string mealDay, string mealTime, int mealId);

        bool DeleteMealFromPlan(int planId, string mealDay, string mealTime, int mealId);

        bool DeletePlan(int planID);
    }
}
