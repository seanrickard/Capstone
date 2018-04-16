using PurchaseReq.Models.Entities;
using PurchaseReq.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    //Good
    public class RequestWithVendor : EntityBase
    {
        [Display(Name = "Quantity Requested")]
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

        public List<Attachment> Attachments { get; set; } = new List<Attachment>();

        [DataType(DataType.Text), MaxLength(50)]
        public string ItemName { get; set; }

        [DataType(DataType.Text), MaxLength(200)]
        public string Description { get; set; }

        public int ItemId { get; set; }

        public string ReasonChosen { get; set; }

        public string VendorName { get; set; }

        public int VendorId { get; set; }
    }
}
