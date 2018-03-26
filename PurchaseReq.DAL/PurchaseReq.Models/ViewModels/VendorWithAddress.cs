using PurchaseReq.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class VendorWithAddress : EntityBase
    {
        [DataType(DataType.Text), MaxLength(20)]
        public string VendorName { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Phone { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Fax { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Website { get; set; }

        public int VendorId { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string StreetAddress { get; set; }

        [MaxLength(10)]
        public string Zip { get; set; }
    }
}
