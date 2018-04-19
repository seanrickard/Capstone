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
                    ActionValue = "ViewApproved",
                    ControllerValue = "Purchasing"

                },
                new PurchasingDeptMenuItem()
                {
                    DisplayValue = "Budget Code Management",
                    ActionValue = "Index",
                    ControllerValue = "Purchasing"
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
