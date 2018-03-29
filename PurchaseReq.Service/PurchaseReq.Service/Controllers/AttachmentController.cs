using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AttachmentController : Controller
    {

        private readonly IAttachmentRepo _repo;

        public AttachmentController(IAttachmentRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Create()
        {
            //Needs implemented
            return NotFound();
        }

        [HttpGet("{requestId}")]
        public IActionResult Get(int requestId)
        {
            //Needs implemented
            return NotFound();
        }
    }
}
