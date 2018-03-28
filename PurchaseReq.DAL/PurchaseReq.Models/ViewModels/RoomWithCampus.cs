using PurchaseReq.Models.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class RoomWithCampus : EntityBase
    {
        [Required]
        public string RoomCode { get; set; }

        [Required]
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public CampusWithAddress Campus { get; set; }

        public int CampusId { get; set; }
    }
}
