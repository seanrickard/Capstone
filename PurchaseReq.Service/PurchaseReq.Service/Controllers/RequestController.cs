using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class RequestController : Controller
    {
        private readonly IRequestRepo _repo;

        public RequestController(IRequestRepo repo)
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
            var item = _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Request model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut]
        public IActionResult Update(int requestId, [FromBody] Request model)
        {
            if (model == null || requestId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtAction("Update", model);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetAllForOrder(int orderId)
        {
            return Ok(_repo.GetAllRequestForOrder(orderId));
        }

        [HttpGet("{orderId}")]
        public IActionResult GetAllChoosenForOrder(int orderId)
        {

            return Ok(_repo.GetAllChoosenForOrder(orderId));
        }


    }
}
