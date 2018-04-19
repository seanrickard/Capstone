using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PurchaseReq.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        

        public AdminController(IWebApiCalls webApiCalls, UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager )
        {
            _webApiCalls = webApiCalls;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();  
        }

        public async Task<IActionResult> UserManagement()
        {
            IList<EmployeeWithDepartmentAndRoomAndRole> employees;
            employees = await _webApiCalls.GetEmployees();

            return View(employees);
        }

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
                UserName =emp.Email,
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

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("UserManagement", _userManager.Users);
            }

            var vm = new PasswordEmployeeViewModel() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Active = user.Active };


            ViewBag.Departments = await _webApiCalls.GetDepartmentsForDropDown();
            ViewBag.Roles = await _webApiCalls.GetRolesForDropdown();
            ViewBag.Rooms = await _webApiCalls.GetRoomsForDropdown();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(PasswordEmployeeViewModel emp)
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

        public IActionResult RoleManagement()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var editRoleViewModel = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Users = new List<string>()
            };


            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    editRoleViewModel.Users.Add(user.UserName);
            }

            return View(editRoleViewModel);
        }

        public async Task<IActionResult> AddUserToRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addUserToRoleViewModel.Users.Add(user);
                }
            }

            return View(addUserToRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId);

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userRoleViewModel);
        }

        public async Task<IActionResult> DeleteUserFromRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addUserToRoleViewModel.Users.Add(user);
                }
            }

            return View(addUserToRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserFromRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId);

            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userRoleViewModel);
        }



    }
}