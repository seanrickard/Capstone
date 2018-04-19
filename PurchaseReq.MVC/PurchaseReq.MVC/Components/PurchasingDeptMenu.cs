using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PurchaseReq.MVC.Components
{
    public class PurchasingDeptMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<PurchasingDeptMenuItem> { new PurchasingDeptMenuItem()
                {
                    DisplayValue = "View Approved",
                    ActionValue = "Approved",
                    ControllerValue = "Order"
                },
                new PurchasingDeptMenuItem()
                {
                    DisplayValue = "Budget Code Management",
                    ActionValue = "Index",
                    ControllerValue = "Budget"
                },
                new PurchasingDeptMenuItem()
                {
                    DisplayValue = "View Completed",
                    ActionValue = "Completed",
                    ControllerValue = "Order"
                },
                new PurchasingDeptMenuItem()
                {
                    DisplayValue = "View Ordered",
                    ActionValue = "Ordered",
                    ControllerValue = "Order"
                }};


            return View(menuItems);
        }
    }

    public class PurchasingDeptMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
        public string ControllerValue { get; set; }
    }
}
