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

        //GetReceipe
        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> GetRecipe(int recipeId)
        {
            return Ok(recipeDAO.GetRecipe(recipeId));
        }
        //CreateReceipe
        [HttpPost]
        public ActionResult<RecipeController> CreateRecipe(Recipe recipe)
        {
            Recipe added = recipeDAO.CreateRecipe(recipe);
            return Created($"/recipe/{recipe.RecipeId}", added);
        }
        //UpdateReceipe
        [HttpPut("{receipeId}")]
        public ActionResult<RecipeController> UpdateReceipe(Recipe recipe)
        {
            Recipe updated = recipeDAO.UpdateRecipe(recipe);
            return Ok(updated);
        }
        //Delete
    }
}
