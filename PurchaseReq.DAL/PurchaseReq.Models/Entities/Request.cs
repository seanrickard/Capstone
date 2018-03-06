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
        public decimal EstimatedCost { get; set; }

        [DataType(DataType.Currency)]
        public decimal EstimatedTotal { get; set; }

        [DataType(DataType.Currency)]
        public decimal PaidCost { get; set; }

        [DataType(DataType.Currency)]
        public decimal PaidTotal { get; set; }

        public bool Chosen { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [InverseProperty(nameof(Attachment.Request))]
        public List<Attachment> Attachments { get; set; }

        public int VendorId { get; set; }

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }

        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }

    }
}
