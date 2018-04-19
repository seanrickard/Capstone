using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PurchaseReq.MVC.Components
{
    public class AuditorMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AuditorMenuItem> { new AuditorMenuItem()
                {
                    DisplayValue = "User Management",
                    ActionValue = "UserManagement",
                    ControllerValue = "Admin"

                },
                new AuditorMenuItem()
                {
                    DisplayValue = "Budget Code Management",
                    ActionValue = "Index",
                    ControllerValue = "Budget"
                },
                new AuditorMenuItem()
                {
                    DisplayValue = "Campus Management",
                    ActionValue = "Index",
                    ControllerValue = "Campus"

                },
                new AuditorMenuItem()
                {
                    DisplayValue = "Division Management",
                    ActionValue = "Index",
                    ControllerValue = "Division"
                },
                new AuditorMenuItem()
                {
                    DisplayValue = "Department Management",
                    ActionValue = "Index",
                    ControllerValue = "Department"
                }};


            return View(menuItems);
        }
    }

    public class AuditorMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
        public string ControllerValue { get; set; }
    }
}


