using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRecipeDAO
    {
        Recipe GetRecipe(int receipeId);

        Recipe CreateRecipe(Recipe recipe);

        Recipe UpdateRecipe(Recipe recipe);

    }
}
