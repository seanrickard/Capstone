using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public AdminController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        public IActionResult Index()
        {
            return View();  
        }

        public async Task<IActionResult> UserManagement()
        {
            IList<EmployeeWithDepartmentAndRoomAndRole> employees;
            employees = await _webApiCalls.GetEmployees();

            return View(employees);
        }

        public async Task<IActionResult> AddUser()
        {
            PasswordEmployeeViewModel emp = new PasswordEmployeeViewModel();
            
            ViewBag.Departments = await _webApiCalls.GetDepartmentsForDropDown();
            ViewBag.Roles = await _webApiCalls.GetRolesForDropdown();
            ViewBag.Rooms = await _webApiCalls.GetRoomsForDropdown();

            return View(emp);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddDivision(EmployeeWithDepartmentAndRoomAndRole emp)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return View(emp);
        //    }
        //}
        
    }
}