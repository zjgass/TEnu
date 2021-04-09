using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeDAO recipeDAO;

        public RecipeController(IRecipeDAO _recipeDAO)
        {
            recipeDAO = _recipeDAO;
        }

        //GetAllRecipes of current user
        [HttpGet]
        [Authorize]
        public ActionResult<List<Recipe>> GetUserRecipes()
        {
            int userId = Int32.Parse(User.FindFirst("sub").Value);
            return Ok(recipeDAO.GetRecipes(userId));    
        }
       
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
            int userId = Int32.Parse(User.FindFirst("sub").Value);
            Recipe added = recipeDAO.CreateRecipe(recipe, userId);
            return Created($"/recipe/{recipe.RecipeId}", added);
        }
        //UpdateRecipe
        [HttpPut("{recipeId}")]
        public ActionResult<RecipeController> UpdateRecipe(Recipe recipe)
        {
            Recipe updated = recipeDAO.UpdateRecipe(recipe);
            return Ok(updated);
        }
        //Remove Recipe
        [HttpDelete("{recipeId}")]
        public ActionResult RemoveRecipe(int recipeId)
        {
            if(recipeDAO.GetRecipe(recipeId) != null)
            {
                if (recipeDAO.DeleteRecipe(recipeId))
                {
                    return NoContent();
                }
            }
            else
            {
                return NotFound();
            }
            return BadRequest();
        }

        //Get all public recipes
        [HttpGet("public")]
        public ActionResult<List<Recipe>> GetPublicRecipes()
        {
            //TODO do we need any error handling here or is it handled by DAO correctly?
            return Ok(recipeDAO.GetPublicRecipes());
        }

        //Get recipes by search
        [HttpGet("search")]
        public ActionResult<List<Recipe>> SearchRecipes(string queries)
        {
            //string requestBody = context.Request.Body.ToString();
            //string[] searchArgs = JsonConvert.DeserializeObject<string[]>(requestBody);

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            List<Recipe> recipes = new List<Recipe>();

            if (queries != null)
            {
                string[] searchArgs = queries.Split(delimiterChars);
                recipes = recipeDAO.SearchRecipes(searchArgs, true);
            }
            else
            {
                recipes = recipeDAO.GetPublicRecipes();
            }
            

            return Ok(recipes);
        }
        
    }
}
