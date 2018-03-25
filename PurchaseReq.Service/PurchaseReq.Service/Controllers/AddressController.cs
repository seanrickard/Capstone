using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressRepo _repo;

        public AddressController(IAddressRepo addressRepo)
        {
            _repo = addressRepo;
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
        public IActionResult Create([FromBody] Address model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtRoute("Get", new {controller = "AddressController", id = model.Id});
        }

        [HttpPut("{addressId}")]
        public IActionResult Update(int addressId, [FromBody] Address model)
        {
            if (model == null ||addressId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtRoute("Get", new { controller = "AddressController", id = model.Id });
        }
    }
}