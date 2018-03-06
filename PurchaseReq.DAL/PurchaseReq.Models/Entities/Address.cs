using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Addresses", Schema = "User")]
    public class Address : EntityBase
    {
        [Required]
        public string City { get; set; }

        //Possibly might want to make State another table
        [Required]
        public string State { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [MaxLength(10)]
        [Required]
        public string Zip { get; set; }

        [InverseProperty(nameof(Building.Address))]
        public List<Building> Buildings { get; set; }

        [InverseProperty(nameof(Vendor.Address))]
        public List<Vendor> Vendors { get; set; }
    }
}
