using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
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

        public IActionResult AddBudgetCode()
        {
            BudgetCodeWithAmount bc = new BudgetCodeWithAmount();

            return View(bc);
        }

        [HttpPost]
        public async Task<IActionResult> AddBudgetCode(BudgetCodeWithAmount bc)
        {
            if (!ModelState.IsValid)
            {
                return View(bc);
            }

            var code = new BudgetCode()
            {
                BudgetCodeName = bc.BudgetCodeName,
                DA = bc.DA,
                Type = bc.Type,
                BudgetAmounts = new List<BudgetAmount>
                {
                    new BudgetAmount
                    {
                        TotalAmount = bc.TotalAmount
                    }
                }
            };
            
            var codeResult = await _webApiCalls.CreateAsync(code);

            return RedirectToAction("Index");
        }

    }
}