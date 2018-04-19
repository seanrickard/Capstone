using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PurchaseReq.MVC.Components
{
    public class SupervisorMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<SupervisorMenuItem> { new SupervisorMenuItem()
                {
                    DisplayValue = "Pending Approval",
                    ActionValue = "ViewSubmitted",
                    ControllerValue = "Supervisor"
                }};


            return View(menuItems);
        }
    }

    public class SupervisorMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
        public string ControllerValue { get; set; }
    }
}
