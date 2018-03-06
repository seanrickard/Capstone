using PurchaseReq.Models.Entities;
using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Buildings", Schema = "User")]
    public class Building : EntityBase
    {
        [Required]
        public string BuildingName { get; set; }

        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }

        [InverseProperty(nameof(Room.Building))]
        public List<Room> Rooms { get; set; }
    }
}
