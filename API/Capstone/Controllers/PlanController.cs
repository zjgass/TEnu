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

        //GetUserPlans
        [HttpGet]
        public ActionResult<List<Plan>> GetUserPlans(int userId)
        {
            return Ok(planDAO.GetPlans(userId));
        }

        //GetPlan
        [HttpGet("{planId}")]
        public ActionResult<Plan> GetPlan(int planId)
        {
            return Ok(planDAO.GetPlan(planId));
        }

        //CreatePlan
        [HttpPost]
        public ActionResult<PlanController> AddPlan(Plan plan)
        {
            Plan added = planDAO.CreatePlan(plan);
            return Created($"/plan/{plan.PlanId}", added);
        }

        //UpdatePlan
        [HttpPut("{planId}")]
        public ActionResult<PlanController> UpdatePlan(Plan plan)
        {
            Plan updated = planDAO.UpdatePlan(plan);
            return Ok(updated);    
        }

        //DeletePlan






    }
}
