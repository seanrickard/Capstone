using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class EmployeeWithDepartmentAndRoomAndRole
    {

        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "First")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int? DepartmentId { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        public int? RoomId { get; set; }

        [Display(Name = "Room")]
        public string RoomName { get; set; }
        [Required]
        public string RoleId { get; set; }

        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
