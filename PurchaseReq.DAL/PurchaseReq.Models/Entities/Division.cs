using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

/**
 * Base recursive relationship off of ->https://stackoverflow.com/questions/27720369/one-to-many-recursive-relationship-with-code-first
 * 
 **/
namespace PurchaseReq.Models.Entities
{
    [Table("Divisions", Schema = "User")]
    public class Division : EntityBase
    {
        [DataType(DataType.Text)]
        public string DivisionName { get; set; }

        public bool Active { get; set; }

        [InverseProperty(nameof(Department.Division))]
        public List<Department> Departments { get; set; }

       public int? ParentId { get; set; }

       [ForeignKey(nameof(ParentId))]
       public Division Parent { get; set; }

       [InverseProperty(nameof(Division.Parent))]
       public List<Division> Children { get; set; }

       public string SupervisorId { get; set; }

       [ForeignKey(nameof(SupervisorId))]
       public Employee Supervisor { get; set; }
    }
}
