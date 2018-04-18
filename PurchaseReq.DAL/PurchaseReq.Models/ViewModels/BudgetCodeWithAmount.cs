using PurchaseReq.Models.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    //Good
    public class BudgetCodeWithAmount : EntityBase
    {
        [Required]
        public int DA { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string BudgetCodeName { get; set; }

        [Required]
        [Display(Name = "Annual")]
        public bool Type { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        public int BudgetAmountId;
    }
}
