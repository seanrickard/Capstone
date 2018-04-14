using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class EmployeeWithDepartmentAndRoomAndRole
    {

        public string Id { get; set; }

        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int? RoomId { get; set; }

        public string RoomName { get; set; }
        [Required]
        public string RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
