using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class DivisionController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public DivisionController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }
        public async Task<IActionResult> Index()
        {
            IList<DivisionWithSupervisor> divisions;
            divisions = await _webApiCalls.GetDivisionsAsync();

            return View(divisions);
        }

        public IActionResult AddDivision()
        {
            DivisionWithSupervisor dv = new DivisionWithSupervisor();
            
            return View(dv);
        }
    }
}