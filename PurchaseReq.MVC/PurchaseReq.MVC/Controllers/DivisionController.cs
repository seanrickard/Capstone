using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class DivisionController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public DivisionController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        //Display all Active Division
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var divisions = await _webApiCalls.GetDivisionsAsync();

            ViewBag.Active = true;

            return View(divisions);
        }

        [HttpGet]
        public async Task<IActionResult> InActive()
        {
            var divisions = await _webApiCalls.GetInActiveDivisionsAsync();

            ViewBag.Active = false;

            return View("Index", divisions);
        }

        [HttpGet]
        public async Task<IActionResult> AddDivision()
        {
            DivisionWithSupervisor division = new DivisionWithSupervisor();
            ViewBag.Supervisors = await _webApiCalls.GetSupervisorsForDropDown();

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
            };

            var result = await _webApiCalls.CreateAsync(dv);

            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EditDivision(int id)
        {
            DivisionWithSupervisor div = await _webApiCalls.GetDivisionAsync(id);

            ViewBag.Supervisors = await _webApiCalls.GetSupervisorsForDropDown();

            return View(div);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditDivision(int id, DivisionWithSupervisor div)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Departments(int id)
        {
            IList<DepartmentWithDivision> departments;

            departments = await _webApiCalls.GetDepartmentsByDivison(id);

            return View(departments);
        }
    }
}