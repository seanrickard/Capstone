using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IWebApiCalls webApiCalls, UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            _webApiCalls = webApiCalls;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //Shows the active employees
        [HttpGet]
        public async Task<IActionResult> UserManagement()
        {
            IList<EmployeeWithDepartmentAndRoomAndRole> employees;
            employees = await _webApiCalls.GetEmployees();
            //For which button to render
            ViewBag.Active = true;

            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> InActiveEmployees()
        {
            //get inactive employees
            var model = await _webApiCalls.GetInActiveEmployees();
            //For which button to render
            ViewBag.Active = false;

            return View("UserManagement", model);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> ChangePassword(string employeeId)
        {
            var user = await _userManager.FindByIdAsync(employeeId);

            if (user == null)
            {
                return RedirectToAction("UserManagement", _userManager.Users);
            }

            var model = new PasswordEmployeeViewModel() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Active = user.Active };

            return View(model);
        }

        [HttpPost("{employeeId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string employeeId, PasswordEmployeeViewModel model)
        {
            if (!ModelState.IsValid && model.Password != model.ConfirmPassword)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);

            await _userManager.RemovePasswordAsync(user);

            var change = await _userManager.AddPasswordAsync(user, model.ConfirmPassword);
            if (!change.Succeeded)
            {
                return View(model);
            }

            return RedirectToAction("UserManagement");
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            PasswordEmployeeViewModel emp = new PasswordEmployeeViewModel();

            ViewBag.Departments = await _webApiCalls.GetDepartmentsForDropDown();
            ViewBag.Roles = await _webApiCalls.GetRolesForDropdown();
            ViewBag.Rooms = await _webApiCalls.GetRoomsForDropdown();

            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(PasswordEmployeeViewModel emp)
        {
            if (!ModelState.IsValid || emp.Password != emp.ConfirmPassword)
            {
                return View(emp);
            }

            var e = new Employee()
            {
                UserName = emp.Email,
                Email = emp.Email,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                DepartmentId = emp.DepartmentId,
                RoomId = emp.RoomId
            };

            IdentityResult result = await _userManager.CreateAsync(e, emp.Password);

            if (result.Succeeded)
            {
                var role = await _roleManager.FindByIdAsync(emp.RoleId);
                IdentityResult roleResult = await _userManager.AddToRoleAsync(e, role.Name);
                return RedirectToAction("UserManagement", _userManager.Users);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ViewBag.Departments = await _webApiCalls.GetDepartmentsForDropDown();
            ViewBag.Roles = await _webApiCalls.GetRolesForDropdown();
            ViewBag.Rooms = await _webApiCalls.GetRoomsForDropdown();
            return View(emp);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("UserManagement", _userManager.Users);
            }

            //Get view model
            var userViewModel = await _webApiCalls.GetEmployeeAsync(user.Id);

            ViewBag.Departments = await _webApiCalls.GetDepartmentsForDropDown();
            ViewBag.Roles = await _webApiCalls.GetRolesForDropdown();
            ViewBag.Rooms = await _webApiCalls.GetRoomsForDropdown();

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EmployeeWithDepartmentAndRoomAndRole emp)
        {
            var user = await _userManager.FindByIdAsync(emp.Id);

            if (user != null)
            {
                user.FirstName = emp.FirstName;
                user.LastName = emp.LastName;
                user.DepartmentId = emp.DepartmentId;
                user.RoomId = emp.RoomId;
                user.Active = emp.Active;
                user.Email = emp.Email;
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("UserManagement", _userManager.Users);
            }

            ModelState.AddModelError("", "User not updated, something went wrong.");

            ViewBag.Departments = await _webApiCalls.GetDepartmentsForDropDown();
            ViewBag.Roles = await _webApiCalls.GetRolesForDropdown();
            ViewBag.Rooms = await _webApiCalls.GetRoomsForDropdown();

            return View(emp);
        }


    }
}