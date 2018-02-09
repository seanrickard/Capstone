using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Requests", Schema = "Order")]
    public class Request : EntityBase
    {
        
        public int QuantityRequested { get; set; }

        [DataType(DataType.Currency)]
        public decimal EstimatedAmount { get; set; }

        [DataType(DataType.Currency)]
        public decimal PaidAmount { get; set; }

        [DataType(DataType.Currency)]
        public decimal PaidTotal { get; set; }


        public bool Chosen { get; set; }


        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
    }
}
