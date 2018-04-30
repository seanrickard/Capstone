using PurchaseReq.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class RequestWithAttachmentsViewModel : EntityBase
    {
        [DataType(DataType.Text), MaxLength(50)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [DataType(DataType.Text), MaxLength(200)]
        public string Description { get; set; }

        public List<AttachmentViewModel> Attachments;
    }
}
