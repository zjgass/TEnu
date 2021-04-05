using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IMealDAO
    {
        Meal GetMeal(int mealId);

        Meal CreateMeal(Meal meal);

        Meal UpdateMeal(Meal meal);
    }
}
