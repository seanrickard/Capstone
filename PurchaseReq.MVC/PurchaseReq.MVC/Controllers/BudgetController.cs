using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public BudgetController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        public async Task<IActionResult> Index()
        {
            IList<BudgetCodeWithAmount> budgets;
            budgets = await _webApiCalls.GetBudgetsAsync();
          
            return View(budgets);
        }
    }
}