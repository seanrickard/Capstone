using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseReq.Service.Controllers
{
    //Way to log in users with JWT -> https://logcorner.com/token-based-authentication-using-asp-net-web-api-core/
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

        public EmployeeController(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Employee> signInManager, IConfiguration configuration)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        private async Task<object> GenerateJwtToken(string email, Employee user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return await GenerateJwtToken(model.Email, appUser);
            }

            return Ok("Why you no work");
            //throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        public async Task<IActionResult> SignOut()
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
