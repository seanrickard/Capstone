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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string id = _userManager.GetUserId(User);
            var request = await _webApiCalls.GetNewOrder(id);
            ViewBag.BudgetCodes = await _webApiCalls.GetBudgetCodesForDropDown();
            ViewBag.Categories = await _webApiCalls.GetCategoriesForDropDown();
            return View(request);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create(int id, PRWithRequest request)
        {


            if (!ModelState.IsValid)
            {
                ViewBag.BudgetCodes = await _webApiCalls.GetBudgetCodesForDropDown();
                ViewBag.Categories = await _webApiCalls.GetCategoriesForDropDown();
                return View(request);
            }


            var order = new Order()
            {
                Id = request.Id,
                DateMade = request.DateMade,
                EmployeeId = request.EmployeeId,
                StatusId = request.StatusId,
                BusinessJustification = request.BusinessJustification,
                CategoryId = request.CategoryId,
                BudgetCodeId = request.BudgetCodeId,
                StateContract = request.StateContract,
                TimeStamp = request.TimeStamp
            };


            var result = await _webApiCalls.UpdateAsync(order.Id, order);


            RequestWithVendor req = new RequestWithVendor
            {
                OrderId = request.Id,
            };

            return RedirectToAction("AddItem", "Request", new { orderId = req.OrderId });
        }

        [HttpGet]
        public async Task<IActionResult> EditOrder(int id)
        {
            var request = await _webApiCalls.GetOrderAsync(id);
            ViewBag.BudgetCodes = await _webApiCalls.GetBudgetCodesForDropDown();
            ViewBag.Categories = await _webApiCalls.GetCategoriesForDropDown();

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder(PRWithRequest request)
        {
            var order = new Order()
            {
                Id = request.Id,
                DateMade = request.DateMade,
                EmployeeId = request.EmployeeId,
                StatusId = request.StatusId,
                BusinessJustification = request.BusinessJustification,
                CategoryId = request.CategoryId,
                BudgetCodeId = request.BudgetCodeId,
                StateContract = request.StateContract,
                TimeStamp = request.TimeStamp
            };


            var result = await _webApiCalls.UpdateAsync(order.Id, order);

            return RedirectToAction("ViewOrders");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var order = await _webApiCalls.GetOrderAsync(id);

            if(order.StatusName == "Ordered")
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await _webApiCalls.CancelOrderAsync(order.Id);

            string userId = _userManager.GetUserId(User);

            IList<PRWithRequest> orders = await _webApiCalls.GetOrdersAsync(userId);

            return RedirectToAction("ViewOrders", orders);
          
        }



        public async Task<IActionResult> ViewOrder(int id)
        {
            PRWithRequest order =  await _webApiCalls.GetOrderAsync(id);

            
            return View(order);
        }

        public async Task<IActionResult> ViewOrders()
        {
            string id = _userManager.GetUserId(User);

            IList<PRWithRequest> orders = await _webApiCalls.GetOrdersAsync(id);

            return View(orders);
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

            return RedirectToAction("Index", "Home" );
        }

        [HttpGet]
        public async Task<IActionResult> PendingByEmployee()
        {
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Pending");

            return View("ViewOrders", orders);
        }


        [HttpGet]
        public async Task<IActionResult> Pending()
        {
            IList<PRWithRequest> orders = await _webApiCalls.GetOrderByTypeAsync("Pending");

            return View("ViewOrders", orders);
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

        [HttpGet]
        public async Task<IActionResult> ApprovedByEmployee()
        {
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Approved");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> Approved()
        {
            IList<PRWithRequest> orders = await _webApiCalls.GetOrderByTypeAsync("Approved");

            return View("ViewOrders", orders);
        }

        public async Task<IActionResult> UpdateToOrdered(int id)
        {
            PRWithRequest order = await _webApiCalls.IncrementStatus(id);
            var empId = order.EmployeeId;

            return RedirectToAction("Ordered", new { id = empId });
        }

        [HttpGet]
        public async Task<IActionResult> OrderedByEmployee()
        {
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Ordered");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> Ordered()
        {
            IList<PRWithRequest> orders = await _webApiCalls.GetOrderByTypeAsync("Ordered");

            return View("ViewOrders", orders);
        }


        public async Task<IActionResult> UpdateToCompleted(int id)
        {
            PRWithRequest order = await _webApiCalls.IncrementStatus(id);
            var empId = order.EmployeeId;

            return RedirectToAction("Completed", new { id = empId });
        }

        [HttpGet]
        public async Task<IActionResult> CompletedByEmployee()
        {
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Completed");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> Completed()
        {
            IList<PRWithRequest> orders = await _webApiCalls.GetOrderByTypeAsync("Completed");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> DeniedByEmployee()
        {
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Denied");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> Denied()
        {
            IList<PRWithRequest> orders = await _webApiCalls.GetOrderByTypeAsync("Denied");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> CreatedByEmployee()
        {
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Created");

            return View("ViewOrders", orders);
        }
    }
}