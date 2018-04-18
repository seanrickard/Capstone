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
        [Display(Name = "Requester")]
        public string EmployeeFullName { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Display(Name = "Supervisor")]
        public string SupervisorFullName { get; set; }

        [Required]
        public string SupervisorId { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Budget")]
        public string BudgetCodeName { get; set; }

        [Required]
        public int BudgetCodeId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime DateMade { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ordered")]
        public DateTime? DateOrdered { get; set; }

        [DefaultValue(false)]
        [Display(Name = "State Contract")]
        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Business Justification")]
        public string BusinessJustification { get; set; }

        public List<RequestWithVendor> RequestsWithVendor { get; set; } = new List<RequestWithVendor>();

        //I Don't think this is necessary
        public List<SupervisorApprovalWithApproval> SupervisorApprovalWithApprovals { get; set; } = new List<SupervisorApprovalWithApproval>();

    }
}
