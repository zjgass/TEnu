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

        public MealController(IMealDAO _mealDAO)
        {
            mealDAO = _mealDAO;
        }

        //GetMeals
        [HttpGet]
        public ActionResult<List<Meal>> GetMeals()
        {
            int userId = Int32.Parse(User.FindFirst("sub").Value);
            return Ok(mealDAO.GetMeals(userId));
        }

        //GetMeal
        [HttpGet("{mealId}")]
        public ActionResult<Meal> GetMeal(int mealId)
        {
            return Ok(mealDAO.GetMeal(mealId));
        }
        //CreateMeal
        [HttpPost]
        public ActionResult<Meal> CreateMeal(Meal meal)
        {
            Meal added = mealDAO.CreateMeal(meal);
            return Created($"/meal/{meal.MealId}", added);
        }
        //UpdateMeal
        [HttpPut("{mealId}")]
        public ActionResult<Meal> UpdateMeal(Meal meal)
        {
            Meal updated = mealDAO.UpdateMeal(meal);
            return Ok(updated);
        }
        //TODO ADD DELETE MEAL MESSAGE
        [HttpDelete("{mealId}")]
        public ActionResult DeleteMeal(int mealId)
        {
            bool success = mealDAO.DeleteMeal(mealId);
            if (success)
            {
                return NoContent();
            }

            return BadRequest();
        }

        //TODO ADD GET api/meal return all meals saved by user

    }
    
    
    
}
