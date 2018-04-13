using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ItemController : Controller
    {
        private readonly IItemRepo _repo;

        public ItemController(IItemRepo repo)
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
        public IActionResult Create([FromBody] Item model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut("{itemId}")]
        public IActionResult Update(int itemId, [FromBody] Item model)
        {
            if (model == null || itemId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtAction("Update", model);
        }
    }
}
