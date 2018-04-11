using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public DepartmentController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        public async Task<IActionResult> Index()
        {
            IList<DepartmentWithDivision> departments;
            departments = await _webApiCalls.GetDepartmentsAsync();

            return View(departments);
        }

        public async Task<IActionResult> AddDepartment()
        {
            DepartmentWithDivision dp = new DepartmentWithDivision();
            var divisionList = await _webApiCalls.GetDivisionsAsync();
            ViewBag.Divisions = divisionList;



            return View(dp);
        }

        public async Task<IActionResult> Employees(int id)
        {
            IList<EmployeeWithDepartmentAndRoomAndRole> employees;
            employees = await _webApiCalls.GetEmployeeByDepartment(id);
            
            foreach (EmployeeWithDepartmentAndRoomAndRole  emp in employees)
            {
                if(emp.DepartmentId == id)
                {

                }
            }

            return View(employees);
        }

    }
}