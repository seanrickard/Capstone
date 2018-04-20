using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PurchaseReq.MVC.Components
{
    public class UserMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<UserMenuItem> { new UserMenuItem()
                {
                    DisplayValue = "New Order",
                    ActionValue = "Create",
                    ControllerValue = "Order"
                },
                new UserMenuItem()
                {
                    DisplayValue = "View Pending Orders",
                    ActionValue = "PendingByEmployee",
                     ControllerValue = "Order"
                },
                new UserMenuItem()
                {
                    DisplayValue = "View Approved Orders",
                    ActionValue = "ApprovedByEmployee",
                     ControllerValue = "Order"
                },
                new UserMenuItem()
                {
                    DisplayValue = "View Completed Orders",
                    ActionValue = "CompletedByEmployee",
                     ControllerValue = "Order"
                },
                new UserMenuItem()
                {
                    DisplayValue = "View Ordered",
                    ActionValue = "OrderedByEmployee",
                     ControllerValue = "Order"
                },
                new UserMenuItem()
                {
                    DisplayValue = "View Denied Orders",
                    ActionValue = "DeniedByEmployee",
                    ControllerValue = "Order"
                }};


            return View(menuItems);
        }
    }

    public class UserMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
        public string ControllerValue { get; set; }
    }

}
