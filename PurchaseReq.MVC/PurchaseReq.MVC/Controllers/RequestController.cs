using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class RequestController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public RequestController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }
        // Needs work
        public async Task<IActionResult> Index()
        {
            IList<RequestWithVendor> requests;
            requests = await _webApiCalls.GetRequestWithVendors();

            return View(requests);
        }
    }
}