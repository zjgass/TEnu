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
