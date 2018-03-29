using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BudgetAmountController : Controller
    {
        private readonly IBudgetAmountRepo _repo;

        public BudgetAmountController(IBudgetAmountRepo repo)
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

        [HttpPost]
        public IActionResult Create([FromBody] BudgetAmount model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtRoute("Get", new { controller = "AddressController", id = model.Id });
        }

        [HttpPut]
        public IActionResult Update(int budgetAmountId, [FromBody] BudgetAmount model)
        {
            if (model == null || budgetAmountId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtRoute("Get", new { controller = "AddressController", id = model.Id });
        }

        [HttpGet]
        public IActionResult GetCurrentAmount(int budgetCodeId)
        {
            var item = _repo.GetBudgetCodesCurrentBudgetAmount(budgetCodeId);

            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet]
        public IActionResult GetAllAmounts(int budgetCodeId)
        {
            return Ok(_repo.GetBudgetCodesCurrentBudgetAmount(budgetCodeId));
        }
    }
}
