using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IRequestRepo : IRepo<Request>
    {
        RequestWithVendor GetRequest(int? id);

        IEnumerable<RequestWithVendor> GetAllForOrder(int orderId);

        new IEnumerable<RequestWithVendor> GetAll();

        IEnumerable<RequestWithVendor> GetAllChoosenForOrder(int orderId);
    }
}
