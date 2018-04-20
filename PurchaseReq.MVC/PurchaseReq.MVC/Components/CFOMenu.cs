using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PurchaseReq.MVC.Components
{
    public class CFOMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<CFOMenuItem> { new CFOMenuItem()
                {
                    DisplayValue = "Pending Approval",
                    ActionValue = "ViewSubmitted",
                    ControllerValue = "CFO"
                },
                new CFOMenuItem()
                {
                    DisplayValue = "Budget Code Management",
                    ActionValue = "Index",
                    ControllerValue = "Budget"
                },
                new CFOMenuItem()
                {
                    DisplayValue = "View Ordered",
                    ActionValue = "Ordered",
                     ControllerValue = "Order"
                },
                new CFOMenuItem()
                {
                    DisplayValue = "View Completed",
                    ActionValue = "Completed",
                    ControllerValue = "Order"
                },
                new CFOMenuItem()
                {
                    DisplayValue = "View Denied",
                    ActionValue = "Denied",
                     ControllerValue = "Order"
                },};


            return View(menuItems);
        }
    }

    public class CFOMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
        public string ControllerValue { get; set; }
    }
}
