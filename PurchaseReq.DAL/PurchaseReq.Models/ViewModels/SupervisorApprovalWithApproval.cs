using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    //Good
    public class SupervisorApprovalWithApproval
    {

        public string ApprovalName { get; set; }

        public int ApprovalId { get; set; }

        public string SupervisorFullName { get; set; }

        [Required]
        public string SupervisorId { get; set; }

        public string SupervisorRoleName { get; set; }

        [Required]
        public string RoleId { get; set; }

        public string DeniedJustification { get; set; }
    }
}
