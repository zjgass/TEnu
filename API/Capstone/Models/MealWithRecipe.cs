using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class MealWithRecipe
    {
        public int MealId { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public List<Recipe> RecipeList { get; set; } = new List<Recipe>();

        public string MealDay { get; set; }

        public string MealTime { get; set; }
    }
}
