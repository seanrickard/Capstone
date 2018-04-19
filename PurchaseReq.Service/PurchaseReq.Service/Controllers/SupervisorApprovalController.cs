
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class SupervisorApprovalController : Controller
    {
        public ISupervisorApproval _repo { get; }


        public SupervisorApprovalController(ISupervisorApproval repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _repo.Get(id);
            if(item == null)
            {
                return BadRequest();
            }
            return Json(item);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetForOrder(int orderId)
        {
            return Ok(_repo.GetForOrder(orderId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] SupervisorApproval model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut("{supervisorApprovalId}")]
        public IActionResult Update(int supervisorApprovalId, [FromBody] SupervisorApproval model)
        {
            if (model == null || supervisorApprovalId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtAction("Update", model);
        }
    }
}
