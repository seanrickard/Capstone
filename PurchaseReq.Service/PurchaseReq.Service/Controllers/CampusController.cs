using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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

        [HttpGet("/Address")]
        public IActionResult GetWithAddress()
        {
            return Ok(_repo.GetAllWithAddress());
        }

        [HttpGet("{id}/Address")]
        public IActionResult GetWithAddress(int id)
        {
            var item = _repo.GetCampusWithAddress(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet("/Rooms")]
        public IActionResult GetWithRooms()
        {
            return Ok(_repo.GetAllWithRooms());
        }

        [HttpGet("{id}/Rooms")]
        public IActionResult GetWithRooms(int id)
        {
            var item = _repo.GetCampusWithRooms(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }
    }
}