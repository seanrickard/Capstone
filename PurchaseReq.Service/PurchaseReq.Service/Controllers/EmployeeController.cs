using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PurchaseReq.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PurchaseReq.Service.Controllers
{

    /*
     * Credit for Generating the JWT token and login, logout functionality goes to BLANK BLANK
     * Source -> https://medium.com/@ozgurgul/asp-net-core-2-0-webapi-jwt-authentication-with-identity-mysql-3698eeba6ff8
     */

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly IConfiguration _configuration;

        public EmployeeController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, IConfiguration configuration)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto model) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad Model");
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok("Signed in");
            }

            return BadRequest("Sign in Failure");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        public class LoginDto
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }

        //Test method for now
        [HttpPost]
        public async Task<IActionResult> Get(string name)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(name);
                
                if (user == null)
                {
                    return BadRequest("My dude is null");
                }
                var can = _signInManager.CanSignInAsync(user);
                return Ok(new{can,user});

            }

            return BadRequest("Bad");
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
