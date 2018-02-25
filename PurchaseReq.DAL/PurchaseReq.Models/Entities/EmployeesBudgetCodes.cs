using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("EmployeesBudgetCodes", Schema = "User")]
    public class EmployeesBudgetCodes : EntityBase
    {
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int BudgetCodeId { get; set; }

        [ForeignKey(nameof(BudgetCodeId))]
        public BudgetCode BudgetCode { get; set; }
    }
}
