using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class VendorController : Controller
    {
        private readonly IVendorRepo _repo;

        public VendorController(IVendorRepo repo)
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

        //Need to add REPO Method check if vendor already exists
        [HttpPost]
        public IActionResult Create([FromBody] Vendor model)
        {

            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut("{vendorId}")]
        public IActionResult Update(int vendorId, [FromBody] Vendor model)
        {
            if (model == null || vendorId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtAction("Update", model);
        }

        [HttpGet]
        public IActionResult GetWithAddress()
        {
            return Ok(_repo.GetAllWithAddress());
        }

        [HttpGet("{addressId}")]
        public IActionResult GetWithAddress(int addressId)
        {
            var item = _repo.GetVendorWithAddress(addressId);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }
    }
}
