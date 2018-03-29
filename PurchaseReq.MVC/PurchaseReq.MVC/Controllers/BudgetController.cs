using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;

namespace PurchaseReq.MVC.Controllers
{
    public class BudgetController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<BudgetCodeWithAmount> list = new List<BudgetCodeWithAmount>();
            return View(list);
        }
    }
}