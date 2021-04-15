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
    public class CategoryController : Controller
    {
        private readonly ICategoryDAO categoryDAO;

        public CategoryController(ICategoryDAO _categoryDAO)
        {
            categoryDAO = _categoryDAO;
        }

        [HttpPost]
        public ActionResult<Category> CreateCategory(Category category)
        {
            return Ok(categoryDAO.CreateCategory(category));
        }

        [HttpGet]
        public ActionResult<List<Category>> GetCategories()
        {
            return Ok(categoryDAO.GetCategories());
        }
    }
}