using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("BudgetCodes", Schema = "User")]
    public class BudgetCode : EntityBase
    {

        public int DA { get; set; }

        [DataType(DataType.Text)]
        public string BudgetCodeName { get; set; }

        public bool Type { get; set; }

        public int Function { get; set; }

        public int Project { get; set; }

        public int Parent { get; set; }
       
        public bool Active { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
    }
}
