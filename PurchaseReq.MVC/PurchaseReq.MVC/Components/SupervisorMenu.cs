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
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "New Order",
                    ActionValue = "Create",
                    ControllerValue = "Order"
                },
                 new SupervisorMenuItem()
                {
                    DisplayValue = "View Pending Orders",
                    ActionValue = "PendingByEmployee",
                     ControllerValue = "Order"
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "View Approved Orders",
                    ActionValue = "ApprovedByEmployee",
                     ControllerValue = "Order"
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "View Completed Orders",
                    ActionValue = "CompletedByEmployee",
                     ControllerValue = "Order"
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "View Ordered",
                    ActionValue = "OrderedByEmployee",
                     ControllerValue = "Order"
                },
                new SupervisorMenuItem()
                {
                    DisplayValue = "View Denied Orders",
                    ActionValue = "DeniedByEmployee",
                    ControllerValue = "Order"
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
