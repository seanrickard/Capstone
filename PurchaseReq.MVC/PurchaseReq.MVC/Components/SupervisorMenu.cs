using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Components
{
    public class SupervisorMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<SupervisorMenuItem> { new SupervisorMenuItem()
                {
                    DisplayValue = "Approve Forms",
                    ActionValue = "UserManagement"
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "Budget Code Management",
                    ActionValue = "BudgetCode"
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "Campus Management",
                    ActionValue = "CampusManagement"
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "Division Management",
                    ActionValue = "DivisionManagement"
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "Department Management",
                    ActionValue = "DepartmentManagement"
                }};


            return View(menuItems);
        }
    }

    public class SupervisorMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}
