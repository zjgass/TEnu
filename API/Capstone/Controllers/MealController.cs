using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : Controller
    {
        private readonly IMealDAO mealDAO;

        //GetMeal
        [HttpGet("{mealId}")]
        public ActionResult<Meal> GetMeal(int mealId)
        {
            return Ok(mealDAO.GetMeal(mealId));
        }
        //CreateMeal
        [HttpPost]
        public ActionResult<MealController> CreateMeal(Meal meal)
        {
            Meal added = mealDAO.CreateMeal(meal);
            return Created($"/meal/{meal.MealId}", added);
        }
        //UpdateMeal
        [HttpPut("{mealId}")]
        public ActionResult<MealController> UpdateMeal(Meal meal)
        {
            Meal updated = mealDAO.UpdateMeal(meal);
            return Ok(updated);
        }
        //TODO ADDDELETEMEALMESSAGE


        //TODO ADD GET api/meal return all meals saved by user

    }
    
    
    
}
