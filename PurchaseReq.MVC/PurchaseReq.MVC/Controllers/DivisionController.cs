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

            var result = await _webApiCalls.CreateDivisionAsync(dv);

            return RedirectToAction("Index");
        }

        public IActionResult EditDivision(int id)
        {
            DivisionWithSupervisor division = new DivisionWithSupervisor();
            return View(division);
        }

        //[HttpPost]
        //public async Task<IActionResult> EditDivision(DivisionWithSupervisor division)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return View(division);
        //    }

            
        //}

        public async Task<IActionResult> Departments(int id)
        {
            IList<DepartmentWithDivision> departments;

            departments = await _webApiCalls.GetDepartmentsByDivison(id);

            return View(departments);
        }
    }
}