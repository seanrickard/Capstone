using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;

namespace PurchaseReq.MVC.Controllers
{
    public class CampusController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable < CampusWithAddress > list = new List<CampusWithAddress>();
            
            return View(list);
        }

        public IActionResult AddCampus()
        {
            CampusWithAddress cmp = new CampusWithAddress();

            return View(cmp);
        }
    }
}