using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Rooms", Schema = "User")]
    public class Room : EntityBase
    {
        [Required]
        public string RoomCode { get; set; }

        public int BuildingId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        public Building Building { get; set; }

        [InverseProperty(nameof(Employee.Room))]
        public List<Employee> Employees { get; set; }
    }
}
