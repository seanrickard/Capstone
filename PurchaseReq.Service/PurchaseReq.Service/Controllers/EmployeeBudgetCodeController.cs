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
    }
}
