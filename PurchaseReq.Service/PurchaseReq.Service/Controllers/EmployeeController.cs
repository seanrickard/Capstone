﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Threading.Tasks;

namespace PurchaseReq.Service.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private const string SUPERVISOR = "Supervisor";
        public readonly UserManager<Employee> _userManager;
        public readonly SignInManager<Employee> _signInManager;

        public readonly IEmployeeRepo Repo;

        public EmployeeController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, IEmployeeRepo repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Repo = repo;
        }

        //[HttpPost]
        //public async Task<object> Login([FromBody] LogInViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Bad Model");
        //    }
        //    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        //    if (result.Succeeded)
        //    {
        //        return Ok("Signed in");
        //    }

        //    return BadRequest("Sign in Failure");
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return Ok();
        //}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Repo.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var item = Repo.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
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
