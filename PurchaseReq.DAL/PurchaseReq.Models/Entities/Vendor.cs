using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace PurchaseReq.Models.Entities
{
    [Table("Vendors", Schema = "Order")]
    public class Vendor : EntityBase
    {
        
        [DataType(DataType.Text), MaxLength(20)]
        public string VendorName { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string City { get; set; }

        [DataType(DataType.Text), MaxLength(2)]
        public string State { get; set; }

        [DataType(DataType.Text), MaxLength(10)]
        public string Zip { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string Address { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Phone { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Fax { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string Website { get; set; }

    }
}

