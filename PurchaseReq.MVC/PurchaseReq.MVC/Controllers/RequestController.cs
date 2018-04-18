using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class RequestController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public RequestController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }



        [HttpGet ("{orderId}") ]
        public IActionResult AddItem(int orderId)
        {
            RequestWithVendor req = new RequestWithVendor
            {
                OrderId = orderId
            };

            return View(req);
        }

        [HttpPost("{orderId}")]
        public async Task<IActionResult> AddItem(int orderId, RequestWithVendor vm)
        {
            Request req = new Request()
            {
                Item = new Item()
                {
                    ItemName = vm.ItemName,
                    Description = vm.Description
                },
                EstimatedCost = vm.EstimatedCost,
                QuantityRequested = vm.QuantityRequested,
                OrderId = orderId                
            };

            var result = await _webApiCalls.CreateAsync(req);
            

            return RedirectToAction("ViewOrder", "Order", new { id = vm.OrderId});
        }
    }

    
}