using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    
    public class Meal
    {
        public int MealId { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public List<int> RecipeList { get; set; } = new List<int>();
        public string MealDay { get; set; }

        public string MealTime { get; set; }
    }
}
