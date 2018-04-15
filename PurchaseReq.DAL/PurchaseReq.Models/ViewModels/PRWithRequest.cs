using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    //Good
    public class PRWithRequest : EntityBase
    {
        public string EmployeeFullName { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        public string SupervisorFullName { get; set; }

        [Required]
        public string SupervisorId { get; set; }

        public string StatusName { get; set; }

        [Required]
        public int StatusId { get; set; }

        public string CategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string BudgetCodeName { get; set; }

        [Required]
        public int BudgetCodeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateMade { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOrdered { get; set; }

        [DefaultValue(false)]
        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        public string BusinessJustification { get; set; }

        public List<RequestWithVendor> RequestsWithVendor { get; set; } = new List<RequestWithVendor>();

        //I Don't think this is necessary
        public List<SupervisorApprovalWithApproval> SupervisorApprovalWithApprovals { get; set; } = new List<SupervisorApprovalWithApproval>();

    }
}
