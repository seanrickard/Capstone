using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class EmployeeBudgetCodeController : Controller
    {
        public IEmployeeBudgetCodeRepo Repo { get; }

        public EmployeeBudgetCodeController(IEmployeeBudgetCodeRepo repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Repo.GetAllWithEmployeeAndBudgetCodes());
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetAllActiveForEmployee(string employeeId)
        {
            return Ok(Repo.GetAllActiveEmployeeBudgetCodes(employeeId));
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetAllForEmployee(string employeeId)
        {
            return Ok(Repo.GetAllEmployeesBudgetCodes(employeeId));
        }

        [HttpGet("{budgetCodeId}")]
        public IActionResult GetEmployeesInBudgetCode(int budgetCodeId)
        {
            return Ok(Repo.GetAllEmployeesInBudgetCode(budgetCodeId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmployeesBudgetCodes model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            Repo.Add(model);
            return CreatedAtAction("Create", model);
        }
    }
}
