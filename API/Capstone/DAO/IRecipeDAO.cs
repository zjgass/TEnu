using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRecipeDAO
    {
        Recipe CreateRecipe(Recipe recipe, int userId);

        List<Recipe> GetPublicRecipes();

        List<Recipe> GetRecipes(int userId);

        Recipe GetRecipe(int recipeId);

        Recipe UpdateRecipe(Recipe recipe);

        bool DeleteRecipe(int recipeId);

        List<Recipe> SearchRecipes(string[] args, bool fuzzy);
    }
}
