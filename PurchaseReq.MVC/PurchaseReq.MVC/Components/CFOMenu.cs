using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Components
{
    public class CFOMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<CFOMenuItem> { new CFOMenuItem()
                {
                    DisplayValue = "Approve Forms",
                    ActionValue = "UserManagement"
                },
                new CFOMenuItem()
                {
                    DisplayValue = "Budget Code Management",
                    ActionValue = "BudgetCode"
                },
                new CFOMenuItem()
                {
                    DisplayValue = "Campus Management",
                    ActionValue = "CampusManagement"
                },
                new CFOMenuItem()
                {
                    DisplayValue = "Division Management",
                    ActionValue = "DivisionManagement"
                },
                new CFOMenuItem()
                {
                    DisplayValue = "Department Management",
                    ActionValue = "DepartmentManagement"
                }};


            return View(menuItems);
        }
    }

    public class CFOMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}
