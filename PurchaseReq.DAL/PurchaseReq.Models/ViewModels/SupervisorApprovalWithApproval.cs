using Microsoft.AspNetCore.Identity;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.Models.ViewModels
{
    //Good
    public class SupervisorApprovalWithApproval
    {
        public Approval Approval { get; set; }

        public int ApprovalId { get; set; }

        public Employee Supervisor { get; set; }

        public string SupervisorId { get; set; }

        public IdentityRole SupervisorRole { get; set; }

        public string RoleId { get; set; }

        public string DeniedJustification { get; set; }
    }
}
