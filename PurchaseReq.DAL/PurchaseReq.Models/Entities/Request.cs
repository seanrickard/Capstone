using PurchaseReq.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReq.Models.Entities
{
    [Table("Requests", Schema = "Order")]
    public class Request : EntityBase
    {
        [Display(Name="Quantity Requested")]
        public int QuantityRequested { get; set; }

        [Display(Name = "Estimated Cost")]
        [DataType(DataType.Currency)]
        public decimal EstimatedCost { get; set; }

        [Display(Name = "Estimated Total")]
        [DataType(DataType.Currency)]
        public decimal EstimatedTotal { get; set; }

        [Display(Name = "Paid Cost")]
        [DataType(DataType.Currency)]
        public decimal PaidCost { get; set; }

        [Display(Name = "Paid Total")]
        [DataType(DataType.Currency)]
        public decimal PaidTotal { get; set; }

        [DefaultValue(true)]
        public bool Chosen { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [InverseProperty(nameof(Attachment.Request))]
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();

        public int VendorId { get; set; }

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }

        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }

        public string ReasonChosen { get; set; }

    }
}
