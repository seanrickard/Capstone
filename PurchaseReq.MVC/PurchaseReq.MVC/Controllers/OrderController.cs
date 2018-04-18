using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;
        private UserManager<Employee> _userManager;

        public OrderController(IWebApiCalls webApiCalls, UserManager<Employee> userManager)
        {
            _webApiCalls = webApiCalls;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create()
        {
            string id = _userManager.GetUserId(User);
            var request = await _webApiCalls.GetNewOrder(id);
            ViewBag.BudgetCodes = await _webApiCalls.GetBudgetCodesForDropDown();
            ViewBag.Categories = await _webApiCalls.GetCategoriesForDropDown();
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PRWithRequest request)
        {
            RequestWithVendor req = new RequestWithVendor
            {
                OrderId = request.Id
            };

            return RedirectToAction("AddItem", "Request");
        }

        public async Task<IActionResult> ViewOrder(int id)
        {
            PRWithRequest order =  await _webApiCalls.GetOrderAsync(id);

            
            return View(order);
        }

        public async Task<IActionResult> UpdateStatus(int id)
        {
            PRWithRequest order = await _webApiCalls.IncrementStatus(id);
            var empId = order.EmployeeId;

            if(order.StatusName == "Waiting for Supervisor Approval")
            {
                return RedirectToAction("Pending", new { id = empId });
            }

            else if(order.StatusName == "Approved")
            {
                return RedirectToAction("Approved", new { id = empId });
            }
            else if (order.StatusName == "Ordered")
            {
                return RedirectToAction("Ordered", new { id = empId });
            }
            else if (order.StatusName == "Completed")
            {
                return RedirectToAction("Completed", new { id = empId });
            }

            return RedirectToAction("Pending", new { id = empId});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Pending(string id)
        {

            IList<PRWithRequest> orders = await _webApiCalls.GetOrdersAsync(id);

            return View("OrderList", orders);
        }

        public async Task<IActionResult> UpdateToCFO(int id)
        {
            PRWithRequest order = await _webApiCalls.IncrementStatus(id);
            var empId = order.EmployeeId;

            return RedirectToAction("PendingCFO", new { id = empId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PendingCFO(string id)
        {
            IList<PRWithRequest> orders = await _webApiCalls.GetOrdersAsync(id);

            return View(orders);
        }

        public async Task<IActionResult> UpdateToApproved(int id)
        {
            PRWithRequest order = await _webApiCalls.IncrementStatus(id);
            var empId = order.EmployeeId;

            return RedirectToAction("Approved", new { id = empId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Approved(string id)
        {

            IList<PRWithRequest> orders = await _webApiCalls.GetOrdersAsync(id);

            return View("OrderList", orders);
        }

        public async Task<IActionResult> UpdateToOrdered(int id)
        {
            PRWithRequest order = await _webApiCalls.IncrementStatus(id);
            var empId = order.EmployeeId;

            return RedirectToAction("Ordered", new { id = empId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Ordered(string id)
        {

            IList<PRWithRequest> orders = await _webApiCalls.GetOrdersAsync(id);

            return View(orders);
        }

        public async Task<IActionResult> UpdateToCompleted(int id)
        {
            PRWithRequest order = await _webApiCalls.IncrementStatus(id);
            var empId = order.EmployeeId;

            return RedirectToAction("Completed", new { id = empId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Completed(string id)
        {

            IList<PRWithRequest> orders = await _webApiCalls.GetOrdersAsync(id);

            return View(orders);
        }
    }
}