using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;

namespace PurchaseReq.MVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult PastOrders()
        {
            IEnumerable<PRWithRequest> list = new List<PRWithRequest>();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Items()
        {
            return View();
        }

        public IActionResult Vendors()
        {
            return View();
        }

    }
}