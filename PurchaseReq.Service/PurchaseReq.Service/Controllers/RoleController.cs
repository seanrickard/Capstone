using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;

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
            return Ok(Repo.GetSupervisor());
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(Repo.GetUsers());
        }

        [HttpGet]
        public IActionResult GetPurchasing()
        {
            return Ok(Repo.GetPurchasing());
        }

        [HttpGet]
        public IActionResult GetAuditors()
        {
            return Ok(Repo.GetAuditors());
        }

        [HttpGet]
        public IActionResult GetCFO()
        {
            return Ok(Repo.GetCFO());
        }

        [HttpGet]
        public IActionResult GetAdmins()
        {
            return Ok(Repo.GetAdmins());
        }
    }
}
