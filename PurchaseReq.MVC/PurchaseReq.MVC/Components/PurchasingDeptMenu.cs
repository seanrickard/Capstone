﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Components
{
    public class PurchasingDeptMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<PurchasingDeptMenuItem> { new PurchasingDeptMenuItem()
                {
                    DisplayValue = "Approve Forms",
                    ActionValue = "UserManagement"
                },
                new PurchasingDeptMenuItem()
                {
                    DisplayValue = "Budget Code Management",
                    ActionValue = "BudgetCode"
                },
                new PurchasingDeptMenuItem()
                {
                    DisplayValue = "Campus Management",
                    ActionValue = "CampusManagement"
                },
                new PurchasingDeptMenuItem()
                {
                    DisplayValue = "Division Management",
                    ActionValue = "DivisionManagement"
                },
                new PurchasingDeptMenuItem()
                {
                    DisplayValue = "Department Management",
                    ActionValue = "DepartmentManagement"
                }};


            return View(menuItems);
        }
    }

    public class PurchasingDeptMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}