using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PurchaseReq.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReq.Models.Entities
{
    [Table("BudgetAmounts", Schema = "User")]
    public class BudgetAmount : EntityBase
    {
        public int BudgetCodeId { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(BudgetCodeId))]
        public BudgetCode BudgetCode { get; set; }
    }
}
