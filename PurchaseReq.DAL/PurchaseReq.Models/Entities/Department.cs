using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Departments", Schema = "User")]
    public class Department : EntityBase
    {
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }

        public bool Active { get; set; }

        [InverseProperty(nameof(Employee.Department))]
        public List<Employee> Employees { get; set; }

        public int? DivisionId { get; set; }

        [ForeignKey(nameof(DivisionId))]
        public Division Division { get; set; }

    }
}
