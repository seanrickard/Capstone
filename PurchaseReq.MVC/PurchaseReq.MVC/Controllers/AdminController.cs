using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;

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