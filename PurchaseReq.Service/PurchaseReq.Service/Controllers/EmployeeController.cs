using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using System.Threading.Tasks;

namespace PurchaseReq.Service.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Employee> _signInManager;

        public EmployeeController(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Employee> signInManager)

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        //public async Task<IActionResult> signIn()
        //{

        //}
        
        //public async Task<IActionResult> signOut()
        //{

        //}

    }
}
