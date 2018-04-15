using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
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

        public IActionResult AddDivision()
        {
            DivisionWithSupervisor division = new DivisionWithSupervisor();
            return View(division);
        }

        [HttpPost]
        public async Task<IActionResult> AddDivision(DivisionWithSupervisor division)
        {
            if (!ModelState.IsValid)
            {
                return View(division);
            }
            var dv = new Division()
            {
                DivisionName = division.DivisionName,
                SupervisorId = division.SupervisorId,
                Active = division.Active

            };

            var result = await _webApiCalls.CreateAsync(dv);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditDivision(int id)
        {
            DivisionWithSupervisor div = await _webApiCalls.GetDivisionAsync(id);

            ViewBag.Supervisors = await _webApiCalls.GetSupervisorsForDropDown();

            return View(div);
        }

        [HttpPost]
        public async Task<IActionResult> EditDivision(DivisionWithSupervisor div)
        {
            if (!ModelState.IsValid)
            {
                return View(div);
            }

            var division = new Division()
            {

                Id = div.Id,
                Active = div.Active,
                DivisionName = div.DivisionName,
                SupervisorId = div.SupervisorId,
                TimeStamp = div.TimeStamp
            };

            var result = await _webApiCalls.UpdateAsync(div.Id, division);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Departments(int id)
        {
            IList<DepartmentWithDivision> departments;

            departments = await _webApiCalls.GetDepartmentsByDivison(id);

            return View(departments);
        }
    }
}