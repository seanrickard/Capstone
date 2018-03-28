using PurchaseReq.Models.Entities;
using PurchaseReq.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    //Maybe Good, Object Props should probably not be a Collection, I picture using them to fill a drop down list
    public class EmployeeBudgetCodeViewModel : EntityBase
    {
        public List<Employee> Employees { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public int BudgetCodeId { get; set; }

        public List<BudgetCode> BudgetCodes { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
    }
}
