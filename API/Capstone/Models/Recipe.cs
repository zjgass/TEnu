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

       // public int TempPublicByte { get; set; }
        //TODO revisit if need public set for IsPublic
        /*
        public bool IsPublic
        {
            get
            {
                return (TempPublicByte == 1) ? true : false;
            }
            set
            {
                IsPublic = value;
            }
        }
        */
        public bool IsPublic { get; set; }

        public int Serves { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public string TotalTime { get; set; }
        //JSON string
        public string Ingredients { get; set; }
        //JSON string
        public string Utensils { get; set; }
        //JSON string
        public string Instructions { get; set; }

        public string ImgUrl { get; set; }
    }

}
