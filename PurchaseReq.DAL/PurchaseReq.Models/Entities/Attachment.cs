using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Attachments", Schema = "Order")]
    public class Attachment : EntityBase
    {
        public int RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; }

        [Required]
        public string AttachmentPath { get; set; }
    }
}
