using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;

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
        public IActionResult GetRoomWithCampus()
        {
            return Ok(_repo.GetAllWithCampus());
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomWithCampus(int id)
        {
            var item = _repo.GetRoomWithCampus(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet]
        public IActionResult GetRoomWithEmployee()
        {
            return Ok(_repo.GetAllWithEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomWithEmployee(int id)
        {
            var item = _repo.GetRoomWithEmployees(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet("{campusId}")]
        public IActionResult GetRoomsForCampus(int campusId)
        {
            return Ok(_repo.GetRoomsForCampus(campusId));
        }
    }
}
