﻿using PurchaseReq.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReq.Models.Entities
{
    [Table("Approval", Schema = "Order")]
    public class Approval : EntityBase
    {
        [DataType(DataType.Text), MaxLength(20)]
        public string ApprovalName { get; set; }

        [InverseProperty(nameof(SupervisorApproval.Approval))]
        public List<SupervisorApproval> SupervisorApprovals { get; set; } = new List<SupervisorApproval>();
    }
}
