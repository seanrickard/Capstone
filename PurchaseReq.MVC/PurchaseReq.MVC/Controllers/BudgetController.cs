using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public BudgetController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        public async Task<IActionResult> Index()
        {
            IList<BudgetCodeWithAmount> budgets;
            budgets = await _webApiCalls.GetBudgetsAsync();
          
            return View(budgets);
        }

        public IActionResult AddBudgetCode()
        {
            BudgetCodeWithAmount bc = new BudgetCodeWithAmount();

            return View(bc);
        }

        [HttpPost]
        public async Task<IActionResult> AddBudgetCode(BudgetCodeWithAmount bc)
        {
            if (!ModelState.IsValid)
            {
                return View(bc);
            }

            var code = new BudgetCode()
            {
                BudgetCodeName = bc.BudgetCodeName,
                DA = bc.DA,
                Type = bc.Type,
                BudgetAmounts = new List<BudgetAmount>
                {
                    new BudgetAmount
                    {
                        TotalAmount = bc.TotalAmount
                    }
                }
            };
            
            var codeResult = await _webApiCalls.CreateAsync(code);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> EditBudgetCode(int id)
        {
            BudgetCodeWithAmount code = await _webApiCalls.GetBudgetAsync(id);

             return View(code);
        }

        [HttpPost]
        public async Task<IActionResult> EditBudgetCode(BudgetCodeWithAmount code)
        {
            if (!ModelState.IsValid)
            {
                return View(code);
            }

            var budget = new BudgetCode()
            {

                Id = code.Id,
                Active = code.Active,
                BudgetCodeName = code.BudgetCodeName,
                DA = code.DA,
                Type = code.Type,
                TimeStamp = code.TimeStamp,
            };

            var result = await _webApiCalls.UpdateAsync(code.Id, budget);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> UpdateTotal(int id)
        {
            BudgetCodeWithAmount code = await _webApiCalls.GetBudgetAsync(id);

            return View(code);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTotal(BudgetCodeWithAmount code)
        {
            if (!ModelState.IsValid)
            {
                return View(code);
            }

            var budget = new BudgetAmount()
            {
                BudgetCodeId = code.Id,
                TotalAmount = code.TotalAmount,
            };

            var result = await _webApiCalls.CreateAsync( budget );

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> ViewUsers(int id)
        {
            IList<EmployeeBudgetCodeViewModel> budgets;
            budgets = await _webApiCalls.GetEmployeesInBudgetCodeAsync(id);
            ViewBag.BudgetId = id;
            return View(budgets);
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToBudgetCode(int id)
        {
            var employees = await _webApiCalls.GetEmployeesAsEmployees();
            var budgets = await _webApiCalls.GetEmployeesInBudgetCodeAsync(id);


            var employeeBudgetViewModel = new EmployeeBudgetViewModel();

            foreach(var emp in employees)
            {
                employeeBudgetViewModel.Users.Add(emp);

                foreach( var employee in budgets)
                {
                    if(employee.EmployeeId == emp.Id)
                    {
                        employeeBudgetViewModel.Users.Remove(emp);
                    }
                }
            }
          
            employeeBudgetViewModel.BudgetCodeId = id;

            return View(employeeBudgetViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToBudgetCode( EmployeeBudgetViewModel employees)
        {
            EmployeesBudgetCodes ebc = new EmployeesBudgetCodes()
            {
                BudgetCodeId = employees.BudgetCodeId,
                EmployeeId = employees.UserId
            };

            var result = await _webApiCalls.CreateBudgetCode(ebc);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteUserFromBudgetCode(int id)
        {
            var employeesInCode = await _webApiCalls.GetEmployeesInBudgetCodeAsync(id);



            EmployeeBudgetCodeViewModel ebc = new EmployeeBudgetCodeViewModel();
            ebc.BudgetCodeId = id;

            return View(ebc);
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteUserFromRole(UserRoleViewModel userRoleViewModel)
        //{
        //    var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId);
        //    var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId);

        //    var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("RoleManagement", _roleManager.Roles);
        //    }

        //    foreach (IdentityError error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error.Description);
        //    }

        //    return View(userRoleViewModel);
        //}

    }
}