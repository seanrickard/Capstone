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
                    DisplayValue = "View Completed Orders",
                    ActionValue = "Completed",
                    ControllerValue = "Order"

                },
                new AuditorMenuItem()
                {
                    DisplayValue = "View Ordered",
                    ActionValue = "Ordered",
                    ControllerValue = "Order"
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


