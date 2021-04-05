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

        public bool Public { get; set; }

        public int Servings { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public string TotalTime { get; set; }

        //TODO Add ingredients to Model? Storing as JSON in database

        public string Utensils { get; set; }

        //TODO Add instructions to Model? Storing as JSON in database

        public string ImgUrl { get; set; }
    }

}
