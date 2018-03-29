using Microsoft.AspNetCore.Identity;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
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

        public List<Department> Departments { get; set; }

        public int? RoomId { get; set; }

        public List<Room> Rooms { get; set; }

        [Required]
        public string RoleId { get; set; }

        public List<IdentityRole> Roles { get; set; }
    }
}
