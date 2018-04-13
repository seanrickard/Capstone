using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BudgetCodeController : Controller
    {
        private readonly IBudgetCodeRepo _repo;

        public BudgetCodeController(IBudgetCodeRepo addressRepo)
        {
            _repo = addressRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllWithBudgetAmount());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _repo.GetBudgetCodeWithCurrentAmount(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet]
        public IActionResult GetActive()
        {
            return Ok(_repo.GetAllActiveBudgetCodes());
        }

        [HttpGet]
        public IActionResult GetActivePage(int skip, int take)
        {
            return Ok(_repo.GetActive(skip, take));
        }

        [HttpGet]
        public IActionResult GetPage(int skip, int take)
        {
            return Ok(_repo.GetRangeWithCurrentAmounts(skip, take));
        }

        [HttpPost]
        public IActionResult Create([FromBody] BudgetCode model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut("{budgetCodeId}")]
        public IActionResult Update(int budgetCodeId, [FromBody] BudgetCode model)
        {
            if (model == null || budgetCodeId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtAction("Update", model);
        }


    }
}
