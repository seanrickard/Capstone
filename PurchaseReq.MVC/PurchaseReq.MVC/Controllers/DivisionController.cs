using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class DivisionController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public DivisionController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }
        public async Task<IActionResult> Index()
        {
            IList<DivisionWithSupervisor> divisions;
            divisions = await _webApiCalls.GetDivisionsAsync();

            return View(divisions);
        }

        public async Task<IActionResult> AddDivision()
        {
            IList<DivisionWithSupervisor> dv = await  _webApiCalls.GetDivisionsAsync();
            return View(dv);
        }

        public async Task<IActionResult> Departments(int id)
        {
            IList<DepartmentWithDivision> departments;

            departments = await _webApiCalls.GetDepartmentsByDivison(id);

            return View(departments);
        }
    }
}