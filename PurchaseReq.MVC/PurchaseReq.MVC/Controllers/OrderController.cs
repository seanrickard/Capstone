using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;
        private UserManager<Employee> _userManager;

        public OrderController(IWebApiCalls webApiCalls, UserManager<Employee> userManager)
        {
            _webApiCalls = webApiCalls;
            _userManager = userManager;
        }

        //public async Task<IActionResult> PastOrders()
        //{
        //    IList<PRWithRequest> orders;
        //    orders = await _webApiCalls.GetOrdersAsync();
        //    return View(orders);
        //}

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



        public IActionResult AddItem()
        {
            return View();
        }

        public IActionResult Vendors()
        {
            return View();
        }

    }
}