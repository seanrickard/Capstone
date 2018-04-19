using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class SupervisorController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;
        private UserManager<Employee> _userManager;

        public SupervisorController(IWebApiCalls webApiCalls, UserManager<Employee> userManager)
        {
            _webApiCalls = webApiCalls;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewSubmitted()
        {
            string id = _userManager.GetUserId(User);
            var orders = await _webApiCalls.GetSubmittedAsync(id);

            return View(orders);
        }
    }
}