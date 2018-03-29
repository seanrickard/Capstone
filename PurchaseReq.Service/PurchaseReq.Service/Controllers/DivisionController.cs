using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class DivisionController : Controller
    {
        private readonly IDivisionRepo _repo;

        public DivisionController(IDivisionRepo addressRepo)
        {
            _repo = addressRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllWithDepartments());
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

        [HttpGet]
        public IActionResult GetActive()
        {
            return Ok(_repo.GetAllWithDepartments().Where(x => x.Active));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Division model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtRoute("Get", new { controller = "AddressController", id = model.Id });
        }

        [HttpPut]
        public IActionResult Update(int divisionId, [FromBody] Division model)
        {
            if (model == null || divisionId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtRoute("Get", new { controller = "DivisionController", id = model.Id });
        }

        [HttpGet]
        public IActionResult GetWithSupervisor()
        {
            return Ok(_repo.GetAllWithSupervisor());
        }

        [HttpGet("{id}")]
        public IActionResult GetWithSupervisor(int id)
        {

            var item = _repo.GetAllWithSupervisor();
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }


    }
}
