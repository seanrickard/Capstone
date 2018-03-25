using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PurchaseReq.MVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Create() => View();
        
    }
}