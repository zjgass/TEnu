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
    public class PlanController : Controller
    {

        private readonly IPlanDAO planDAO;

        public PlanController(IPlanDAO _planDAO)
        {
            planDAO = _planDAO;
        }

        //GetUserPlans
        [HttpGet]
        public ActionResult<List<Plan>> GetUserPlans(int userId)
        {
            return Ok(planDAO.GetPlans(userId));
        }

        //GetPlan
        [HttpGet("{planId}", Name = "GetPlan")]
        public ActionResult<Plan> GetPlan(int planId)
        {
            return Ok(planDAO.GetPlan(planId));
        }

        //GetGroceryList
        [HttpGet("{planId}/groceryList")]
        public ActionResult<List<Ingredient>> GetGroceryList(int planId)
        {
            return Ok(planDAO.GetGroceryList(planId));
        }

        //CreatePlan
        [HttpPost]
        public ActionResult<Plan> AddPlan(Plan plan)
        {
            Plan added = planDAO.CreatePlan(plan);
            return CreatedAtRoute("GetPlan", new { planId = plan.PlanId }, plan);
        }

        //UpdatePlan
        [HttpPut("{planId}")]
        public ActionResult<Plan> UpdatePlan(Plan plan)
        {
            Plan updated = planDAO.UpdatePlan(plan);
            return Ok(updated);    
        }

        //AddMealToPlan
        [HttpPost("{planId}/add/{mealDay}/{mealTime}/{mealId}")]
        public ActionResult<bool> AddMealToPlan(int planId, string mealDay, string mealTime, int mealId)
        {
            return Ok(planDAO.AddMealToPlan(planId, mealDay, mealTime, mealId));
        }

        //DeleteMealFromPlan
        [HttpDelete("{planId}/delete/{mealDay}/{mealTime}/{mealId}")]
        public ActionResult<bool> DeleteMealFromPlan(int planId, string mealDay, string mealTime, int mealId)
        {
            return Ok(planDAO.DeleteMealFromPlan(planId, mealDay, mealTime, mealId));
        }

        //DeletePlan
        [HttpDelete("{planId}")]
        public ActionResult DeletePlan(int planId)
        {
            bool success = planDAO.DeletePlan(planId);
            //return success ? NoContent() : BadRequest();
            if (success)
            {
                return NoContent();
            }

            return BadRequest();
        }





    }
}
