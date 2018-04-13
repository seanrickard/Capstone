using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class RoomController : Controller
    {
        private readonly IRoomRepo _repo;

        public RoomController(IRoomRepo repo)
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
        public IActionResult GetWithCampus()
        {
            return Ok(_repo.GetAllWithCampus());
        }

        [HttpGet("{id}")]
        public IActionResult GetWithCampus(int id)
        {
            var item = _repo.GetRoomWithCampus(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet]
        public IActionResult GetWithEmployee()
        {
            return Ok(_repo.GetAllWithEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetWithEmployee(int id)
        {
            var item = _repo.GetRoomWithEmployees(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet("{campusId}")]
        public IActionResult GetByCampus(int campusId)
        {
            return Ok(_repo.GetRoomsForCampus(campusId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Room model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut]
        public IActionResult Update(int roomId, [FromBody] Room model)
        {
            if (model == null || roomId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtAction("Update", model);
        }
    }
}
