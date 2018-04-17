using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ApprovalController : Controller
    {
        public IApprovalRepo Repo { get; }
        
        public ApprovalController(IApprovalRepo repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = Repo.Find(id);
            if(item == null)
            {
                return BadRequest();
            }

            return Json(item);
        }
    }
}
