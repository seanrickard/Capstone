using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IOrderRepo : IRepo<Order>
    {
        Order GetOrderWithRequestAndSupervisorApprovalAndStatusAndCategory(int? id);

        IEnumerable<Order> GetAllWithRequestAndSupervisorApprovalAndStatusAndCategory();

        IEnumerable<Order> GetAllOrdersForUser(string userId);

        IEnumerable<Order> GetAllOrdersWaitingForSupervisorApproval(string supervisorId);

        IEnumerable<Order> GetAllOrdersWaitingForCfoApproval();
    }
}
