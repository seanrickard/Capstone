using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserManagement()
        {
            IEnumerable<EmployeeWithDepartmentAndRoomAndRole> list = new List<EmployeeWithDepartmentAndRoomAndRole>();

            return View(list);
        }

        public IActionResult AddUser() => View();

        
    }
}