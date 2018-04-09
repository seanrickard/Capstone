using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public EmployeeController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                StatusCodeResult result = (StatusCodeResult) await _webApiCalls.LoginEmployee(loginViewModel);

                

                Console.WriteLine("Result was + " + result);
                //Add check for successful later
                return View();
            }
         
            return RedirectToAction("Index");
        }
    }
}