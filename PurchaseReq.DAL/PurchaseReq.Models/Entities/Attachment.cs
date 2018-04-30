﻿using PurchaseReq.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReq.Models.Entities
{
    [Table("Attachments", Schema = "Order")]
    public class Attachment : EntityBase
    {
        public int RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }
    }
}
