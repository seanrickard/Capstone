using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;

namespace PurchaseReq.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly SignInManager<Employee> _signInManager;

        public EmployeeController(SignInManager<Employee> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogInViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
         
            return RedirectToAction("Index");
        }
    }
}