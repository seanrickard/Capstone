using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;


namespace PurchaseReq.MVC.Controllers
{
    public class DivisionController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<DivisionWithSupervisor> list = new List<DivisionWithSupervisor>();

            return View(list);
        }

        public IActionResult AddDivision()
        {
            DivisionWithSupervisor dv = new DivisionWithSupervisor();
            
            return View(dv);
        }
    }
}