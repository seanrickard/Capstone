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
                    ActionValue = "Index",
                    ControllerValue = "Budget"
                },
                new AdminMenuItem()
                {
                    DisplayValue = "Campus Management",
                    ActionValue = "Index",
                    ControllerValue = "Campus"

                },
                new AdminMenuItem()
                {
                    DisplayValue = "Division Management",
                    ActionValue = "Index",
                    ControllerValue = "Division"
                },
                new AdminMenuItem()
                {
                    DisplayValue = "Department Management",
                    ActionValue = "Index",
                    ControllerValue = "Department"
                }};


            return View(menuItems);
        }
    }

    public class AdminMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
        public string ControllerValue { get; set; }
    }
}
