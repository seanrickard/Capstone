using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System;
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
                OrderId = orderId,
                Chosen = vm.Chosen,
                ReasonChosen = vm.ReasonChosen
            };

            var result = await _webApiCalls.CreateAsync(req);


            return RedirectToAction("ViewOrder", "Order", new { id = vm.OrderId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EditItems(int id)
        {
            var order = await _webApiCalls.GetOrderAsync(id);

            return View(order);
        }

        [HttpGet("{id}/{itemId}")]
        public async Task<IActionResult> EditItem(int id, int itemId)
        {
            var order = await _webApiCalls.GetOneRequest(id);

            return View(order);
        }

        [HttpPost("{id}/{itemId}")]
        public async Task<IActionResult> EditItem(RequestWithVendor request)
        {
            var item = await _webApiCalls.GetOneItem(request.ItemId);

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            Request updateRequest = new Request {
                Id = request.Id,
                Chosen = request.Chosen,
                EstimatedCost = request.EstimatedCost,
                EstimatedTotal = request.EstimatedTotal,
                OrderId = request.OrderId,
                PaidCost = request.PaidCost,
                PaidTotal = request.PaidTotal,
                QuantityRequested = request.QuantityRequested,
                ReasonChosen = request.ReasonChosen,
                TimeStamp = request.TimeStamp,
                ItemId = request.ItemId,
            };

            Item updateItem = new Item
            {
                Id = request.ItemId,
                ItemName = request.ItemName,
                Description = request.Description,
                TimeStamp = item.TimeStamp,
            };

            var itemResult = await _webApiCalls.UpdateAsync(updateItem.Id, updateItem);
            var requestResult = await _webApiCalls.UpdateAsync(updateRequest.Id, updateRequest);

            //foreach(Request asdf in item.Requests)
            //{
            //    if(asdf.ItemId == request.ItemId)
            //    {
            //        asdf.EstimatedCost = request.EstimatedCost;
            //        asdf.EstimatedTotal = request.EstimatedTotal;
            //        asdf.QuantityRequested = request.QuantityRequested;
            //        item.ItemName = request.ItemName;
            //        item.Description = request.Description;
            //    }
            //    var req = await _webApiCalls.GetOneRequest(request.Id);
            //    var r = await _webApiCalls.UpdateAsync(item.Id, item);
            //    var result = await _webApiCalls.UpdateAsync(request.Id, req);
            //}

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("{id}, {itemId}")]
        public async Task<IActionResult> EditItems(int id, int itemId)
        {
            var req = await _webApiCalls.GetOneRequest(id);

            if (req.ItemId == itemId)
            {
                req.Chosen = false;
            }

            Request request = new Request()
            {
                Id = req.Id,
                OrderId = req.OrderId,
                EstimatedCost = req.EstimatedCost,
                EstimatedTotal = req.EstimatedTotal,
                ItemId = req.ItemId,
                Chosen = req.Chosen,
                TimeStamp = req.TimeStamp,
                QuantityRequested = req.QuantityRequested
            };

            var order = await _webApiCalls.GetOrderAsync(request.OrderId);

            if (order.StatusId > 2)
            {
                Order update = new Order()
                {
                    EmployeeId = order.EmployeeId,
                    StateContract = order.StateContract,
                    CategoryId = order.CategoryId,
                    StatusId = 2,
                    BudgetCodeId = order.BudgetCodeId,
                    BusinessJustification = order.BusinessJustification,

                };

                var orderUpdate = _webApiCalls.UpdateAsync(order.Id, update);
            }

            var result = _webApiCalls.UpdateAsync(req.Id, request);

            return RedirectToAction("ViewOrder", "Order", new { id = request.OrderId });
        }
    }

}
