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
                    DisplayValue = "Order History",
                    ActionValue = "ViewOrders",
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
