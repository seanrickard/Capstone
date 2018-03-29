using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PurchaseReq.MVC.Components
{
    public class AdminMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AdminMenuItem> { new AdminMenuItem()
                {
                    DisplayValue = "User Management",
                    ActionValue = "UserManagement"
                },
                new AdminMenuItem()
                {
                    DisplayValue = "Budget Code Management",
                    ActionValue = "BudgetCode"
                },
                new AdminMenuItem()
                {
                    DisplayValue = "Campus Management",
                    ActionValue = "CampusManagement"
                },
                new AdminMenuItem()
                {
                    DisplayValue = "Division Management",
                    ActionValue = "DivisionManagement"
                },
                new AdminMenuItem()
                {
                    DisplayValue = "Department Management",
                    ActionValue = "DepartmentManagement"
                }};


            return View(menuItems);
        }
    }

    public class AdminMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}
