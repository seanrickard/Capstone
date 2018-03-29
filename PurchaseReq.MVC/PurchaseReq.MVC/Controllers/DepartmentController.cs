using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;


namespace PurchaseReq.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<DepartmentWithDivision> list = new List<DepartmentWithDivision>();

            return View(list);
        }

        public IActionResult AddDepartment()
        {
            DepartmentWithDivision dp = new DepartmentWithDivision();

            return View(dp);
        }
    }
}