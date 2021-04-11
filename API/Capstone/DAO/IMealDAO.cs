using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IMealDAO
    {
        List<Meal> GetMeals(int userId);

        Meal GetMeal(int mealId);

        Meal CreateMeal(Meal meal, int userId);

        Meal UpdateMeal(Meal meal);

        bool DeleteRecipeFromMeal(int recipeId, int mealId);

        bool DeleteMeal(int mealId);
    }
}
