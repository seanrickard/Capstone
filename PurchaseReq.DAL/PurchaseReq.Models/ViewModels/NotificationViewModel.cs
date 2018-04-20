namespace PurchaseReq.Models.ViewModels
{
    public class NotificationViewModel
    {
        public string FullName { get; set; }

        public int WaitingForSupervisor { get; set; }

        public int WaitingForCFO { get; set; }

        public int WaitingToBeOrdered { get; set; }

        public int BeingDeliverd { get; set; }
    }
}
