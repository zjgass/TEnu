using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController :Controller
    {
        private readonly IRecipeDAO recipeDAO;

        //GetRecipe
        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> GetRecipe(int recipeId)
        {
            return Ok(recipeDAO.GetRecipe(recipeId));
        }
        //CreateRecipe
        [HttpPost]
        public ActionResult<RecipeController> CreateRecipe(Recipe recipe)
        {
            Recipe added = recipeDAO.CreateRecipe(recipe);
            return Created($"/recipe/{recipe.RecipeId}", added);
        }
        //UpdateRecipe
        [HttpPut("{recipeId}")]
        public ActionResult<RecipeController> UpdateRecipe(Recipe recipe)
        {
            Recipe updated = recipeDAO.UpdateRecipe(recipe);
            return Ok(updated);
        }
        //TODO Delete

        //TODO get api/recipe return all recipes of user
    }
}
