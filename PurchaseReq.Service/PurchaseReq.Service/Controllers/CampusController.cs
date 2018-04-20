using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CampusController : Controller
    {
        private readonly ICampusRepo _repo;

        public CampusController(ICampusRepo repo)
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

        [HttpGet]
        public IActionResult GetWithAddress()
        {
            return Ok(_repo.GetAllWithAddress().Where(x => x.Active));
        }

        [HttpGet]
        public IActionResult GetInActive()
        {
            return Ok(_repo.GetAllWithAddress().Where(x => !x.Active));
        }

        [HttpGet("{id}")]
        public IActionResult GetWithAddress(int id)
        {
            var item = _repo.GetCampusWithAddress(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet]
        public IActionResult GetWithRooms()
        {
            return Ok(_repo.GetAllWithRooms());
        }

        [HttpGet("{id}")]
        public IActionResult GetWithRooms(int id)
        {
            var item = _repo.GetCampusWithRooms(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Campus model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut("{campusId}")]
        public IActionResult Update(int campusId, [FromBody] Campus model)
        {
            if (model == null || campusId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtAction("Update", model);
        }
    }
}