using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PurchaseReq.Models.Entities
{
    [Table("Employees", Schema = "User")]
    public class Employee : IdentityUser
    {
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        [InverseProperty(nameof(EmployeesBudgetCodes.Employee))]
        public List<EmployeesBudgetCodes> EmployeesBudgetCode { get; set; } = new List<EmployeesBudgetCodes>();

        [InverseProperty(nameof(Division.Supervisor))]
        public List<Division> SupervisedDivision { get; set; } = new List<Division>();

        public int? RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }


    }
}
