using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("CFOApprovals", Schema = "Order")]
    public class CFOApproval : EntityBase
    {
        
        public int ApprovalId { get; set; }

        [ForeignKey(nameof(ApprovalId))]
        public Approval Approval { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        public int CFOId { get; set; }

        [ForeignKey(nameof(CFOId))]
        public CFO CFO { get; set; }

        [DataType(DataType.MultilineText)]
        public string DeniedJustification { get; set; }
    }
}
