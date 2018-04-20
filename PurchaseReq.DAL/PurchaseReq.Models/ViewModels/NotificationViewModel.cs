using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class NotificationViewModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Waiting For Supervisor Approval")]
        public int WaitingForSupervisor { get; set; }

        [Display(Name = "Waiting For CFO Approval")]
        public int WaitingForCFO { get; set; }

        [Display(Name = "Waiting For Purchasing To Order")]
        public int WaitingToBeOrdered { get; set; }

        [Display(Name = "Being Delivered")]
        public int BeingDeliverd { get; set; }

        [Display(Name = "Waiting To Be Approved")]
        public int NumberNeedingToBeApproved { get; set; }

        [Display(Name = "Needing To Be Purchased")]
        public int NumberNeedingToBePurchased { get; set; }
    }
}
