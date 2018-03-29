using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using System.Threading.Tasks;

namespace PurchaseReq.Service.Controllers
{
    //Way to log in users with JWT -> https://logcorner.com/token-based-authentication-using-asp-net-web-api-core/
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


//        [HttpPut]
//        public async Task<IActionResult> SignIn([FromBody] Employee user, String password)
//        {
//            //return await _signInManager.PasswordSignInAsync(user, password, false, false);
//        }
//        
//        public async Task<IActionResult> SignOut()
//        {
//
//        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userManager);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee model, string password)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _userManager.CreateAsync(model, password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return CreatedAtAction("Create", model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string employeeId, [FromBody] Employee model)
        {
            if (model == null || employeeId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _userManager.UpdateAsync(model);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return CreatedAtAction("Update", model);
        }

        [HttpPut]
        public async Task<IActionResult> ChangePassword(string employeeId, [FromBody] Employee model, string newPassword)
        {
            if (model == null || employeeId != model.Id || !ModelState.IsValid || newPassword.Length < 0)
            {
                return BadRequest();
            }

            
            var result = await _userManager.RemovePasswordAsync(model);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            var change = await _userManager.AddPasswordAsync(model, newPassword);
            if (!change.Succeeded)
            {
                return BadRequest();
            }

            return CreatedAtAction("ChangePassword", model);
        }


    }
}
