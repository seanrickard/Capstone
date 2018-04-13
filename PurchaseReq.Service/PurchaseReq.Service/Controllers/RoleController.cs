using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class RoleController : Controller
    {
        public IRoleRepo Repo { get; }

        public RoleController(IRoleRepo repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Repo.GetRoles());
        }

        [HttpGet]
        public IActionResult GetSupervisors()
        {
            return Ok(Repo.GetSupervisor().Result);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(Repo.GetUsers().Result);
        }

        [HttpGet]
        public IActionResult GetPurchasing()
        {
            return Ok(Repo.GetPurchasing().Result);
        }

        [HttpGet]
        public IActionResult GetAuditors()
        {
            return Ok(Repo.GetAuditors().Result);
        }

        [HttpGet]
        public IActionResult GetCFO()
        {
            return Ok(Repo.GetCFO().Result);
        }

        [HttpGet]
        public IActionResult GetAdmins()
        {
            return Ok(Repo.GetAdmins().Result);
        }

        [HttpPost("{employeeId}")]
        public IActionResult AddToSupervisor(string employeeId, [FromBody] Employee model)
        {
            if (model == null || employeeId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = Repo.AddToSupervisor(employeeId).Result;

            if(result)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{employeeId}")]
        public IActionResult AddToCFO(string employeeId, [FromBody] Employee model)
        {
            if (model == null || employeeId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = Repo.AddToCFO(employeeId).Result;

            if (result)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{employeeId}")]
        public IActionResult AddToPurchasing(string employeeId, [FromBody] Employee model)
        {
            if (model == null || employeeId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = Repo.AddToPurchasing(employeeId).Result;

            if (result)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{employeeId}")]
        public IActionResult AddToAuditor(string employeeId, [FromBody] Employee model)
        {
            if (model == null || employeeId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = Repo.AddToAuditor(employeeId).Result;

            if (result)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{employeeId}")]
        public IActionResult AddToUsers(string employeeId, [FromBody] Employee model)
        {
            if (model == null || employeeId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = Repo.AddToUsers(employeeId).Result;

            if (result)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{employeeId}")]
        public IActionResult AddToAdmin(string employeeId, [FromBody] Employee model)
        {
            if (model == null || employeeId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = Repo.AddToAdmin(employeeId).Result;

            if (result)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
