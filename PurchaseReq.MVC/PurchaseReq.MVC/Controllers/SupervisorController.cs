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
    public class SupervisorController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;
        private UserManager<Employee> _userManager;
        private SignInManager<Employee> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public SupervisorController(IWebApiCalls webApiCalls, UserManager<Employee> userManager, SignInManager<Employee> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _webApiCalls = webApiCalls;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

        public async Task<IActionResult> OrderApproval(int id)
        {


            PRWithRequest req = await _webApiCalls.GetOrderAsync(id);

            return View(req);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DenyOrder(int id)
        {
            string userId = _userManager.GetUserId(User);
            Employee emp = await _userManager.GetUserAsync(User);
            SupervisorApproval approval = new SupervisorApproval();
            approval.OrderId = id;

            approval.SupervisorId = userId;
            IList<string> roleId =  await _userManager.GetRolesAsync(emp);
            
            IdentityRole role = await _roleManager.FindByNameAsync(roleId[0]);
            approval.UserRoleId = role.Id;
            approval.ApprovalId = 2;    
            

           
            return View(approval);
        }

        [HttpPost("{approval},  {UserRoleId}, {OrderId}, {ApprovalId},{SupervisorId} ")]
        public async Task<IActionResult> DenyOrder(SupervisorApproval approval, string UserRoleId, int OrderId, int ApprovalId, string SupervisorId)
        {

            if(!ModelState.IsValid)
            {
                return View(approval);
            }
            SupervisorApproval app = new SupervisorApproval
            {
                ApprovalId = approval.ApprovalId,
                UserRoleId = approval.UserRoleId,
                SupervisorId = approval.SupervisorId,
                OrderId = approval.OrderId,
                DeniedJustification = approval.DeniedJustification
            };

            var result = await _webApiCalls.CreateAsync(app);

            return RedirectToAction("ViewSubmitted");
        }
    }
}