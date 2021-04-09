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
    public class IngredientController : Controller
    {
        private readonly IIngredientDAO ingredientDAO;

        public IngredientController(IIngredientDAO _ingredientDAO)
        {
            ingredientDAO = _ingredientDAO;
        }

        [HttpPost]
        public ActionResult<Ingredient> CreateIngredient(Ingredient ingredient)
        {
            return Ok(ingredientDAO.CreateIngredient(ingredient));
        }

        [HttpGet]
        public ActionResult<List<Ingredient>> GetIngredients()
        {
            return Ok(ingredientDAO.GetIngredients());
        }
    }
}
