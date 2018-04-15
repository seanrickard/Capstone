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
            if(item == null)
            {
                return BadRequest();
            }

            return Json(item);
        }

    }
}
