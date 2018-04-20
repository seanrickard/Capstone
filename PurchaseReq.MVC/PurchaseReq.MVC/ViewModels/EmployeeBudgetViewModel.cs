using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.MVC.ViewModels
{
    public class EmployeeBudgetViewModel
    {
        public EmployeeBudgetViewModel()
        {
            Users = new List<Employee>();
        }
        public string UserId { get; set; }
        public int BudgetCodeId { get; set; }
        public List<Employee> Users { get; set; }
    }
}
