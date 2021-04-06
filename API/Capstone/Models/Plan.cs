using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Plan
    {
        public int PlanId { get; set; }

        public int UserId { get; set; }

        public String Name { get; set; }

       

        List<Meal> Meals { get; set; }
    }
}
