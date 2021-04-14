using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public int Rating { get; set; }

        public int Serves { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public string TotalTime { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        //JSON string
        public string[] Utensils { get; set; }

        //JSON string
        public string Instructions { get; set; }

        public string ImgUrl { get; set; }

        public string SubmittedBy { get; set; }
    }

}
