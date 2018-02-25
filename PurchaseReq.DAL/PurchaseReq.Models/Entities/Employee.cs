﻿using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace PurchaseReq.Models.Entities
{
    [Table("Employees", Schema = "User")]
    public class Employee : EntityBase
    {
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress), MaxLength(50), Display(Name = "Email Addresss")]
        public string Email { get; set; }

        [Phone]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        public bool Active { get; set; }

        [DataType(DataType.Password), MaxLength(50)]
        public string Password { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        [InverseProperty(nameof(EmployeesBudgetCodes.Employee))]
        public List<EmployeesBudgetCodes> EmployeesBudgetCode { get; set; }

        //Just pretend tag is there not really required
        //[InverseProperty(nameof(CFO.Employee))]
        public CFO CFO { get; set; }
    }
}
