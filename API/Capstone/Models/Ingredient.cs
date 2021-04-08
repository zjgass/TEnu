using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string Name { get; set; }

        public double Qty { get; set; }

        public string Unit { get; set; }
    }
}
