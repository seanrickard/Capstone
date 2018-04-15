using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


    }
}
