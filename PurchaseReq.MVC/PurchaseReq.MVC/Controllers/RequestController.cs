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



        [HttpGet("{orderId}")]
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


            return RedirectToAction("ViewOrder", "Order", new { id = vm.OrderId });
        }

        //    [HttpGet ("{id}")]
        //    public async Task<IActionResult> EditItems(int id)
        //    {
        //        var order = await _webApiCalls.GetOrderAsync(id);

        //        return View(order);
        //    }

        //    [HttpPost ("{id}, {itemId}")]
        //    public async Task<IActionResult> EditItems(int id, int itemId)
        //    {
        //        var req = await _webApiCalls.GetOneRequest(id);

        //        if (req.ItemId == itemId)
        //        {
        //            req.Chosen = false;
        //        }

        //        Request request = new Request()
        //        {
        //            Id = req.Id,
        //            OrderId = req.OrderId,
        //            EstimatedCost = req.EstimatedCost,
        //            EstimatedTotal = req.EstimatedTotal,
        //            ItemId = req.ItemId,
        //            Chosen = req.Chosen,
        //            TimeStamp = req.TimeStamp,
        //            QuantityRequested = req.QuantityRequested
        //        };

        //        var order = await _webApiCalls.GetOrderAsync(request.OrderId);

        //        if(order.StatusId > 2)
        //        {
        //            Order update = new Order()
        //            {
        //                EmployeeId = order.EmployeeId,
        //                StateContract = order.StateContract,
        //                CategoryId = order.CategoryId,
        //                StatusId = 2,
        //                BudgetCodeId = order.BudgetCodeId,
        //                BusinessJustification = order.BusinessJustification,

        //            };

        //            var orderUpdate = _webApiCalls.UpdateAsync(order.Id, update);
        //        }

        //        var result = _webApiCalls.UpdateAsync(req.Id, request);

        //        return RedirectToAction("ViewOrder", "Order", new { id = request.OrderId });
        //    }
        //}

    }
}