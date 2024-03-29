﻿using PurchaseReq.Models.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    //Good
    public class CampusWithAddress : EntityBase
    {
        [Required]
        [Display(Name = "Name")]
        public string CampusName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int AddressId { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [MaxLength(10)]
        [Required]
        public string Zip { get; set; }
    }
}
