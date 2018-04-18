using PurchaseReq.Models.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    //Maybe Good, Object Props should probably not be a Collection, I picture using them to fill a drop down list
    public class EmployeeBudgetCodeViewModel : EntityBase
    {

        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public int BudgetCodeId { get; set; }

        [Display(Name = "Budget Name")]
        public string BudgetCodeName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
    }
}
