using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class DepartmentController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public DepartmentController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Show active
            IList<DepartmentWithDivision> departments;
            departments = await _webApiCalls.GetDepartmentsAsync();
            ViewBag.Active = true;

            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> InActive()
        {
            //Need to go make that api call at service
            var departments = await _webApiCalls.GetInactiveDepartmentsAsync();

            ViewBag.Active = false;

            return View("Index", departments);
        }

        [HttpGet]
        public async Task<IActionResult> AddDepartment()
        {
            DepartmentWithDivision dp = new DepartmentWithDivision();

            ViewBag.Divisions = await _webApiCalls.GetDivisionsForDropDown();


            return View(dp);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentWithDivision dept)
        {
            if (!ModelState.IsValid)
            {
                return View(dept);
            }

            var dp = new Department()
            {
                DepartmentName = dept.DepartmentName,
                DivisionId = dept.DivisionId
            };

            var result = await _webApiCalls.CreateAsync(dp);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditDepartment(int id)
        {
            DepartmentWithDivision dp = await _webApiCalls.GetDepartmentAsync(id);

            ViewBag.Divisions = await _webApiCalls.GetDivisionsForDropDown();

            return View(dp);
        }

        [HttpPost]
        public async Task<IActionResult> EditDepartment(DepartmentWithDivision dept)
        {
            if (!ModelState.IsValid)
            {
                return View(dept);
            }

            var dp = new Department()
            {

                Id = dept.Id,
                Active = dept.Active,
                DepartmentName = dept.DepartmentName,
                DivisionId = dept.DivisionId,
                TimeStamp = dept.TimeStamp
            };

            var result = await _webApiCalls.UpdateAsync(dept.Id, dp);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Employees(int id)
        {
            IList<EmployeeWithDepartmentAndRoomAndRole> employees;
            employees = await _webApiCalls.GetEmployeeByDepartment(id);

            foreach (EmployeeWithDepartmentAndRoomAndRole emp in employees)
            {
                if (emp.DepartmentId == id)
                {

                }
            }

            return View(employees);
        }

    }
}