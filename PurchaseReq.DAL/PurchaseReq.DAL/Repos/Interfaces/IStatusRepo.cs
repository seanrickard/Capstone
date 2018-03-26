using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IStatusRepo : IRepo<Status>
    {
        Status GetStatusWithOrders(int? id);

        IEnumerable<Status> GetAllWithOrders();
    }
}
