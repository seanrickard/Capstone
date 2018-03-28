using PurchaseReq.Models.Entities;
using PurchaseReq.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class DivisionWithSupervisor : EntityBase
    {
        [DataType(DataType.Text)]
        public string DivisionName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public string SupervisorId { get; set; }

        public Employee Supervisor { get; set; }

        public List<Employee> SupervisorList { get; set; }
    }
}
