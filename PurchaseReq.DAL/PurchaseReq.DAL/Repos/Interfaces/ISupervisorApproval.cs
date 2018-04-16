using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface ISupervisorApproval : IRepo<SupervisorApproval>
    {
        IEnumerable<SupervisorApproval> Get();

        SupervisorApproval Get(int id);

        IEnumerable<SupervisorApproval> GetForOrder(int orderId);
    }
}
