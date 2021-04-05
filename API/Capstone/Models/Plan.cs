using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Plan
    {
        public int PlanId { get; set; }

        public String PlanName { get; set; }

        List<Meal> PlanMeals { get; set; }
    }
}
