using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("SupervisorApprovals", Schema = "Order")]
    public class SupervisorApproval : EntityBase
    {
        public int ApprovalId { get; set; }

        [ForeignKey(nameof(ApprovalId))]
        public Approval Approval { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        public int SupervisorId { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        public Employee Employee { get; set; }

        [DataType(DataType.MultilineText)]
        public string DeniedJustification { get; set; }


    }
}
