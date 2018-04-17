using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
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
        
        public IActionResult AddItem(PRWithRequest request)
        {           
            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> AddItem(RequestWithVendor vm)
        {
            return View(vm);
        }
    }
}