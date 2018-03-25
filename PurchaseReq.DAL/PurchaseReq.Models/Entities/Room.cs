using PurchaseReq.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReq.Models.Entities
{
    [Table("Rooms", Schema = "User")]
    public class Room : EntityBase
    {
        [Required]
        public string RoomCode { get; set; }

        public int BuildingId { get; set; }

        [Required]
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [ForeignKey(nameof(BuildingId))]
        public Campus Campus { get; set; }

        [InverseProperty(nameof(Employee.Room))]
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
