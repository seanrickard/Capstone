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

        // When user presses new order, order is automatically created and user is presented with a view to choose category and budgetcode
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string id = _userManager.GetUserId(User);
            var request = await _webApiCalls.GetNewOrder(id);
            ViewBag.BudgetCodes = await _webApiCalls.GetBudgetCodesForDropDown(id);
            ViewBag.Categories = await _webApiCalls.GetCategoriesForDropDown();
            return View(request);
        }

        // When user 
        [HttpPost("{id}")]
        public async Task<IActionResult> Create(int id, PRWithRequest request)
        {


            if (!ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                ViewBag.BudgetCodes = await _webApiCalls.GetBudgetCodesForDropDown(userId);
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
            string userId = _userManager.GetUserId(User);
            ViewBag.BudgetCodes = await _webApiCalls.GetBudgetCodesForDropDown(userId);
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
                return RedirectToAction("PendingByEmployee", new { id = empId });
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
            ViewData["OrderNames"] = "Pending Orders";
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
            ViewData["OrderNames"] = "Approved Orders";
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Approved");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> Approved()
        {
            ViewData["OrderNames"] = "Approved Orders";
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
            ViewData["OrderNames"] = "Ordered";
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Ordered");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> Ordered()
        {
            
            Employee user = await _userManager.GetUserAsync(User);
            var isCfo = await _userManager.IsInRoleAsync(user, "Purchasing");
            if(isCfo)
            {
                ViewData["OrderNames"] = "Approved";
                IList<PRWithRequest> approvedOrders = await _webApiCalls.GetOrderByTypeAsync("Approved");
                //if(createdOrders.Count == 1)
                //{
                //    return RedirectToAction("Index", "Home");           //probably don't need
                //}
                return View("ViewOrders", approvedOrders);
            }
            ViewData["OrderNames"] = "Ordered";
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
            ViewData["OrderNames"] = "Completed Orders";
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Completed");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> Completed()
        {
            ViewData["OrderNames"] = "Completed Orders";
            IList<PRWithRequest> orders = await _webApiCalls.GetOrderByTypeAsync("Completed");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> DeniedByEmployee()
        {
            ViewData["OrderNames"] = "Denied Orders";
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Denied");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> Denied()
        {
            ViewData["OrderNames"] = "Denied Orders";
            IList<PRWithRequest> orders = await _webApiCalls.GetOrderByTypeAsync("Denied");

            return View("ViewOrders", orders);
        }

        [HttpGet]
        public async Task<IActionResult> CreatedByEmployee()
        {
            ViewData["OrderNames"] = "Drafts";
            string id = _userManager.GetUserId(User);
            IList<PRWithRequest> orders = await _webApiCalls.GetEmployeeOrderByTypeAsync(id, "Created");

            return View("ViewOrders", orders);
        }
    }
}