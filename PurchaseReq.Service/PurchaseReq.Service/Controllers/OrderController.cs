using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OrderController : Controller
    {
        public IOrderRepo Repo { get; }

        public OrderController(IOrderRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var item = Repo.GetOrder(id);
            if (item == null)
            {
                return BadRequest();
            }

            return Json(item);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetAll(string employeeId)
        {
            return Ok(Repo.GetAllForUser(employeeId));
        }

        [HttpGet]
        public IActionResult GetApproved()
        {
            return Ok(Repo.GetAllApproved());
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetApproved(string employeeId)
        {
            return Ok(Repo.GetAllApprovedForUser(employeeId));
        }

        //GetAllThatAreOrdered
        [HttpGet]
        public IActionResult GetOrdered()
        {
            return Ok(Repo.GetAllOrdered());
        }

        //Base getAllWaitingForSupervisor
        [HttpGet]
        public IActionResult GetWaitingSupervisor()
        {
            return Ok(Repo.GetAllWaitingForSupervisor());
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetWaitingSupervisorForUser(string employeeId)
        {
            return Ok(Repo.GetAllWaitingForSupervisorForUser(employeeId));
        }

        [HttpGet("{supervisorId}")]
        public IActionResult GetWaitingSupervisor(string supervisorId)
        {
            return Ok(Repo.GetAllWaitingForSupervisorForUser(supervisorId));
        }

        [HttpGet]
        public IActionResult GetWaitingCFO()
        {
            return Ok(Repo.GetAllWaitingForCFO());
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetWaitingCFO(string employeeId)
        {
            return Ok(Repo.GetAllWaitingForCFOForUser(employeeId));
        }

        [HttpGet]
        public IActionResult GetCompleted()
        {
            return Ok(Repo.GetAllCompleted());
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetCompleted(string employeeId)
        {
            return Ok(Repo.GetAllCompletedForUser(employeeId));
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetCreated(string employeeId)
        {
            return Ok(Repo.GetAllCreatedForUser(employeeId));
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetNewOrder(string employeeId)
        {
            var item = Repo.GetNewOrder(employeeId);
            if (item == null)
            {
                return BadRequest();
            }

            return Json(item);
        }

        [HttpGet("{orderId}")]
        public IActionResult MoveOrderLifeCycleUp(int orderId)
        {
            var item = Repo.MoveToTheNextLifeCycle(orderId);
            if (item == null)
            {
                return BadRequest();
            }

            return Json(item);
        }

        //Shouldn't Need to use these (Create & Update)
        //Just here in case or as convience
        [HttpPost]
        public IActionResult Create([FromBody] Order model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            Repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut("{orderId}")]
        public IActionResult Update(int orderId, [FromBody] Order model)
        {
            if (model == null || orderId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            Repo.Update(model);
            return CreatedAtAction("Update", model);
        }

        [HttpGet]
        public IActionResult GetDenied()
        {
            return Ok(Repo.GetDenied());
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetDenied(string employeeId)
        {
            return Ok(Repo.GetDenied(employeeId));
        }

        [HttpGet("{orderId}")]
        public IActionResult DenyOrder(int orderId)
        {
            var item = Repo.DenyOrder(orderId);
            if (item == null)
            {
                return BadRequest();
            }
            return Json(item);
        }

        [HttpGet("{orderId}")]
        public IActionResult MoveToCFOStatus(int orderId)
        {
            var item = Repo.MoveToCFOStatus(orderId);
            if (item == null)
            {
                return BadRequest();
            }
            return Json(item);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetCancelled(string employeeId)
        {
            return Ok(Repo.GetAllCancelled(employeeId));
        }

        [HttpGet("{orderId}")]
        public IActionResult CancellOrder(int orderId)
        {
            var item = Repo.CancelOrder(orderId);
            if (item == null)
            {
                return BadRequest();
            }
            return Json(item);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetPending(string employeeId)
        {
            return Ok(Repo.GetPendingForUser(employeeId));
        }
    }
}
